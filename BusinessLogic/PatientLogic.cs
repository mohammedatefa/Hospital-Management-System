using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalSystemManagement.BusinessLogic
{
    public class PatientLogic
    {
        DataContext dataContext;
        public PatientLogic() {
        dataContext=new DataContext();
        }

        public IEnumerable<object> GetAllPatients()
        {
            return 
                dataContext.Patients.Select(p => new
                {
                    p.ID,
                    Name = p.Name,
                    p.NationalID,
                    p.Phone,
                    p.Address,
                    DName = p.Doctor.Name,
                    p.BloodType,
                    RoomID = p.Room.ID
                }).ToList();
            }

        public Patient GetPatient(int id) {
            return dataContext.Patients.First(p=>p.ID==id);
        }

        public Doctor GetDoctorByPatient(int patientID)
        {
            return dataContext.Patients.Where(p => p.ID == patientID).Select(p => p.Doctor).First();
        }
        public IEnumerable<Doctor> GetDoctors(int patientID) {
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(GetDoctorByPatient(patientID));
            Doctor doctor= GetDoctorByPatient(patientID);
            doctors.AddRange(dataContext.Doctors.Where(d => d.ID != doctor.ID));
            return doctors;
        }

        public IEnumerable<Room> GetRooms(int roomID) {
            List<Room> rooms = new List<Room>();
            Room room = dataContext.Rooms.First(r => r.ID == roomID);
           
            rooms.Add(room);
            rooms.AddRange(dataContext.Rooms.Where(r => !r.Status).ToList());
            return rooms;
        }

        public IEnumerable<Room> GetEmptyRooms()
        {
            return dataContext.Rooms.Where(r => !r.Status).ToList();
        }

        public bool AddPatient(string name, string NID, string address, string phone, string desc, string blod, int doctorID , Room room)
        {

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(NID) || String.IsNullOrEmpty(address) || String.IsNullOrEmpty(phone) ||
                String.IsNullOrEmpty(desc) || String.IsNullOrEmpty(blod) || room == null || NID.Length < 14 || phone.Length < 11 ) return false;
            else
            {
                Doctor doctor = dataContext.Doctors.First(d => d.ID == doctorID);
                Patient p = new Patient
                {
                    Name = name,
                    NationalID = NID,
                    Phone = phone,
                    Address = address,
                    Description = desc,
                    Doctor = doctor,
                    BloodType = blod,
                    Room = room,

                };
                dataContext.Patients.Add(p);
                Room roomStatus = dataContext.Rooms.First(r => r.ID == room.ID);
                room.Status = true;
                dataContext.SaveChanges();

                var lastPatient = dataContext.Patients.ToList();

                dataContext.Histories.Add(new History
                {
                    PatientId = lastPatient.Last().ID,
                    PatientName = lastPatient.Last().Name,
                    Description = lastPatient.Last().Description,
                    Doctor = doctor,
                    Room = room,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                });
                dataContext.SaveChanges();

                return true;
            }
        }
    
    public bool UpdatePatient(int id, string name, string NID, string address, string phone, string desc, string blod,int doctorID, int oldRoomID, int newRoomID)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(NID) || String.IsNullOrEmpty(address) || String.IsNullOrEmpty(phone) ||
                 String.IsNullOrEmpty(desc) || String.IsNullOrEmpty(blod) || NID.Length < 14 || phone.Length < 11) return false;
            else
            {
                Doctor doctor = dataContext.Doctors.First(d => d.ID == doctorID);
                var oldRoom = dataContext.Rooms.Single(r => r.ID == oldRoomID);
                var newRoom = dataContext.Rooms.Single(r => r.ID == newRoomID);

                Patient p = dataContext.Patients.First(pa => pa.ID == id);
                p.Name = name;
                p.NationalID = NID;
                p.Phone = phone;
                p.Address = address;
                p.Description = desc;
                p.Doctor = doctor;
                p.BloodType = blod;
                p.Room = newRoom;
                oldRoom = dataContext.Rooms.First(rom => rom.ID == oldRoomID);
                oldRoom.Status = false;
                newRoom.Status = true;
                dataContext.SaveChanges();
                return true;
            }
        }
    }
}
