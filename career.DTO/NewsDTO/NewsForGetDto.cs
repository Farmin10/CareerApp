using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.NewsDTO
{
    public class NewsForGetDto
    {
        public int NewsId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string NewsImage { get; set; }
    }
}
