using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement.BusinessLogic
{
    public class DepartmentLogic
    {
        DataContext dataContext;
        public DepartmentLogic() { 
        dataContext=new DataContext();
        }

        public bool addDept(string name, string desc)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(desc))
            return false;

            else
            {
                dataContext.Departments.Add(new Department() {Name=name,Description=desc });
                dataContext.SaveChanges();
                return true;
            }
        }

        public bool updateDept(int id,string name, string desc)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(desc))
            {
                MessageBox.Show("All Field Must not be Empty");
                return false;
            }
            else
            {
                Department department = dataContext.Departments.First(d => d.ID == id);
                department.Name = name;
                department.Description = desc;
                dataContext.SaveChanges();
                return true;
            }
        }

        public void deleteDept(int id)
        {
            try
            {
                var dept = dataContext.Departments.Where(d => d.ID == id).First();
                dataContext.Departments.Remove(dept);
                dataContext.SaveChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't delete this item that are related anthor table");
            }

        }

        public IEnumerable<object> getAllDept()
        {
            var departments = dataContext.Departments.Select(dept => new { dept.ID, dept.Name, dept.Description, Doctors = dept.Doctors.Count, Rooms = dept.Rooms.Count }).ToList();
            return departments;
        }

        public Department getDept(int id)
        {
            var department = dataContext.Departments.First(dept => dept.ID == id);
            return department;
        }
        public IEnumerable<object> searchDept(string txt)
        {
            var departments = dataContext.Departments.Where(d => d.Name.Contains(txt) || d.Description.Contains(txt) || d.ID.ToString() == txt).Select(dept => new { dept.ID, dept.Name, dept.Description, Doctors = dept.Doctors.Count, Rooms = dept.Rooms.Count }).ToList();
            return departments;
        }
       
    }
}
