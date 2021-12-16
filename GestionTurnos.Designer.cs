namespace PracticaFinal.Formularios
{
    partial class GestionTurnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionTurnos));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAsignarMedico = new System.Windows.Forms.Button();
            this.btnCambiarPrioridad = new System.Windows.Forms.Button();
            this.btnSacarMedico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AllowUserToResizeColumns = false;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(2, 56);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersVisible = false;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(635, 332);
            this.Grid.TabIndex = 10;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnVolver.Location = new System.Drawing.Point(12, 408);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(77, 28);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCancelarTurno.Location = new System.Drawing.Point(512, 408);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(113, 28);
            this.btnCancelarTurno.TabIndex = 35;
            this.btnCancelarTurno.Text = "Cancelar turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = true;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtBuscar.Location = new System.Drawing.Point(177, 17);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(212, 23);
            this.txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnBuscar.Location = new System.Drawing.Point(397, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 25);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAsignarMedico
            // 
            this.btnAsignarMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAsignarMedico.Location = new System.Drawing.Point(101, 408);
            this.btnAsignarMedico.Name = "btnAsignarMedico";
            this.btnAsignarMedico.Size = new System.Drawing.Size(124, 28);
            this.btnAsignarMedico.TabIndex = 20;
            this.btnAsignarMedico.Text = "Asignar médico";
            this.btnAsignarMedico.UseVisualStyleBackColor = true;
            this.btnAsignarMedico.Click += new System.EventHandler(this.btnAsignarMedico_Click);
            // 
            // btnCambiarPrioridad
            // 
            this.btnCambiarPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCambiarPrioridad.Location = new System.Drawing.Point(361, 408);
            this.btnCambiarPrioridad.Name = "btnCambiarPrioridad";
            this.btnCambiarPrioridad.Size = new System.Drawing.Size(139, 28);
            this.btnCambiarPrioridad.TabIndex = 30;
            this.btnCambiarPrioridad.Text = "Cambiar prioridad";
            this.btnCambiarPrioridad.UseVisualStyleBackColor = true;
            this.btnCambiarPrioridad.Click += new System.EventHandler(this.btnCambiarPrioridad_Click);
            // 
            // btnSacarMedico
            // 
            this.btnSacarMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSacarMedico.Location = new System.Drawing.Point(237, 408);
            this.btnSacarMedico.Name = "btnSacarMedico";
            this.btnSacarMedico.Size = new System.Drawing.Size(112, 28);
            this.btnSacarMedico.TabIndex = 25;
            this.btnSacarMedico.Text = "Anular médico";
            this.btnSacarMedico.UseVisualStyleBackColor = true;
            this.btnSacarMedico.Click += new System.EventHandler(this.btnSacarMedico_Click);
            // 
            // GestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.btnSacarMedico);
            this.Controls.Add(this.btnCambiarPrioridad);
            this.Controls.Add(this.btnAsignarMedico);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnCancelarTurno);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.Grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GestionTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionar turnos";
            this.Load += new System.EventHandler(this.GrillaSeleccionar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAsignarMedico;
        private System.Windows.Forms.Button btnCambiarPrioridad;
        private System.Windows.Forms.Button btnSacarMedico;
    }
}