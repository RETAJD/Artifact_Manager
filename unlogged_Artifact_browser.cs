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
    public partial class unlogged_Artifact_browser : Form
    {
        public unlogged_Artifact_browser()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Powitalny menu = new Powitalny();
            menu.ShowDialog();  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void unlogged_Artifact_browser_Load(object sender, EventArgs e)
        {
            DatabaseContext dbContext = new DatabaseContext();
            dataGridView1.DataSource = dbContext.Categoryss.ToList();
            using(dbContext){ 
                foreach(var c in dbContext.Categoryss){
                    comboBox1.Items.Add(c.poj_kategoria);
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
                                    dataGridView2.Rows.Add(d.ID,d.element, d.wartosc, d.nazwa_wartosci);
                                    //MessageBox.Show(d.element);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new DatabaseContext();

            dataGridView1.DataSource = null;
            using (db)
            {
                dataGridView1.ColumnCount = 2;
                dataGridView1.Rows.Clear();

                foreach(var c in db.Categoryss)
                {
                    if (c.poj_kategoria.Contains(textBox1.Text))
                    {
                        dataGridView1.Rows.Add(c.poj_kategoria, c.autor_kategorii);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            /////////////////////////////////////////////
            top5andNew t5n = new top5andNew();
            t5n.ShowDialog();
        }
    }
}
