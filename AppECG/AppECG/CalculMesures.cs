using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppECG
{
    class CalculMesures
    {
        // TODO : à mettre comme variable dans le form
        static public int debutECG;
        static public int finECG;
        static public int debutPics;
        static public int intervalPic;

        // TODO : à commenter
        /// <summary>
        /// Détecte les pics R sur le signal
        /// </summary>
        /// <param name="ecg"> Signal </param>
        /// <returns> Dictionnaire des pics avec comme clé l'abscisse et comme valeur l'ordonnée </returns>
        static public Dictionary<double, double> DetectPicBIS(double[] ecg)
        {
            Dictionary<double, double> pics = new Dictionary<double, double>();

            int cpt = 0;
            int position = 0;
            debutPics = debutECG + intervalPic;

            do
            {
                int finSeq = debutPics + intervalPic;
                double pic = 0;

                for (int i = debutPics; i < finSeq; i++)
                {
                    if (i >= ecg.Length)
                    { }
                    else
                    {
                        if (ecg[i] > pic)
                        {
                            pic = ecg[i];
                            position = i;
                        }
                    }
                }
                pics.Add(position, pic);
                cpt++;
                debutPics = finSeq;
            }
            while (debutPics < finECG);

            return pics;
        }


        /// <summary>
        /// Calcul de l'écart-type sur l'intervale NN (sdnn)
        /// </summary>
        /// <param name="pics"> Tableau des pics </param>
        /// <returns> Ecart-type </returns>
        static public double SDNN(Dictionary<double, double> pics)
        {
            int longueurPics = pics.Count();
            double somme = 0;
            double moy = 0;

            for (int i = 0; i < longueurPics - 1; i++)
            {
                moy = moy + (pics.ElementAt(i + 1).Key - pics.ElementAt(i).Key);
            }
            moy = moy / longueurPics - 1;

            for (int i = 0; i < longueurPics - 1; i++)
            {
                double ecart = pics.ElementAt(i + 1).Key - pics.ElementAt(i).Key;
                //double moy = (pics[i + 1] + pics[i]) / 2;
                somme += Math.Pow(ecart - moy, 2);
            }

            return Math.Sqrt((1.0 / (longueurPics - 2)) * somme);
        }


        /// <summary>
        /// Calcul de la moyenne quadratique des différences successives de la fréquence cardiaque (rmssd)
        /// </summary>
        /// <param name="pics"> Tableau des pics </param>
        /// <returns> RMSSD </returns>
        static public double RMSSD(Dictionary<double, double> pics)
        {
            int longueurPics = pics.Count();
            double somme = 0;

            for (int i = 0; i < longueurPics - 2; i++)
            {
                double ecart1 = pics.ElementAt(i + 2).Key - pics.ElementAt(i + 1).Key;
                double ecart2 = pics.ElementAt(i + 1).Key - pics.ElementAt(i).Key;
                somme += Math.Pow(ecart1 - ecart2, 2);
            }

            return Math.Sqrt((1.0 / (longueurPics - 2)) * somme);
        }

        /// <summary>
        /// Calcul du coefficient d'asymétrie du signal
        /// </summary>
        /// <param name="ecg"> Tableau des données du signal </param>
        /// <returns> Coefficient d'asymétrie </returns>
        static public double Skew(double[] ecg)
        {
            double longueurECG = finECG - debutECG;
            double skew = 0.0d;
            for (int i = debutECG; i < finECG; i++)
                skew += Math.Pow((ecg[i] - Mean(ecg)) / Sd(ecg), 3);

            return longueurECG / (longueurECG - 1) / (longueurECG - 2) * skew;
        }

        /// <summary>
        /// Calcul de la moyenne des données du signal
        /// </summary>
        /// <param name="ecg"> Tableau des données du signal </param>
        /// <returns> Moyenne </returns>
        static public double Mean(double[] ecg)
        {
            double mean = 0;
            for (int i = debutECG; i < finECG; i++)
                mean += ecg[i];

            return mean / (finECG - debutECG);
        }

        /// <summary>
        /// Calcul de la variance des données du signal
        /// </summary>
        /// <param name="ecg"> Tableau des données du signal </param>
        /// <param name="mean"> Moyenne des données du signal </param>
        /// <returns> Variance </returns>
        static public double Variance(double[] ecg, double mean)
        {
            double variance = 0;

            for (int i = debutECG; i < finECG; i++)
                variance += Math.Pow((ecg[i] - mean), 2);

            int n = finECG - debutECG;
            if (debutECG > 0)
                n -= 1;

            return variance / n;
        }

        /// <summary>
        /// Calcul de l'écart-type des données du signal
        /// </summary>
        /// <param name="ecg"> Tableau des données du signal </param>
        /// <returns> Ecart-type </returns>
        static public double Sd(double[] ecg)
        {
            double mean = Mean(ecg);
            double variance = Variance(ecg, mean);

            return Math.Sqrt(variance);
        }

    }
}
