using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemManagement.Model
{
    public class Payments
    {
        public int ID { get; set; }
        public string PatientName { get; set; }
        public int PatientID {get; set; } 
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public double Paymented { get; set; }
        public double Remained { get; set; }
        public bool Status { get; set; }

    }
}
