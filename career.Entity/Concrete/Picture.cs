using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.Entity.Concrete
{
    public class Picture
    {
       
        public int PictureId { get; set; }
        [Required]
        public string PicturePath { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public bool IsDeleted { get; set; }
    }
}
