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
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Registration_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login_text = textBox1.Text;
            string Haslo_text = textBox2.Text;

            Register register1 = new Register();

            if (register1.czy_zostaly_wprowadzone_dane(Login_text, Haslo_text))
            {
                //TODO  - Wywolaj metode która rejestruje użytkownika
                register1.zarejestrujUzytkownika(Login_text, Haslo_text);
                // Pomyslnie zarejestrowano - mozesz sie teraz zalogowac

                this.Hide();
                Powitalny powitalny = new Powitalny();
                powitalny.ShowDialog();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Powitalny menu = new Powitalny();
            menu.ShowDialog();
        }
    }
}
