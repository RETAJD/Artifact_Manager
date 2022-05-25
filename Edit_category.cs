using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using App.Business_logic;
using App.Data;

namespace App
{
    public partial class Edit_category : Form
    {
        public string curr { get; set; }
        public Edit_category()
        {
            InitializeComponent();
        }

        public Edit_category(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
        }

        private void Edit_category_Load(object sender, EventArgs e)
        {
            string nazwa_uzytkownika = curr;
            label2.Text = nazwa_uzytkownika;

            odswiezenie();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        void odswiezenie()
        {
            DatabaseContext dbContext = new DatabaseContext();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox7.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox3.Items.Clear();
            comboBox8.Items.Clear();

            using (dbContext)
            {
                foreach (var c in dbContext.Categoryss)
                {
                    comboBox1.Items.Add(c.poj_kategoria);
                    comboBox2.Items.Add(c.poj_kategoria);
                    comboBox4.Items.Add(c.poj_kategoria);
                    comboBox7.Items.Add(c.poj_kategoria);
                }
                //dodanie comboboxa3
                if (comboBox2.Text != "")
                {
                    //combobox3
                    foreach (var d in dbContext.Elementsss)
                    {
                        if (d.kategoria_ele == comboBox2.Text)
                        {
                            comboBox3.Items.Add(d.element);
                        }
                    }
                }


                //dodanie comboboxa5
                if (comboBox4.Text != "")
                {
                    //combobox3
                    foreach (var d in dbContext.Elementsss)
                    {
                        if (d.kategoria_ele == comboBox4.Text)
                        {
                            comboBox5.Items.Add(d.element);
                        }
                    }
                }

                //dodanie comboboxa6
                if (comboBox5.Text != "")
                {
                    foreach (var d in dbContext.Elementsvaluess)
                    {
                        if (d.element == comboBox5.Text)
                        {
                            comboBox6.Items.Add(d.nazwa_wartosci);
                        }
                    }
                }

                foreach( var d in dbContext.Elementsss)
                {
                    comboBox8.Items.Add(d.element);
                }




            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            odswiezenie();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Categoryy AC = new Add_Categoryy();
            Edit_categoryy EC = new Edit_categoryy();

            if(comboBox1.Text != "" && textBox1.Text != "")
            {
                if (AC.czy_kategoria_juz_istnieje(textBox1.Text)==false)
                {
                    EC.zmiana_nazwy_kategorii(comboBox1.Text, textBox1.Text, curr);
                    MessageBox.Show("Pomyślnie zaktualizowano !");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź dane !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Categoryy AC = new Add_Categoryy();
            Edit_categoryy EC = new Edit_categoryy();

            if (textBox2.Text !="" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if(AC.sprawdzenie_czy_istnieje_juz_taki_element(textBox2.Text) == false)
                {
                    EC.zmiana_nazwy_elementu(comboBox2.Text, comboBox3.Text, textBox2.Text,curr);
                    MessageBox.Show("Pomyślnie zaktualizowano !");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź dane !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Add_Categoryy AC = new Add_Categoryy();
            Edit_categoryy EC = new Edit_categoryy();

            if (textBox3.Text != "" && textBox7.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "")
            {
                EC.zmiana_wartosci(comboBox5.Text, textBox7.Text, comboBox6.Text, textBox3.Text);
                MessageBox.Show("Pomyślnie zaktualizowano !");
            }
            else
            {
                MessageBox.Show("Wprowadź dane !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Categoryy AC = new Add_Categoryy();
            Edit_categoryy EC = new Edit_categoryy();


            if (comboBox7.Text != "" && textBox4.Text != "")
            {
                if (AC.sprawdzenie_czy_istnieje_juz_taki_element(textBox4.Text) == false)
                {
                    EC.dodanie_elementu(comboBox7.Text, textBox4.Text);
                    MessageBox.Show("Pomyślnie dodano !");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź dane !");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Categoryy AC = new Add_Categoryy();
            Edit_categoryy EC = new Edit_categoryy();


            if (comboBox8.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                EC.dodanie_wartosci_pojedynczej(comboBox8.Text, textBox5.Text, textBox6.Text);
                MessageBox.Show("Pomyślnie dodano !");
            }
            else
            {
                MessageBox.Show("Wprowadź dane !");
            }
        }
    }
}
