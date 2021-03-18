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
        static int longueurECG = 5000;
        public Form1()
        {
            InitializeComponent();


            // Affichage du signal ECG brut
            rawECG = Program.lectureRawECG();
            //foreach (int raw in rawECG)
            //    Console.WriteLine(raw);

            // Affichage du signal ECG en mV
            signal_mV = Program.TransferFunction(rawECG);
            //foreach (double sample in signal_mV)
            //    Console.WriteLine(sample);

            //Affichage du signal ECG débruité
            denoisingECG = Program.dwt(signal_mV);
            //foreach (double sample in denoisingECG)
            //    Console.WriteLine(sample);

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
            for (int i = 3000; i< longueurECG; i++)
            {
                serie.Points.AddXY(i, rawECG[i] );
            }
            serie.ChartType = SeriesChartType.Spline;


            //////// CHART 2 /////////
            this.chart2.Series.Clear();

            this.chart2.Titles.Add("ECG");

            chart2.Series.Clear();

            string seriesName2 = "ECG in mV";
            Series serie2 = chart2.Series.Add(seriesName2);

            serie2.ChartArea = chart2.ChartAreas[0].Name;
            serie2.Name = seriesName2;
            serie2.ChartType = SeriesChartType.Stock;

            for (int i = 3000; i < longueurECG; i++)
            {
                serie2.Points.AddXY(i, signal_mV[i]);
            }

            serie2.ChartType = SeriesChartType.Spline;



            //////// CHART 3 /////////
            this.chart3.Series.Clear();

            this.chart3.Titles.Add("ECG");

            chart3.Series.Clear();

            string seriesName3 = "denoising ECG";
            Series serie3 = chart3.Series.Add(seriesName3);

            serie3.ChartArea = chart3.ChartAreas[0].Name;
            serie3.Name = seriesName3;
            serie3.ChartType = SeriesChartType.Stock;

            for (int i = 3000; i < longueurECG; i++)
            {
                serie3.Points.AddXY(i, denoisingECG[i]);
            }

            serie3.ChartType = SeriesChartType.Spline;
        }


    }
}
