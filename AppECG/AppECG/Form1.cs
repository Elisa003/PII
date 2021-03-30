using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace AppECG
{
    public partial class Form1 : Form
    {
        int[] rawECG;
        double[] signal_mV;
        double[] denoisingECG;
        static int debutECG = 3000;
        static int finECG = 7500;
        public Form1()
        {
            InitializeComponent();

            AffichageRawECG();
            AffichageECGmV();
            AffichageDenoisingECG();


            double[] ecg = Program.TransferFunction(rawECG);

            foreach (double pic in DetectPic(ecg))
            {
                picTrouvé.Text += "pic : " + pic.ToString() + "   ";
            }

            tbSDNN.Text = SDNN(DetectPic(ecg)).ToString();
            tbRMSSD.Text = RMSSD(DetectPic(ecg)).ToString();
            tbSkew.Text = Skew(ecg).ToString();
        }

        void AffichageRawECG()
        {
            // Affichage du signal ECG brut
            rawECG = Program.lectureRawECG();

            //////// CHART 1 /////////

            this.chart1.Series.Clear();

            this.chart1.Titles.Add("ECG");

            chart1.Series.Clear();

            string seriesName = "raw ECG";
            Series serie = chart1.Series.Add(seriesName);

            serie.ChartArea = chart1.ChartAreas[0].Name;
            serie.Name = seriesName;
            serie.ChartType = SeriesChartType.Stock;

            //fenetre à faire varier
            for (int i = debutECG; i < finECG; i++)
            {
                serie.Points.AddXY(i, rawECG[i]);
            }
            serie.ChartType = SeriesChartType.Spline;
        }

        void AffichageECGmV()
        {
            // Affichage du signal ECG en mV
            signal_mV = Program.TransferFunction(rawECG);

            //////// CHART 2 /////////
            this.chart2.Series.Clear();

            this.chart2.Titles.Add("ECG");

            chart2.Series.Clear();

            string seriesName2 = "ECG in mV";
            Series serie2 = chart2.Series.Add(seriesName2);

            serie2.ChartArea = chart2.ChartAreas[0].Name;
            serie2.Name = seriesName2;
            serie2.ChartType = SeriesChartType.Stock;

            for (int i = debutECG; i < finECG; i++)
            {
                serie2.Points.AddXY(i, signal_mV[i]);
            }

            serie2.ChartType = SeriesChartType.Spline;
        }

        void AffichageDenoisingECG()
        {
            //Affichage du signal ECG débruité
            denoisingECG = Program.dwt(signal_mV);

            //////// CHART 3 /////////
            this.chart3.Series.Clear();

            this.chart3.Titles.Add("ECG");

            chart3.Series.Clear();

            string seriesName3 = "denoising ECG";
            Series serie3 = chart3.Series.Add(seriesName3);

            serie3.ChartArea = chart3.ChartAreas[0].Name;
            serie3.Name = seriesName3;
            serie3.ChartType = SeriesChartType.Stock;

            for (int i = debutECG; i < finECG; i++)
            {
                serie3.Points.AddXY(i, denoisingECG[i]);
            }

            serie3.ChartType = SeriesChartType.Spline;
        }


        public double[] DetectPic(double[] ecg)
        {
            double[] pics = new double[50];

            int debut = 3199;
            int cpt = 0;

            do
            {
                int finSeq = debut + 100;

                double pic = 0;

                for (int i = debut; i < finSeq; i++)
                {
                    if (ecg[i] > pic)
                        pic = ecg[i];
                }
                pics[cpt] = pic;
                cpt++;
                debut = finSeq;
            }
            while (debut < finECG);

            return pics;
        }

        public double SDNN(double[] pics)
        {
            int longueurPics = 44;
            double somme = 0;

            for (int i = 0; i < longueurPics - 1; i++)
            {
                double ecart = pics[i + 1] - pics[i];
                double moy = (pics[i + 1] + pics[i]) / 2;
                somme += Math.Pow(ecart - moy, 2);
            }

            return Math.Sqrt((1.0 / (longueurPics - 2)) * somme);
        }

        public double RMSSD(double[] pics)
        {
            int longueurPics = 44;
            double somme = 0;

            for (int i = 0; i < longueurPics - 2; i++)
            {
                double ecart1 = pics[i + 2] - pics[i + 1];
                double ecart2 = pics[i + 1] - pics[i];
                somme += Math.Pow(ecart1 - ecart2, 2);
            }

            return Math.Sqrt((1.0 / (longueurPics - 2)) * somme);
        }

        public double Skew(double[] ecg)
        {
            double longueurECG = finECG - debutECG;
            double skew = 0.0d;
            for (int i = debutECG; i < finECG; i++)
            {
                skew += Math.Pow((ecg[i] - Mean(ecg)) / Sd(ecg), 3);
            }
            return longueurECG / (longueurECG - 1) / (longueurECG - 2) * skew;
        }

        public double Mean(double[] ecg)
        {
            double mean = 0;
            for (int i = debutECG; i < finECG; i++)
            {
                mean += ecg[i];
            }
            return mean / (finECG - debutECG);
        }

        public double Variance(double[] ecg, double mean)
        {
            double variance = 0;

            for (int i = debutECG; i < finECG; i++)
            {
                variance += Math.Pow((ecg[i] - mean), 2);
            }

            int n = finECG - debutECG;
            if (debutECG > 0)
                n -= 1;

            return variance / (n);
        }

        public double Sd(double[] ecg)
        {
            double mean = Mean(ecg);
            double variance = Variance(ecg, mean);

            return Math.Sqrt(variance);
        }

    }
}
