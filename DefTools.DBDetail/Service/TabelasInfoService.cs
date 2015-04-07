using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DefTools.DBDetail.Model;

namespace DefTools.DBDetail.Service
{

    public static class TabelasInfoService
    {
        public static DataTable ListaTabelas()
        {
            try
            {
                return DAO.TabelasInfoSQLDao.ListaTabelas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable ListaDestalhesTabelas(string nomeTabela)
        {
            try
            {

                DataTable lsDestalhesTabelas = DAO.TabelasInfoSQLDao.ListaDestalhesTabelas(nomeTabela);

                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();

                foreach (DataColumn coluna in lsDestalhesTabelas.Columns)
                {
                    if (coluna.ColumnName == "COLUMN_DESCRIPTION")
                    {
                        coluna.ReadOnly = false;
                        coluna.MaxLength = 900;
                        coluna.AllowDBNull = true;
                    }
                    else
                    {
                        coluna.ReadOnly = true;
                    }
                }

                foreach (DataRow registro in lsDestalhesTabelas.Rows)
                {
                    XMLModel.DescricaoColunaModel descricaoColuna = (from ds in lsDescricoes.listaDescricoesColuna where String.Equals(ds.NomeColuna, registro["COLUMN_NAME"].ToString(), StringComparison.OrdinalIgnoreCase) select ds).DefaultIfEmpty().First();
                    if (descricaoColuna != null)
                        registro["COLUMN_DESCRIPTION"] = descricaoColuna.Descricao;
                }

                return lsDestalhesTabelas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        public static void GravaDestalhesAtributos(DataTable tableAlterados)
        {
            try
            {
                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();

                foreach (DataRow registro in tableAlterados.Rows)
                {
                    XMLModel.DescricaoColunaModel descricaoColunaNova = (from ds in lsDescricoes.listaDescricoesColuna 
                                                                         where String.Equals(ds.NomeColuna, registro["COLUMN_NAME"].ToString(), StringComparison.OrdinalIgnoreCase) 
                                                                         select ds).DefaultIfEmpty().First();
                    if (descricaoColunaNova != null)
                    {
                        descricaoColunaNova.Descricao = registro["COLUMN_DESCRIPTION"].ToString();
                    }
                    else
                    {
                        descricaoColunaNova = new XMLModel.DescricaoColunaModel();
                        descricaoColunaNova.NomeColuna = registro["COLUMN_NAME"].ToString();
                        descricaoColunaNova.Descricao = registro["COLUMN_DESCRIPTION"].ToString();
                        lsDescricoes.listaDescricoesColuna.Add(descricaoColunaNova);
                    }
                }

                DAO.DescricaoXMLDAO.PersistirAtributos(lsDescricoes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void GravaDestalhesAtributos(string nomeColuna, string descricaoColuna)
        {
            try
            {
                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();


                XMLModel.DescricaoColunaModel descricaoColunaNova = (from ds in lsDescricoes.listaDescricoesColuna where String.Equals(ds.NomeColuna, nomeColuna, StringComparison.OrdinalIgnoreCase) select ds).DefaultIfEmpty().First();
                if (descricaoColunaNova != null)
                {
                    descricaoColunaNova.Descricao = descricaoColuna;
                }
                else
                {
                    descricaoColunaNova = new XMLModel.DescricaoColunaModel();
                    descricaoColunaNova.NomeColuna = nomeColuna;
                    descricaoColunaNova.Descricao = descricaoColuna;
                    lsDescricoes.listaDescricoesColuna.Add(descricaoColunaNova);
                }

                DAO.DescricaoXMLDAO.PersistirAtributos(lsDescricoes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static void GerarDocumentoTabela(TableInfoModel tableInfo)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Planilha Excel xml|*.xml";
                saveFileDialog.Title = "Salvar Excel xml";
                saveFileDialog.FileName = tableInfo.nomeTabela;
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    DAO.GeradorDocumentos.GerarDocumentoTabela(saveFileDialog.FileName, tableInfo);
                    MessageBox.Show("Documento gerado com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro au gerar arquivo: " + ex.Message);
            }
        }

        internal static void DetalhaTabela(TableInfoModel tableInfo, string nomeTabela)
        {
            tableInfo.nomeTabela = nomeTabela;
            tableInfo.dtDetalheColunas = ListaDestalhesTabelas(tableInfo.nomeTabela);
            tableInfo.dtReferenciasFK = DAO.TabelasInfoSQLDao.DependenciasFK(tableInfo.nomeTabela);
            tableInfo.schema = DAO.TabelasInfoSQLDao.SchemaTabela(tableInfo.nomeTabela);
            tableInfo.dtPermissoes = DAO.TabelasInfoSQLDao.Permissoes(tableInfo.nomeTabela);

            //Chaves Primarias
            DataTable chavesPrimarias = DAO.TabelasInfoSQLDao.ChavesPrimarias(tableInfo.nomeTabela);
            for (int row = 0; row < chavesPrimarias.Rows.Count; row++)
            {
                tableInfo.chavesPrimarias += chavesPrimarias.Rows[row][0].ToString();
                if (row != chavesPrimarias.Rows.Count - 1)
                    tableInfo.chavesPrimarias += ", ";
            }



            XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();
            XMLModel.DescricaoTabelaModel tableDescription = (from ts in lsDescricoes.listaDescricaoTabelas 
                                                              where String.Equals(ts.NomeTabela, nomeTabela, StringComparison.OrdinalIgnoreCase) 
                                                              select ts).DefaultIfEmpty().First();
            if (tableDescription != null)
            {
                tableInfo.descricaoTabela = tableDescription.Descricao;
                tableInfo.dtRegras = tableDescription.Regras;
            }
            else
            {
                tableInfo.descricaoTabela = "";
            }

        }
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        internal static void GravaDestalhesTabelas(string nomeTabela, string descricao)
        {
            XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();
            XMLModel.DescricaoTabelaModel descricaoTabela = (from ds in lsDescricoes.listaDescricaoTabelas where String.Equals(ds.NomeTabela, nomeTabela, StringComparison.OrdinalIgnoreCase) select ds).DefaultIfEmpty().First();

            if (descricaoTabela != null)
            {
                descricaoTabela.Descricao = descricao;
            }
            else
            {
                descricaoTabela = new XMLModel.DescricaoTabelaModel();
                descricaoTabela.NomeTabela = nomeTabela;
                descricaoTabela.Descricao = descricao;
                lsDescricoes.listaDescricaoTabelas.Add(descricaoTabela);
            }

            DAO.DescricaoXMLDAO.PersistirAtributos(lsDescricoes);
        }
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        internal static void GravaDestalhesRegras(string nomeTabela, List<string> lsRegras)
        {
            XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();
            XMLModel.DescricaoTabelaModel descricaoTabela = (from ds in lsDescricoes.listaDescricaoTabelas where String.Equals(ds.NomeTabela, nomeTabela, StringComparison.OrdinalIgnoreCase) select ds).DefaultIfEmpty().First();

            if (descricaoTabela != null)
            {
                descricaoTabela.Regras = lsRegras;
            }
            else
            {
                descricaoTabela = new XMLModel.DescricaoTabelaModel();
                descricaoTabela.NomeTabela = nomeTabela;
                descricaoTabela.Regras = lsRegras;
                lsDescricoes.listaDescricaoTabelas.Add(descricaoTabela);
            }

            DAO.DescricaoXMLDAO.PersistirAtributos(lsDescricoes);
        }

    }
}
