using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemManagement.BusinessLogic
{
    public class DoctorLogic
    {
        DataContext dataContext;
        public DoctorLogic()
        {
                dataContext = new DataContext();
        }
        public IEnumerable<object> GetAllDoctors()
        {
            return
                dataContext.Doctors.Select(D => new
                {
                    D.ID,
                    Name = D.Name,
                    D.Phone,
                    D.Email,
                    D.Salary,
                    D.Address,
                    D.BirthDate,
                    Department = D.Department.Name,
                }).ToList();
        }

        public Patient GetDoctor(int id)
        {
            return dataContext.Patients.First(D => D.ID == id);
        }
    }
}
