using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace AppECG
{
    static class Program
    {
        static int longueurECG = 5000;
        static public int[] lectureRawECG()
        {
            int[] rawECG = new int[longueurECG];
            char[] separateur = { '\t' };
            int cpt = 0;

            string fichierSource = "../../../signals_math.txt";

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            StreamReader streamReader = new StreamReader(fichierSource, encoding);
            string reader = streamReader.ReadLine();

            while (reader != null && cpt < longueurECG)
            {
                //Console.WriteLine("Lecture ligne " + cpt);
                if (!reader.Contains("#"))
                {
                    string[] data = reader.Split(separateur);
                    rawECG[cpt] = Int32.Parse(data[7]);
                    cpt++;
                }
                reader = streamReader.ReadLine();
            }
            streamReader.Close();

            return rawECG;
        }

        public static double[] TransferFunction(int[] rawECG)
        {
            double[] signal_mV = new double[longueurECG];
            
            //A faire varier
            int resolution = 10;
            int vcc = 3000; // mV
            int gain = 1000;
            for (int i = 0; i < longueurECG; i++)
                signal_mV[i] = (((rawECG[i] / Math.Pow(2, resolution)) - 0.5) * vcc) / gain;

            return signal_mV;
        }

        public static double[] dwt(double[] signal_mV)
        {
            double[] dwt = new double[signal_mV.Length];

            for (int taille = signal_mV.Length / 2; ; taille = taille / 2)
            {
                for (int i = 0; i < taille; ++i)
                {
                    double somme = signal_mV[i * 2] + signal_mV[i * 2 + 1];
                    double diff = signal_mV[i * 2] - signal_mV[i * 2 + 1];
                    dwt[i] = somme;
                    dwt[taille + i] = diff;
                }
                if (taille == 1)
                {
                    return dwt;
                }
                Array.Copy(dwt, 0, signal_mV, 0, taille);
            }
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
