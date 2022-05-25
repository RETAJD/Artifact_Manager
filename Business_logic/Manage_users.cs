using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Business_logic;
using App.Data;


namespace App.Business_logic
{
    class Manage_users
    {
        public bool czy_ma_odpowienia_role(string login)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Roless)
                {
                    if(c.username == login && c.rola == "admin")
                    {
                        return true;
                    }
                }
                return false;
            }  
        }


        public void usun_role(string rola_)
        {
            DatabaseContext db = new DatabaseContext();

            using (db)
            {
                //usuniecie z onlyRoless
                db.onlyRoless.RemoveRange(db.onlyRoless.Where(x => x.Rola_pojedyncza == rola_));

                //usuniecie z Users
                foreach(var c in db.Roless)
                {
                      if(c.rola == rola_)
                      {
                            db.Userss.RemoveRange(db.Userss.Where(x => x.UserName == c.username));
                      }
                }
               
                //usuniecie z Roles
                db.Roless.RemoveRange(db.Roless.Where(x => x.rola == rola_));
                
                MessageBox.Show("Usunieto rolę z bazy !");
                db.SaveChanges();
            }
        }
        public bool czy_pozwolenie_istnieje(string pozwolenie)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach (var c in db.OnlyPozwolenias)
                {
                    if (c.pozwolenie_pojedyncze == pozwolenie) { return true; }
                }
                MessageBox.Show("Pozwolenie nie istnieje !");
                return false;
            }
            
        }
        public void usuniecie_pozwolenia(string pozwol)
        {
            DatabaseContext db = new DatabaseContext();

            int ktora_w_bazie = 0;
            using (db)
            {
                foreach(var c in db.OnlyPozwolenias)
                {
                    if(c.pozwolenie_pojedyncze == pozwol) { break; }
                    else { ktora_w_bazie++; }
                }

                //usuniecie z onlyPozwolenia
                var dousuniecia = db.OnlyPozwolenias.Where(d => d.pozwolenie_pojedyncze == pozwol).First();
                db.OnlyPozwolenias.Remove(dousuniecia);


                int iloscZerIjedynek = 0;
                foreach (var c in db.Roless)
                {
                    for (int i = 0; i < c.pozwolenia_wszystkie.Length; i++)
                    {
                        if (c.pozwolenia_wszystkie[i] == '0' || c.pozwolenia_wszystkie[i] == '1')
                        {
                            iloscZerIjedynek++;
                        }
                    }
                    break;
                }

                foreach (var c in db.Roless)
                {
                   if(ktora_w_bazie == 0)   c.pozwolenia_wszystkie = c.pozwolenia_wszystkie.Remove(0, 2);
                   else if (ktora_w_bazie+1 == iloscZerIjedynek) c.pozwolenia_wszystkie = c.pozwolenia_wszystkie.Remove(c.pozwolenia_wszystkie.Length-2, 2);
                   else
                   {
                        c.pozwolenia_wszystkie = c.pozwolenia_wszystkie.Remove(ktora_w_bazie*2, 2);
                   }
                }
                MessageBox.Show("Usunieto pozwolenie z bazy !");
                db.SaveChanges();
            }
        }

        private bool czy_istnieje_juz_takie_pozwolenie(string pozwol_)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach (var c in db.OnlyPozwolenias)
                {
                    if (c.pozwolenie_pojedyncze == pozwol_) { MessageBox.Show("Takie pozwolenie już istnieje ! "); return true; }
                }
                return false;
            }
        }

        private void dodanie_miejsca_zero_w_pozwoleniach(string pozwo)
        {
            DatabaseContext db = new DatabaseContext();

            int ktory = 0; // tu trzeba wkleic 0
            int iloscZerIjedynek = 0;

            using (db)
            {
                foreach (var c in db.OnlyPozwolenias)
                {
                    if (c.pozwolenie_pojedyncze == pozwo) { break; }
                    else ktory++; 
                }

                foreach (var c in db.Roless)
                {
                    for(int i = 0; i < c.pozwolenia_wszystkie.Length; i++)
                    {
                        if (c.pozwolenia_wszystkie[i] == '0' || c.pozwolenia_wszystkie[i] == '1')
                        {
                            iloscZerIjedynek++;
                        }
                    }
                    break;
                }

                foreach(var c in db.Roless)
                {
                    //c.pozwolenia_wszystkie.Insert(ktory * 2, "0,");
                    if (ktory == 0) c.pozwolenia_wszystkie = "0," + c.pozwolenia_wszystkie;
                    if (ktory == iloscZerIjedynek) c.pozwolenia_wszystkie = c.pozwolenia_wszystkie + ",0";
                    else
                    {
                        c.pozwolenia_wszystkie =  c.pozwolenia_wszystkie.Insert(ktory * 2, "0,");
                    }
                }
                db.SaveChanges();
            }
        }
        public void dodanie_nowego_pozwolenia(string nowe_pozwolenie)
        {
            DatabaseContext db = new DatabaseContext();
            if (czy_istnieje_juz_takie_pozwolenie(nowe_pozwolenie) == false)
            {
                var nowePozwolenie = new onlyPozwolenia { pozwolenie_pojedyncze = nowe_pozwolenie };
                using (db)
                {
                    db.OnlyPozwolenias.Add(nowePozwolenie);
                    db.SaveChanges();
                }
                dodanie_miejsca_zero_w_pozwoleniach(nowe_pozwolenie);
                MessageBox.Show("Pomyślnie dodano pozwolenie !");
            }
        }


        private bool czy_istnieje_juz_taka_rola(string rola_)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.onlyRoless)
                {
                    if(c.Rola_pojedyncza == rola_) { MessageBox.Show("Taka rola już istnieje ! "); return true; }
                }
                return false;
            }
        } 
        public void dodanie_nowej_roli(string rola)
        {
            DatabaseContext db = new DatabaseContext();
            if (czy_istnieje_juz_taka_rola(rola) == false) {
                var nowaRola = new onlyRoles { Rola_pojedyncza = rola };
                using (db)
                {
                    db.onlyRoless.Add(nowaRola);
                    db.SaveChanges();
                }
                MessageBox.Show("Pomyślnie dodano rolę !");
            } 
        }
        
        public void zatwierdz_button(string login, string rola, int[] tab, int ilosc)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach (var c in db.Roless)
                {
                    if(c.username == login && c.username != "admin")
                    {
                        string pozwolenie = "";
                        for(int i=0; i < ilosc; i++)
                        {
                            if (i != ilosc - 1) { pozwolenie = pozwolenie + tab[i] + ','; }
                            else { pozwolenie = pozwolenie + tab[i]; }
                        }
                         c.pozwolenia_wszystkie = pozwolenie;
                         c.rola = rola;
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Pomyślnie zaktualizowano ! ");
            }
        }
        public int ilosc_pozwolen()
        {
            DatabaseContext db = new DatabaseContext();
            int ilosc = 0;
            using (db)
            {
                foreach(var c in db.OnlyPozwolenias)
                {
                    ilosc++;
                }
            }
            return ilosc;
        }
    }
}
