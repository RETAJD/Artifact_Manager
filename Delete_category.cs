using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using App.Data;
using App.Business_logic;

namespace App
{
    public partial class Delete_category : Form
    {
        public string curr { get; set; }
        public Delete_category()
        {
            InitializeComponent();
        }
        public Delete_category(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
        }
        private void Delete_category_Load(object sender, EventArgs e)
        {
            string nazwa_uzytkownika = curr;
            label2.Text = nazwa_uzytkownika;


            odswiezenie();

        }

        void odswiezenie()
        {
            DatabaseContext db = new DatabaseContext();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            using (db)
            {
                foreach (var c in db.Categoryss)
                {
                    comboBox1.Items.Add(c.poj_kategoria);
                    comboBox2.Items.Add(c.poj_kategoria);
                    comboBox4.Items.Add(c.poj_kategoria);
                }

                if(comboBox2.Text != "")
                {
                    foreach (var c in db.Elementsss)
                    {
                        if(c.kategoria_ele == comboBox2.Text)
                        {
                            comboBox3.Items.Add(c.element);
                        }
                    }
                }

                if (comboBox4.Text != "")
                {
                    foreach (var c in db.Elementsss)
                    {
                        if (c.kategoria_ele == comboBox4.Text)
                        {
                            comboBox5.Items.Add(c.element);
                        }
                    }
                }

                if(comboBox5.Text != "")
                {
                    foreach (var c in db.Elementsvaluess)
                    {
                        if(c.element == comboBox5.Text)
                        {
                            comboBox6.Items.Add(c.nazwa_wartosci);
                        }
                    }
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deleting_rows DR = new Deleting_rows();

            if (comboBox1.Text != "")
            {
                DR.usuniecie_kategorii(comboBox1.Text);
                MessageBox.Show("Usunieto !");
            }
            else
            {
                MessageBox.Show("Wybierz kategorie!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deleting_rows DR = new Deleting_rows();

            if (comboBox2.Text != "" && comboBox3.Text != "")
            {
                DR.usuniecie_elementu_z_wartosciami(comboBox2.Text, comboBox3.Text);
                MessageBox.Show("Usunieto !");
            }
            else
            {
                MessageBox.Show("Uzupełnij dane !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deleting_rows DR = new Deleting_rows();

            if (comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "")
            {
                DR.usuniecie_nazwy_wartosci(comboBox5.Text, comboBox6.Text);
                MessageBox.Show("Usunieto !");
            }
            else
            {
                MessageBox.Show("Uzupełnij dane !");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            odswiezenie();
        }
    }
}
