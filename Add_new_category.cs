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
    public partial class Add_new_category : Form
    {

        public string curr { get; set; }
        int ilosc_wartosci;
        int ilosc_elementow;
        public Add_new_category()
        {
            InitializeComponent();
        }
        public Add_new_category(string current_User)
        {
            InitializeComponent();
            this.curr = current_User;
        }

        private void Add_new_category_Load(object sender, EventArgs e)
        {
            label1.Text = "Witaj, " + curr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Categoryy AC = new Add_Categoryy();
            string nazwa_uzytkownika = curr;
            if(textBox1.Text != "")
            {
                if(AC.czy_kategoria_juz_istnieje(textBox1.Text) == false)
                {
                    AC.dodaj_kategorie(textBox1.Text, nazwa_uzytkownika);
                    button1.Enabled = false;  // nie mozna wprowadzic nowej kategorii
                }
            }
            else
            {
                MessageBox.Show("Wprowadź nazwe kategorii!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Categoryy AD = new Add_Categoryy();
            //TODO   dodaj do tabeli Elements   Textbox2   wierszy z nazwa kategorii= textbox1 
            if(textBox2.Text != "")
            {
                if (AD.czyZawieraLitery(textBox2.Text))
                {
                    MessageBox.Show("Wprowadź poprawna liczbe ! ");
                }
                else
                {
                    AD.dodanie_ilosci_elementow(Int32.Parse(textBox2.Text), textBox1.Text);
                    button2.Enabled = false;  // nie mozna wprowadzic nowej kategorii
                    ilosc_elementow = Int32.Parse(textBox2.Text);
                }
            }

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            // odpalamy petle tyle ile jest w  Textbox2
            // uzupelniamy pierwsza wartosc w tabeli  Elements
            // dodajemy textbox4 wierszy do tabeli element_values z nazwa elementu = textbox3
            // odpalamy petle tyle ile jest w textbox4
            // dopisujemy pokolei nazwe wartosci i wartosc  az do textbox4 wtedy przechodzimy do kolejnej iteracji w textbox2
            Add_Categoryy AD = new Add_Categoryy();
            if (textBox3.Text != "" && textBox4.Text !="")
            {
                if (AD.czyZawieraLitery(textBox4.Text))
                {
                    MessageBox.Show("Wprowadź poprawna liczbe ! ");
                }
                if(AD.sprawdzenie_czy_istnieje_juz_taki_element(textBox3.Text)== true)
                {
                    MessageBox.Show("Taki element juz istnieje !");
                }
                else
                {
                    //for od 1 do textbox
                    //zupelniamy pierwsza wartosc w tabeli  Elements
                    // false - > nie mozna dodac elementu
                    //LECIMY koks
                    //dodalismy wszystkie wartosci
                    // true - > dodaj element i znowu
                    //jezeli for przejdzie to Message box dziekujemy za dodanie kategorii
                    if(ilosc_elementow != 0)
                    {
                        AD.dodawanie_elementow(textBox3.Text, Int32.Parse(textBox4.Text));
                        button3.Enabled = false;
                        ilosc_wartosci = Int32.Parse(textBox4.Text);  // licznik ile zostalo
                        button4.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Dodales wszystkie elementy!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wprowadź parametry !");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Categoryy AD = new Add_Categoryy();
            if (textBox5.Text !="" && textBox6.Text != "")
            {
                if(ilosc_wartosci != 0)
                {
                    AD.dodanie_wartosci(textBox6.Text, textBox5.Text);
                    textBox6.Text = "";
                    textBox5.Text = "";
                    ilosc_wartosci--;
                }
                else{
                    MessageBox.Show("Dodales wszystkie wartosci !");
                }
               
            }
            if(ilosc_wartosci == 0)
            {
                MessageBox.Show("Dodales wszystkie wartosci elementu !");
                ilosc_elementow--;
                button3.Enabled = true;
                button4.Enabled = false;
            }
            else
            {
                MessageBox.Show("Wprowadź parametry !");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(ilosc_elementow == ilosc_wartosci && ilosc_wartosci == 0)
            {
                MessageBox.Show("Pomyslnie DODANO !");
                this.Hide();
            }
        }
    }
}
