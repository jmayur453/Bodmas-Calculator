using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace Calculator
{
    public partial class Form1 : Form
    {
        public void myControl_NumPad(object sender, KeyPressEventArgs e)
        {
            
            
        }
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "0";

            string s = "";
            int k = 1;
            while (k < textBox1.Text.Length)
            {
                s += textBox1.Text[k - 1];
                k++;
            }
            k--;
            if (textBox1.Text[k] < 48 || textBox1.Text[k] > 57)
            {
                textBox1.Clear();
                textBox1.Text = s;
            }
            s="";
            string d = "";
            string t = "";
            string d2 = "";
            string f = "";
            string tmp = "";
            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "0";
            }
            double i = 0.00, j = 0.00, r2 = 0, sum = 0;
            int  l;
            d = textBox1.Text;
            
            x:
            l = 0;
            k= d.Length;
            k--;
            while (l<=k)
            {
                if ((d[l] >= 48 && d[l] <= 57) || d[l]=='-' || d[l]==46) //
                    {
                        d2 =d2+ d[l];
                    }
                    else if (d[l] == '+' || d[l] == 'x')
                    {
                        tmp += d2;
                        tmp += d[l];
                        d2 = "";
                    }
                    if(d[l]=='%')
                    {
                       l=l+1;
                        while ((l <= k && d[l] >=48 && d[l] <= 57) || (l <= k && d[l] == '-' &&d[l-1]=='%') ||(l <= k && d[l]==46))
                        {
                            f += d[l];
                            l++;
                        }
                        i = double.Parse(d2);
                        j = double.Parse(f);
                        i=Math.Round(i, 4);
                        j=Math.Round(j, 4);
                    if (j!=0)  r2 = i / j;
                        r2=Math.Round(r2, 4);
                        tmp = tmp+r2;
                    if (l<=k && d[l] == '%')
                    {
                        while (l<=k)
                        {
                            tmp=tmp+d[l];
                            l++;
                        }
                        d = tmp;
                        tmp = "";
                        f = "";
                        d2 = "";
                        goto x;
                    }
                        if (l<=k &&(d[l]<48 || d[l]>57 || d[l]!=46)) tmp = tmp+d[l]; // abhi dekhn h
                        i = 0;
                        j = 0;
                        f = "";
                        d2 = "";
                        r2 = 0;
                    }
                l++;
            }
            int p;
            i = 0;
            if (d2 != null)
            {
                tmp += d2;
                d2 = "";
                for (p = 0; p < tmp.Length; p++)
                {
                    if (tmp[p] == '%')
                    {
                        i = 1;
                        break;
                    }
                }
                if (i==1)
                {
                    d = tmp;
                    tmp = "";
                    goto x;
                }
            }
            t = tmp;
            k = t.Length;
            k--;
            i = 0;
            for (p = 0; p <= k; p++)
            {
                if (t[p] != '+' || t[p] != '-' || t[p] != 'x')
                {
                    i = 1;
                    break;
                }
            }
            MessageBox.Show("divide k baad=" + t);

            /****************** mul********************/


            d = t;
        y:
            tmp = "";
            k = d.Length;
            k--;
            t = "";
            d2= "";
            f = "";
            while (k >= 0)
            {
                if (p > k && i == 0) break;
                if ((d[k] >= 48 && d[k] <= 57 ) || d[k]=='-' || d[k]==46)
                {
                    d2 = d[k] + d2;
                }
                else if (d[k] == '+')
                {
                    tmp = d2 + tmp;
                    tmp = d[k] + tmp;
                    d2 = "";
                }
                if(d[k] == 'x')
                {
                    k = k - 1;
                    while ((k >= 0 && d[k] >= 48 && d[k] <= 57) ||  (k >= 0 && d[k] == '-' && d[l - 1] == 'x') ||(k>=0 && d[k] == 46)) // yaha ni ja raha h abhi  5.89x2-7x1+2-28+32%65x98
                    {
                        f = d[k] + f;
                        k--;
                    }
                    
                    i = double.Parse(f);
                    j = double.Parse(d2);
                    i = Math.Round(i, 4);
                    j = Math.Round(j, 4);
                    r2 = i * j;
                    r2=Math.Round(r2, 4);
                    //MessageBox.Show(Math.Round(r2, 3)+"");
                    tmp = r2 + tmp;
                    if (k >= 0) tmp = d[k] + tmp;
                    f = "";
                    d2 = "";
                }
                k--;
            }
            if (d2 != null)
            {
                tmp = d2 + tmp;
            }
            k = tmp.Length;
            k--;
            i = 0;
            for (p = 0; p <= k; p++)
            {
                if ( tmp[p] =='x' )
                {
                    i = 1;
                    break;
                }
            }
            if (i == 1)
            {
                d = tmp;
                tmp = "";
                goto y;
            }
            MessageBox.Show("mul ke baad="+tmp);
            
            /******************* MUL *******************/


            t = tmp;
            k = t.Length;
            k--;
           // i = 0;

            while (k>=0)
            {
                //if (p>k && i==0) break;
                if ((t[k] >= 48 && t[k] <= 57)|| t[k]==46) 
                {
                    s = t[k]+s;
                }
                else if (t[k] == '+')
                {
                    sum += double.Parse(s);
                    s = "";
                }
                else if (t[k] == '-')
                {
                    sum -= double.Parse(s);
                    s = "";
                }
                //else if (t[k] == 'x')
                //{
                //    k--;
                //    while((t[k] >= 48 && t[k] <= 57 )|| t[k]==46) // changes  1.43pm yaha or lagaya kyoki wo . k liye condition har bar true ni hoti 
                //    {
                //        m = t[k] + m;
                //        if (k == 0) break;
                //        k--;
                //    }
                //    i =double.Parse(s) ;
                //    j= double.Parse(m);
                //    res = i * j;
                //    if (t[k] == '-') sum -= res;
                //    else sum += res;
                //        m = "";
                //        s = "";
                //}
                k--;
            }
            if (s!="") 
            {
                sum += double.Parse(s);
            }
            textBox1.Text = ("" + sum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string s = "";
                int k = 1;
                if ((textBox1.Text[0] == '-' || textBox1.Text[0] == '.') && textBox1.Text.Length == 1) return;
                while (k < textBox1.Text.Length)
                {
                    s += textBox1.Text[k - 1];
                    k++;
                }
                k--;
                if (textBox1.Text[k] < 48 || textBox1.Text[k] > 57)
                {
                    textBox1.Clear();
                    textBox1.Text = s;
                }
                textBox1.Text += "+";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        { 
           
            string s = "";
            int k=1;
            while (k<textBox1.Text.Length)
            {
                s += textBox1.Text[k-1];
                k++;
            }
            textBox1.Clear();
            textBox1.Text =s;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string s = "";
                int k = 1;
                while (k < textBox1.Text.Length)
                {
                    s += textBox1.Text[k - 1];
                    k++;
                }
                k--;
                if (textBox1.Text[k] == '+' || textBox1.Text[k] == '-')
                {
                    textBox1.Clear();
                    textBox1.Text = s;
                }
                //textBox1.Text[k] != 'x' || textBox1.Text[k] != '%'
            }
            textBox1.Text += '-';
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += '0';
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "")
            {
                string s = "";
                int k = 1;
                if ((textBox1.Text[0] == '-' || textBox1.Text[0] == '.') && textBox1.Text.Length == 1) return;
                while (k < textBox1.Text.Length)
                {
                    s += textBox1.Text[k - 1];
                    k++;
                }
                k--;
                if (textBox1.Text[k] < 48 || textBox1.Text[k] > 57)
                {
                    textBox1.Clear();
                    textBox1.Text = s;
                    
                }
               textBox1.Text += "x";
            }
        }
        

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string s = "";
                int k = 1;
                if ((textBox1.Text[0] == '-' || textBox1.Text[0] == '.') && textBox1.Text.Length==1) return;
                while (k < textBox1.Text.Length)
                {
                    s += textBox1.Text[k - 1];
                    k++;
                }
                k--;

                if (textBox1.Text[k] < 48 || textBox1.Text[k] > 57)
                {
                    textBox1.Clear();
                    textBox1.Text = s;
                }

               textBox1.Text += "%";
                //k = 0;
                //if (textBox1.Text[k] != '-')
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int i = textBox1.Text.Length;
            i--;
            if(textBox1.Text == "" || textBox1.Text[i]!='.') textBox1.Text += ".";
        }
    }
}
