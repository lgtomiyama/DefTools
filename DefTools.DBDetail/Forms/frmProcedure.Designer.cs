namespace DefTools.DBDetail.Forms
{
    partial class frmProcedure
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
            this.btnAreaTransferencia = new System.Windows.Forms.Button();
            this.btnDetalha = new System.Windows.Forms.Button();
            this.lstProcedure = new System.Windows.Forms.ListBox();
            this.gbProcedure = new System.Windows.Forms.GroupBox();
            this.gdvGrant = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesProcedure = new System.Windows.Forms.TextBox();
            this.btnGerarDocumento = new System.Windows.Forms.Button();
            this.rdbEng = new System.Windows.Forms.RadioButton();
            this.rdbPtb = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gdvDetalheParametros = new System.Windows.Forms.DataGridView();
            this.txtBuscaDetalheProc = new SENAC.OrdemServico.Components.txtBusca();
            this.txtBuscaProcedures = new SENAC.OrdemServico.Components.txtBusca();
            this.gbProcedure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGrant)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvDetalheParametros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAreaTransferencia
            // 
            this.btnAreaTransferencia.Location = new System.Drawing.Point(884, 436);
            this.btnAreaTransferencia.Name = "btnAreaTransferencia";
            this.btnAreaTransferencia.Size = new System.Drawing.Size(75, 23);
            this.btnAreaTransferencia.TabIndex = 11;
            this.btnAreaTransferencia.Text = "&Copiar";
            this.btnAreaTransferencia.UseVisualStyleBackColor = true;
            this.btnAreaTransferencia.Click += new System.EventHandler(this.btnAreaTransferencia_Click);
            // 
            // btnDetalha
            // 
            this.btnDetalha.Location = new System.Drawing.Point(352, 11);
            this.btnDetalha.Name = "btnDetalha";
            this.btnDetalha.Size = new System.Drawing.Size(75, 23);
            this.btnDetalha.TabIndex = 8;
            this.btnDetalha.Text = "&Detalhes";
            this.btnDetalha.UseVisualStyleBackColor = true;
            this.btnDetalha.Click += new System.EventHandler(this.btnDetalha_Click);
            // 
            // lstProcedure
            // 
            this.lstProcedure.FormattingEnabled = true;
            this.lstProcedure.Location = new System.Drawing.Point(12, 39);
            this.lstProcedure.Name = "lstProcedure";
            this.lstProcedure.Size = new System.Drawing.Size(415, 108);
            this.lstProcedure.TabIndex = 6;
            this.lstProcedure.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstProcedure_MouseDoubleClick);
            // 
            // gbProcedure
            // 
            this.gbProcedure.Controls.Add(this.gdvGrant);
            this.gbProcedure.Controls.Add(this.label2);
            this.gbProcedure.Controls.Add(this.label1);
            this.gbProcedure.Controls.Add(this.txtDesProcedure);
            this.gbProcedure.Location = new System.Drawing.Point(12, 153);
            this.gbProcedure.Name = "gbProcedure";
            this.gbProcedure.Size = new System.Drawing.Size(415, 277);
            this.gbProcedure.TabIndex = 12;
            this.gbProcedure.TabStop = false;
            this.gbProcedure.Text = "Procedure";
            // 
            // gdvGrant
            // 
            this.gdvGrant.AllowUserToAddRows = false;
            this.gdvGrant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvGrant.Location = new System.Drawing.Point(9, 118);
            this.gdvGrant.Name = "gdvGrant";
            this.gdvGrant.Size = new System.Drawing.Size(400, 153);
            this.gdvGrant.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Permissões:";
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
            // txtDesProcedure
            // 
            this.txtDesProcedure.Location = new System.Drawing.Point(6, 38);
            this.txtDesProcedure.Multiline = true;
            this.txtDesProcedure.Name = "txtDesProcedure";
            this.txtDesProcedure.Size = new System.Drawing.Size(403, 51);
            this.txtDesProcedure.TabIndex = 7;
            this.txtDesProcedure.TextChanged += new System.EventHandler(this.txtDesProcedure_TextChanged);
            // 
            // btnGerarDocumento
            // 
            this.btnGerarDocumento.Location = new System.Drawing.Point(12, 436);
            this.btnGerarDocumento.Name = "btnGerarDocumento";
            this.btnGerarDocumento.Size = new System.Drawing.Size(75, 23);
            this.btnGerarDocumento.TabIndex = 6;
            this.btnGerarDocumento.Text = "&Exportar";
            this.btnGerarDocumento.UseVisualStyleBackColor = true;
            this.btnGerarDocumento.Click += new System.EventHandler(this.btnGerarDocumento_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbPtb);
            this.panel1.Controls.Add(this.rdbEng);
            this.panel1.Location = new System.Drawing.Point(854, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 29);
            this.panel1.TabIndex = 13;
            // 
            // gdvDetalheParametros
            // 
            this.gdvDetalheParametros.AllowUserToAddRows = false;
            this.gdvDetalheParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvDetalheParametros.Location = new System.Drawing.Point(433, 42);
            this.gdvDetalheParametros.Name = "gdvDetalheParametros";
            this.gdvDetalheParametros.Size = new System.Drawing.Size(526, 388);
            this.gdvDetalheParametros.TabIndex = 14;
            this.gdvDetalheParametros.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvDetalheParametros_CellEndEdit);
            // 
            // txtBuscaDetalheProc
            // 
            this.txtBuscaDetalheProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaDetalheProc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscaDetalheProc.Location = new System.Drawing.Point(433, 13);
            this.txtBuscaDetalheProc.Name = "txtBuscaDetalheProc";
            this.txtBuscaDetalheProc.Size = new System.Drawing.Size(415, 20);
            this.txtBuscaDetalheProc.TabIndex = 10;
            this.txtBuscaDetalheProc.Text = "Busca";
            // 
            // txtBuscaProcedures
            // 
            this.txtBuscaProcedures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaProcedures.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscaProcedures.Location = new System.Drawing.Point(12, 13);
            this.txtBuscaProcedures.Name = "txtBuscaProcedures";
            this.txtBuscaProcedures.Size = new System.Drawing.Size(334, 20);
            this.txtBuscaProcedures.TabIndex = 7;
            this.txtBuscaProcedures.Text = "Busca";
            // 
            // frmProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 471);
            this.Controls.Add(this.gdvDetalheParametros);
            this.Controls.Add(this.gbProcedure);
            this.Controls.Add(this.btnGerarDocumento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAreaTransferencia);
            this.Controls.Add(this.txtBuscaDetalheProc);
            this.Controls.Add(this.btnDetalha);
            this.Controls.Add(this.txtBuscaProcedures);
            this.Controls.Add(this.lstProcedure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmProcedure";
            this.Text = "DBDetail - Procedure";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmProcedure_Resize);
            this.gbProcedure.ResumeLayout(false);
            this.gbProcedure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGrant)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvDetalheParametros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAreaTransferencia;
        private SENAC.OrdemServico.Components.txtBusca txtBuscaDetalheProc;
        private System.Windows.Forms.Button btnDetalha;
        private SENAC.OrdemServico.Components.txtBusca txtBuscaProcedures;
        private System.Windows.Forms.ListBox lstProcedure;
        private System.Windows.Forms.GroupBox gbProcedure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesProcedure;
        private System.Windows.Forms.Button btnGerarDocumento;
        private System.Windows.Forms.RadioButton rdbEng;
        private System.Windows.Forms.RadioButton rdbPtb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gdvGrant;
        private System.Windows.Forms.DataGridView gdvDetalheParametros;
    }
}