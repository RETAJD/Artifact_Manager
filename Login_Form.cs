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

namespace App
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login_text = textBox1.Text;
            string Haslo_text = textBox2.Text;

            Login login1 = new Login();
            bool zalogowany = false;

            if (login1.czy_zostaly_wprowadzone_dane(Login_text, Haslo_text))
            {
                //TODO  - Sprawdz w bazie czy istnieje ten uzytkownik- jezeli istnieje to zaloguj.
                if (login1.czy_poprawne_dane_logowania(Login_text, Haslo_text))
                {
                    zalogowany = true;
                    this.Hide();
                    MainMenu menu = new MainMenu(Login_text);
                    menu.ShowDialog();
                }
                if(login1.czy_poprawne_dane_logowania(Login_text, Haslo_text) == false)
                {
                    zalogowany = false;
                    MessageBox.Show("Złe dane logowania !");
                }
                if(zalogowany == true) Close();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
