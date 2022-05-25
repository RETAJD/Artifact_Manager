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
    public partial class top5andNew : Form
    {
        public string curr { get; set; }
        int ktory = 0;
        public top5andNew()
        {
            InitializeComponent();
        }
        public top5andNew(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
            ktory++;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void top5andNew_Load(object sender, EventArgs e)
        {
            odswiezenie();
        }

        void odswiezenie()
        {
            DatabaseContext db = new DatabaseContext();

            dataGridView1.DataSource = null;
            using (db)
            {
                // dodanie elementow
                dataGridView1.ColumnCount = 3;
                dataGridView1.Rows.Clear();

                dataGridView1.Columns[0].HeaderText = "nazwa elementu";
                dataGridView1.Columns[1].HeaderText = "nazwa wartosci";
                dataGridView1.Columns[2].HeaderText = "wartosc";

                foreach (var c in db.Elementsvaluess)
                {
                    dataGridView1.Rows.Add(c.element,c.nazwa_wartosci,c.wartosc);
                }

                // dodanie najnowszych kategorii
                dataGridView2.ColumnCount = 3;
                dataGridView2.Rows.Clear();

                dataGridView2.Columns[0].HeaderText = "nazwa kategorii";
                dataGridView2.Columns[1].HeaderText = "autor";
                dataGridView2.Columns[2].HeaderText = "jak nowa kategoria";

                foreach (var c in db.Categoryss)
                {
                    dataGridView2.Rows.Add(c.poj_kategoria,c.autor_kategorii,c.ktora_kategoria);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ktory == 1)
            {
                this.Hide();
                string nazwa_uzytkownika = curr;
                MainMenu menu = new MainMenu(nazwa_uzytkownika);
                menu.ShowDialog();
            }
            else
            {
                this.Hide();
                Powitalny menu = new Powitalny();
                menu.ShowDialog();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            odswiezenie();
        }
    }
}
