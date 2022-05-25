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
        public void aktualizacja_hasla(string login_, string haslo)
        {
            string passwordHash = szyfrowanieHasla(haslo);

            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Userss)
                {
                    if(c.UserName == login_)
                    {
                        c.Password = passwordHash;
                        break;
                    }
                }
                MessageBox.Show("Ustawiono nowe hasło !");
                db.SaveChanges();
            }
        }


        // Metoda odpowiedzalna za sprawdzenie bledow przy logowaniu
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

        public string szyfrowanieHasla(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }

        public void zarejestrujUzytkownika(string loginn, string hasloo)
        {
            // Szyfrowanie Hasła
            string passwordHash = szyfrowanieHasla(hasloo);

            //Sprawdzenie hasła
            //bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);

            var NewUser = new Users { UserName = loginn, Password = passwordHash };

            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                //dodanie uzytkownika do bazy User
                db.Userss.Add(NewUser);
                //dodanie do tabeli Rola
                int ilosc_pozwolen = 0;
                foreach (var pozwolenie in db.OnlyPozwolenias)
                {
                    ilosc_pozwolen++;
                }
                string pozwolenie_string = "";
                for (int i = 0; i < ilosc_pozwolen; i++)
                {
                    if (i != ilosc_pozwolen - 1) { pozwolenie_string = pozwolenie_string + '0' + ','; }
                    else { pozwolenie_string = pozwolenie_string + '0'; }
                }
                var newRole_withUser = new Roles { username = loginn, rola = "user", pozwolenia_wszystkie = pozwolenie_string };
                db.Roless.Add(newRole_withUser);

                db.SaveChanges();
            }
            MessageBox.Show("Pomyślnie zarejestrowano !");

        }


    }
}
