using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.FileDTO
{
    public class FileUploadDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
