namespace InstaColor.Pantallas
{
    partial class Histograma
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
            this.zgc_Histograma = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zgc_Histograma
            // 
            this.zgc_Histograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgc_Histograma.Location = new System.Drawing.Point(0, 0);
            this.zgc_Histograma.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.zgc_Histograma.Name = "zgc_Histograma";
            this.zgc_Histograma.ScrollGrace = 0D;
            this.zgc_Histograma.ScrollMaxX = 0D;
            this.zgc_Histograma.ScrollMaxY = 0D;
            this.zgc_Histograma.ScrollMaxY2 = 0D;
            this.zgc_Histograma.ScrollMinX = 0D;
            this.zgc_Histograma.ScrollMinY = 0D;
            this.zgc_Histograma.ScrollMinY2 = 0D;
            this.zgc_Histograma.Size = new System.Drawing.Size(382, 353);
            this.zgc_Histograma.TabIndex = 0;
            this.zgc_Histograma.UseExtendedPrintDialog = true;
            // 
            // Histograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.zgc_Histograma);
            this.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Histograma";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Histograma";
            this.Load += new System.EventHandler(this.Histograma_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgc_Histograma;
    }
}