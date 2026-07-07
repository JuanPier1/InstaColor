namespace InstaColor.Pantallas
{
    partial class InicioUC
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bn_Inicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bn_Inicio
            // 
            this.bn_Inicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(174)))));
            this.bn_Inicio.Dock = System.Windows.Forms.DockStyle.Left;
            this.bn_Inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bn_Inicio.Location = new System.Drawing.Point(8, 8);
            this.bn_Inicio.Name = "bn_Inicio";
            this.bn_Inicio.Size = new System.Drawing.Size(127, 44);
            this.bn_Inicio.TabIndex = 1;
            this.bn_Inicio.Text = "Inicio";
            this.bn_Inicio.UseVisualStyleBackColor = false;
            this.bn_Inicio.Click += new System.EventHandler(this.bn_Inicio_Click);
            // 
            // InicioUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.bn_Inicio);
            this.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InicioUC";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(562, 60);
            this.Load += new System.EventHandler(this.InicioUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bn_Inicio;
    }
}
