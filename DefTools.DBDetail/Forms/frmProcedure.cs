using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DefTools.DBDetail.Service;
using DefTools.DBDetail.Model;

namespace DefTools.DBDetail.Forms
{
    public partial class frmProcedure : Form
    {
        public frmProcedure()
        {
            InitializeComponent();
            CarregaListaProcedures();
            this.WindowState = FormWindowState.Normal;
        }

        ProcedureInfoModel procInfo;
        BindingSource bsProcedures = new BindingSource();
        private void CarregaListaProcedures()
        {
            bsProcedures.DataSource = ProceduresInfoService.ListaProcedures();

            txtBuscaProcedures.ADDRecursos(lstProcedure, bsProcedures);
            txtBuscaProcedures.filtro.Add("NAME");

            lstProcedure.DisplayMember = "NAME";
            lstProcedure.ValueMember = "NAME";
        }

        BindingSource bsDetalhesParametros = new BindingSource();
        BindingSource bsGrant = new BindingSource();
        private void Detalha()
        {
            if (lstProcedure.SelectedItems.Count == 1)
            {
                procInfo = new ProcedureInfoModel();
                ProceduresInfoService.DetalhaProcedure(procInfo, lstProcedure.SelectedValue.ToString());

                txtDesProcedure.Text = procInfo.descricaoProcedure;
                gbProcedure.Text = procInfo.nomeProcedure;

                procInfo.dtParam = ProceduresInfoService.ListaDestalhesParametros(lstProcedure.SelectedValue.ToString());
                bsDetalhesParametros.DataSource = procInfo.dtParam;

                bsGrant.DataSource = procInfo.dtPermissoes;
                txtBuscaDetalheProc.ADDRecursos(gdvGrant, bsGrant);
                txtBuscaDetalheProc.ADDRecursos(gdvDetalheParametros, bsDetalhesParametros);
                txtBuscaDetalheProc.filtro.Add("PARAMETER_NAME");
                txtBuscaDetalheProc.filtro.Add("DESCRIPTION");
                txtBuscaDetalheProc.filtro.Add("TYPE");
            }
        }

        private void btnDetalha_Click(object sender, EventArgs e)
        {
            Detalha();
        }

        private void lstProcedure_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Detalha();
        }
        private void gdvDetalheParametros_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string descricaoParametro = "";
            string nomeParametro = gdvDetalheParametros.Rows[e.RowIndex].Cells["PARAMETER_NAME"].Value.ToString();

            if (gdvDetalheParametros.Rows[e.RowIndex].Cells["DESCRIPTION"].Value != null)
                descricaoParametro = gdvDetalheParametros.Rows[e.RowIndex].Cells["DESCRIPTION"].Value.ToString();

            ProceduresInfoService.GravaDestalhesParametros(nomeParametro, descricaoParametro);
        }


        private void frmProcedure_Resize(object sender, EventArgs e)
        {
            gdvDetalheParametros.Height = this.Height - 205;
        }

        private void btnAreaTransferencia_Click(object sender, EventArgs e)
        {
            if (gdvDetalheParametros.Rows.Count > 0)
            {
                gdvDetalheParametros.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                gdvDetalheParametros.SelectAll();
                DataObject dataObj = gdvDetalheParametros.GetClipboardContent();
                Clipboard.SetDataObject(dataObj, true);
                gdvDetalheParametros.ClearSelection();

                MessageBox.Show("Dados copiados para a área de transferência. Use a opção \"Mesclar Tabelas\" no Excel para colar os dados corretamente.");
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

        private void btnGerarDocumento_Click(object sender, EventArgs e)
        {
            Service.ProceduresInfoService.GerarDocumentoProcedures(procInfo);
        }

        private void txtDesProcedure_TextChanged(object sender, EventArgs e)
        {
            if (gdvDetalheParametros.Rows.Count > 0)
            {
                Service.ProceduresInfoService.GravaDestalhesProcedure(procInfo.nomeProcedure, txtDesProcedure.Text);
                procInfo.descricaoProcedure = txtDesProcedure.Text;
            }
        }
    }
}
