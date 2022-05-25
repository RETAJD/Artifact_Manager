using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Data;
using App.Business_logic;

namespace App.Business_logic
{
    class Edit_categoryy
    {
        public void zmiana_nazwy_kategorii(string stara_nazwa_kat, string nowa_nazwa_kat,string autor)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Elementsss)
                {
                    if(c.kategoria_ele == stara_nazwa_kat)
                    {
                        c.kategoria_ele = nowa_nazwa_kat;
                    }
                }
                
                foreach (var c in db.Categoryss)
                {
                    if(c.poj_kategoria == stara_nazwa_kat)
                    {
                        c.poj_kategoria = nowa_nazwa_kat;
                        c.autor_kategorii = autor;
                    }
                }
                db.SaveChanges();
            }
        }


        public void zmiana_nazwy_elementu(string kategoria, string stara_nazwa_ele, string nowa_nazwa_ele, string autor)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                //zmiana w elements
                foreach (var c in db.Elementsss)
                {
                    if (c.element == stara_nazwa_ele)
                    {
                        c.element = nowa_nazwa_ele;
                    }
                }
                // zmiana w ele value
                foreach (var c in db.Elementsvaluess)
                {
                    if (c.element == stara_nazwa_ele)
                    {
                        c.element = nowa_nazwa_ele;
                    }
                }

                foreach (var c in db.Categoryss)
                {
                    if (c.poj_kategoria == kategoria)
                    {
                        c.autor_kategorii = autor;
                    }
                }

                db.SaveChanges();

            }

        }

        public void zmiana_wartosci(string stara_nazwa_ele, string wartosc1, string stara_nazwa_wart, string nowa_nazwa_wart)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Elementsvaluess)
                {
                    if(c.element == stara_nazwa_ele && c.nazwa_wartosci == stara_nazwa_wart)
                    {
                        c.nazwa_wartosci = nowa_nazwa_wart;
                        c.wartosc = wartosc1;
                    }
                }
                db.SaveChanges();
            }
        }

        public void dodanie_elementu(string kategoria, string element)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                var nowy = new Elements { element = element , kategoria_ele = kategoria };
                db.Elementsss.Add(nowy);
                db.SaveChanges();
            }
        }

        public void dodanie_wartosci_pojedynczej(string element, string nazwa, string wartosc)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                var nowy = new elements_values { element = element, nazwa_wartosci = nazwa, wartosc = wartosc };
                db.Elementsvaluess.Add(nowy);
                db.SaveChanges();
            }
        }


    }
}
