using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement.BusinessLogic
{
    public class FloorLogic
    {
        DataContext dataContext;
       public FloorLogic() {
        dataContext= new DataContext();
        }
       public bool CheckName(string floorName)
        {
            IEnumerable<string> namesOfFloor = dataContext.Floors.Select(d => d.Name).ToList();
            foreach (string item in namesOfFloor)
            {
                if (item == floorName) return true;
            }
            return false;
        }

        public IEnumerable<object> GetAllFloor() {
            var floors = dataContext.Floors.Select(f => new { f.ID, f.Name, f.NumberOfRooms }).ToList();
            return floors;
        }

        public Floor GetFloor(int id) {
            Floor floor= dataContext.Floors.FirstOrDefault(f => f.ID == id);
            return floor;
        }

        public void DeleteFloor(int id) {
            try
            {
                Floor floor = dataContext.Floors.Where(f => f.ID == id).First();
                dataContext.Floors.Remove(floor);
                dataContext.SaveChanges();
            }
            catch {
                MessageBox.Show("Can not do this action because this floor related to rooms !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool AddFloor(string name,int num) {
            if (!String.IsNullOrEmpty(name))
            {
                if (!CheckName(name))
                {
                    Floor floor = new Floor() { Name = name, NumberOfRooms = num };
                    dataContext.Floors.Add(floor);
                    dataContext.SaveChanges();
                    return true;
                }
                MessageBox.Show("This name is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                MessageBox.Show("Floor name Must Not Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
        }

        public bool UpdateFloor(int id,string newName,string oldName,int numberOfFloor) {
            if (!String.IsNullOrEmpty(newName))
            {
                if (!CheckName(newName) || newName == oldName)
                {
                    Floor f = dataContext.Floors.Where(fl => fl.ID == id).FirstOrDefault();
                    f.Name = newName;
                    f.NumberOfRooms = numberOfFloor;
                    dataContext.SaveChanges();
                    return true;
                }
                else
                    MessageBox.Show("This name is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            else
                MessageBox.Show("Floor name Must Not Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
