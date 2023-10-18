using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalSystemManagement.Test
{
    public class UserLogic
    {
        DataContext dataContext;
        public UserLogic() {
        dataContext=new DataContext();
        }
        public bool Login(string username,string password)
        {

            var Users = dataContext.Users.Select(user => user);
            foreach (var item in Users)
            {
                if (item.Username == username && item.Password == password)
                {
                    Profile.Username = username;
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<UserAdmin> getUsers(string username) {
            if (username == "admin")
            {
                return getAllUsers();
            }
            return null;
        }

        public IEnumerable<UserAdmin> getAllUsers()
        {    
                var users = dataContext.Users.Select(u => u).ToList();
                return users;
        }

        public void AddUser(string username,string password) {
            dataContext.Users.Add(new UserAdmin {Username=username,Password=password });
            dataContext.SaveChanges();
        }
    
        
    }
    }

