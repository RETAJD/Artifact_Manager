using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using App.Data;

namespace App.Business_logic
{
    class Register
    {
        // Metoda odpowiedzalna za sprawdzenie czy są puste miejsca przy logowaniu
        public bool czy_zostaly_wprowadzone_dane(string loginn, string hasloo)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach (var c in db.Userss)
                {
                    if (c.UserName == loginn)
                    {
                        MessageBox.Show("Użytkownik o takim loginie już istnieje !");
                        return false;
                    }
                }
            }

            if ((loginn == "" || hasloo == "")){
                MessageBox.Show("Uzupełnij dokładnie wszystkie pola!");
                return false;
            }
            if((loginn.Length < 3 || hasloo.Length < 3)){
                MessageBox.Show("Login i hasło muszą być minimum 3 znakowe !");
                return false;
            }

            return true;
        }

        public void zarejestrujUzytkownika(string loginn, string hasloo)
        {
            // Szyfrowanie Hasła
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(hasloo);

            //Sprawdzenie hasła
            //bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);

            var NewUser = new Users { UserName = loginn, Password = passwordHash };

            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                // Czy użytkownik o takim loginie juz istnieje ?              
                db.Userss.Add(NewUser);
                db.SaveChanges();
            }
            MessageBox.Show("Pomyślnie zarejestrowano !");

        }


    }
}
