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
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace App
{
    public partial class Zarzadzanie_uzytkownikami : Form
    {

        Register reg = new Register();
        DatabaseContext db = new DatabaseContext();
        public string curr { get; set; }
        public Zarzadzanie_uzytkownikami(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
        }

        private void toMenu_Click(object sender, EventArgs e)
        {
           this.Hide();
           string nazwa_uzytkownika = curr;
           MainMenu menu = new MainMenu(nazwa_uzytkownika);
           menu.ShowDialog();
        }

        
        private void Zarzadzanie_uzytkownikami_Load(object sender, EventArgs e)
        {
            string nazwa_uzytkownika = curr;
            label1.Text= "Zarzadzanie uzytkownikami, witaj: " + curr;

            dataGridView1.DataSource = db.Userss.ToList();      // Wyswietlenie bazy Userow
            dataGridView2.DataSource = db.Roless.ToList();       //wyswietlenie  bazy Roles


            //Załadowanie do edycji uzytkownikow
            using (db)
            {
                foreach (var c in db.Roless)
                {
                    comboBox1.Items.Add(c.username.ToString());
                }
                // dodanie mozliwych rol
                foreach (var c in db.onlyRoless)
                {
                    comboBox2.Items.Add(c.Rola_pojedyncza);
                }
                // dodanie mozliwych pozwoleń
                foreach (var c in db.OnlyPozwolenias)
                {
                    checkedListBox1.Items.Add(c.pozwolenie_pojedyncze);
                }

                // dodanie rol do usuniecia
                foreach (var c in db.onlyRoless)
                {
                    comboBox3.Items.Add(c.Rola_pojedyncza);
                }

                // dodanie pozwolen do usuniecia
                foreach (var c in db.OnlyPozwolenias)
                {
                    comboBox4.Items.Add(c.pozwolenie_pojedyncze);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Login_text = textBox2.Text;
            string Haslo_text = textBox3.Text;
            DatabaseContext db1 = new DatabaseContext();

            if (reg.czy_zostaly_wprowadzone_dane(Login_text, Haslo_text))
            {
                reg.zarejestrujUzytkownika(Login_text, Haslo_text);
                dataGridView1.DataSource = db1.Userss.ToList();
            } 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Manage_users mu = new Manage_users();
            string login_wybrany = comboBox1.Text;
            string rola_wybrana = comboBox2.Text;

            // Generowanie tablicy zaznaczonych pozwolen 
            int ilosc_dostepnych_pozwolen = mu.ilosc_pozwolen();
            int[] wybrane_pozwolenia;
            wybrane_pozwolenia = new int[ilosc_dostepnych_pozwolen];

            for(int i =0; i<ilosc_dostepnych_pozwolen; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true) { wybrane_pozwolenia[i] = 1; }
                else { wybrane_pozwolenia[i] = 0; }
            }

            /*
            string napis = "";
            for(int i=0;i<wybrane_pozwolenia.Length; i++)
            {
                    napis= napis + wybrane_pozwolenia[i].ToString();
            }
            MessageBox.Show("napis: " + napis);
            */
            // Dodanie nowych
            // rzeczy to wybranego usera
            // TODO dodaj tylko wtedy kiedy zaznaczyl cos w user oraz rola ! ! ! ! 
            mu.zatwierdz_button(login_wybrany, rola_wybrana, wybrane_pozwolenia , ilosc_dostepnych_pozwolen);
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new DatabaseContext();
            dataGridView2.DataSource = db.Roless.ToList();

            using (db)
            {
                comboBox1.Items.Clear();
                foreach (var c in db.Roless)
                {
                    comboBox1.Items.Add(c.username.ToString());
                }

                // dodanie mozliwych rol
                comboBox2.Items.Clear();
                foreach (var c in db.onlyRoless)
                {
                    comboBox2.Items.Add(c.Rola_pojedyncza);
                }
                // dodanie mozliwych pozwoleń
                checkedListBox1.Items.Clear();
                foreach (var c in db.OnlyPozwolenias)
                {
                    checkedListBox1.Items.Add(c.pozwolenie_pojedyncze);
                }

                // dodanie rol do usuniecia
                comboBox3.Items.Clear();
                foreach (var c in db.onlyRoless)
                {
                    comboBox3.Items.Add(c.Rola_pojedyncza);
                }

                // dodanie pozwolen do usuniecia
                comboBox4.Items.Clear();
                foreach (var c in db.OnlyPozwolenias)
                {
                    comboBox4.Items.Add(c.pozwolenie_pojedyncze);
                }
            }

        }

        //Dodawanie nowej roli
        private void button5_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new DatabaseContext();

            if(textBox1.Text != "")
            {
                Manage_users mu = new Manage_users();
                string nowa_rola = textBox1.Text;
                mu.dodanie_nowej_roli(nowa_rola);

                //dodanie nowej roli do comboBoxa z zaktualizowanej bazy danych
                using (db)
                {
                    comboBox2.Items.Clear();
                    foreach (var c in db.onlyRoless)
                    {
                        comboBox2.Items.Add(c.Rola_pojedyncza);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wpisz poprawna nazwe roli !");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new DatabaseContext();
            if(textBox4.Text != "")
            {
                Manage_users mu = new Manage_users();
                string nowe_pozwolenie = textBox4.Text;
                mu.dodanie_nowego_pozwolenia(nowe_pozwolenie);

                using (db)
                {
                    checkedListBox1.Items.Clear();
                    foreach (var c in db.OnlyPozwolenias)
                    {
                        checkedListBox1.Items.Add(c.pozwolenie_pojedyncze);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wpisz poprawną nazwe pozwolenia !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manage_users manage_Users = new Manage_users();
            if(comboBox4.Text != ""  && manage_Users.czy_pozwolenie_istnieje(comboBox4.Text) ) manage_Users.usuniecie_pozwolenia(comboBox4.Text);
            else { MessageBox.Show("Wybierz pozwolenie do usunięcia !"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // gdy wybierze rolę do usuniecia to usuwa ta role oraz usuwa wszystkich uzytkownikow ktorzy maja tą rolę
            Manage_users manage_Users = new Manage_users();
            if (comboBox3.Text != "") manage_Users.usun_role(comboBox3.Text);
            else { MessageBox.Show("Wybierz rolę !"); }

        }
    }
}
