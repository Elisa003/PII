namespace AppECG
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.tbSDNN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRMSSD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSkew = new System.Windows.Forms.TextBox();
            this.numericChartRangeControlClient1 = new DevExpress.XtraEditors.NumericChartRangeControlClient();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMinSelected = new System.Windows.Forms.TextBox();
            this.btnSelectionSegment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMaxSelected = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbSignalBrut = new System.Windows.Forms.RadioButton();
            this.rbSignalEtalonne = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCommencerAcquisition = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSignalNonStresse = new System.Windows.Forms.Button();
            this.btnSignalStresse = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbSDNNcorrect = new System.Windows.Forms.Label();
            this.lbSkewCorrect = new System.Windows.Forms.Label();
            this.lbRMSSDcorrect = new System.Windows.Forms.Label();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.btnAffichageAcquisition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "SDNN (écart-type des intervales RR) :";
            // 
            // tbSDNN
            // 
            this.tbSDNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSDNN.Location = new System.Drawing.Point(622, 503);
            this.tbSDNN.Name = "tbSDNN";
            this.tbSDNN.Size = new System.Drawing.Size(123, 23);
            this.tbSDNN.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(571, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "RMSSD (moyenne quadratique des différences successives de la fréquence cardiaque)" +
    " :";
            // 
            // tbRMSSD
            // 
            this.tbRMSSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRMSSD.Location = new System.Drawing.Point(622, 532);
            this.tbRMSSD.Name = "tbRMSSD";
            this.tbRMSSD.Size = new System.Drawing.Size(123, 23);
            this.tbRMSSD.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 563);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(561, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Skewness (coefficient d\'asymétrie du signal) :";
            // 
            // tbSkew
            // 
            this.tbSkew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSkew.Location = new System.Drawing.Point(622, 560);
            this.tbSkew.Name = "tbSkew";
            this.tbSkew.Size = new System.Drawing.Size(123, 23);
            this.tbSkew.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Segment sélectionné :";
            // 
            // tbMinSelected
            // 
            this.tbMinSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinSelected.Location = new System.Drawing.Point(219, 421);
            this.tbMinSelected.Name = "tbMinSelected";
            this.tbMinSelected.Size = new System.Drawing.Size(83, 23);
            this.tbMinSelected.TabIndex = 14;
            // 
            // btnSelectionSegment
            // 
            this.btnSelectionSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectionSegment.Location = new System.Drawing.Point(581, 379);
            this.btnSelectionSegment.Name = "btnSelectionSegment";
            this.btnSelectionSegment.Size = new System.Drawing.Size(185, 26);
            this.btnSelectionSegment.TabIndex = 15;
            this.btnSelectionSegment.Text = "Selectionner ce segment";
            this.btnSelectionSegment.UseVisualStyleBackColor = true;
            this.btnSelectionSegment.Click += new System.EventHandler(this.btnSelectionSegment_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(551, 37);
            this.label5.TabIndex = 18;
            this.label5.Text = "Utilisez la molette de la souris pour zoomer sur le signal et la barre de défilem" +
    "ent horizontale pour sélectionner le segment qui convient le mieux.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(183, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(315, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "max";
            // 
            // tbMaxSelected
            // 
            this.tbMaxSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaxSelected.Location = new System.Drawing.Point(354, 421);
            this.tbMaxSelected.Name = "tbMaxSelected";
            this.tbMaxSelected.Size = new System.Drawing.Size(100, 23);
            this.tbMaxSelected.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(784, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Vous souhaitez afficher :";
            // 
            // rbSignalBrut
            // 
            this.rbSignalBrut.AutoSize = true;
            this.rbSignalBrut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSignalBrut.Location = new System.Drawing.Point(800, 323);
            this.rbSignalBrut.Name = "rbSignalBrut";
            this.rbSignalBrut.Size = new System.Drawing.Size(107, 21);
            this.rbSignalBrut.TabIndex = 25;
            this.rbSignalBrut.TabStop = true;
            this.rbSignalBrut.Text = "le signal brut";
            this.rbSignalBrut.UseVisualStyleBackColor = true;
            this.rbSignalBrut.CheckedChanged += new System.EventHandler(this.rbSignalBrut_CheckedChanged);
            // 
            // rbSignalEtalonne
            // 
            this.rbSignalEtalonne.AutoSize = true;
            this.rbSignalEtalonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSignalEtalonne.Location = new System.Drawing.Point(800, 346);
            this.rbSignalEtalonne.Name = "rbSignalEtalonne";
            this.rbSignalEtalonne.Size = new System.Drawing.Size(137, 21);
            this.rbSignalEtalonne.TabIndex = 26;
            this.rbSignalEtalonne.TabStop = true;
            this.rbSignalEtalonne.Text = "le signal étalonné";
            this.rbSignalEtalonne.UseVisualStyleBackColor = true;
            this.rbSignalEtalonne.CheckedChanged += new System.EventHandler(this.rbSignalEtalonne_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 481);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(350, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "A partir du signal, différentes mesures sont calculées :";
            // 
            // btnCommencerAcquisition
            // 
            this.btnCommencerAcquisition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommencerAcquisition.Location = new System.Drawing.Point(787, 119);
            this.btnCommencerAcquisition.Name = "btnCommencerAcquisition";
            this.btnCommencerAcquisition.Size = new System.Drawing.Size(340, 32);
            this.btnCommencerAcquisition.TabIndex = 28;
            this.btnCommencerAcquisition.Text = "Commencer l\'acquisition";
            this.btnCommencerAcquisition.UseVisualStyleBackColor = true;
            this.btnCommencerAcquisition.Click += new System.EventHandler(this.btnCommencerAcquisition_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(477, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 31);
            this.label10.TabIndex = 29;
            this.label10.Text = "DON\'T STRESS";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1103, 58);
            this.label11.TabIndex = 30;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // btnSignalNonStresse
            // 
            this.btnSignalNonStresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignalNonStresse.Location = new System.Drawing.Point(787, 219);
            this.btnSignalNonStresse.Name = "btnSignalNonStresse";
            this.btnSignalNonStresse.Size = new System.Drawing.Size(340, 32);
            this.btnSignalNonStresse.TabIndex = 31;
            this.btnSignalNonStresse.Text = "Utiliser un signal pré-acquis non stressé";
            this.btnSignalNonStresse.UseVisualStyleBackColor = true;
            this.btnSignalNonStresse.Click += new System.EventHandler(this.btnSignalNonStresse_Click);
            // 
            // btnSignalStresse
            // 
            this.btnSignalStresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignalStresse.Location = new System.Drawing.Point(787, 257);
            this.btnSignalStresse.Name = "btnSignalStresse";
            this.btnSignalStresse.Size = new System.Drawing.Size(340, 32);
            this.btnSignalStresse.TabIndex = 32;
            this.btnSignalStresse.Text = "Utiliser un signal pré-acquis stressé";
            this.btnSignalStresse.UseVisualStyleBackColor = true;
            this.btnSignalStresse.Click += new System.EventHandler(this.btnSignalStresse_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(897, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 18);
            this.label12.TabIndex = 33;
            this.label12.Text = "Vous pouvez :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(932, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 17);
            this.label13.TabIndex = 34;
            this.label13.Text = "ou";
            // 
            // lbSDNNcorrect
            // 
            this.lbSDNNcorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSDNNcorrect.Location = new System.Drawing.Point(751, 506);
            this.lbSDNNcorrect.Name = "lbSDNNcorrect";
            this.lbSDNNcorrect.Size = new System.Drawing.Size(263, 18);
            this.lbSDNNcorrect.TabIndex = 35;
            // 
            // lbSkewCorrect
            // 
            this.lbSkewCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSkewCorrect.Location = new System.Drawing.Point(751, 563);
            this.lbSkewCorrect.Name = "lbSkewCorrect";
            this.lbSkewCorrect.Size = new System.Drawing.Size(263, 18);
            this.lbSkewCorrect.TabIndex = 36;
            // 
            // lbRMSSDcorrect
            // 
            this.lbRMSSDcorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRMSSDcorrect.Location = new System.Drawing.Point(751, 535);
            this.lbRMSSDcorrect.Name = "lbRMSSDcorrect";
            this.lbRMSSDcorrect.Size = new System.Drawing.Size(263, 18);
            this.lbRMSSDcorrect.TabIndex = 37;
            // 
            // chartControl1
            // 
            this.chartControl1.Location = new System.Drawing.Point(27, 102);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(739, 265);
            this.chartControl1.TabIndex = 38;
            // 
            // btnAffichageAcquisition
            // 
            this.btnAffichageAcquisition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAffichageAcquisition.ForeColor = System.Drawing.Color.Green;
            this.btnAffichageAcquisition.Location = new System.Drawing.Point(787, 157);
            this.btnAffichageAcquisition.Name = "btnAffichageAcquisition";
            this.btnAffichageAcquisition.Size = new System.Drawing.Size(340, 32);
            this.btnAffichageAcquisition.TabIndex = 39;
            this.btnAffichageAcquisition.Text = "Afficher le signal acquis";
            this.btnAffichageAcquisition.UseVisualStyleBackColor = true;
            this.btnAffichageAcquisition.Visible = false;
            this.btnAffichageAcquisition.Click += new System.EventHandler(this.btnAffichageAcquisition_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 595);
            this.Controls.Add(this.btnAffichageAcquisition);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.lbRMSSDcorrect);
            this.Controls.Add(this.lbSkewCorrect);
            this.Controls.Add(this.lbSDNNcorrect);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSignalStresse);
            this.Controls.Add(this.btnSignalNonStresse);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCommencerAcquisition);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rbSignalEtalonne);
            this.Controls.Add(this.rbSignalBrut);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMaxSelected);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelectionSegment);
            this.Controls.Add(this.tbMinSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSkew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRMSSD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSDNN);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSDNN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRMSSD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSkew;
        private DevExpress.XtraEditors.NumericChartRangeControlClient numericChartRangeControlClient1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMinSelected;
        private System.Windows.Forms.Button btnSelectionSegment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMaxSelected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbSignalBrut;
        private System.Windows.Forms.RadioButton rbSignalEtalonne;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCommencerAcquisition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSignalNonStresse;
        private System.Windows.Forms.Button btnSignalStresse;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbSDNNcorrect;
        private System.Windows.Forms.Label lbSkewCorrect;
        private System.Windows.Forms.Label lbRMSSDcorrect;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Button btnAffichageAcquisition;
    }
}

