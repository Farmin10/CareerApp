using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.Responses
{
    public class CountResponse
    {
        public int CountOfEmployee { get; set; }
        public int CountOfProject { get; set; }
        public int CountOfVacancy { get; set; }
        public int CountOfAppeal { get; set; }
    }
}
