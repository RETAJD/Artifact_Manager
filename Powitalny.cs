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
    public partial class Powitalny : Form
    {
        DatabaseContext db = new DatabaseContext();
        public Powitalny()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Form log_form = new Login_Form();
            this.Hide();
            log_form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration_Form registration_form = new Registration_Form();
            this.Hide();
            registration_form.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            unlogged_Artifact_browser art_men = new unlogged_Artifact_browser();
            this.Hide();
            art_men.ShowDialog();
            this.Close();
        }
    }
}
