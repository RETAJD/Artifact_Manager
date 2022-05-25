using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Business_logic;
using App.Data;

namespace App.Business_logic
{
    class Deleting_rows
    {
        public void usuniecie_kategorii(string kategoria)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                db.Categoryss.RemoveRange(db.Categoryss.Where(x => x.poj_kategoria == kategoria));

                //usuniecie z tabeli values
                foreach(var c in db.Elementsss)
                {
                    if(c.kategoria_ele == kategoria)
                    {
                        foreach(var d in db.Elementsvaluess)
                        {
                            if(c.element == d.element)
                            {
                                db.Elementsvaluess.Remove(d);
                            }
                        }
                    }
                }

                foreach(var d in db.Elementsss)
                {
                    if(d.kategoria_ele == kategoria)
                    {
                        db.Elementsss.Remove(d);
                    }
                }
                db.SaveChanges();
            }
        }


        public void usuniecie_elementu_z_wartosciami(string kategoria, string element_do)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Elementsss)
                {
                    if(c.kategoria_ele == kategoria && c.element == element_do)
                    {
                        db.Elementsss.Remove(c);
                    }
                }

                //wartosci
                foreach( var c in db.Elementsvaluess)
                {
                    if(c.element == element_do)
                    {
                        db.Elementsvaluess.Remove(c);
                    }
                }
                db.SaveChanges();
            }
        }

        public void usuniecie_nazwy_wartosci(string element, string nazwa_wartosci)
        {
            DatabaseContext db = new DatabaseContext();
            using (db)
            {
                foreach(var c in db.Elementsvaluess)
                {
                    if(c.element == element && c.nazwa_wartosci == nazwa_wartosci)
                    {
                        db.Elementsvaluess.Remove(c);
                    }
                }
                db.SaveChanges();
            }
        }

    }
}
