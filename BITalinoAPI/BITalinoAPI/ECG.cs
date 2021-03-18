using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BITalinoAPI
{
    class ECG
    {
        static public string[] lectureRawECG()
        {
            int longueurECG = 1000;
            string[] rawECG = new string[longueurECG];
            int cpt = 0;

            string fichierSource = "../../../signals_math.txt";

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            StreamReader streamReader = new StreamReader(fichierSource, encoding);
            string reader = streamReader.ReadLine();

            while (reader != null)
            {
                if (!reader.Contains("#"))
                {

                    string letrucquejerécupère = reader.Substring(14, 3);
                    rawECG[cpt] = letrucquejerécupère;
                    cpt++;
                }

            }
            streamReader.Close();

            return rawECG;

        }

        static void Main(string[] args)
        {
            try
            {
                string[] rawECG = lectureRawECG();
                foreach (string raw in rawECG)
                    Console.WriteLine(raw);
            }
            catch(Exception e)
            {
                Console.WriteLine("ça marche pas " + e);
            }
        }


    }
}
