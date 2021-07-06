using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using career.DTO.FileDTO;
using Microsoft.AspNetCore.Http;

namespace career.BLL.Abstract
{
    public interface IFileService
    {
        FileUploadDto UploadFile(IFormFile file);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);
        string SizeConverter(long bytes);
    }
}
