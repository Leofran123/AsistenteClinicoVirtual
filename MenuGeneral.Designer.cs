namespace PracticaFinal.Formularios
{
    partial class MenuGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuGeneral));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mitAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.mitUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mitInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.mitGestionTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPacientesGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.mitAsignarTurno = new System.Windows.Forms.ToolStripMenuItem();
            this.mitAceptarTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mitHC = new System.Windows.Forms.ToolStripMenuItem();
            this.mitCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPedidoInsumo = new System.Windows.Forms.ToolStripMenuItem();
            this.mitInsumoGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.mitSubirMetCompl = new System.Windows.Forms.ToolStripMenuItem();
            this.mitInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.estadosDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edadDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPaciente = new System.Windows.Forms.Panel();
            this.btnCargaPedCompl = new System.Windows.Forms.Button();
            this.btnDevolverPaciente = new System.Windows.Forms.Button();
            this.btnPasarPaciente = new System.Windows.Forms.Button();
            this.btnCerrarPaciente = new System.Windows.Forms.Button();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHistorialClinica = new System.Windows.Forms.Button();
            this.btnAntecendentes = new System.Windows.Forms.Button();
            this.btnCargarFichaMed = new System.Windows.Forms.Button();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlPaciente.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitAdministracion,
            this.mitPaciente,
            this.mitCerrarSesion,
            this.mitPedidos,
            this.mitInformes,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mitAdministracion
            // 
            this.mitAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitUsuarios,
            this.mitInventario,
            this.mitGestionTurnos});
            this.mitAdministracion.Name = "mitAdministracion";
            this.mitAdministracion.Size = new System.Drawing.Size(100, 20);
            this.mitAdministracion.Text = "Administración";
            // 
            // mitUsuarios
            // 
            this.mitUsuarios.Name = "mitUsuarios";
            this.mitUsuarios.Size = new System.Drawing.Size(161, 22);
            this.mitUsuarios.Text = "Usuarios";
            this.mitUsuarios.Click += new System.EventHandler(this.mitUsuarios_Click);
            // 
            // mitInventario
            // 
            this.mitInventario.Name = "mitInventario";
            this.mitInventario.Size = new System.Drawing.Size(161, 22);
            this.mitInventario.Text = "Insumo";
            this.mitInventario.Click += new System.EventHandler(this.mitInventario_Click);
            // 
            // mitGestionTurnos
            // 
            this.mitGestionTurnos.Name = "mitGestionTurnos";
            this.mitGestionTurnos.Size = new System.Drawing.Size(161, 22);
            this.mitGestionTurnos.Text = "Gestionar turnos";
            this.mitGestionTurnos.Click += new System.EventHandler(this.gestionarTurnosToolStripMenuItem_Click);
            // 
            // mitPaciente
            // 
            this.mitPaciente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitPacientesGestion,
            this.mitAsignarTurno,
            this.mitAceptarTurnos,
            this.mitHC});
            this.mitPaciente.Name = "mitPaciente";
            this.mitPaciente.Size = new System.Drawing.Size(69, 20);
            this.mitPaciente.Text = "Pacientes";
            // 
            // mitPacientesGestion
            // 
            this.mitPacientesGestion.Name = "mitPacientesGestion";
            this.mitPacientesGestion.Size = new System.Drawing.Size(172, 22);
            this.mitPacientesGestion.Text = "Gestión";
            this.mitPacientesGestion.Click += new System.EventHandler(this.mitPacientes_Click);
            // 
            // mitAsignarTurno
            // 
            this.mitAsignarTurno.Name = "mitAsignarTurno";
            this.mitAsignarTurno.Size = new System.Drawing.Size(172, 22);
            this.mitAsignarTurno.Text = "Asignar turno";
            this.mitAsignarTurno.Click += new System.EventHandler(this.mitAsignarTurno_Click);
            // 
            // mitAceptarTurnos
            // 
            this.mitAceptarTurnos.Name = "mitAceptarTurnos";
            this.mitAceptarTurnos.Size = new System.Drawing.Size(172, 22);
            this.mitAceptarTurnos.Text = "Aceptar turno";
            this.mitAceptarTurnos.Click += new System.EventHandler(this.mitAceptarTurnos_Click);
            // 
            // mitHC
            // 
            this.mitHC.Name = "mitHC";
            this.mitHC.Size = new System.Drawing.Size(172, 22);
            this.mitHC.Text = "Historiales clínicos";
            this.mitHC.Click += new System.EventHandler(this.historialesClínicosToolStripMenuItem_Click);
            // 
            // mitCerrarSesion
            // 
            this.mitCerrarSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mitCerrarSesion.Name = "mitCerrarSesion";
            this.mitCerrarSesion.Size = new System.Drawing.Size(87, 20);
            this.mitCerrarSesion.Text = "Cerrar sesión";
            this.mitCerrarSesion.Click += new System.EventHandler(this.mitCerrarSesion_Click);
            // 
            // mitPedidos
            // 
            this.mitPedidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitPedidoInsumo,
            this.mitInsumoGestion,
            this.mitSubirMetCompl});
            this.mitPedidos.Name = "mitPedidos";
            this.mitPedidos.Size = new System.Drawing.Size(61, 20);
            this.mitPedidos.Text = "Pedidos";
            // 
            // mitPedidoInsumo
            // 
            this.mitPedidoInsumo.Name = "mitPedidoInsumo";
            this.mitPedidoInsumo.Size = new System.Drawing.Size(219, 22);
            this.mitPedidoInsumo.Text = "Insumo";
            this.mitPedidoInsumo.Click += new System.EventHandler(this.mitPedidoInv_Click);
            // 
            // mitInsumoGestion
            // 
            this.mitInsumoGestion.Name = "mitInsumoGestion";
            this.mitInsumoGestion.Size = new System.Drawing.Size(219, 22);
            this.mitInsumoGestion.Text = "Gestion insumos";
            this.mitInsumoGestion.Click += new System.EventHandler(this.gestionInsumoToolStripMenuItem_Click);
            // 
            // mitSubirMetCompl
            // 
            this.mitSubirMetCompl.Name = "mitSubirMetCompl";
            this.mitSubirMetCompl.Size = new System.Drawing.Size(219, 22);
            this.mitSubirMetCompl.Text = "Subir met. complementario";
            this.mitSubirMetCompl.Click += new System.EventHandler(this.metComplementariosToolStripMenuItem_Click);
            // 
            // mitInformes
            // 
            this.mitInformes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadosDePacientesToolStripMenuItem,
            this.edadDePacientesToolStripMenuItem,
            this.insumosToolStripMenuItem});
            this.mitInformes.Name = "mitInformes";
            this.mitInformes.Size = new System.Drawing.Size(66, 20);
            this.mitInformes.Text = "Informes";
            // 
            // estadosDePacientesToolStripMenuItem
            // 
            this.estadosDePacientesToolStripMenuItem.Name = "estadosDePacientesToolStripMenuItem";
            this.estadosDePacientesToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.estadosDePacientesToolStripMenuItem.Text = "Estados finales de pacientes por fecha";
            this.estadosDePacientesToolStripMenuItem.Click += new System.EventHandler(this.estadosDePacientesToolStripMenuItem_Click);
            // 
            // edadDePacientesToolStripMenuItem
            // 
            this.edadDePacientesToolStripMenuItem.Name = "edadDePacientesToolStripMenuItem";
            this.edadDePacientesToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.edadDePacientesToolStripMenuItem.Text = "Rango de edades de pacientes en los turnos";
            this.edadDePacientesToolStripMenuItem.Click += new System.EventHandler(this.edadDePacientesToolStripMenuItem_Click);
            // 
            // insumosToolStripMenuItem
            // 
            this.insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            this.insumosToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.insumosToolStripMenuItem.Text = "Insumos faltantes por fecha";
            this.insumosToolStripMenuItem.Click += new System.EventHandler(this.insumosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem1.Text = "Contáctanos";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pnlPaciente
            // 
            this.pnlPaciente.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlPaciente.Controls.Add(this.btnCargaPedCompl);
            this.pnlPaciente.Controls.Add(this.btnDevolverPaciente);
            this.pnlPaciente.Controls.Add(this.btnPasarPaciente);
            this.pnlPaciente.Controls.Add(this.btnCerrarPaciente);
            this.pnlPaciente.Controls.Add(this.txtTurno);
            this.pnlPaciente.Controls.Add(this.label1);
            this.pnlPaciente.Controls.Add(this.btnHistorialClinica);
            this.pnlPaciente.Controls.Add(this.btnAntecendentes);
            this.pnlPaciente.Controls.Add(this.btnCargarFichaMed);
            this.pnlPaciente.Controls.Add(this.txtPaciente);
            this.pnlPaciente.Controls.Add(this.label2);
            this.pnlPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaciente.Location = new System.Drawing.Point(0, 24);
            this.pnlPaciente.Name = "pnlPaciente";
            this.pnlPaciente.Size = new System.Drawing.Size(906, 654);
            this.pnlPaciente.TabIndex = 1;
            this.pnlPaciente.Visible = false;
            // 
            // btnCargaPedCompl
            // 
            this.btnCargaPedCompl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCargaPedCompl.Location = new System.Drawing.Point(214, 62);
            this.btnCargaPedCompl.Name = "btnCargaPedCompl";
            this.btnCargaPedCompl.Size = new System.Drawing.Size(160, 28);
            this.btnCargaPedCompl.TabIndex = 10;
            this.btnCargaPedCompl.Text = "Cargar pedido compl.";
            this.btnCargaPedCompl.UseVisualStyleBackColor = true;
            this.btnCargaPedCompl.Click += new System.EventHandler(this.btnCargaPedCompl_Click);
            // 
            // btnDevolverPaciente
            // 
            this.btnDevolverPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnDevolverPaciente.Location = new System.Drawing.Point(724, 20);
            this.btnDevolverPaciente.Name = "btnDevolverPaciente";
            this.btnDevolverPaciente.Size = new System.Drawing.Size(160, 28);
            this.btnDevolverPaciente.TabIndex = 25;
            this.btnDevolverPaciente.Text = "Devolver turno";
            this.btnDevolverPaciente.UseVisualStyleBackColor = true;
            this.btnDevolverPaciente.Click += new System.EventHandler(this.btnDevolverPaciente_Click);
            // 
            // btnPasarPaciente
            // 
            this.btnPasarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnPasarPaciente.Location = new System.Drawing.Point(724, 62);
            this.btnPasarPaciente.Name = "btnPasarPaciente";
            this.btnPasarPaciente.Size = new System.Drawing.Size(160, 28);
            this.btnPasarPaciente.TabIndex = 30;
            this.btnPasarPaciente.Text = "Asignar turno";
            this.btnPasarPaciente.UseVisualStyleBackColor = true;
            this.btnPasarPaciente.Click += new System.EventHandler(this.btnPasarPaciente_Click);
            // 
            // btnCerrarPaciente
            // 
            this.btnCerrarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCerrarPaciente.Location = new System.Drawing.Point(724, 104);
            this.btnCerrarPaciente.Name = "btnCerrarPaciente";
            this.btnCerrarPaciente.Size = new System.Drawing.Size(160, 28);
            this.btnCerrarPaciente.TabIndex = 35;
            this.btnCerrarPaciente.Text = "Cerrar turno";
            this.btnCerrarPaciente.UseVisualStyleBackColor = true;
            this.btnCerrarPaciente.Click += new System.EventHandler(this.btnCerrarPaciente_Click);
            // 
            // txtTurno
            // 
            this.txtTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtTurno.Location = new System.Drawing.Point(458, 20);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(121, 23);
            this.txtTurno.TabIndex = 3;
            this.txtTurno.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(405, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Turno";
            // 
            // btnHistorialClinica
            // 
            this.btnHistorialClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnHistorialClinica.Location = new System.Drawing.Point(214, 104);
            this.btnHistorialClinica.Name = "btnHistorialClinica";
            this.btnHistorialClinica.Size = new System.Drawing.Size(160, 28);
            this.btnHistorialClinica.TabIndex = 20;
            this.btnHistorialClinica.Text = "Ver historial clínico";
            this.btnHistorialClinica.UseVisualStyleBackColor = true;
            this.btnHistorialClinica.Click += new System.EventHandler(this.btnHistorialClinica_Click);
            // 
            // btnAntecendentes
            // 
            this.btnAntecendentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAntecendentes.Location = new System.Drawing.Point(37, 104);
            this.btnAntecendentes.Name = "btnAntecendentes";
            this.btnAntecendentes.Size = new System.Drawing.Size(160, 28);
            this.btnAntecendentes.TabIndex = 15;
            this.btnAntecendentes.Text = "Antecedentes";
            this.btnAntecendentes.UseVisualStyleBackColor = true;
            this.btnAntecendentes.Click += new System.EventHandler(this.btnAntecendentes_Click);
            // 
            // btnCargarFichaMed
            // 
            this.btnCargarFichaMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCargarFichaMed.Location = new System.Drawing.Point(37, 62);
            this.btnCargarFichaMed.Name = "btnCargarFichaMed";
            this.btnCargarFichaMed.Size = new System.Drawing.Size(160, 28);
            this.btnCargarFichaMed.TabIndex = 5;
            this.btnCargarFichaMed.Text = "Cargar ficha médica";
            this.btnCargarFichaMed.UseVisualStyleBackColor = true;
            this.btnCargarFichaMed.Click += new System.EventHandler(this.btnCargarFichaMed_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtPaciente.Location = new System.Drawing.Point(89, 20);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(298, 23);
            this.txtPaciente.TabIndex = 0;
            this.txtPaciente.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paciente";
            // 
            // MenuGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 678);
            this.Controls.Add(this.pnlPaciente);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asistente Clínico Virtual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuGeneral_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPaciente.ResumeLayout(false);
            this.pnlPaciente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mitAdministracion;
        private System.Windows.Forms.ToolStripMenuItem mitUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mitPaciente;
        private System.Windows.Forms.ToolStripMenuItem mitPacientesGestion;
        private System.Windows.Forms.ToolStripMenuItem mitAsignarTurno;
        private System.Windows.Forms.ToolStripMenuItem mitAceptarTurnos;
        private System.Windows.Forms.Panel pnlPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHistorialClinica;
        private System.Windows.Forms.Button btnAntecendentes;
        private System.Windows.Forms.Button btnCargarFichaMed;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mitCerrarSesion;
        private System.Windows.Forms.Button btnPasarPaciente;
        private System.Windows.Forms.Button btnCerrarPaciente;
        private System.Windows.Forms.Button btnDevolverPaciente;
        private System.Windows.Forms.ToolStripMenuItem mitInventario;
        private System.Windows.Forms.ToolStripMenuItem mitGestionTurnos;
        private System.Windows.Forms.ToolStripMenuItem mitPedidos;
        private System.Windows.Forms.ToolStripMenuItem mitPedidoInsumo;
        private System.Windows.Forms.ToolStripMenuItem mitInformes;
        private System.Windows.Forms.ToolStripMenuItem estadosDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitHC;
        private System.Windows.Forms.Button btnCargaPedCompl;
        private System.Windows.Forms.ToolStripMenuItem mitSubirMetCompl;
        private System.Windows.Forms.ToolStripMenuItem edadDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mitInsumoGestion;
    }
}