namespace SupplyFlow
{
    partial class frmEditarInsumos
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
            this.pnlEditarI = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblTelaC = new System.Windows.Forms.Label();
            this.pnlEditarI.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEditarI
            // 
            this.pnlEditarI.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlEditarI.Controls.Add(this.btnVoltar);
            this.pnlEditarI.Controls.Add(this.lblTelaC);
            this.pnlEditarI.Location = new System.Drawing.Point(0, 0);
            this.pnlEditarI.Name = "pnlEditarI";
            this.pnlEditarI.Size = new System.Drawing.Size(762, 58);
            this.pnlEditarI.TabIndex = 17;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Teal;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVoltar.Location = new System.Drawing.Point(611, 0);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(151, 58);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            // 
            // lblTelaC
            // 
            this.lblTelaC.AutoSize = true;
            this.lblTelaC.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelaC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTelaC.Location = new System.Drawing.Point(3, 17);
            this.lblTelaC.Name = "lblTelaC";
            this.lblTelaC.Size = new System.Drawing.Size(162, 24);
            this.lblTelaC.TabIndex = 2;
            this.lblTelaC.Text = "Editar Insumos";
            // 
            // frmEditarInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 347);
            this.Controls.Add(this.pnlEditarI);
            this.Name = "frmEditarInsumos";
            this.Text = "Editar Insumos";
            this.pnlEditarI.ResumeLayout(false);
            this.pnlEditarI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEditarI;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblTelaC;
    }
}