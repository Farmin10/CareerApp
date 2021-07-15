using career.BLL.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace career.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        IWebHostEnvironment _hostingEnvironment;

        public FilesController(IFileService fileService, IWebHostEnvironment hostingEnvironment)
        {
            _fileService = fileService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost(nameof(Upload))]
        public IActionResult Upload([Required] IFormFile formFiles)
        {
            try
            {
                var result= _fileService.UploadFile(formFiles);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      

        /// <summary>
        /// file download
        /// </summary>
        /// <param name="subDirectory"></param>
        /// <returns></returns>
        [HttpGet("getFile")]
        public async Task<IActionResult> DownloadFile([Required] string subDirectory)
        {
            var path = Path.Combine(subDirectory);
            string mimeType = "application/pdf";
            var bytes = await System.IO.File.ReadAllBytesAsync(path);
            return  File(bytes,mimeType, Path.GetExtension(path));
        }
    }
}
