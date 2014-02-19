using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MVCMedicalCare.Models
{
    public class User
    {
        string userName { get; set; }
        string password { get; set; }

        public bool IsValid(string userName, string password) {
            
            DataMedicalDataContext database = new DataMedicalDataContext();
            var acc = (from c in database.Accounts
                      where c.empno == userName && c.Password == password
                      select c).FirstOrDefault();

            if (acc != null)
            {
                return true;
            }
            else
                return false;
        }
        
    }
}