using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.Entity.Concrete
{
    public class News
    {
        public int NewsId { get; set; }
        [Required]
        public string  Header { get; set; }
        public string  Content { get; set; }
        public string  NewsImage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
