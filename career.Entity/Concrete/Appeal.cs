using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.Entity.Concrete
{
    public class Appeal
    {
        public int AppealId { get; set; }
        [Required]
        public string  CandidateName { get; set; }
        [Required]
        public string  CandidateSurname { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        [Required]
        public string  Email { get; set; }
        [Required]
        public string  PhoneNumber { get; set; }
        public DateTime ApplyDate { get; set; }
        public string  ResumePath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
