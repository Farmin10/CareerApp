using career.DTO.PictureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.Responses
{
    public class ProjectForAddResponse
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAbbreviatura { get; set; }
        public string ProjectDescription { get; set; }
        public List<PictureForGetDto> Pictures { get; set; }
        public string ProjectLink { get; set; }
        public bool IsPublicProject { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
