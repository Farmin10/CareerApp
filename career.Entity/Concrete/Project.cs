using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.Entity.Concrete
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string  ProjectName { get; set; }
        [Required]
        public string  ProjectAbbreviatura { get; set; }
        [Required]
        public string  ProjectDescription { get; set; }
        
        public string  ProjectLink { get; set; }
        public List<Picture> Pictures { get; set; }
        public bool IsPublicProject { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
