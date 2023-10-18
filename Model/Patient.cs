using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemManagement.Model
{
    public class Patient
    {
        public int ID { get; set; }
        public string NationalID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Doctor Doctor { get; set; }
        public string BloodType { get; set; }
        public Room Room { get; set; }
        public string Description { get; set; }


    }
}
