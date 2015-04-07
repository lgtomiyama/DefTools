using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DefTools.DBDetail.Service;
using System.Xml;
using DefTools.DBDetail.Model;

namespace DefTools.DBDetail.Forms
{
    public partial class frmTabelas : Form
    {
        public frmTabelas()
        {
            InitializeComponent();
            CarregaListaTabelas();
            this.WindowState = FormWindowState.Normal;
        }

        BindingSource bsTabelas = new BindingSource();
        private void CarregaListaTabelas()
        {
            bsTabelas.DataSource = TabelasInfoService.ListaTabelas();

            txtBuscaTabelas.ADDRecursos(lstTabela, bsTabelas);
            txtBuscaTabelas.filtro.Add("TABLE_NAME");

            lstTabela.DisplayMember = "TABLE_NAME";
            lstTabela.ValueMember = "TABLE_NAME";
        }

        BindingSource bsDetalheColunas = new BindingSource();
        TableInfoModel tableInfo;

        private void Detalha()
        {
            if (lstTabela.SelectedItems.Count == 1)
            {
                tableInfo = new TableInfoModel();
                TabelasInfoService.DetalhaTabela(tableInfo, lstTabela.SelectedValue.ToString());

                txtDesTabela.Text = tableInfo.descricaoTabela;
                gbTabela.Text = tableInfo.nomeTabela;
                txtChaves.Text = tableInfo.chavesPrimarias;

                bsDetalheColunas.DataSource = tableInfo.dtDetalheColunas;

                gdvFK.DataSource = tableInfo.dtReferenciasFK;
                gdvGrant.DataSource = tableInfo.dtPermissoes;
                if (tableInfo.dtRegras == null)
                    tableInfo.dtRegras = new List<string>();
                gdvRegras.DataSource = tableInfo.dtRegras.Select(x => new { Value = x }).ToList();

                txtBuscaDetalheColuna.ADDRecursos(gdvDetalheColuna, bsDetalheColunas);
                txtBuscaDetalheColuna.filtro.Add("COLUMN_NAME");
                txtBuscaDetalheColuna.filtro.Add("COLUMN_DESCRIPTION");
                txtBuscaDetalheColuna.filtro.Add("DATA_TYPE");

                txtRegra.Enabled = true;
                btnRegra.Enabled = true;
            }
        }
        #region Eventos
        private void gdvDetalheColuna_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string descricaoColuna = "";
            string nomeColuna = gdvDetalheColuna.Rows[e.RowIndex].Cells["COLUMN_NAME"].Value.ToString();

            if (gdvDetalheColuna.Rows[e.RowIndex].Cells["COLUMN_DESCRIPTION"].Value != null)
                descricaoColuna = gdvDetalheColuna.Rows[e.RowIndex].Cells["COLUMN_DESCRIPTION"].Value.ToString();

            Service.TabelasInfoService.GravaDestalhesAtributos(nomeColuna, descricaoColuna);
        }

        private void btnAreaTransferencia_Click(object sender, EventArgs e)
        {
            if (gdvDetalheColuna.Rows.Count > 0)
            {
                gdvDetalheColuna.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                gdvDetalheColuna.SelectAll();
                DataObject dataObj = gdvDetalheColuna.GetClipboardContent();
                Clipboard.SetDataObject(dataObj, true);
                gdvDetalheColuna.ClearSelection();

                MessageBox.Show("Dados copiados para a área de transferência. Use a opção \"Mesclar Tabelas\" no Excel para colar os dados corretamente.");
            }
        }
        private void btnDetalha_Click(object sender, EventArgs e)
        {
            Detalha();
        }
        private void lstTabela_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Detalha();
        }

        private void btnGerarDocumento_Click(object sender, EventArgs e)
        {
            Service.TabelasInfoService.GerarDocumentoTabela(tableInfo);
        }

        private void txtDesTabela_TextChanged(object sender, EventArgs e)
        {
            if (gdvDetalheColuna.Rows.Count > 0)
            {
                Service.TabelasInfoService.GravaDestalhesTabelas(tableInfo.nomeTabela, txtDesTabela.Text);
                tableInfo.descricaoTabela = txtDesTabela.Text;
            }
        }

        private void rdbPtb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEng.Checked)
            {
                Global.idioma = Global.Idioma.ENG;
            }
            else if (rdbPtb.Checked)
            {
                Global.idioma = Global.Idioma.PTB;

            }
            Detalha();
        }
        #endregion

        private void btnRegra_Click(object sender, EventArgs e)
        {
            if (regraAlteracao == null)
            {
                if (tableInfo.dtRegras == null)
                {
                    tableInfo.dtRegras = new List<string>();
                }
                tableInfo.dtRegras.Add(txtRegra.Text);
                gdvRegras.DataSource = tableInfo.dtRegras.Select(x => new { Value = x }).ToList();
                Service.TabelasInfoService.GravaDestalhesRegras(tableInfo.nomeTabela, tableInfo.dtRegras);
            }
            else
            {
                tableInfo.dtRegras = new List<string>();

                foreach (DataGridViewRow row in gdvRegras.Rows)
                {
                    if (row.Index == regraAlteracao.RowIndex)
                        tableInfo.dtRegras.Add(txtRegra.Text);
                    else
                        tableInfo.dtRegras.Add(row.Cells[0].Value.ToString());
                }
                gdvRegras.DataSource = tableInfo.dtRegras.Select(x => new { Value = x }).ToList();
                Service.TabelasInfoService.GravaDestalhesRegras(tableInfo.nomeTabela, tableInfo.dtRegras);

                regraAlteracao = null;
                txtRegra.Text = "";
                btnRegra.Text = "Adicionar Regras";
            }
        }
        DataGridViewCellEventArgs regraAlteracao;
        private void dgvRegras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRegra.Text = gdvRegras.Rows[e.RowIndex].Cells[0].Value.ToString();
            regraAlteracao = e;
            btnRegra.Text = "Alterar Regra";
        }
    }
}
