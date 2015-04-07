using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SENAC.OrdemServico.Components
{
    public class txtBusca : TextBox
    {
        private List<BindingSource> Fontes = new List<BindingSource>();
        public List<string> filtro = new List<string>();
        private List<object> DGV = new List<object>();
        public bool EmBusca = false;
        public txtBusca()
        {
            this.Enter += new EventHandler(txtBusca_Enter);
            this.Leave += new EventHandler(txtBusca_Leave);
            this.TextChanged += new EventHandler(txtBusca_TextChanged);
            this.Text = "Busca";
            this.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = SystemColors.GrayText;
        }
        void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.Text) && this.Focused)
                {
                    foreach (BindingSource B in Fontes)
                    {
                        string filtroFinal = "";
                        foreach (string S in filtro)
                        {
                            filtroFinal += S + " Like '*" + this.Text + "*' or ";
                        }
                        if (B != null)
                            B.Filter = filtroFinal.Remove(filtroFinal.Length - 3);
                    }
                }
                else
                {
                    foreach (BindingSource B in Fontes)
                    {
                        if (B != null)
                            B.Filter = "";
                    }
                }
            }
            catch { }
        }
        public void ADDFontes(BindingSource bs)
        {
            try
            {
                BindingSource toremove = new BindingSource();
                foreach (BindingSource bind in Fontes)
                {
                    if (bind == bs)
                    {
                        toremove = bind;
                    }
                }
                Fontes.Remove(toremove);
                Fontes.Add(bs);
            }
            catch { }
        }
        void txtBusca_Enter(object sender, EventArgs e)
        {
            EmBusca = true;
            this.Text = "";
            this.Font = new Font(this.Font, FontStyle.Regular);
            this.ForeColor = Color.Black;
        }
        void txtBusca_Leave(object sender, EventArgs e)
        {
            PerderFoco();
        }
        public void PerderFoco()
        {
            try
            {
                bool infocus = false;
                foreach (object GV in DGV)
                {
                    switch (GV.GetType().ToString())
	                {
                        case "System.Windows.Forms.DataGridView":
                            if (((DataGridView)GV).Focused)
                                infocus = true;
                        break;
                        case "System.Windows.Forms.ListBox":
                            if (((ListBox)GV).Focused)
                                infocus = true;
                        break;
	                } 

                }
                if (!infocus)
                {
                    this.Text = "Busca";
                    this.Font = new Font(this.Font, FontStyle.Italic);
                    this.ForeColor = Color.Gray;
                    foreach (BindingSource B in Fontes)
                    {
                        if (B != null)
                        {
                            B.Filter = "";
                            EmBusca = false;
                        }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Adiciona componente de visualização da pesquisa e sua fonte de dados
        /// </summary>
        /// <param name="dataDisplay">Componente de visualização(DataGridView,ListBox)</param>
        /// <param name="bs">Fonte de dados</param>
        public void ADDRecursos(object dataDisplay, BindingSource bs)
        {
            Fontes.Add(bs);
            DGV.Add(dataDisplay);
            switch (dataDisplay.GetType().ToString())
            {
                case "System.Windows.Forms.DataGridView":
                    ((DataGridView)dataDisplay).DataSource = bs;
                    break;
                case "System.Windows.Forms.ListBox":
                    ((ListBox)dataDisplay).DataSource = bs;
                    break;
            } 
        }
    }
}
