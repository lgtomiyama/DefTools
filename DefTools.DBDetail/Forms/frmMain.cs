using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DefTools.DBDetail.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            FormularioDeConexao();

            InitializeComponent();
            InciaMenu();
            Global.idioma = Global.Idioma.ENG;
        }

        private void FormularioDeConexao()
        {
            frmConn connectionForm = new frmConn();
            connectionForm.ShowDialog();
        }
        ToolStripComboBox DataBases = new ToolStripComboBox();
        private void InciaMenu()
        {

            ToolStripMenuItem menuInicio = new ToolStripMenuItem("&Inicio");
            //Tabelas
            ToolStripMenuItem menuInfoTabelas = new ToolStripMenuItem("Info &Tabelas");
            menuInfoTabelas.Click += new EventHandler(MenuInicial_InfoTabelas);
            menuInicio.DropDownItems.Add(menuInfoTabelas);
            //Procedures
            ToolStripMenuItem menuInfoProcedures = new ToolStripMenuItem("Info &Procedures");
            menuInfoProcedures.Click += new EventHandler(MenuInicial_InfoProcedures);
            menuInicio.DropDownItems.Add(menuInfoProcedures);
            //Conexão
            ToolStripSeparator ArquivoConnSeparator = new ToolStripSeparator();
            menuInicio.DropDownItems.Add(ArquivoConnSeparator);
            ToolStripMenuItem Arquivo_Conexao = new ToolStripMenuItem("Mudar &Conexão");
            Arquivo_Conexao.Click += new EventHandler(Conexao);
            menuInicio.DropDownItems.Add(Arquivo_Conexao);
            //Sair
            ToolStripSeparator ArquivoSairSeparator = new ToolStripSeparator();
            menuInicio.DropDownItems.Add(ArquivoSairSeparator);
            ToolStripMenuItem Arquivo_Sair = new ToolStripMenuItem("&Sair");
            Arquivo_Sair.Click += new EventHandler(Sair);
            menuInicio.DropDownItems.Add(Arquivo_Sair);

            //
            
            DataBases.ComboBox.SelectedIndexChanged += new System.EventHandler(this.DataBases_SelectedIndexChanged);
            DataBases.ComboBox.DataSource = Global.listaBancos;
            DataBases.Text = Global.banco;
            DataBases.ComboBox.DisplayMember = "name";


            //
            

            //Adiciona a barra
            DBDetail.Items.Add(menuInicio);
            DBDetail.Items.Add(new ToolStripSeparator());
            DBDetail.Items.Add(DataBases);
        }


        public void TrocaJanela(Form janela)
        {
            bool existe = false;
            foreach (Form i in this.MdiChildren)
            {
                if (i.ToString().Equals(janela.ToString()))
                {
                    i.Dispose();
                    existe = true;
                }

            }
            if (!existe)
            {
                ToolStripButton Tab = new ToolStripButton();
                Tab.Text = janela.Text;
                Tab.Click += new EventHandler(Tab_Click);
                DBDetail.Items.Add(Tab);
            }
            janela.MdiParent = this;
            janela.FormClosed += new FormClosedEventHandler(janela_FormClosed);
            janela.Show();

        }
        ToolStripItem btnRemover;
        public void FechaForm(Form form)
        {
            foreach (ToolStripItem btn in DBDetail.Items)
            {
                if (form.Text == btn.ToString())
                {
                    btnRemover = btn;
                }
            }
            DBDetail.Items.Remove(btnRemover);
        }


        void Tab_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                ToolStripButton btnTab = ((ToolStripButton)sender);

                if (btnTab.Text == frm.Text)
                {
                    frm.Focus();
                    frm.WindowState = FormWindowState.Maximized;
                }
            }
        }
        public void Sair(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja realmente sair do sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                this.Dispose();
        }
        public void Conexao(object sender, EventArgs e)
        {
            if (MessageBox.Show("Isso vai fechar todas as janelas, deseja realmente mudar a conexão?", "Mudar conexão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FormularioDeConexao();
                foreach (Form i in this.MdiChildren)
                {
                    FechaForm(i);
                    i.Dispose();
                }
            }
        }
        #region Eventos mdiChilds

        public void MenuInicial_InfoTabelas(object sender, EventArgs e)
        {
            this.TrocaJanela(new Forms.frmTabelas());
        }
        public void MenuInicial_InfoProcedures(object sender, EventArgs e)
        {
            this.TrocaJanela(new Forms.frmProcedure());
        }
        void janela_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.FechaForm((Form)sender);
        }
        #endregion


        private void DataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Isso vai fechar todas as janelas, deseja realmente mudar a conexão?", "Mudar conexão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                
                foreach (Form i in this.MdiChildren)
                {
                    FechaForm(i);
                    i.Dispose();
                }
                Global.banco = DataBases.Text;
            }
            
        }
    }
}
