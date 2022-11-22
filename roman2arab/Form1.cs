using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace roman2arab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        public int Roman_Parse(char[] roman)
        {
            Dictionary<char, short> lookup = new Dictionary<char, short>();
            lookup.Add('M', 1000);
            lookup.Add('D', 500);
            lookup.Add('C', 100);
            lookup.Add('L', 50);
            lookup.Add('X', 10);
            lookup.Add('V', 5);
            lookup.Add('I', 1);

            lookup.Add('m', 1000);
            lookup.Add('d', 500);
            lookup.Add('c', 100);
            lookup.Add('l', 50);
            lookup.Add('x', 10);
            lookup.Add('v', 5);
            lookup.Add('i', 1);

            int arabic = 0;

            for (int i = 0; i < roman.Count(); i++)
            {
                //
                // return 0 if not valid roman numeral
                //
                if (!lookup.ContainsKey(roman[i]))
                    return 0;

                if (i == roman.Count() - 1)
                {
                    arabic += lookup[roman[i]];
                }
                else
                {
                    if (lookup[roman[i + 1]] > lookup[roman[i]]) arabic -= lookup[roman[i]];
                    else arabic += lookup[roman[i]];
                }
            }
            return arabic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char [] s = this.textBox1.Text.ToCharArray();
            int x = Roman_Parse(s);
            this.textBox2.Text = x.ToString();

        }


       
            protected readonly Dictionary<int, string> RomanLetters = new Dictionary<int, string>
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

            public string IntToRoman(int value)
            {
                var romain = new StringBuilder();
                while (value > 0)
                {
                    foreach (var key in RomanLetters.Keys)
                    {
                        if (value >= key)
                        {
                            value -= key;
                            romain.Append(RomanLetters[key]);
                            break;
                        }
                    }
                }
                return romain.ToString();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16( this.textBox3.Text);
            string x = IntToRoman(i);
            this.textBox4.Text = x;
        }
    }
}
