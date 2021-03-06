using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitalinoAcquisition
{
    public class Program
    {
        public static double[] ecg;
        
        static void Main(string[] args)
        {

        }
        
        public static void TestFonction(int duree)
        {
            ecg = new double[duree];
            try
            {
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
                int cpt = 0;
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
                    ecg[cpt] = f.analog[2];
                    cpt++;

                } while (cpt < ecg.Length) ;

                dev.stop(); // stop acquisition

                dev.Dispose(); // disconnect from device


            }
            catch (Bitalino.Exception e)
            {
                Console.WriteLine("BITalino exception: {0}", e.Message);
            }
        }

    }
}
