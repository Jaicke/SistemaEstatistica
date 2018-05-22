using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoEstatistica_v0._01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }


        private void calcular_Click(object sender, EventArgs e)
        {
            double[] amostra = new double[9];
            amostra[0] = double.Parse(txtN1.Text);
            amostra[1] = double.Parse(txtN2.Text);
            amostra[2] = double.Parse(txtN3.Text);
            amostra[3] = double.Parse(txtN4.Text);
            amostra[4] = double.Parse(txtN5.Text);
            amostra[5] = double.Parse(txtN6.Text);
            amostra[6] = double.Parse(txtN7.Text);
            amostra[7] = double.Parse(txtN8.Text);
            amostra[8] = double.Parse(txtN9.Text);
            //Calculo de média            
            txtMedia.Text = Convert.ToString(CalculaMedia());
            
            //Desvio padrão                     
            txtDp.Text = Convert.ToString(CalculaDesvio(amostra));

            //Mediana
            txtMediana.Text = Convert.ToString(CalculaMediana(amostra));

            //Moda
            txtModa.Text = Convert.ToString(CalculaModa(amostra));            

            //Simetria            
            txtSimetria.Text = Convert.ToString(CalculaSimetria(amostra));

            // Primeiro Quartil
            txtPrimeiroQ.Text = Convert.ToString(PrimeiroQuatil(amostra));

            // Segundo Quatil/Mediana
            txtSegundoQ.Text = Convert.ToString(CalculaMediana(amostra)) ;

            // Terceiro Quatil
            txtTerceiroQ.Text = Convert.ToString(TerceiroQuartil(amostra));    
        }

        private double CalculaMedia()
        {
            float n1, n2, n3, n4, n5, n6, n7, n8, n9;
            n1 = float.Parse(txtN1.Text);
            n2 = float.Parse(txtN2.Text);
            n3 = float.Parse(txtN3.Text);
            n4 = float.Parse(txtN4.Text);
            n5 = float.Parse(txtN5.Text);
            n6 = float.Parse(txtN6.Text);
            n7 = float.Parse(txtN7.Text);
            n8 = float.Parse(txtN8.Text);
            n9 = float.Parse(txtN9.Text);

            double media = (n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9) / 9;            
            return media;
        }

        private double CalculaMediana(double[] amostra)
        {         
            Array.Sort(amostra);
            double mediana = amostra[4];//mediana = 9+1/2, posição 4 no vetor
            return mediana;
        }

        private double CalculaDesvio(double[] amostra)
        {            
            double media = CalculaMedia();
            double dp1 = 0;
            double dp2 = 0;
            double dpR = 0;
            for(int i = 0; i <9; i++)
            {
                dp1 += Math.Pow((amostra[i] - media),2);//somatorio de cada elemento do array menos a media elevado ao quadrado
                dp2 = dp1 / (9 - 1);
                dpR = Math.Sqrt(dp2);
                
            }                               
            
            return dpR;
            
        }
        private double CalculaModa(double[] amostra)
        {           

            int repeticao = 0;
            double moda = 0;
            int comparacao = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    if (amostra[i] == amostra[j])
                    {
                        ++repeticao;
                    }

                }
                if (repeticao > comparacao)
                {
                    moda = amostra[i];
                    comparacao = repeticao;
                }
            }
            return moda;
        }
        private double CalculaSimetria(double[] amostra)
        {
            double simetria = 0;          
            simetria = 3 * (CalculaMedia() - CalculaMediana(amostra)) / CalculaDesvio(amostra);
            return simetria;
        }
        private double PrimeiroQuatil(double[] amostra)
        {         
            Array.Sort(amostra);
            double quartil1 = amostra[2];//Q1 = 9+1/4 = 2,5(Arredonda pra 3), posição 2 do vetor 
            return quartil1;
        }
        private double TerceiroQuartil(double[] amostra)
        {        
            Array.Sort(amostra);
            double quartil2 = amostra[6];
            return quartil2;
        }
        private void BtnLimpa_Click(object sender, EventArgs e)
        {
            txtN1.Text = "";
            txtN2.Text = "";
            txtN3.Text = "";
            txtN4.Text = "";
            txtN5.Text = "";
            txtN6.Text = "";
            txtN7.Text = "";
            txtN8.Text = "";
            txtN9.Text = "";
            txtMedia.Text = "";
            txtMediana.Text = "";
            txtModa.Text =  "";
            txtDp.Text = "";
            txtSimetria.Text = "";
            txtPrimeiroQ.Text = "";
            txtSegundoQ.Text = "";
            txtTerceiroQ.Text = "";

        }
    }
}
