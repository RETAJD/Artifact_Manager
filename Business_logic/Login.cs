using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Data;

namespace App.Business_logic
{
    class Login
    {
        //Metoda odpowiedzalna za sprawdzenie czy są puste miejsca przy logowaniu
        public bool czy_zostaly_wprowadzone_dane(string a, string b)
        {
            if ((a == "" || b == ""))
            {
                MessageBox.Show("Uzupełnij dokładnie wszystkie pola!");
                return false;
            }
            return true;
        }
        public bool czy_poprawne_dane_logowania(string loginn, string hasloo)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach (var c in db.Userss)
                {
                    if (c.UserName == loginn)
                    {
                        bool verified = BCrypt.Net.BCrypt.Verify(hasloo, c.Password);
                        if (verified)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }


    }
}
