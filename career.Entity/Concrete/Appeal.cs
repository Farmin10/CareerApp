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
        /*
         AppealId int pk,
CandidateName string required,
CandidateSurname string required,
VacancyId fk required(fk to Vacancy table),
Mail required (validate mail address),
PhoneNumber required (validate phone number),
ApplyDate datetime,
ResumePath string,
IsDeleted bool
         */
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
