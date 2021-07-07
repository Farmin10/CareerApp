using career.DTO.PictureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.ProjectDTO
{
    public class ProjectForGetDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAbbreviatura { get; set; }
        public string ProjectDescription { get; set; }
        public List<PictureForGetDto> PicturesPath { get; set; }
        public string ProjectLink { get; set; }
        public bool IsPublicProject { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
