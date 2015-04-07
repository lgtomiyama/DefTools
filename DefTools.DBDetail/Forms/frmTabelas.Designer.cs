namespace DefTools.DBDetail.Forms
{
    partial class frmTabelas
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
            this.lstTabela = new System.Windows.Forms.ListBox();
            this.btnDetalha = new System.Windows.Forms.Button();
            this.gdvDetalheColuna = new System.Windows.Forms.DataGridView();
            this.btnAreaTransferencia = new System.Windows.Forms.Button();
            this.btnGerarDocumento = new System.Windows.Forms.Button();
            this.gbTabela = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegra = new System.Windows.Forms.Button();
            this.txtRegra = new System.Windows.Forms.TextBox();
            this.gdvRegras = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.gdvGrant = new System.Windows.Forms.DataGridView();
            this.txtChaves = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesTabela = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gdvFK = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbPtb = new System.Windows.Forms.RadioButton();
            this.rdbEng = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtBuscaTabelas = new SENAC.OrdemServico.Components.txtBusca();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBuscaDetalheColuna = new SENAC.OrdemServico.Components.txtBusca();
            ((System.ComponentModel.ISupportInitialize)(this.gdvDetalheColuna)).BeginInit();
            this.gbTabela.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRegras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGrant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvFK)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTabela
            // 
            this.lstTabela.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTabela.FormattingEnabled = true;
            this.lstTabela.Location = new System.Drawing.Point(4, 35);
            this.lstTabela.Name = "lstTabela";
            this.lstTabela.Size = new System.Drawing.Size(360, 95);
            this.lstTabela.TabIndex = 0;
            this.lstTabela.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTabela_MouseDoubleClick);
            // 
            // btnDetalha
            // 
            this.btnDetalha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalha.Location = new System.Drawing.Point(0, 4);
            this.btnDetalha.Name = "btnDetalha";
            this.btnDetalha.Size = new System.Drawing.Size(75, 23);
            this.btnDetalha.TabIndex = 2;
            this.btnDetalha.Text = "&Detalhes";
            this.btnDetalha.UseVisualStyleBackColor = true;
            this.btnDetalha.Click += new System.EventHandler(this.btnDetalha_Click);
            // 
            // gdvDetalheColuna
            // 
            this.gdvDetalheColuna.AllowUserToAddRows = false;
            this.gdvDetalheColuna.AllowUserToDeleteRows = false;
            this.gdvDetalheColuna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvDetalheColuna.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvDetalheColuna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvDetalheColuna.Location = new System.Drawing.Point(3, 35);
            this.gdvDetalheColuna.Name = "gdvDetalheColuna";
            this.gdvDetalheColuna.RowHeadersVisible = false;
            this.gdvDetalheColuna.Size = new System.Drawing.Size(549, 486);
            this.gdvDetalheColuna.TabIndex = 3;
            this.gdvDetalheColuna.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvDetalheColuna_CellEndEdit);
            // 
            // btnAreaTransferencia
            // 
            this.btnAreaTransferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaTransferencia.Location = new System.Drawing.Point(862, 695);
            this.btnAreaTransferencia.Name = "btnAreaTransferencia";
            this.btnAreaTransferencia.Size = new System.Drawing.Size(75, 23);
            this.btnAreaTransferencia.TabIndex = 5;
            this.btnAreaTransferencia.Text = "&Copiar";
            this.btnAreaTransferencia.UseVisualStyleBackColor = true;
            this.btnAreaTransferencia.Click += new System.EventHandler(this.btnAreaTransferencia_Click);
            // 
            // btnGerarDocumento
            // 
            this.btnGerarDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGerarDocumento.Location = new System.Drawing.Point(3, 695);
            this.btnGerarDocumento.Name = "btnGerarDocumento";
            this.btnGerarDocumento.Size = new System.Drawing.Size(75, 23);
            this.btnGerarDocumento.TabIndex = 6;
            this.btnGerarDocumento.Text = "&Exportar";
            this.btnGerarDocumento.UseVisualStyleBackColor = true;
            this.btnGerarDocumento.Click += new System.EventHandler(this.btnGerarDocumento_Click);
            // 
            // gbTabela
            // 
            this.gbTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTabela.Controls.Add(this.groupBox1);
            this.gbTabela.Controls.Add(this.label4);
            this.gbTabela.Controls.Add(this.gdvGrant);
            this.gbTabela.Controls.Add(this.txtChaves);
            this.gbTabela.Controls.Add(this.label2);
            this.gbTabela.Controls.Add(this.label1);
            this.gbTabela.Controls.Add(this.txtDesTabela);
            this.gbTabela.Location = new System.Drawing.Point(4, 136);
            this.gbTabela.Name = "gbTabela";
            this.gbTabela.Size = new System.Drawing.Size(366, 540);
            this.gbTabela.TabIndex = 7;
            this.gbTabela.TabStop = false;
            this.gbTabela.Text = "Tabela";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRegra);
            this.groupBox1.Controls.Add(this.txtRegra);
            this.groupBox1.Controls.Add(this.gdvRegras);
            this.groupBox1.Location = new System.Drawing.Point(6, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 272);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regras de negócio";
            // 
            // btnRegra
            // 
            this.btnRegra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegra.Enabled = false;
            this.btnRegra.Location = new System.Drawing.Point(6, 76);
            this.btnRegra.Name = "btnRegra";
            this.btnRegra.Size = new System.Drawing.Size(342, 23);
            this.btnRegra.TabIndex = 17;
            this.btnRegra.Text = "Adicionar Regras";
            this.btnRegra.UseVisualStyleBackColor = true;
            this.btnRegra.Click += new System.EventHandler(this.btnRegra_Click);
            // 
            // txtRegra
            // 
            this.txtRegra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegra.Enabled = false;
            this.txtRegra.Location = new System.Drawing.Point(6, 19);
            this.txtRegra.Multiline = true;
            this.txtRegra.Name = "txtRegra";
            this.txtRegra.Size = new System.Drawing.Size(342, 51);
            this.txtRegra.TabIndex = 16;
            // 
            // gdvRegras
            // 
            this.gdvRegras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvRegras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvRegras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvRegras.Location = new System.Drawing.Point(6, 105);
            this.gdvRegras.Name = "gdvRegras";
            this.gdvRegras.Size = new System.Drawing.Size(342, 161);
            this.gdvRegras.TabIndex = 15;
            this.gdvRegras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegras_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Permissões:";
            // 
            // gdvGrant
            // 
            this.gdvGrant.AllowUserToAddRows = false;
            this.gdvGrant.AllowUserToDeleteRows = false;
            this.gdvGrant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvGrant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvGrant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvGrant.Location = new System.Drawing.Point(6, 153);
            this.gdvGrant.Name = "gdvGrant";
            this.gdvGrant.RowHeadersVisible = false;
            this.gdvGrant.Size = new System.Drawing.Size(351, 103);
            this.gdvGrant.TabIndex = 13;
            // 
            // txtChaves
            // 
            this.txtChaves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChaves.Enabled = false;
            this.txtChaves.Location = new System.Drawing.Point(6, 111);
            this.txtChaves.Name = "txtChaves";
            this.txtChaves.Size = new System.Drawing.Size(354, 20);
            this.txtChaves.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chaves Primárias: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Descrição:";
            // 
            // txtDesTabela
            // 
            this.txtDesTabela.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesTabela.Location = new System.Drawing.Point(6, 38);
            this.txtDesTabela.Multiline = true;
            this.txtDesTabela.Name = "txtDesTabela";
            this.txtDesTabela.Size = new System.Drawing.Size(354, 51);
            this.txtDesTabela.TabIndex = 7;
            this.txtDesTabela.TextChanged += new System.EventHandler(this.txtDesTabela_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Chaves estrangeiras:";
            // 
            // gdvFK
            // 
            this.gdvFK.AllowUserToAddRows = false;
            this.gdvFK.AllowUserToDeleteRows = false;
            this.gdvFK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvFK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvFK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvFK.Location = new System.Drawing.Point(3, 540);
            this.gdvFK.Name = "gdvFK";
            this.gdvFK.RowHeadersVisible = false;
            this.gdvFK.Size = new System.Drawing.Size(552, 130);
            this.gdvFK.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rdbPtb);
            this.panel1.Controls.Add(this.rdbEng);
            this.panel1.Location = new System.Drawing.Point(446, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 29);
            this.panel1.TabIndex = 8;
            // 
            // rdbPtb
            // 
            this.rdbPtb.AutoSize = true;
            this.rdbPtb.Location = new System.Drawing.Point(56, 7);
            this.rdbPtb.Name = "rdbPtb";
            this.rdbPtb.Size = new System.Drawing.Size(46, 17);
            this.rdbPtb.TabIndex = 11;
            this.rdbPtb.Text = "PTB";
            this.rdbPtb.UseVisualStyleBackColor = true;
            this.rdbPtb.CheckedChanged += new System.EventHandler(this.rdbPtb_CheckedChanged);
            // 
            // rdbEng
            // 
            this.rdbEng.AutoSize = true;
            this.rdbEng.Checked = true;
            this.rdbEng.Location = new System.Drawing.Point(2, 7);
            this.rdbEng.Name = "rdbEng";
            this.rdbEng.Size = new System.Drawing.Size(48, 17);
            this.rdbEng.TabIndex = 10;
            this.rdbEng.TabStop = true;
            this.rdbEng.Text = "ENG";
            this.rdbEng.UseVisualStyleBackColor = true;
            this.rdbEng.CheckedChanged += new System.EventHandler(this.rdbPtb_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGerarDocumento, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAreaTransferencia, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(940, 721);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.gbTabela);
            this.panel3.Controls.Add(this.lstTabela);
            this.panel3.Controls.Add(this.txtBuscaTabelas);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 679);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnDetalha);
            this.panel4.Location = new System.Drawing.Point(289, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(75, 31);
            this.panel4.TabIndex = 8;
            // 
            // txtBuscaTabelas
            // 
            this.txtBuscaTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaTabelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaTabelas.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscaTabelas.Location = new System.Drawing.Point(4, 9);
            this.txtBuscaTabelas.Name = "txtBuscaTabelas";
            this.txtBuscaTabelas.Size = new System.Drawing.Size(279, 20);
            this.txtBuscaTabelas.TabIndex = 1;
            this.txtBuscaTabelas.Text = "Busca";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdvDetalheColuna);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtBuscaDetalheColuna);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.gdvFK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(379, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 679);
            this.panel2.TabIndex = 0;
            // 
            // txtBuscaDetalheColuna
            // 
            this.txtBuscaDetalheColuna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaDetalheColuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaDetalheColuna.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscaDetalheColuna.Location = new System.Drawing.Point(3, 9);
            this.txtBuscaDetalheColuna.Name = "txtBuscaDetalheColuna";
            this.txtBuscaDetalheColuna.Size = new System.Drawing.Size(439, 20);
            this.txtBuscaDetalheColuna.TabIndex = 4;
            this.txtBuscaDetalheColuna.Text = "Busca";
            // 
            // frmTabelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 721);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmTabelas";
            this.Text = "DBDetail - Tabela";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gdvDetalheColuna)).EndInit();
            this.gbTabela.ResumeLayout(false);
            this.gbTabela.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRegras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGrant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvFK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTabela;
        private SENAC.OrdemServico.Components.txtBusca txtBuscaTabelas;
        private System.Windows.Forms.Button btnDetalha;
        private System.Windows.Forms.DataGridView gdvDetalheColuna;
        private SENAC.OrdemServico.Components.txtBusca txtBuscaDetalheColuna;
        private System.Windows.Forms.Button btnAreaTransferencia;
        private System.Windows.Forms.Button btnGerarDocumento;
        private System.Windows.Forms.GroupBox gbTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesTabela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbPtb;
        private System.Windows.Forms.RadioButton rdbEng;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gdvFK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChaves;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gdvGrant;
        private System.Windows.Forms.DataGridView gdvRegras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRegra;
        private System.Windows.Forms.Button btnRegra;
    }
}