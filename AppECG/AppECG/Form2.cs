using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitalinoAcquisition;

namespace AppECG
{
    public partial class Form2 : Form
    {
        public static double[] ecgBitalino;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnDebutAcquisition_Click(object sender, EventArgs e)
        {
            int duree = int.Parse(tbDuree.Text);
            if (duree < 30)
            {
                MessageBox.Show("La durée doit être supérieure à 30 secondes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ecgBitalino = new double[duree*7];

                MessageBox.Show("Connexion à l'appareil\nL'opération peut prendre quelques instants... ", "Acquisition en cours", MessageBoxButtons.OK);
                BitalinoAcquisition.Program.TestFonction(duree*7);
                ecgBitalino = BitalinoAcquisition.Program.ecg;

                if (ecgBitalino != null)
                {
                    CalculMesures.debutECG = 0;
                    CalculMesures.finECG = ecgBitalino.Length;
                    CalculMesures.debutPics = 10;
                    CalculMesures.intervalPic = 50;
                    TraitementDonnees.longueurECG = ecgBitalino.Length;
                    MessageBox.Show("Opération terminée !\nVous pouvez afficher le signal acquis", "Acquisition terminée", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez recommencer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
