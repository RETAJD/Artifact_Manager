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
    public partial class Artifact_manage : Form
    {

        public string curr { get; set; }
        public Artifact_manage()
        {
            InitializeComponent();
        }
       
        public Artifact_manage(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
        }

        private void Artifact_manage_Load(object sender, EventArgs e)
        {
            string nazwa_uzytkownika = curr;
            label1.Text = "Zarzadzanie uzytkownikami, witaj: " + nazwa_uzytkownika;


            DatabaseContext dbContext = new DatabaseContext();
            dataGridView1.DataSource = dbContext.Categoryss.ToList();
            using (dbContext)
            {
                foreach (var c in dbContext.Categoryss)
                {
                    comboBox1.Items.Add(c.poj_kategoria);
                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new DatabaseContext();

            dataGridView1.DataSource = null;
            using (db)
            {
                dataGridView1.ColumnCount = 2;
                dataGridView1.Rows.Clear();

                foreach (var c in db.Categoryss)
                {
                    if (c.poj_kategoria.Contains(textBox1.Text))
                    {
                        dataGridView1.Rows.Add(c.poj_kategoria, c.autor_kategorii);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // dodawanie elementow do DatagridView2
            DatabaseContext dbContext = new DatabaseContext();
            if (comboBox1.Text != "")
            {
                dataGridView2.Rows.Clear();
                using (dbContext)
                {
                    dataGridView2.ColumnCount = 4;
                    foreach (var c in dbContext.Elementsss)
                    {
                        if (c.kategoria_ele == comboBox1.Text)
                        {
                            foreach (var d in dbContext.Elementsvaluess)
                            {
                                if (c.element == d.element)
                                {
                                    dataGridView2.Rows.Add(d.ID, d.element, d.nazwa_wartosci, d.wartosc);
                                    //MessageBox.Show(d.element);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nazwa_uzytkownika = curr;
            Add_new_category ANC = new Add_new_category(nazwa_uzytkownika);
            ANC.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        { 
            string nazwa_uzytkownika = curr;
            Edit_category EC = new Edit_category(nazwa_uzytkownika);
            EC.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            string nazwa_uzytkownika = curr;
            MainMenu menu = new MainMenu(nazwa_uzytkownika);
            menu.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nazwa_uzytkownika = curr;
            Delete_category DC = new Delete_category(nazwa_uzytkownika);
            DC.ShowDialog();
        }
    }
}
