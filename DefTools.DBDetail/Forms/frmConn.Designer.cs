namespace DefTools.DBDetail.Forms
{
    partial class frmConn
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
            this.lblServidor = new System.Windows.Forms.Label();
            this.cmbServidor = new System.Windows.Forms.ComboBox();
            this.lblAutentica = new System.Windows.Forms.Label();
            this.cmbAutentica = new System.Windows.Forms.ComboBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(11, 13);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(49, 13);
            this.lblServidor.TabIndex = 0;
            this.lblServidor.Text = "Servidor:";
            // 
            // cmbServidor
            // 
            this.cmbServidor.FormattingEnabled = true;
            this.cmbServidor.Location = new System.Drawing.Point(90, 10);
            this.cmbServidor.Name = "cmbServidor";
            this.cmbServidor.Size = new System.Drawing.Size(223, 21);
            this.cmbServidor.TabIndex = 1;
            this.cmbServidor.SelectedIndexChanged += new System.EventHandler(this.cmbServidor_SelectedIndexChanged);
            this.cmbServidor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.cmbServidor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbServidor_MouseClick);
            // 
            // lblAutentica
            // 
            this.lblAutentica.AutoSize = true;
            this.lblAutentica.Location = new System.Drawing.Point(11, 40);
            this.lblAutentica.Name = "lblAutentica";
            this.lblAutentica.Size = new System.Drawing.Size(73, 13);
            this.lblAutentica.TabIndex = 15;
            this.lblAutentica.Text = "Autenticação:";
            // 
            // cmbAutentica
            // 
            this.cmbAutentica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutentica.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAutentica.FormattingEnabled = true;
            this.cmbAutentica.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cmbAutentica.Location = new System.Drawing.Point(90, 37);
            this.cmbAutentica.Name = "cmbAutentica";
            this.cmbAutentica.Size = new System.Drawing.Size(223, 21);
            this.cmbAutentica.TabIndex = 16;
            this.cmbAutentica.SelectedIndexChanged += new System.EventHandler(this.cmbAutentica_SelectedIndexChanged);
            this.cmbAutentica.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(90, 65);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(223, 20);
            this.txtUsuario.TabIndex = 17;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(11, 68);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 18;
            this.lblUsuario.Text = "Usuário:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(11, 94);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 20;
            this.lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(90, 91);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(223, 20);
            this.txtSenha.TabIndex = 19;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            // 
            // cmbBanco
            // 
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(90, 117);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(223, 21);
            this.cmbBanco.TabIndex = 22;
            this.cmbBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.cmbBanco.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbBanco_MouseClick);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(11, 120);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 21;
            this.lblBanco.Text = "Banco:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(238, 144);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 174);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbBanco);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.cmbAutentica);
            this.Controls.Add(this.lblAutentica);
            this.Controls.Add(this.cmbServidor);
            this.Controls.Add(this.lblServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexão";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.ComboBox cmbServidor;
        private System.Windows.Forms.Label lblAutentica;
        private System.Windows.Forms.ComboBox cmbAutentica;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Button btnOk;
    }
}