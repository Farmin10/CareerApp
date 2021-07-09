using career.BLL.Abstract;
using career.Entity.Concrete;
using career.DAL.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using career.DTO.FileDTO;
using career.DTO.Responce;

namespace career.BLL.Concrete
{
    public class FileManager : IFileService
    {
        IWebHostEnvironment _hostingEnvironment;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public FileManager(IWebHostEnvironment hostingEnvironment, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _hostingEnvironment = hostingEnvironment;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public FileUploadDto UploadFile(IFormFile file)
        {
            if (file.Length <= 0) return null;
            var fileName = Guid.NewGuid() + file.FileName;
            var filePath = Path.Combine("wwwroot", Guid.NewGuid() + file.FileName);
            var extension = Path.GetExtension(filePath);
            var size = SizeConverter(file.Length);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            var mappedFile = new FileUploadDto() { FileName = fileName.ToString(), FilePath = filePath, FileExtension = extension, FileSize = size, CreatedDate = DateTime.Now };
            var result = _mapper.Map<Entity.Concrete.File>(mappedFile);
            _unitOfWork.FileDal.Add(result);


            _unitOfWork.Commit();
            return mappedFile;
        }

        public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine("D:\\webroot\\", subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(System.IO.File.ReadAllText(file));
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }

        }

        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
    }
}
