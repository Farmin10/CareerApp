using career.DTO.PictureDTO;
using career.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.ProjectDTO
{
    public class ProjectForAddDto
    {
        public string ProjectName { get; set; }
        public string ProjectAbbreviatura { get; set; }
        public string ProjectDescription { get; set; }
        public List<PictureForGetDto> Pictures { get; set; }
        public string ProjectLink { get; set; }
        public bool IsPublicProject { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
