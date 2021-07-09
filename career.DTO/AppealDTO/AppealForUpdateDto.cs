using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.AppealDTO
{
    public class AppealForUpdateDto
    {
        public int AppealId { get; set; }
        public int VacancyId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ApplyDate { get; set; }
        public string ResumePath { get; set; }
    }
}
