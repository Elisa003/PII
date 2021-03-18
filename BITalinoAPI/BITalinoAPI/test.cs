using System;
using System.IO;
using System.Text;

class Program
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
    /*
    static void Main(string[] args)
    {
        try
        {
            string[] rawECG = lectureRawECG();
            foreach (string raw in rawECG)
                Console.WriteLine(raw);


            // uncomment this block to search for Bluetooth devices
            /*
            Bitalino.DevInfo[] devs = Bitalino.find();   
            foreach (Bitalino.DevInfo d in devs)
               Console.WriteLine("{0} - {1}", d.macAddr, d.name);
            return;
            

            Console.WriteLine("Connecting to device...");

            Bitalino dev = new Bitalino("20:15:05:29:22:23");  // device MAC address
                                                               //Bitalino dev = new Bitalino("COM7");  // Bluetooth virtual COM port or USB-UART COM port

            Console.WriteLine("Connected to device. Press Enter to exit.");

            string ver = dev.version();    // get device version string
            Console.WriteLine("BITalino version: {0}", ver);

            dev.battery(10);  // set battery threshold (optional)

            dev.start(1000, new int[] { 0, 1, 2, 3, 4, 5 });   // start acquisition of all channels at 1000 Hz

            bool ledState = false;

            Bitalino.Frame[] frames = new Bitalino.Frame[100];
            for (int i = 0; i < frames.Length; i++)
                frames[i] = new Bitalino.Frame();   // must initialize all elements in the array

            do
            {
                ledState = !ledState;   // toggle LED state
                dev.trigger(new bool[] { false, false, ledState, false });

                dev.read(frames); // get 100 frames from device
                Bitalino.Frame f = frames[0];  // get a reference to the first frame of each 100 frames block
                Console.WriteLine("{0} : {1} {2} {3} {4} ; {5} {6} {7} {8} {9} {10}",   // dump the first frame
                                  f.seq,
                                  f.digital[0], f.digital[1], f.digital[2], f.digital[3],
                                  f.analog[0], f.analog[1], f.analog[2], f.analog[3], f.analog[4], f.analog[5]);

            } while (!Console.KeyAvailable); // until a key is pressed

            dev.stop(); // stop acquisition

            dev.Dispose(); // disconnect from device

            
        }
        //catch (Bitalino.Exception e)
        //{
        //    Console.WriteLine("BITalino exception: {0}", e.Message);
        //}
        catch(Exception e)
        {
            Console.WriteLine("ça marche pas" + e);
        }


    }*/
}
