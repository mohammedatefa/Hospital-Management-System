using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemManagement.Model
{
    public class History
    {
        public int ID { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public Doctor Doctor { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
