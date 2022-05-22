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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // Uzyskanie Loginu zalogowanego użytkownika
        public string curr { get; set; }
        public MainMenu(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            probab_Admin.Text = "";
            label_User.Text = "";

            string nazwauzytkownika = curr;
            if (nazwauzytkownika == "admin")
            {
                probab_Admin.Text = "PANEL ADMINA";
            }
            else
            {
                label_User.Text = "Witaj: " + nazwauzytkownika;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            string nazwauzytkownika = curr;  // przekazanie uzytkownika zalogowanego do zarzadzania uzytkownikami
            Zarzadzanie_uzytkownikami zarz = new Zarzadzanie_uzytkownikami(nazwauzytkownika);
            zarz.ShowDialog();
        }
    }
}
