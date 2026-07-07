namespace InstaColor.Pantallas
{
    partial class Camara
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_dispos = new System.Windows.Forms.ComboBox();
            this.bn_activar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bn_guardar = new System.Windows.Forms.Button();
            this.pb_foto = new System.Windows.Forms.PictureBox();
            this.bn_capturar = new System.Windows.Forms.Button();
            this.bn_detectar = new System.Windows.Forms.Button();
            this.pb_webcam = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_contador = new System.Windows.Forms.Label();
            this.bn_aplicar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_filtros = new System.Windows.Forms.ComboBox();
            this.inicioUC1 = new InstaColor.Pantallas.InicioUC();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_foto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_webcam)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_actualizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cb_dispos);
            this.panel1.Controls.Add(this.bn_activar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 70);
            this.panel1.TabIndex = 1;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.Location = new System.Drawing.Point(618, 17);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(126, 34);
            this.btn_actualizar.TabIndex = 5;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dispositivos:";
            // 
            // cb_dispos
            // 
            this.cb_dispos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dispos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_dispos.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dispos.FormattingEnabled = true;
            this.cb_dispos.Location = new System.Drawing.Point(277, 17);
            this.cb_dispos.Margin = new System.Windows.Forms.Padding(6);
            this.cb_dispos.Name = "cb_dispos";
            this.cb_dispos.Size = new System.Drawing.Size(319, 34);
            this.cb_dispos.TabIndex = 0;
            this.cb_dispos.SelectedIndexChanged += new System.EventHandler(this.cb_dispos_SelectedIndexChanged);
            // 
            // bn_activar
            // 
            this.bn_activar.BackColor = System.Drawing.Color.Gainsboro;
            this.bn_activar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_activar.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_activar.Location = new System.Drawing.Point(753, 17);
            this.bn_activar.Margin = new System.Windows.Forms.Padding(6);
            this.bn_activar.Name = "bn_activar";
            this.bn_activar.Size = new System.Drawing.Size(126, 34);
            this.bn_activar.TabIndex = 0;
            this.bn_activar.Text = "Activar";
            this.bn_activar.UseVisualStyleBackColor = false;
            this.bn_activar.Click += new System.EventHandler(this.bn_activar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bn_guardar);
            this.panel3.Controls.Add(this.pb_foto);
            this.panel3.Controls.Add(this.bn_capturar);
            this.panel3.Controls.Add(this.bn_detectar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(700, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 463);
            this.panel3.TabIndex = 3;
            // 
            // bn_guardar
            // 
            this.bn_guardar.BackColor = System.Drawing.Color.RosyBrown;
            this.bn_guardar.Enabled = false;
            this.bn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_guardar.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_guardar.Location = new System.Drawing.Point(37, 207);
            this.bn_guardar.Margin = new System.Windows.Forms.Padding(6);
            this.bn_guardar.Name = "bn_guardar";
            this.bn_guardar.Size = new System.Drawing.Size(170, 50);
            this.bn_guardar.TabIndex = 4;
            this.bn_guardar.Text = "Guardar Foto";
            this.bn_guardar.UseVisualStyleBackColor = false;
            this.bn_guardar.Click += new System.EventHandler(this.bn_guardar_Click);
            // 
            // pb_foto
            // 
            this.pb_foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_foto.Location = new System.Drawing.Point(20, 271);
            this.pb_foto.Margin = new System.Windows.Forms.Padding(6);
            this.pb_foto.Name = "pb_foto";
            this.pb_foto.Size = new System.Drawing.Size(200, 150);
            this.pb_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_foto.TabIndex = 3;
            this.pb_foto.TabStop = false;
            // 
            // bn_capturar
            // 
            this.bn_capturar.BackColor = System.Drawing.Color.Gainsboro;
            this.bn_capturar.Enabled = false;
            this.bn_capturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_capturar.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_capturar.Location = new System.Drawing.Point(37, 145);
            this.bn_capturar.Margin = new System.Windows.Forms.Padding(6);
            this.bn_capturar.Name = "bn_capturar";
            this.bn_capturar.Size = new System.Drawing.Size(170, 50);
            this.bn_capturar.TabIndex = 2;
            this.bn_capturar.Text = "Capturar Foto";
            this.bn_capturar.UseVisualStyleBackColor = false;
            this.bn_capturar.Click += new System.EventHandler(this.bn_capturar_Click);
            // 
            // bn_detectar
            // 
            this.bn_detectar.BackColor = System.Drawing.Color.Gainsboro;
            this.bn_detectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_detectar.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_detectar.Location = new System.Drawing.Point(20, 83);
            this.bn_detectar.Margin = new System.Windows.Forms.Padding(6);
            this.bn_detectar.Name = "bn_detectar";
            this.bn_detectar.Size = new System.Drawing.Size(200, 50);
            this.bn_detectar.TabIndex = 1;
            this.bn_detectar.Text = "Detectar Rostros";
            this.bn_detectar.UseVisualStyleBackColor = false;
            this.bn_detectar.Click += new System.EventHandler(this.bn_detectar_Click);
            // 
            // pb_webcam
            // 
            this.pb_webcam.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_webcam.Location = new System.Drawing.Point(77, 9);
            this.pb_webcam.Margin = new System.Windows.Forms.Padding(6);
            this.pb_webcam.Name = "pb_webcam";
            this.pb_webcam.Size = new System.Drawing.Size(550, 350);
            this.pb_webcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_webcam.TabIndex = 0;
            this.pb_webcam.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_contador);
            this.panel2.Controls.Add(this.bn_aplicar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cb_filtros);
            this.panel2.Controls.Add(this.pb_webcam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 463);
            this.panel2.TabIndex = 2;
            // 
            // lb_contador
            // 
            this.lb_contador.AutoSize = true;
            this.lb_contador.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_contador.Location = new System.Drawing.Point(367, 365);
            this.lb_contador.Name = "lb_contador";
            this.lb_contador.Size = new System.Drawing.Size(102, 23);
            this.lb_contador.TabIndex = 4;
            this.lb_contador.Text = "contador";
            this.lb_contador.Visible = false;
            // 
            // bn_aplicar
            // 
            this.bn_aplicar.BackColor = System.Drawing.Color.Salmon;
            this.bn_aplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_aplicar.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_aplicar.Location = new System.Drawing.Point(524, 414);
            this.bn_aplicar.Name = "bn_aplicar";
            this.bn_aplicar.Size = new System.Drawing.Size(103, 34);
            this.bn_aplicar.TabIndex = 3;
            this.bn_aplicar.Text = "Aplicar";
            this.bn_aplicar.UseVisualStyleBackColor = false;
            this.bn_aplicar.Click += new System.EventHandler(this.bn_aplicar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtros:";
            // 
            // cb_filtros
            // 
            this.cb_filtros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filtros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_filtros.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_filtros.FormattingEnabled = true;
            this.cb_filtros.Location = new System.Drawing.Point(188, 414);
            this.cb_filtros.Margin = new System.Windows.Forms.Padding(6);
            this.cb_filtros.Name = "cb_filtros";
            this.cb_filtros.Size = new System.Drawing.Size(319, 34);
            this.cb_filtros.TabIndex = 2;
            this.cb_filtros.SelectedIndexChanged += new System.EventHandler(this.cb_filtros_SelectedIndexChanged);
            // 
            // inicioUC1
            // 
            this.inicioUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.inicioUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.inicioUC1.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioUC1.Location = new System.Drawing.Point(0, 0);
            this.inicioUC1.Margin = new System.Windows.Forms.Padding(0);
            this.inicioUC1.Name = "inicioUC1";
            this.inicioUC1.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.inicioUC1.Size = new System.Drawing.Size(942, 70);
            this.inicioUC1.TabIndex = 0;
            // 
            // Camara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(942, 603);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inicioUC1);
            this.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Camara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camara";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camara_FormClosing);
            this.Load += new System.EventHandler(this.Camara_Load);
            this.Shown += new System.EventHandler(this.Camara_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_foto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_webcam)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private InicioUC inicioUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_dispos;
        private System.Windows.Forms.Button bn_activar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pb_webcam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_detectar;
        private System.Windows.Forms.Button bn_capturar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_filtros;
        private System.Windows.Forms.PictureBox pb_foto;
        private System.Windows.Forms.Button bn_aplicar;
        private System.Windows.Forms.Label lb_contador;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button bn_guardar;
    }
}