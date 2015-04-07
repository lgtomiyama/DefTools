using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using DefTools.DBDetail.Model;

namespace DefTools.DBDetail.DAO
{
    public static class GeradorDocumentos
    {
        public static void GerarDocumentoTabela(string caminhoArquivo, TableInfoModel tableInfo)
        {
            string arquivoXML = caminhoArquivo;
            XmlTextWriter xmlWriter = new XmlTextWriter(arquivoXML, Encoding.UTF8);

            GerarCabecalhoDocumento(xmlWriter);
            AdicionarEstilos(xmlWriter);

            GerarConteudoDocumentoTabela(xmlWriter, tableInfo);

            FinalizarArquivo(xmlWriter);
        }

        public static void GerarDocumentoProc(string caminhoArquivo, ProcedureInfoModel procInfo) 
        {
            string arquivoXML = caminhoArquivo;
            XmlTextWriter xmlWriter = new XmlTextWriter(arquivoXML, Encoding.UTF8);

            GerarCabecalhoDocumento(xmlWriter);
            AdicionarEstilos(xmlWriter);

            GerarConteudoDocumentoProcedure(xmlWriter, procInfo);

            FinalizarArquivo(xmlWriter);

        }

        private static void FinalizarArquivo(XmlTextWriter xmlWriter)
        {
            //WorksheetOptions 
            xmlWriter.WriteStartElement("WorksheetOptions");
            xmlWriter.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:office:excel");
            xmlWriter.WriteElementString("Selected", "");
            xmlWriter.WriteElementString("ProtectObjects", "False");
            xmlWriter.WriteElementString("ProtectScenarios", "False");

            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        private static void GerarConteudoDocumentoProcedure(XmlTextWriter xmlWriter, ProcedureInfoModel procInfo) 
        {
            //Planilha
            xmlWriter.WriteStartElement("Worksheet");
            xmlWriter.WriteAttributeString("ss:Name", "Procedures");
            //Tabela
            xmlWriter.WriteStartElement("Table");
            xmlWriter.WriteAttributeString("ss:DefaultRowHeight", "15");
            //Cabeçalho tabelas
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "196.38");
            xmlWriter.WriteEndElement();//Column
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "106.23");
            xmlWriter.WriteEndElement();//Column
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "63.11");
            xmlWriter.WriteEndElement();//Column
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "92.38");
            xmlWriter.WriteEndElement();//Column

            //Linha cabeçalho procedures
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type","String");
            xmlWriter.WriteRaw(Global.colunaNomeProc);
            xmlWriter.WriteEndElement(); //Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.colunaDescProc);
            xmlWriter.WriteEndElement(); //Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteEndElement();//Row

            //Linha nome procedure e descrição procedure
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            //Conta a quantidade de parâmetros existem na procedure e faz o merge
            xmlWriter.WriteAttributeString("ss:MergeDown", (1 + procInfo.dtParam.Rows.Count).ToString());
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(procInfo.nomeProcedure);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(procInfo.descricaoProcedure);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteEndElement();//Row

            //Cabeçalho parâmetros
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:Index", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.colunaParam);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:Index", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.colunaParamType);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:Index", "4");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.descricao);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteEndElement();//Row

            //Lista de parâmetros
            foreach (DataRow row in procInfo.dtParam.Rows) 
            {
                //Linha de descrição de parâmetros
                xmlWriter.WriteStartElement("Row");

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:Index", "2");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["PARAMETER_NAME"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:Index", "3");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["TYPE"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:Index", "4");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["DESCRIPTION"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteEndElement();//Row
            }

            //Linha Grant
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.grant);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.permissao);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteEndElement();//Row


            //Se não houber nenhuma grant na lista irá gerar uma linha em branco na tabela
            if (procInfo.dtPermissoes.Rows.Count < 1)
            {
                xmlWriter.WriteStartElement("Row");

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteEndElement();//Row
            }
            else
            {
                //Linha lista grants
                foreach (DataRow row in procInfo.dtPermissoes.Rows)
                {
                    xmlWriter.WriteStartElement("Row");

                    xmlWriter.WriteStartElement("Cell");
                    xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                    xmlWriter.WriteStartElement("Data");
                    xmlWriter.WriteAttributeString("ss:Type", "String");
                    xmlWriter.WriteRaw(row["PRINCIPAL_NAME"].ToString());
                    xmlWriter.WriteEndElement();//Data
                    xmlWriter.WriteEndElement();//Cell

                    xmlWriter.WriteStartElement("Cell");
                    xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                    xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
                    xmlWriter.WriteStartElement("Data");
                    xmlWriter.WriteAttributeString("ss:Type", "String");
                    xmlWriter.WriteRaw(row["PERMISSION_NAME"].ToString());
                    xmlWriter.WriteEndElement();//Data
                    xmlWriter.WriteEndElement();//Cell

                    xmlWriter.WriteEndElement();//Row
                }
                xmlWriter.WriteEndElement();//Table
                xmlWriter.WriteEndElement();//Worksheet
            }
        }

        private static void GerarConteudoDocumentoTabela(XmlTextWriter xmlWriter, TableInfoModel tableInfo)
        {
            //Planilha
            xmlWriter.WriteStartElement("Worksheet");
            xmlWriter.WriteAttributeString("ss:Name", "Tabelas");
            //Tabela
            xmlWriter.WriteStartElement("Table");
            xmlWriter.WriteAttributeString("ss:DefaultRowHeight", "13");
            //Cabeçalho tabelas
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "162.72");
            xmlWriter.WriteEndElement();//Column
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "115.92");
            xmlWriter.WriteEndElement();//Column
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "115.92");
            xmlWriter.WriteEndElement();//Column
            xmlWriter.WriteStartElement("Column");
            xmlWriter.WriteAttributeString("ss:Width", "115.92");
            xmlWriter.WriteEndElement();//Column

            //Linha cabeçalho tabelas
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.colunaEntidade);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.descricao);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row

            //Linha detalhes tabela
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(tableInfo.nomeTabela);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(tableInfo.descricaoTabela);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteEndElement();//Row
            //----Linha titulos banco
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.BaseDeDados);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.Esquema);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell


            xmlWriter.WriteEndElement();//Row
            //----Linha detalhes banco
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.banco);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(tableInfo.schema);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Linha titulo atributos
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.Coluna);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.descricaoColuna);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.tipoDados);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.aceitaNulo);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row

            foreach (DataRow row in tableInfo.dtDetalheColunas.Rows)
            {
                //----Linha descricao atributos
                xmlWriter.WriteStartElement("Row");

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["COLUMN_NAME"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["COLUMN_DESCRIPTION"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["DATA_TYPE"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(Global.getIsNullable(row["IS_NULLABLE"].ToString()));
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteEndElement();//Row
            }
            //--Linha em branco
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Linha chaves primarias
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.chavePrimaria);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(tableInfo.chavesPrimarias);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row

            //--Linha em branco
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Titulo Regras negocio
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.regrasNegocio);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //--Regras
            foreach (string regra in tableInfo.dtRegras)
            {
                xmlWriter.WriteStartElement("Row");
                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(regra);
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell
                xmlWriter.WriteEndElement();//Row
            }

            //--Linha em branco
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Linha Grant
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.grant);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Tilulo Permissoes
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.usuario);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.permissao);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            foreach (DataRow row in tableInfo.dtPermissoes.Rows)
            {
                xmlWriter.WriteStartElement("Row");

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["GRANTEE"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:MergeAcross", "2");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["PERMISSION"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell
                xmlWriter.WriteEndElement();//Row
            }
            //--Linha em branco
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Linha FK
            xmlWriter.WriteStartElement("Row");
            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "3");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.chaveEstrangeira);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell
            xmlWriter.WriteEndElement();//Row
            //----Linha titulo FKs
            xmlWriter.WriteStartElement("Row");

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.Coluna);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.origemTabelaFk);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteStartElement("Cell");
            xmlWriter.WriteAttributeString("ss:StyleID", "Titulo");
            xmlWriter.WriteAttributeString("ss:MergeAcross", "1");
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteAttributeString("ss:Type", "String");
            xmlWriter.WriteRaw(Global.origemColunaFk);
            xmlWriter.WriteEndElement();//Data
            xmlWriter.WriteEndElement();//Cell

            xmlWriter.WriteEndElement();//Row


            foreach (DataRow row in tableInfo.dtReferenciasFK.Rows)
            {
                //----Linha descricao FKs
                xmlWriter.WriteStartElement("Row");

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["Coluna"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["TabelaOrigem"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteStartElement("Cell");
                xmlWriter.WriteAttributeString("ss:StyleID", "Conteudo");
                xmlWriter.WriteAttributeString("ss:MergeAcross", "1");
                xmlWriter.WriteStartElement("Data");
                xmlWriter.WriteAttributeString("ss:Type", "String");
                xmlWriter.WriteRaw(row["CampoOrigem"].ToString());
                xmlWriter.WriteEndElement();//Data
                xmlWriter.WriteEndElement();//Cell

                xmlWriter.WriteEndElement();//Row
            }
            xmlWriter.WriteEndElement();//Table
        }

        private static void GerarCabecalhoDocumento(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartDocument();
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteRaw("<?mso-application progid=\"Excel.Sheet\"?>");

            xmlWriter.WriteStartElement("Workbook");
            //Cabeçalho para interpretaçao do excel
            xmlWriter.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:office:spreadsheet");
            xmlWriter.WriteAttributeString("xmlns:o", "urn:schemas-microsoft-com:office:office");
            xmlWriter.WriteAttributeString("xmlns:x", "urn:schemas-microsoft-com:office:excel");
            xmlWriter.WriteAttributeString("xmlns:ss", "urn:schemas-microsoft-com:office:spreadsheet");
            xmlWriter.WriteAttributeString("xmlns:html", "http://www.w3.org/TR/REC-html40");

            //Propriedades do arquivo
            xmlWriter.WriteStartElement("DocumentProperties");
            xmlWriter.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:office:excel");
            xmlWriter.WriteElementString("Author", Global.nomeSistema);
            xmlWriter.WriteElementString("LastAuthor", System.Environment.UserName);
            xmlWriter.WriteElementString("Created", DateTime.Now.ToString());
            xmlWriter.WriteElementString("Version", "1.0");
            xmlWriter.WriteEndElement();//DocumentProperties
            //Propriedades do livro de trabalho
            xmlWriter.WriteStartElement("ExcelWorkbook");
            xmlWriter.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:office:excel");
            xmlWriter.WriteElementString("ProtectStructure", "False");
            xmlWriter.WriteElementString("ProtectWindows", "False");
            xmlWriter.WriteEndElement();//ExcelWorkbook
        }
        private static void AdicionarEstilos(XmlTextWriter xmlWriter)
        {
            //Estilos
            xmlWriter.WriteStartElement("Styles");
            //---------------Titulo
            xmlWriter.WriteStartElement("Style");
            xmlWriter.WriteAttributeString("ss:ID", "Titulo");
            xmlWriter.WriteAttributeString("ss:Name", "Titulo");
            xmlWriter.WriteStartElement("Alignment");
            xmlWriter.WriteAttributeString("Vertical", "Top");
            xmlWriter.WriteAttributeString("ss:WrapText", "1");
            xmlWriter.WriteEndElement();//Font
            xmlWriter.WriteStartElement("Font");
            xmlWriter.WriteAttributeString("ss:FontName", "Arial Narrow");
            xmlWriter.WriteAttributeString("ss:Size", "10");
            xmlWriter.WriteAttributeString("ss:Bold", "1");
            xmlWriter.WriteEndElement();//Font
            xmlWriter.WriteStartElement("Borders");
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Bottom");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Left");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Right");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Top");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteEndElement();//Borders
            xmlWriter.WriteEndElement();//Style
            //---------------Conteudo
            xmlWriter.WriteStartElement("Style");
            xmlWriter.WriteAttributeString("ss:ID", "Conteudo");
            xmlWriter.WriteAttributeString("ss:Name", "Conteudo");
            xmlWriter.WriteStartElement("Alignment");
            xmlWriter.WriteAttributeString("Vertical", "Top");
            xmlWriter.WriteAttributeString("ss:WrapText", "1");
            xmlWriter.WriteEndElement();//Font
            xmlWriter.WriteStartElement("Font");
            xmlWriter.WriteAttributeString("ss:FontName", "Arial Narrow");
            xmlWriter.WriteAttributeString("ss:Size", "10");

            xmlWriter.WriteEndElement();//Font
            xmlWriter.WriteStartElement("Borders");

            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Bottom");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Left");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Right");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");
            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteStartElement("Border");
            xmlWriter.WriteAttributeString("ss:Position", "Top");
            xmlWriter.WriteAttributeString("ss:LineStyle", "Continuous");
            xmlWriter.WriteAttributeString("ss:Weight", "2");

            xmlWriter.WriteEndElement();//Border
            xmlWriter.WriteEndElement();//Borders
            xmlWriter.WriteEndElement();//Style

            xmlWriter.WriteEndElement();//Styles

        }

    }

}

