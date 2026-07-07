namespace InstaColor.Pantallas
{
    partial class Video
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Video));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bn_Pause = new System.Windows.Forms.Button();
            this.bn_Res = new System.Windows.Forms.Button();
            this.bn_Play = new System.Windows.Forms.Button();
            this.bn_Bajar = new System.Windows.Forms.Button();
            this.bn_Stop = new System.Windows.Forms.Button();
            this.bn_Subir = new System.Windows.Forms.Button();
            this.pl_RGB = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_B = new System.Windows.Forms.TextBox();
            this.tb_G = new System.Windows.Forms.TextBox();
            this.tb_R = new System.Windows.Forms.TextBox();
            this.pl_Grad = new System.Windows.Forms.Panel();
            this.tb_B2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_G2 = new System.Windows.Forms.TextBox();
            this.tb_R2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.bn_RGB = new System.Windows.Forms.Button();
            this.bn_Red = new System.Windows.Forms.Button();
            this.bn_Green = new System.Windows.Forms.Button();
            this.bn_Blue = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bn_FV = new System.Windows.Forms.Button();
            this.bn_FH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Filtros = new System.Windows.Forms.ComboBox();
            this.bn_Aplicar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_A2 = new System.Windows.Forms.Label();
            this.lb_A3 = new System.Windows.Forms.Label();
            this.lb_A1 = new System.Windows.Forms.Label();
            this.tbar_Ajuste = new System.Windows.Forms.TrackBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pb_video = new System.Windows.Forms.PictureBox();
            this.inicioUC1 = new InstaColor.Pantallas.InicioUC();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pl_RGB.SuspendLayout();
            this.pl_Grad.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Ajuste)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_video)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bn_Pause);
            this.panel1.Controls.Add(this.bn_Res);
            this.panel1.Controls.Add(this.bn_Play);
            this.panel1.Controls.Add(this.bn_Bajar);
            this.panel1.Controls.Add(this.bn_Stop);
            this.panel1.Controls.Add(this.bn_Subir);
            this.panel1.Controls.Add(this.pl_RGB);
            this.panel1.Controls.Add(this.pl_Grad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 713);
            this.panel1.TabIndex = 2;
            // 
            // bn_Pause
            // 
            this.bn_Pause.BackColor = System.Drawing.Color.LightGray;
            this.bn_Pause.Enabled = false;
            this.bn_Pause.FlatAppearance.BorderSize = 2;
            this.bn_Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Pause.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Pause.Image = global::InstaColor.Properties.Resources.pause;
            this.bn_Pause.Location = new System.Drawing.Point(70, 326);
            this.bn_Pause.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Pause.Name = "bn_Pause";
            this.bn_Pause.Size = new System.Drawing.Size(64, 64);
            this.bn_Pause.TabIndex = 13;
            this.bn_Pause.UseVisualStyleBackColor = false;
            this.bn_Pause.Click += new System.EventHandler(this.bn_Pause_Click);
            // 
            // bn_Res
            // 
            this.bn_Res.BackColor = System.Drawing.Color.Salmon;
            this.bn_Res.Enabled = false;
            this.bn_Res.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Res.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Res.Location = new System.Drawing.Point(15, 148);
            this.bn_Res.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Res.Name = "bn_Res";
            this.bn_Res.Size = new System.Drawing.Size(185, 60);
            this.bn_Res.TabIndex = 5;
            this.bn_Res.Text = "Reestablecer Vídeo";
            this.bn_Res.UseVisualStyleBackColor = false;
            this.bn_Res.Click += new System.EventHandler(this.bn_Res_Click);
            // 
            // bn_Play
            // 
            this.bn_Play.BackColor = System.Drawing.Color.LimeGreen;
            this.bn_Play.Enabled = false;
            this.bn_Play.FlatAppearance.BorderSize = 2;
            this.bn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Play.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Play.Image = global::InstaColor.Properties.Resources.play;
            this.bn_Play.Location = new System.Drawing.Point(70, 250);
            this.bn_Play.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Play.Name = "bn_Play";
            this.bn_Play.Size = new System.Drawing.Size(64, 64);
            this.bn_Play.TabIndex = 12;
            this.bn_Play.UseVisualStyleBackColor = false;
            this.bn_Play.Click += new System.EventHandler(this.bn_Play_Click);
            // 
            // bn_Bajar
            // 
            this.bn_Bajar.BackColor = System.Drawing.Color.SeaShell;
            this.bn_Bajar.Enabled = false;
            this.bn_Bajar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Bajar.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Bajar.Location = new System.Drawing.Point(15, 76);
            this.bn_Bajar.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Bajar.Name = "bn_Bajar";
            this.bn_Bajar.Size = new System.Drawing.Size(185, 60);
            this.bn_Bajar.TabIndex = 4;
            this.bn_Bajar.Text = "Descargar Vídeo";
            this.bn_Bajar.UseVisualStyleBackColor = false;
            this.bn_Bajar.Click += new System.EventHandler(this.bn_Bajar_Click);
            // 
            // bn_Stop
            // 
            this.bn_Stop.BackColor = System.Drawing.Color.Tomato;
            this.bn_Stop.Enabled = false;
            this.bn_Stop.FlatAppearance.BorderSize = 2;
            this.bn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Stop.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Stop.Image = global::InstaColor.Properties.Resources.stop;
            this.bn_Stop.Location = new System.Drawing.Point(70, 402);
            this.bn_Stop.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Stop.Name = "bn_Stop";
            this.bn_Stop.Size = new System.Drawing.Size(64, 64);
            this.bn_Stop.TabIndex = 11;
            this.bn_Stop.UseVisualStyleBackColor = false;
            this.bn_Stop.Click += new System.EventHandler(this.bn_Stop_Click);
            // 
            // bn_Subir
            // 
            this.bn_Subir.BackColor = System.Drawing.Color.SeaShell;
            this.bn_Subir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Subir.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Subir.Location = new System.Drawing.Point(15, 14);
            this.bn_Subir.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Subir.Name = "bn_Subir";
            this.bn_Subir.Size = new System.Drawing.Size(185, 50);
            this.bn_Subir.TabIndex = 3;
            this.bn_Subir.Text = "Subir Vídeo";
            this.bn_Subir.UseVisualStyleBackColor = false;
            this.bn_Subir.Click += new System.EventHandler(this.bn_Subir_Click);
            // 
            // pl_RGB
            // 
            this.pl_RGB.Controls.Add(this.label4);
            this.pl_RGB.Controls.Add(this.label10);
            this.pl_RGB.Controls.Add(this.label9);
            this.pl_RGB.Controls.Add(this.label8);
            this.pl_RGB.Controls.Add(this.tb_B);
            this.pl_RGB.Controls.Add(this.tb_G);
            this.pl_RGB.Controls.Add(this.tb_R);
            this.pl_RGB.Location = new System.Drawing.Point(1, 520);
            this.pl_RGB.Margin = new System.Windows.Forms.Padding(0);
            this.pl_RGB.Name = "pl_RGB";
            this.pl_RGB.Size = new System.Drawing.Size(208, 116);
            this.pl_RGB.TabIndex = 12;
            this.pl_RGB.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Color Vídeo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(152, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 23);
            this.label10.TabIndex = 15;
            this.label10.Text = "B";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(92, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "G";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "R";
            // 
            // tb_B
            // 
            this.tb_B.Location = new System.Drawing.Point(138, 67);
            this.tb_B.MaxLength = 3;
            this.tb_B.Name = "tb_B";
            this.tb_B.Size = new System.Drawing.Size(54, 38);
            this.tb_B.TabIndex = 2;
            this.tb_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_G
            // 
            this.tb_G.Location = new System.Drawing.Point(78, 67);
            this.tb_G.MaxLength = 3;
            this.tb_G.Name = "tb_G";
            this.tb_G.Size = new System.Drawing.Size(54, 38);
            this.tb_G.TabIndex = 1;
            this.tb_G.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_R
            // 
            this.tb_R.Location = new System.Drawing.Point(18, 67);
            this.tb_R.MaxLength = 3;
            this.tb_R.Name = "tb_R";
            this.tb_R.Size = new System.Drawing.Size(54, 38);
            this.tb_R.TabIndex = 0;
            this.tb_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pl_Grad
            // 
            this.pl_Grad.Controls.Add(this.tb_B2);
            this.pl_Grad.Controls.Add(this.label5);
            this.pl_Grad.Controls.Add(this.tb_G2);
            this.pl_Grad.Controls.Add(this.tb_R2);
            this.pl_Grad.Enabled = false;
            this.pl_Grad.Location = new System.Drawing.Point(1, 636);
            this.pl_Grad.Margin = new System.Windows.Forms.Padding(0);
            this.pl_Grad.Name = "pl_Grad";
            this.pl_Grad.Size = new System.Drawing.Size(208, 77);
            this.pl_Grad.TabIndex = 13;
            this.pl_Grad.Visible = false;
            // 
            // tb_B2
            // 
            this.tb_B2.Location = new System.Drawing.Point(138, 27);
            this.tb_B2.MaxLength = 3;
            this.tb_B2.Name = "tb_B2";
            this.tb_B2.Size = new System.Drawing.Size(54, 38);
            this.tb_B2.TabIndex = 5;
            this.tb_B2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Gradiente";
            // 
            // tb_G2
            // 
            this.tb_G2.Location = new System.Drawing.Point(78, 27);
            this.tb_G2.MaxLength = 3;
            this.tb_G2.Name = "tb_G2";
            this.tb_G2.Size = new System.Drawing.Size(54, 38);
            this.tb_G2.TabIndex = 4;
            this.tb_G2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_R2
            // 
            this.tb_R2.Location = new System.Drawing.Point(18, 27);
            this.tb_R2.MaxLength = 3;
            this.tb_R2.Name = "tb_R2";
            this.tb_R2.Size = new System.Drawing.Size(54, 38);
            this.tb_R2.TabIndex = 3;
            this.tb_R2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1122, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 570);
            this.panel2.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.bn_RGB);
            this.flowLayoutPanel1.Controls.Add(this.bn_Red);
            this.flowLayoutPanel1.Controls.Add(this.bn_Green);
            this.flowLayoutPanel1.Controls.Add(this.bn_Blue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(140, 570);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 52);
            this.label2.TabIndex = 11;
            this.label2.Text = "Histograma";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bn_RGB
            // 
            this.bn_RGB.BackColor = System.Drawing.Color.Silver;
            this.bn_RGB.Enabled = false;
            this.bn_RGB.FlatAppearance.BorderSize = 2;
            this.bn_RGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_RGB.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_RGB.Location = new System.Drawing.Point(20, 87);
            this.bn_RGB.Margin = new System.Windows.Forms.Padding(8);
            this.bn_RGB.Name = "bn_RGB";
            this.bn_RGB.Size = new System.Drawing.Size(95, 40);
            this.bn_RGB.TabIndex = 10;
            this.bn_RGB.Text = "RGB";
            this.bn_RGB.UseVisualStyleBackColor = false;
            this.bn_RGB.Click += new System.EventHandler(this.bn_RGB_Click);
            // 
            // bn_Red
            // 
            this.bn_Red.BackColor = System.Drawing.Color.Red;
            this.bn_Red.Enabled = false;
            this.bn_Red.FlatAppearance.BorderSize = 2;
            this.bn_Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Red.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Red.Location = new System.Drawing.Point(20, 143);
            this.bn_Red.Margin = new System.Windows.Forms.Padding(8);
            this.bn_Red.Name = "bn_Red";
            this.bn_Red.Size = new System.Drawing.Size(95, 40);
            this.bn_Red.TabIndex = 12;
            this.bn_Red.Text = "Red";
            this.bn_Red.UseVisualStyleBackColor = false;
            this.bn_Red.Click += new System.EventHandler(this.bn_Red_Click);
            // 
            // bn_Green
            // 
            this.bn_Green.BackColor = System.Drawing.Color.Green;
            this.bn_Green.Enabled = false;
            this.bn_Green.FlatAppearance.BorderSize = 2;
            this.bn_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Green.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Green.Location = new System.Drawing.Point(20, 199);
            this.bn_Green.Margin = new System.Windows.Forms.Padding(8);
            this.bn_Green.Name = "bn_Green";
            this.bn_Green.Size = new System.Drawing.Size(95, 40);
            this.bn_Green.TabIndex = 13;
            this.bn_Green.Text = "Green";
            this.bn_Green.UseVisualStyleBackColor = false;
            this.bn_Green.Click += new System.EventHandler(this.bn_Green_Click);
            // 
            // bn_Blue
            // 
            this.bn_Blue.BackColor = System.Drawing.Color.Blue;
            this.bn_Blue.Enabled = false;
            this.bn_Blue.FlatAppearance.BorderSize = 2;
            this.bn_Blue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Blue.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Blue.Location = new System.Drawing.Point(20, 255);
            this.bn_Blue.Margin = new System.Windows.Forms.Padding(8);
            this.bn_Blue.Name = "bn_Blue";
            this.bn_Blue.Size = new System.Drawing.Size(95, 40);
            this.bn_Blue.TabIndex = 14;
            this.bn_Blue.Text = "Blue";
            this.bn_Blue.UseVisualStyleBackColor = false;
            this.bn_Blue.Click += new System.EventHandler(this.bn_Blue_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bn_FV);
            this.panel3.Controls.Add(this.bn_FH);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cb_Filtros);
            this.panel3.Controls.Add(this.bn_Aplicar);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lb_A2);
            this.panel3.Controls.Add(this.lb_A3);
            this.panel3.Controls.Add(this.lb_A1);
            this.panel3.Controls.Add(this.tbar_Ajuste);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(209, 630);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 143);
            this.panel3.TabIndex = 4;
            // 
            // bn_FV
            // 
            this.bn_FV.FlatAppearance.BorderSize = 0;
            this.bn_FV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_FV.Image = global::InstaColor.Properties.Resources.flip_vertical;
            this.bn_FV.Location = new System.Drawing.Point(904, 51);
            this.bn_FV.Margin = new System.Windows.Forms.Padding(6);
            this.bn_FV.Name = "bn_FV";
            this.bn_FV.Size = new System.Drawing.Size(64, 64);
            this.bn_FV.TabIndex = 39;
            this.bn_FV.UseVisualStyleBackColor = true;
            this.bn_FV.Visible = false;
            // 
            // bn_FH
            // 
            this.bn_FH.FlatAppearance.BorderSize = 0;
            this.bn_FH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_FH.Image = global::InstaColor.Properties.Resources.flip_horizontal;
            this.bn_FH.Location = new System.Drawing.Point(829, 51);
            this.bn_FH.Margin = new System.Windows.Forms.Padding(6);
            this.bn_FH.Name = "bn_FH";
            this.bn_FH.Size = new System.Drawing.Size(64, 64);
            this.bn_FH.TabIndex = 38;
            this.bn_FH.UseVisualStyleBackColor = true;
            this.bn_FH.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(832, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 26);
            this.label1.TabIndex = 37;
            this.label1.Text = "Girar Vídeo";
            this.label1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(419, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 26);
            this.label6.TabIndex = 36;
            this.label6.Text = "Filtros";
            // 
            // cb_Filtros
            // 
            this.cb_Filtros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Filtros.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Filtros.FormattingEnabled = true;
            this.cb_Filtros.Location = new System.Drawing.Point(290, 58);
            this.cb_Filtros.Name = "cb_Filtros";
            this.cb_Filtros.Size = new System.Drawing.Size(300, 34);
            this.cb_Filtros.TabIndex = 35;
            this.cb_Filtros.SelectedIndexChanged += new System.EventHandler(this.cb_Filtros_SelectedIndexChanged);
            // 
            // bn_Aplicar
            // 
            this.bn_Aplicar.BackColor = System.Drawing.Color.LightCoral;
            this.bn_Aplicar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Aplicar.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_Aplicar.Location = new System.Drawing.Point(599, 54);
            this.bn_Aplicar.Margin = new System.Windows.Forms.Padding(6);
            this.bn_Aplicar.Name = "bn_Aplicar";
            this.bn_Aplicar.Size = new System.Drawing.Size(180, 40);
            this.bn_Aplicar.TabIndex = 34;
            this.bn_Aplicar.Text = "Aplicar";
            this.bn_Aplicar.UseVisualStyleBackColor = false;
            this.bn_Aplicar.Click += new System.EventHandler(this.bn_Aplicar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(88, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 26);
            this.label7.TabIndex = 33;
            this.label7.Text = "Ajuste";
            // 
            // lb_A2
            // 
            this.lb_A2.AutoSize = true;
            this.lb_A2.Font = new System.Drawing.Font("Cooper Black", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A2.Location = new System.Drawing.Point(127, 88);
            this.lb_A2.Name = "lb_A2";
            this.lb_A2.Size = new System.Drawing.Size(21, 21);
            this.lb_A2.TabIndex = 32;
            this.lb_A2.Text = "5";
            // 
            // lb_A3
            // 
            this.lb_A3.AutoSize = true;
            this.lb_A3.Font = new System.Drawing.Font("Cooper Black", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A3.Location = new System.Drawing.Point(223, 88);
            this.lb_A3.Name = "lb_A3";
            this.lb_A3.Size = new System.Drawing.Size(32, 21);
            this.lb_A3.TabIndex = 31;
            this.lb_A3.Text = "10";
            // 
            // lb_A1
            // 
            this.lb_A1.AutoSize = true;
            this.lb_A1.Font = new System.Drawing.Font("Cooper Black", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A1.Location = new System.Drawing.Point(23, 88);
            this.lb_A1.Name = "lb_A1";
            this.lb_A1.Size = new System.Drawing.Size(21, 21);
            this.lb_A1.TabIndex = 30;
            this.lb_A1.Text = "0";
            // 
            // tbar_Ajuste
            // 
            this.tbar_Ajuste.Enabled = false;
            this.tbar_Ajuste.Location = new System.Drawing.Point(17, 54);
            this.tbar_Ajuste.Name = "tbar_Ajuste";
            this.tbar_Ajuste.Size = new System.Drawing.Size(238, 56);
            this.tbar_Ajuste.TabIndex = 29;
            this.tbar_Ajuste.Value = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pb_video);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(209, 60);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(20);
            this.panel4.Size = new System.Drawing.Size(913, 570);
            this.panel4.TabIndex = 6;
            // 
            // pb_video
            // 
            this.pb_video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_video.Location = new System.Drawing.Point(20, 20);
            this.pb_video.Name = "pb_video";
            this.pb_video.Size = new System.Drawing.Size(873, 530);
            this.pb_video.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_video.TabIndex = 0;
            this.pb_video.TabStop = false;
            // 
            // inicioUC1
            // 
            this.inicioUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.inicioUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.inicioUC1.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioUC1.Location = new System.Drawing.Point(0, 0);
            this.inicioUC1.Margin = new System.Windows.Forms.Padding(0);
            this.inicioUC1.Name = "inicioUC1";
            this.inicioUC1.Padding = new System.Windows.Forms.Padding(8);
            this.inicioUC1.Size = new System.Drawing.Size(1262, 60);
            this.inicioUC1.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1262, 773);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inicioUC1);
            this.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Video";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Video_FormClosing);
            this.Load += new System.EventHandler(this.Video_Load);
            this.panel1.ResumeLayout(false);
            this.pl_RGB.ResumeLayout(false);
            this.pl_RGB.PerformLayout();
            this.pl_Grad.ResumeLayout(false);
            this.pl_Grad.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Ajuste)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_video)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InicioUC inicioUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bn_RGB;
        private System.Windows.Forms.Button bn_Red;
        private System.Windows.Forms.Button bn_Green;
        private System.Windows.Forms.Button bn_Blue;
        private System.Windows.Forms.Button bn_Res;
        private System.Windows.Forms.Button bn_Bajar;
        private System.Windows.Forms.Button bn_Subir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pl_RGB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_B;
        private System.Windows.Forms.TextBox tb_G;
        private System.Windows.Forms.TextBox tb_R;
        private System.Windows.Forms.Panel pl_Grad;
        private System.Windows.Forms.TextBox tb_B2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_G2;
        private System.Windows.Forms.TextBox tb_R2;
        private System.Windows.Forms.Button bn_Play;
        private System.Windows.Forms.Button bn_Stop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_A2;
        private System.Windows.Forms.Label lb_A3;
        private System.Windows.Forms.Label lb_A1;
        private System.Windows.Forms.TrackBar tbar_Ajuste;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_Filtros;
        private System.Windows.Forms.Button bn_Aplicar;
        private System.Windows.Forms.Button bn_Pause;
        private System.Windows.Forms.PictureBox pb_video;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button bn_FV;
        private System.Windows.Forms.Button bn_FH;
        private System.Windows.Forms.Label label1;
    }
}