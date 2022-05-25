using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Data;


namespace App.Business_logic
{
    internal class Add_Categoryy
    {
        public bool czy_kategoria_juz_istnieje(string kategoria)
        {
            DatabaseContext db = new DatabaseContext();

            using (db)
            {
                foreach(var c in db.Categoryss)
                {
                    if(c.poj_kategoria == kategoria)
                    {
                        MessageBox.Show("Taka kategoria już istnieje !");
                        return true;
                    }
                }
                return false;
            }  
        }


        public void dodaj_kategorie(string kategoria, string login)
        {
            DatabaseContext db = new DatabaseContext(); // data_kategorii
           
            int ilosc_kategorii = 0;
            using (db)
            {
                foreach(var c in db.Categoryss)
                {
                    ilosc_kategorii++;
                }
                var cat = new Category { poj_kategoria = kategoria, autor_kategorii = login,ktora_kategoria = ilosc_kategorii };
                db.Categoryss.Add(cat);
                db.SaveChanges();
            }
                MessageBox.Show("Dodano kategorię !");
        }

        public void dodanie_ilosci_elementow(int ilosc, string kategoria)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
               for(int i=0;i<ilosc;i++)
                {
                    var cat = new Elements { element = "", kategoria_ele = kategoria };
                    db.Elementsss.Add(cat);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Pomyslnie dodano !");
        }

        public bool czyZawieraLitery(string ilosc)
        {
            bool containsLetter = Regex.IsMatch(ilosc, "[a-zA-Z]");
            return containsLetter;
        }


        public void dodawanie_elementow(string nazwa_elementu, int ilosc_wartosci)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                // zapisanie do elements nowego elementu
                foreach(var c in db.Elementsss)
                {
                    if (c.element == "")
                    {
                        c.element = nazwa_elementu;
                        break;
                    }
                }

                //zapisanie do ele values    N  razy  puste
                for(int i = 0; i < ilosc_wartosci; i++)
                {
                    var wartosci = new elements_values  { element = nazwa_elementu, nazwa_wartosci ="", wartosc ="" };
                    db.Elementsvaluess.Add(wartosci);
                }
                db.SaveChanges();
                MessageBox.Show("Dodano, Wpisz teraz " + ilosc_wartosci.ToString() + " nazw i wartosci !");
            }
        }

        public void dodanie_wartosci(string nazwa_wartoscii, string wartosc)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Elementsvaluess)
                {
                    if (c.nazwa_wartosci == "")
                    {
                        c.nazwa_wartosci = nazwa_wartoscii;
                        c.wartosc = wartosc;
                        break;
                    }
                }
                db.SaveChanges();
            }
        }


        public bool sprawdzenie_czy_istnieje_juz_taki_element(string element)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Elementsss)
                {
                    if (c.element == element) return true;
                }
                return false;
            }
        }

    }
}
