using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DefTools.DBDetail.Forms
{
    public partial class frmConn : Form
    {
        public frmConn()
        {
            InitializeComponent();
            PreparaTela();
        }

        private void cmbServidor_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbServidor.DataSource == null)
            {
                CarregarServidores();
            }
        }

        private void cmbAutentica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAutentica.SelectedIndex == 0)
            {
                txtSenha.Enabled = false;
                txtUsuario.Enabled = false;
            }
            else
            {
                txtSenha.Enabled = true;
                txtUsuario.Enabled = true;
            }
        }

        private void cmbBanco_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbBanco.DataSource == null)
            {
                try
                {
                    CarregaBancos();
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar!");
                }
            }
        }

        private void CarregaBancos()
        {
            string Conn = "";
            if (cmbAutentica.SelectedIndex == 0)
            {
                Conn = "server=" + cmbServidor.Text + ";Integrated Security=SSPI;";
            }
            else
            {
                Conn = "server=" + cmbServidor.Text + ";User Id=" + txtUsuario.Text + ";" + "pwd=" + txtSenha.Text + ";";
            }
            SqlConnection con = new SqlConnection(Conn);
            con.Open();

            SqlCommand command = new SqlCommand("SELECT name FROM master.sys.databases", con);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();

            da.Fill(dataset);

            cmbBanco.DisplayMember = "name";
            
            Global.listaBancos = dataset.Tables[0];
            cmbBanco.DataSource = Global.listaBancos;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = "";
                if (cmbAutentica.SelectedIndex == 0)
                {
                    strConn = "server=" + cmbServidor.Text + ";Integrated Security=SSPI;Initial Catalog=" + cmbBanco.Text + ";";
                }
                else
                {
                    strConn = "server=" + cmbServidor.Text + ";User Id=" + txtUsuario.Text + ";" + "pwd=" + txtSenha.Text + ";Initial Catalog=" + cmbBanco.Text + ";";
                }
                SqlConnection sqlcon = new SqlConnection(strConn);
                sqlcon.Open();

                MessageBox.Show("Conexão realizada com sucesso!");
                Global.servidor = cmbServidor.Text;
                Global.autenticacao = cmbAutentica.SelectedIndex;
                Global.usuarioBanco = txtUsuario.Text;
                Global.senha = txtSenha.Text;
                Global.banco = cmbBanco.Text;

                Global.ConnectionString = strConn;
                this.Dispose();
            }
            catch
            {
                MessageBox.Show("Falha ao conectar!");
            }
        }

        private void PreparaTela()
        {
            txtSenha.Enabled = false;
            txtUsuario.Enabled = false;

            cmbServidor.Text = Global.servidor;
            cmbAutentica.SelectedIndex = Global.autenticacao;
            txtUsuario.Text = Global.usuarioBanco;
            txtSenha.Text = Global.senha;
            cmbBanco.Text = Global.banco;
        }

        private void CarregarServidores()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            cmbServidor.ValueMember = "ServerName";
            cmbServidor.DisplayMember = "ServerName";
            cmbServidor.DataSource = instance.GetDataSources();
        }

        private void cmbServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBanco.DataSource = null;
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOk.PerformClick();
            }
        }
    }
}
