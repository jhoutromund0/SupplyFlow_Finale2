namespace SupplyFlow
{
    partial class frmGerente
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
            this.btnSair = new System.Windows.Forms.Button();
            this.lblTela = new System.Windows.Forms.Label();
            this.btnCardapio = new System.Windows.Forms.Button();
            this.btnRelatorioVendas = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnCadastrarFunc = new System.Windows.Forms.Button();
            this.btnInsumo = new System.Windows.Forms.Button();
            this.btnCadMesa = new System.Windows.Forms.Button();
            this.btnEditarFunc = new System.Windows.Forms.Button();
            this.btnEditarCard = new System.Windows.Forms.Button();
            this.btnEditarInsumo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.lblTela);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1277, 54);
            this.panel1.TabIndex = 21;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Teal;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSair.Location = new System.Drawing.Point(1128, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(148, 54);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblTela
            // 
            this.lblTela.AutoSize = true;
            this.lblTela.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTela.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTela.Location = new System.Drawing.Point(3, 15);
            this.lblTela.Name = "lblTela";
            this.lblTela.Size = new System.Drawing.Size(100, 24);
            this.lblTela.TabIndex = 2;
            this.lblTela.Text = "Gerência";
            // 
            // btnCardapio
            // 
            this.btnCardapio.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCardapio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCardapio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCardapio.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardapio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCardapio.Location = new System.Drawing.Point(481, 287);
            this.btnCardapio.Name = "btnCardapio";
            this.btnCardapio.Size = new System.Drawing.Size(256, 57);
            this.btnCardapio.TabIndex = 25;
            this.btnCardapio.Text = "Cadastrar Item do Cardápio";
            this.btnCardapio.UseVisualStyleBackColor = false;
            this.btnCardapio.Click += new System.EventHandler(this.btnCardapio_Click);
            // 
            // btnRelatorioVendas
            // 
            this.btnRelatorioVendas.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRelatorioVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelatorioVendas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRelatorioVendas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorioVendas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRelatorioVendas.Location = new System.Drawing.Point(24, 352);
            this.btnRelatorioVendas.Name = "btnRelatorioVendas";
            this.btnRelatorioVendas.Size = new System.Drawing.Size(256, 73);
            this.btnRelatorioVendas.TabIndex = 24;
            this.btnRelatorioVendas.Text = "Relatório de Vendas";
            this.btnRelatorioVendas.UseVisualStyleBackColor = false;
            this.btnRelatorioVendas.Click += new System.EventHandler(this.btnRelatorioVendas_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEstoque.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEstoque.Location = new System.Drawing.Point(24, 210);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(256, 46);
            this.btnEstoque.TabIndex = 23;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVendas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVendas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVendas.Location = new System.Drawing.Point(24, 95);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(256, 46);
            this.btnVendas.TabIndex = 22;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = false;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnCadastrarFunc
            // 
            this.btnCadastrarFunc.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCadastrarFunc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarFunc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrarFunc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarFunc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCadastrarFunc.Location = new System.Drawing.Point(481, 95);
            this.btnCadastrarFunc.Name = "btnCadastrarFunc";
            this.btnCadastrarFunc.Size = new System.Drawing.Size(256, 73);
            this.btnCadastrarFunc.TabIndex = 26;
            this.btnCadastrarFunc.Text = "Cadastrar Funcionários";
            this.btnCadastrarFunc.UseVisualStyleBackColor = false;
            this.btnCadastrarFunc.Click += new System.EventHandler(this.btnCadastrarFunc_Click);
            // 
            // btnInsumo
            // 
            this.btnInsumo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsumo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsumo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInsumo.Location = new System.Drawing.Point(481, 391);
            this.btnInsumo.Name = "btnInsumo";
            this.btnInsumo.Size = new System.Drawing.Size(256, 80);
            this.btnInsumo.TabIndex = 27;
            this.btnInsumo.Text = "Cadastrar Insumo de Receita";
            this.btnInsumo.UseVisualStyleBackColor = false;
            this.btnInsumo.Click += new System.EventHandler(this.btnInsumo_Click);
            // 
            // btnCadMesa
            // 
            this.btnCadMesa.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCadMesa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadMesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadMesa.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadMesa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCadMesa.Location = new System.Drawing.Point(481, 199);
            this.btnCadMesa.Name = "btnCadMesa";
            this.btnCadMesa.Size = new System.Drawing.Size(256, 46);
            this.btnCadMesa.TabIndex = 28;
            this.btnCadMesa.Text = "Cadastrar Mesa";
            this.btnCadMesa.UseVisualStyleBackColor = false;
            this.btnCadMesa.Click += new System.EventHandler(this.btnCadMesa_Click);
            // 
            // btnEditarFunc
            // 
            this.btnEditarFunc.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditarFunc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarFunc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarFunc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarFunc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarFunc.Location = new System.Drawing.Point(913, 95);
            this.btnEditarFunc.Name = "btnEditarFunc";
            this.btnEditarFunc.Size = new System.Drawing.Size(256, 73);
            this.btnEditarFunc.TabIndex = 29;
            this.btnEditarFunc.Text = "Editar Funcionários";
            this.btnEditarFunc.UseVisualStyleBackColor = false;
            this.btnEditarFunc.Click += new System.EventHandler(this.btnEditarFunc_Click);
            // 
            // btnEditarCard
            // 
            this.btnEditarCard.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditarCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarCard.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarCard.Location = new System.Drawing.Point(913, 194);
            this.btnEditarCard.Name = "btnEditarCard";
            this.btnEditarCard.Size = new System.Drawing.Size(256, 57);
            this.btnEditarCard.TabIndex = 31;
            this.btnEditarCard.Text = "Editar Item do Cardápio";
            this.btnEditarCard.UseVisualStyleBackColor = false;
            this.btnEditarCard.Click += new System.EventHandler(this.btnEditarCard_Click);
            // 
            // btnEditarInsumo
            // 
            this.btnEditarInsumo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditarInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarInsumo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarInsumo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarInsumo.Location = new System.Drawing.Point(913, 287);
            this.btnEditarInsumo.Name = "btnEditarInsumo";
            this.btnEditarInsumo.Size = new System.Drawing.Size(256, 80);
            this.btnEditarInsumo.TabIndex = 32;
            this.btnEditarInsumo.Text = "Editar Insumo de Receita";
            this.btnEditarInsumo.UseVisualStyleBackColor = false;
            this.btnEditarInsumo.Click += new System.EventHandler(this.btnEditarInsumo_Click);
            // 
            // frmGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1278, 483);
            this.ControlBox = false;
            this.Controls.Add(this.btnEditarInsumo);
            this.Controls.Add(this.btnEditarCard);
            this.Controls.Add(this.btnEditarFunc);
            this.Controls.Add(this.btnCadMesa);
            this.Controls.Add(this.btnInsumo);
            this.Controls.Add(this.btnCadastrarFunc);
            this.Controls.Add(this.btnCardapio);
            this.Controls.Add(this.btnRelatorioVendas);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmGerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGerente";
            this.Load += new System.EventHandler(this.frmGerente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblTela;
        private System.Windows.Forms.Button btnCardapio;
        private System.Windows.Forms.Button btnRelatorioVendas;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnCadastrarFunc;
        private System.Windows.Forms.Button btnInsumo;
        private System.Windows.Forms.Button btnCadMesa;
        private System.Windows.Forms.Button btnEditarFunc;
        private System.Windows.Forms.Button btnEditarCard;
        private System.Windows.Forms.Button btnEditarInsumo;
    }
}