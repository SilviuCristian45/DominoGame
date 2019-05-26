using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino
{
    public partial class Form1 : Form
    {
        int n,ivechi,jvechi;
        int clic = 0;
        private Button[,] btn = new Button[11,11];

        bool exista_2()
        {   
            bool ex = false;
            for(int i = 0;i<n;i++)
            {   
                for(int j =  0;j<n;j++)
                {
                    if(Convert.ToInt32(btn[i,j].Tag)!=0)
                    {
                        if (i > 0 && Convert.ToInt32(btn[i - 1, j].Tag) != 0)
                        {
                            ex = true;
                        }
                        else if (j > 0 && Convert.ToInt32(btn[i, j - 1].Tag) != 0)
                        {
                            ex = true;
                        }
                        else if (j < n - 1 && Convert.ToInt32(btn[i, j + 1].Tag) != 0)
                        {
                            ex = true;
                        }

                        else if (i < n - 1 && Convert.ToInt32(btn[i+1, j].Tag) != 0)
                        {
                            ex = true;
                        }
                    }
                }
             
            }
            return ex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            for(int i= 0;i< n;i++)
            {
                for(int j = 0;j< n;j++)
                {
                    btn[i, j] = new Button(); btn[i, j].Width = 50;
                    btn[i, j].Height = 50;

                    btn[i, j].Left = 50 + j * 50;

                    btn[i, j].Top = 50 * i + 100;

                    btn[i, j].BackColor = Color.Yellow;

                    btn[i, j].Tag = Convert.ToString(i * n + j + 1);

                    btn[i, j].Click += new EventHandler(btn_Click);

                    this.Controls.Add(btn[i, j]);
                }
            }
        }

        public void btn_Click(object sender,EventArgs eArgs)
        {
            if(!exista_2())
            {
                MessageBox.Show("Ai pierdut"); this.Close();
            }
            else
            {
                int i, j, tag;clic++;
                int nrb = Convert.ToInt32(((Button)sender).Tag) - 1;
                i = nrb / n;
                j = nrb % n;
                Console.WriteLine(i);
                Console.WriteLine(j);
                tag = Convert.ToInt32(btn[i, j].Tag);
                if(tag==0)
                {
                    MessageBox.Show("Ai pierdut"); this.Close();
                }
                if(clic ==1)
                {
                    btn[i, j].Tag = 0;
                    ivechi = i;
                    jvechi = j;
                }
                else
                {
                    clic = 0;
                    bool ok = true;
                    if (Math.Abs(i - ivechi) + Math.Abs(j - jvechi) != 1) ok = false;
                    if(ok)
                    {
                        btn[i, j].BackColor = Color.Aqua;
                        btn[ivechi, jvechi].BackColor = Color.Aqua;
                        MessageBox.Show("Muta calculatorul");
                        btn[n - i - 1, n - j - 1].BackColor = Color.Red;
                        btn[n - ivechi - 1, n - jvechi - 1].BackColor = Color.Red;
                        btn[i, j].Tag = 0;
                        btn[ivechi, jvechi].Tag = 0;
                        btn[n - i - 1, n - j - 1].Tag= 0;
                        btn[n - ivechi - 1, n - jvechi - 1].Tag = 0;
                        if (!exista_2())
                        {
                            MessageBox.Show("Ai pierdut");
                            this.Close();
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Ai pierdut");
                        this.Close();
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
