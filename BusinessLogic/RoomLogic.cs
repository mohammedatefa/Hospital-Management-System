using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement.BusinessLogic
{
    public class RoomLogic
    {
        DataContext dataContext;
        public RoomLogic() {
        dataContext= new DataContext();
        }
       public IEnumerable<object> GetAllRoom()
        {
           return dataContext.Rooms.Select(r => new { RoomID = r.ID, Location = r.Floor.Name, Department = r.Department.Name, r.Status }).ToList();
            
        }
        public Room GetRoom(int id) {
            return dataContext.Rooms.First(r => r.ID == id);
        }

        public void DeleteRoom(int id) {
            try
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show(id.ToString());
                    var room = dataContext.Rooms.Where(d => d.ID == id).First();
                    dataContext.Rooms.Remove(room);
                    dataContext.SaveChanges();
                }
            }
            catch {
                MessageBox.Show("Can not do this action becouse this floor related to rooms !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool AddRoom(Department dept,Floor floor) {
           int count = dataContext.Rooms.Count(r => r.Floor.ID == floor.ID);
            if (count < floor.NumberOfRooms)
            {
                Department deptUp = dataContext.Departments.FirstOrDefault(f => f.ID == dept.ID);
                Floor floorUp = dataContext.Floors.FirstOrDefault(f=> f.ID == floor.ID);

                dataContext.Rooms.Add(new Room() { Department = deptUp, Floor = floorUp });
                dataContext.SaveChanges();
                return true;      
            }
            else
            {
                MessageBox.Show("This Floor is Completed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateRoom(int id,Department dept,Floor floor) {
            
            int count = dataContext.Rooms.Count(r => r.Floor.ID == floor.ID);
            if (count < floor.NumberOfRooms)
            {
                Department deptUp = dataContext.Departments.FirstOrDefault(f => f.ID == dept.ID);
                Floor floorUp = dataContext.Floors.FirstOrDefault(f => f.ID == floor.ID);

                Room room = dataContext.Rooms.First(r => r.ID ==id);
                room.Department = deptUp;
                room.Floor = floorUp;
                dataContext.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("This Floor is Completed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
