namespace PracticaFinal.Formularios
{
    partial class AntecedentesABM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AntecedentesABM));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAntPatologicos = new System.Windows.Forms.TextBox();
            this.txtAntQuirurgicos = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtAntAlergicos = new System.Windows.Forms.TextBox();
            this.txtAntToxicos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(168, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Antecedentes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Antecedentes patológicos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(18, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Antecedentes quirúrgicos";
            // 
            // txtAntPatologicos
            // 
            this.txtAntPatologicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAntPatologicos.Location = new System.Drawing.Point(21, 72);
            this.txtAntPatologicos.MaxLength = 300;
            this.txtAntPatologicos.Multiline = true;
            this.txtAntPatologicos.Name = "txtAntPatologicos";
            this.txtAntPatologicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntPatologicos.Size = new System.Drawing.Size(674, 85);
            this.txtAntPatologicos.TabIndex = 0;
            // 
            // txtAntQuirurgicos
            // 
            this.txtAntQuirurgicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAntQuirurgicos.Location = new System.Drawing.Point(21, 206);
            this.txtAntQuirurgicos.MaxLength = 300;
            this.txtAntQuirurgicos.Multiline = true;
            this.txtAntQuirurgicos.Name = "txtAntQuirurgicos";
            this.txtAntQuirurgicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntQuirurgicos.Size = new System.Drawing.Size(674, 85);
            this.txtAntQuirurgicos.TabIndex = 5;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.btnGrabar.Location = new System.Drawing.Point(568, 583);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(127, 34);
            this.btnGrabar.TabIndex = 25;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(21, 583);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(127, 34);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtAntAlergicos
            // 
            this.txtAntAlergicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAntAlergicos.Location = new System.Drawing.Point(21, 474);
            this.txtAntAlergicos.MaxLength = 300;
            this.txtAntAlergicos.Multiline = true;
            this.txtAntAlergicos.Name = "txtAntAlergicos";
            this.txtAntAlergicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntAlergicos.Size = new System.Drawing.Size(674, 85);
            this.txtAntAlergicos.TabIndex = 15;
            // 
            // txtAntToxicos
            // 
            this.txtAntToxicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAntToxicos.Location = new System.Drawing.Point(21, 338);
            this.txtAntToxicos.MaxLength = 300;
            this.txtAntToxicos.Multiline = true;
            this.txtAntToxicos.Name = "txtAntToxicos";
            this.txtAntToxicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntToxicos.Size = new System.Drawing.Size(674, 85);
            this.txtAntToxicos.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 93;
            this.label1.Text = "Antecedentes alérgicos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 91;
            this.label3.Text = "Antecedentes tóxicos";
            // 
            // AntecedentesABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 635);
            this.Controls.Add(this.txtAntAlergicos);
            this.Controls.Add(this.txtAntToxicos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtAntQuirurgicos);
            this.Controls.Add(this.txtAntPatologicos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AntecedentesABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Antecedentes";
            this.Load += new System.EventHandler(this.FichaMedABM_Load);
            this.Shown += new System.EventHandler(this.AntecedentesABM_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAntPatologicos;
        private System.Windows.Forms.TextBox txtAntQuirurgicos;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtAntAlergicos;
        private System.Windows.Forms.TextBox txtAntToxicos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}