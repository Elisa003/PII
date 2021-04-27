using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppECG
{
    class TraitementDonnees
    {
        // Longueur du signal à faire varier
        // TODO : à mettre comme variable dans le form
        //static int longueurECG = CalculMesures.finECG+10; 
        public static int longueurECG;


        // TODO : mettre le fichier texte en paramètre de la fonction
        /// <summary>
        /// Lit les données dans le fichier texte
        /// </summary>
        /// <returns> Tableau de données ECG </returns>
        static public double[] lectureRawECG(string fichiertxt)
        {
            double[] rawECG = new double[longueurECG];
            char[] separateur = { '\t' };
            int cpt = 0;

            string fichierSource = "../../../../" + fichiertxt + ".txt";

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

        /// <summary>
        /// Transforme les données brutes d'un ECG en signal en mV
        /// </summary>
        /// <param name="rawECG"> Données brutes ECG </param>
        /// <returns> Tableau des données en mV </returns>
        public static double[] TransferFunction(double[] rawECG)
        {
            double[] signal_mV = new double[longueurECG];

            //A faire varier
            int n = 10; //nbre de bits du canal
            int vcc = 3300; // mV
            int gain = 1100;
            for (int i = 0; i < longueurECG; i++)
                signal_mV[i] = (((rawECG[i] / Math.Pow(2, n)) - 0.5) * vcc) / gain;

            return signal_mV;
        }


        // TODO : à vérifier 
        /// <summary>
        /// Réduit le bruit du signal
        /// </summary>
        /// <param name="signal_mV"> Tableau des données du signal en mV </param>
        /// <returns> Tableau des données du signal débruité </returns>
        public static double[] dwt(double[] signal_mV)
        {
            double[] copie = new double[signal_mV.Length]; // copie du tableau signal_mV pour le garder intact
            Array.Copy(signal_mV, 0, copie, 0, signal_mV.Length);

            double[] dwt = new double[copie.Length];

            for (int taille = copie.Length / 2; ; taille = taille / 2)
            {
                for (int i = 0; i < taille; ++i)
                {
                    double somme = copie[i * 2] + copie[i * 2 + 1];
                    double diff = copie[i * 2] - copie[i * 2 + 1];
                    dwt[i] = somme;
                    dwt[taille + i] = diff;
                }
                if (taille == 1)
                {
                    return dwt;
                }
                Array.Copy(dwt, 0, copie, 0, taille);
            }
        }
    }
}
