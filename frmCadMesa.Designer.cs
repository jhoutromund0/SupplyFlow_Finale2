namespace SupplyFlow
{
    partial class frmCadMesa
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
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblTela = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtCapacidade = new System.Windows.Forms.TextBox();
            this.lblCapacidade = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lboStatus = new System.Windows.Forms.ListBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.lblTela);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 54);
            this.panel1.TabIndex = 22;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Teal;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVoltar.Location = new System.Drawing.Point(537, 0);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(148, 54);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblTela
            // 
            this.lblTela.AutoSize = true;
            this.lblTela.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTela.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTela.Location = new System.Drawing.Point(3, 15);
            this.lblTela.Name = "lblTela";
            this.lblTela.Size = new System.Drawing.Size(192, 24);
            this.lblTela.TabIndex = 2;
            this.lblTela.Text = "Cadastro de Mesa";
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(114, 93);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(117, 26);
            this.txtNum.TabIndex = 0;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.Color.Black;
            this.lblNum.Location = new System.Drawing.Point(12, 95);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(96, 24);
            this.lblNum.TabIndex = 39;
            this.lblNum.Text = "Número:";
            // 
            // txtCapacidade
            // 
            this.txtCapacidade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidade.Location = new System.Drawing.Point(502, 93);
            this.txtCapacidade.Name = "txtCapacidade";
            this.txtCapacidade.Size = new System.Drawing.Size(117, 26);
            this.txtCapacidade.TabIndex = 1;
            // 
            // lblCapacidade
            // 
            this.lblCapacidade.AutoSize = true;
            this.lblCapacidade.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacidade.ForeColor = System.Drawing.Color.Black;
            this.lblCapacidade.Location = new System.Drawing.Point(360, 95);
            this.lblCapacidade.Name = "lblCapacidade";
            this.lblCapacidade.Size = new System.Drawing.Size(136, 24);
            this.lblCapacidade.TabIndex = 41;
            this.lblCapacidade.Text = "Capacidade:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(12, 178);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 24);
            this.lblStatus.TabIndex = 43;
            this.lblStatus.Text = "Status:";
            // 
            // lboStatus
            // 
            this.lboStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboStatus.FormattingEnabled = true;
            this.lboStatus.ItemHeight = 18;
            this.lboStatus.Items.AddRange(new object[] {
            "Livre",
            "Ocupada",
            "Reservada"});
            this.lboStatus.Location = new System.Drawing.Point(100, 180);
            this.lboStatus.Name = "lboStatus";
            this.lboStatus.Size = new System.Drawing.Size(209, 58);
            this.lboStatus.TabIndex = 2;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar.Location = new System.Drawing.Point(528, 345);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(148, 54);
            this.btnLimpar.TabIndex = 4;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.Teal;
            this.btnCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCadastrar.Location = new System.Drawing.Point(274, 345);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(148, 54);
            this.btnCadastrar.TabIndex = 3;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.Location = new System.Drawing.Point(0, 345);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(148, 54);
            this.btnEditar.TabIndex = 44;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmCadMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.ControlBox = false;
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtCapacidade);
            this.Controls.Add(this.lblCapacidade);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCadMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Mesa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblTela;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtCapacidade;
        private System.Windows.Forms.Label lblCapacidade;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lboStatus;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnEditar;
    }
}