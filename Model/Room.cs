using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemManagement.Model
{
    public class Room
    {
        public int ID { get; set; }
        public bool Status { get; set; }=false;
        public Floor Floor { get; set; }
        public Department Department { get; set; }
        //public Patient? Patient { get; set; }
    }
}
