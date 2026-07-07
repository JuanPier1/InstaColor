namespace InstaColor.Pantallas
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bn_Imagen = new System.Windows.Forms.Button();
            this.bn_Video = new System.Windows.Forms.Button();
            this.bn_Camara = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bn_Imagen);
            this.flowLayoutPanel1.Controls.Add(this.bn_Video);
            this.flowLayoutPanel1.Controls.Add(this.bn_Camara);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(392, 453);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // bn_Imagen
            // 
            this.bn_Imagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(174)))));
            this.bn_Imagen.Dock = System.Windows.Forms.DockStyle.Left;
            this.bn_Imagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Imagen.Image = global::InstaColor.Properties.Resources.iconImage;
            this.bn_Imagen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bn_Imagen.Location = new System.Drawing.Point(1, 1);
            this.bn_Imagen.Margin = new System.Windows.Forms.Padding(1);
            this.bn_Imagen.Name = "bn_Imagen";
            this.bn_Imagen.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.bn_Imagen.Size = new System.Drawing.Size(389, 149);
            this.bn_Imagen.TabIndex = 0;
            this.bn_Imagen.Text = "Imagen";
            this.bn_Imagen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bn_Imagen.UseVisualStyleBackColor = false;
            this.bn_Imagen.Click += new System.EventHandler(this.bn_Imagen_Click);
            this.bn_Imagen.MouseLeave += new System.EventHandler(this.bn_Button_MouseLeave);
            this.bn_Imagen.MouseHover += new System.EventHandler(this.bn_Button_MouseHover);
            // 
            // bn_Video
            // 
            this.bn_Video.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(174)))));
            this.bn_Video.Dock = System.Windows.Forms.DockStyle.Left;
            this.bn_Video.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Video.Image = global::InstaColor.Properties.Resources.iconVideocamera;
            this.bn_Video.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bn_Video.Location = new System.Drawing.Point(1, 152);
            this.bn_Video.Margin = new System.Windows.Forms.Padding(1);
            this.bn_Video.Name = "bn_Video";
            this.bn_Video.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.bn_Video.Size = new System.Drawing.Size(389, 149);
            this.bn_Video.TabIndex = 1;
            this.bn_Video.Text = "Vídeo";
            this.bn_Video.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bn_Video.UseVisualStyleBackColor = false;
            this.bn_Video.Click += new System.EventHandler(this.bn_Video_Click);
            this.bn_Video.MouseLeave += new System.EventHandler(this.bn_Button_MouseLeave);
            this.bn_Video.MouseHover += new System.EventHandler(this.bn_Button_MouseHover);
            // 
            // bn_Camara
            // 
            this.bn_Camara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(174)))));
            this.bn_Camara.Dock = System.Windows.Forms.DockStyle.Left;
            this.bn_Camara.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_Camara.Image = global::InstaColor.Properties.Resources.iconCamera;
            this.bn_Camara.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bn_Camara.Location = new System.Drawing.Point(1, 303);
            this.bn_Camara.Margin = new System.Windows.Forms.Padding(1);
            this.bn_Camara.Name = "bn_Camara";
            this.bn_Camara.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.bn_Camara.Size = new System.Drawing.Size(389, 149);
            this.bn_Camara.TabIndex = 2;
            this.bn_Camara.Text = "Cámara";
            this.bn_Camara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bn_Camara.UseVisualStyleBackColor = false;
            this.bn_Camara.Click += new System.EventHandler(this.bn_Camara_Click);
            this.bn_Camara.MouseLeave += new System.EventHandler(this.bn_Button_MouseLeave);
            this.bn_Camara.MouseHover += new System.EventHandler(this.bn_Button_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(404, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(429, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 69);
            this.label2.TabIndex = 2;
            this.label2.Text = "C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(504, 361);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 69);
            this.label3.TabIndex = 3;
            this.label3.Text = "o";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(572, 361);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 69);
            this.label4.TabIndex = 4;
            this.label4.Text = "l";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(626, 361);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 69);
            this.label5.TabIndex = 5;
            this.label5.Text = "o";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Magenta;
            this.label6.Location = new System.Drawing.Point(694, 361);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 69);
            this.label6.TabIndex = 6;
            this.label6.Text = "r";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InstaColor.Properties.Resources.iconInicio;
            this.pictureBox1.Location = new System.Drawing.Point(452, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 246);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(40F, 69F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bn_Imagen;
        private System.Windows.Forms.Button bn_Video;
        private System.Windows.Forms.Button bn_Camara;
    }
}