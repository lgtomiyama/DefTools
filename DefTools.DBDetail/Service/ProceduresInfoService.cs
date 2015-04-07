using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DefTools.DBDetail.Model;


namespace DefTools.DBDetail.Service
{
    public class ProceduresInfoService
    {
        public static DataTable ListaProcedures()
        {
            return DAO.ProceduresInfoSQLDao.ListaProcedures();
        }

        public static DataTable ListaDestalhesParametros(string nomeProcedure)
        {
            try
            {
                DataTable lsDestalhesProcedures = DAO.ProceduresInfoSQLDao.ListaDestalhesProcedures(nomeProcedure);

                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();

                foreach (DataRow registro in lsDestalhesProcedures.Rows)
                {
                    XMLModel.DescricaoParametroModel descricaoParametro = (from ds in lsDescricoes.listaDescricoesParametro 
                                                                     where String.Equals(ds.NomeParametro, registro["PARAMETER_NAME"].ToString(), StringComparison.OrdinalIgnoreCase) 
                                                                     select ds).DefaultIfEmpty().First();
                    if (descricaoParametro != null)
                        registro["DESCRIPTION"] = descricaoParametro.Descricao;
                }

                return lsDestalhesProcedures;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }
        
       public static void GravaDestalhesProcedure(string nomeProcedure, string descricao)
        {
                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();
                XMLModel.DescricaoProcedureModel descricaoProcedure = (from ds in lsDescricoes.listaDescricaoProcedure 
                                                                       where String.Equals(ds.NomeProcedure, nomeProcedure, StringComparison.OrdinalIgnoreCase) 
                                                                       select ds).DefaultIfEmpty().First();
                if (descricaoProcedure != null)
                    descricaoProcedure.Descricao = descricao;
                else
                {
                    descricaoProcedure = new XMLModel.DescricaoProcedureModel();
                    descricaoProcedure.NomeProcedure = nomeProcedure;
                    descricaoProcedure.Descricao = descricao;
                    lsDescricoes.listaDescricaoProcedure.Add(descricaoProcedure);
                }

                DAO.DescricaoXMLDAO.PersistirAtributos(lsDescricoes);
        }

        public static DataTable ListaGrantProcedures(string nomeProcedure)
        {
            try
            {
                DataTable lsDestalhesProcedures = DAO.ProceduresInfoSQLDao.ListaGrantProcedures(nomeProcedure);
                return lsDestalhesProcedures;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        public static void GravaDestalhesProcedures(DataTable procedureAlterados)
        {
            try
            {
                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();

                foreach (DataRow registro in procedureAlterados.Rows)
                {
                    XMLModel.DescricaoProcedureModel descricaoProcedureNova = (from ds in lsDescricoes.listaDescricaoProcedure 
                                                                         where String.Equals(ds.NomeProcedure, registro["PROCEDURE_NAME"].ToString(), StringComparison.OrdinalIgnoreCase)
                                                                         select ds).DefaultIfEmpty().First();
                    if (descricaoProcedureNova != null)
                    {
                        descricaoProcedureNova.Descricao = registro["PROCEDURE_DESCRIPTION"].ToString();
                    }
                    else
                    {
                        descricaoProcedureNova = new XMLModel.DescricaoProcedureModel();
                        descricaoProcedureNova.NomeProcedure = registro["PROCEDURE_NAME"].ToString();
                        descricaoProcedureNova.Descricao = registro["PROCEDURE_DESCRIPTION"].ToString();
                        lsDescricoes.listaDescricaoProcedure.Add(descricaoProcedureNova);
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


        public static void GravaDestalhesParametros(string nomeParametro, string descricaoParametro)
        {
            try
            {
                XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();


                XMLModel.DescricaoParametroModel descricaoParametroNovo = (from ds in lsDescricoes.listaDescricoesParametro 
                                                                     where String.Equals(ds.NomeParametro, nomeParametro, StringComparison.OrdinalIgnoreCase) 
                                                                     select ds).DefaultIfEmpty().First();
                if (descricaoParametroNovo != null)
                {            
                    descricaoParametroNovo.Descricao = descricaoParametro;
                }
                else
                {
                    descricaoParametroNovo = new XMLModel.DescricaoParametroModel();
                    descricaoParametroNovo.NomeParametro = nomeParametro;
                    descricaoParametroNovo.Descricao = descricaoParametro;
                    lsDescricoes.listaDescricoesParametro.Add(descricaoParametroNovo);
                }

                DAO.DescricaoXMLDAO.PersistirAtributos(lsDescricoes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void DetalhaProcedure(ProcedureInfoModel procInfo, string nomeProcedure)
        {
            procInfo.nomeProcedure = nomeProcedure;

            XMLModel.ListaDescricoesModel lsDescricoes = DAO.DescricaoXMLDAO.Ler();
            XMLModel.DescricaoProcedureModel procedureDescription = (from ts in lsDescricoes.listaDescricaoProcedure
                                                              where String.Equals(ts.NomeProcedure, nomeProcedure, StringComparison.OrdinalIgnoreCase)
                                                              select ts).DefaultIfEmpty().First();
            if (procedureDescription != null)
            {
                procInfo.descricaoProcedure = procedureDescription.Descricao;
            }
            else
            {
                procInfo.descricaoProcedure = "";
            }

            procInfo.dtPermissoes = DAO.ProceduresInfoSQLDao.ListaGrantProcedures(procInfo.nomeProcedure);
            procInfo.dtParam = DAO.ProceduresInfoSQLDao.ListaDestalhesProcedures(procInfo.nomeProcedure);
        }

        public static void GerarDocumentoProcedures(ProcedureInfoModel procInfo)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Planilha Excel xml|*.xml";
                saveFileDialog.Title = "Salvar Excel xml";
                saveFileDialog.FileName = procInfo.nomeProcedure;
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    DAO.GeradorDocumentos.GerarDocumentoProc(saveFileDialog.FileName, procInfo);
                    MessageBox.Show("Documento gerado com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar arquivo: " + ex.Message);
            }
        }

    }
}
