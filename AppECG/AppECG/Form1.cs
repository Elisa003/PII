using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
//using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace AppECG
{
    public partial class Form1 : Form
    {
        string fichierTxt = string.Empty;
        double[] rawECG;
        double[] signal_mV;
        double[] denoisingECG;
        Dictionary<double, double> pics = new Dictionary<double, double>();

        static public double minSelected;
        static public double maxSelected;

        double sdnn;
        double rmssd;
        double skew;


        public Form1()
        {
            InitializeComponent();
        }
        private void btnSignalNonStresse_Click(object sender, EventArgs e)
        {
            fichierTxt = "signals_math";
            CalculMesures.debutECG = 3000;
            CalculMesures.finECG = 7500;
            CalculMesures.intervalPic = 100;
            TraitementDonnees.longueurECG = 8000;

            rawECG = TraitementDonnees.lectureRawECG(fichierTxt);
            TraitementSignal(rawECG);
            rbSignalBrut.Checked = true;
            AffichageChartControl(rawECG);
        }
        private void btnSignalStresse_Click(object sender, EventArgs e)
        {
            fichierTxt = "signals_leo"; // A CHANGER
            CalculMesures.debutECG = 58110;
            CalculMesures.finECG = 61600;
            CalculMesures.intervalPic = 75;
            TraitementDonnees.longueurECG = 62100;

            rawECG = TraitementDonnees.lectureRawECG(fichierTxt);
            TraitementSignal(rawECG);
            rbSignalBrut.Checked = true;
            AffichageChartControl(rawECG);
        }

        public void TraitementSignal(double[] ecg)
        {
            if (ecg != null)
            {
                signal_mV = TraitementDonnees.TransferFunction(ecg);
                denoisingECG = TraitementDonnees.dwt(signal_mV);
                pics = CalculMesures.DetectPicBIS(signal_mV);

                sdnn = Math.Round(CalculMesures.SDNN(pics), 3);
                rmssd = Math.Round(CalculMesures.RMSSD(pics), 3);
                skew = Math.Round(CalculMesures.Skew(signal_mV), 3);

                // SDNN
                if (VerifDouble(sdnn))
                    tbSDNN.Text = sdnn.ToString();
                else
                {
                    tbSDNN.Text = "Non calculé";
                    lbSDNNcorrect.Text = "Le signal donné ne permet pas un calcul optimal";
                    lbSDNNcorrect.ForeColor = Color.Black;
                }

                // RMSSD
                if (VerifDouble(rmssd))
                    tbRMSSD.Text = rmssd.ToString();
                else
                {
                    tbRMSSD.Text = "Non calculé";
                    lbRMSSDcorrect.Text = "Le signal donné ne permet pas un calcul optimal";
                    lbRMSSDcorrect.ForeColor = Color.Black;
                }

                // SKEW
                if (VerifDouble(skew))
                    tbSkew.Text = skew.ToString();
                else
                {
                    tbSkew.Text = "Non calculé";
                    lbSkewCorrect.Text = "Le signal donné ne permet pas un calcul optimal";
                    lbSDNNcorrect.ForeColor = Color.Black;
                }
                ECGstresseOUnon();
            }
            else
            {
                MessageBox.Show("Erreur");
            }

        }

        public bool VerifDouble(double var)
        {
            if (double.IsNaN(var) || double.IsInfinity(var))
                return false;
            else return true;
        }

        public void AffichageChartControl(double[] signal)
        {
            if (signal != null)
            {
                chartControl1.Series.Clear();
                chartControl1.SeriesDataMember = string.Empty;
                chartControl1.SeriesTemplate.ArgumentDataMember = string.Empty;

                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series("ECG", ViewType.Line);

                for (int i = CalculMesures.debutECG; i < CalculMesures.finECG; i++)
                {
                    series1.Points.Add(new SeriesPoint(i, signal[i]));
                }
                chartControl1.Series.Add(series1);
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                // Enable the diagram's scrolling.
                diagram.EnableAxisXScrolling = true;
                diagram.EnableAxisYScrolling = true;
                diagram.EnableAxisXZooming = true;
                diagram.EnableAxisYZooming = false;

                diagram.AxisX.WholeRange.Auto = true;
                diagram.AxisY.WholeRange.Auto = true;

                diagram.AxisX.VisualRange.AutoSideMargins = false;

                diagram.AxisX.VisualRange.Auto = false;
                diagram.AxisY.WholeRange.Auto = false;
            }
            else
            {
                MessageBox.Show("Erreur");
            }

        }

        public void ECGstresseOUnon()
        {
            // SDNN
            if (sdnn > 20 ) // ECG normal 
            {
                lbSDNNcorrect.Text = "ECG normal car > 20";
                lbSDNNcorrect.ForeColor = Color.Green;
            }
            else // ECG stressé 
            {
                lbSDNNcorrect.Text = "ECG stressé car < 20";
                lbSDNNcorrect.ForeColor = Color.Orange;
            }

            //RMSSD
            if (rmssd > 30) // ECG normal 
            {
                lbRMSSDcorrect.Text = "ECG normal car > 30";
                lbRMSSDcorrect.ForeColor = Color.Green;
            }
            else // ECG stressé 
            {
                lbRMSSDcorrect.Text = "ECG stressé car < 30";
                lbRMSSDcorrect.ForeColor = Color.Orange;
            }

            //SKEW
            if (skew < 2.5) // ECG normal
            {
                lbSkewCorrect.Text = "ECG normal car < 2.5";
                lbSkewCorrect.ForeColor = Color.Green;
            }
            else // ECG stressé
            {
                lbSkewCorrect.Text = "ECG stressé car > 2.5";
                lbSkewCorrect.ForeColor = Color.Orange;
            }
        }


        private void btnSelectionSegment_Click(object sender, EventArgs e)
        {
            if (rawECG != null)
            {
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                tbMinSelected.Text = Math.Round((double)diagram.AxisX.VisualRange.MinValue,3).ToString();
                minSelected = double.Parse(tbMinSelected.Text);

                tbMaxSelected.Text = Math.Round((double)diagram.AxisX.VisualRange.MaxValue,3).ToString();
                maxSelected = double.Parse(tbMaxSelected.Text);

                CalculMesures.debutECG = (int)minSelected;
                CalculMesures.finECG = (int)maxSelected;

                TraitementSignal(rawECG);
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }


        private void rbSignalBrut_CheckedChanged(object sender, EventArgs e)
        {
            if (rawECG != null)
            {
                if (rbSignalBrut.Checked)
                    AffichageChartControl(rawECG);
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }


        private void rbSignalEtalonne_CheckedChanged(object sender, EventArgs e)
        {
            if (rawECG != null)
            {
                if (rbSignalEtalonne.Checked)
                    AffichageChartControl(signal_mV);
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private void btnCommencerAcquisition_Click(object sender, EventArgs e)
        {
            Form2 FormAcquisition = new Form2();
            FormAcquisition.Show();
            btnAffichageAcquisition.Visible = true;
        }

        private void btnAffichageAcquisition_Click(object sender, EventArgs e)
        {
            rawECG = Form2.ecgBitalino;
            AffichageChartControl(rawECG);
            btnAffichageAcquisition.ForeColor = Color.Black;
        }
    }
}
