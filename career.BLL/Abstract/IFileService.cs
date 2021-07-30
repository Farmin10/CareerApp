using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using career.DAL.Utilities.Results;
using career.DTO.FileDTO;
using Microsoft.AspNetCore.Http;

namespace career.BLL.Abstract
{
    public interface IFileService
    {
        IDataResult<FileUploadDto> UploadFile(IFormFile file);
        string SizeConverter(long bytes);
        Dictionary<string, string> GetMimeTypes();
    }
}
