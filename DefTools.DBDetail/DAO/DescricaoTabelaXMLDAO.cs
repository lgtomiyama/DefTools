using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using DefTools.DBDetail.XMLModel;
using System.Configuration;

namespace DefTools.DBDetail.DAO
{
    public static class DescricaoXMLDAO

    {

        public static ListaDescricoesModel Ler()
        {
            try
            {
                string arquivoXML = ConfigurationManager.AppSettings["ArquivoXML"];
                ListaDescricoesModel listaDescricao = new ListaDescricoesModel();

                XmlSerializer serializer = new XmlSerializer(typeof(ListaDescricoesModel));
                if (!File.Exists(arquivoXML))
                {
                    PersistirAtributos(new ListaDescricoesModel());
                }

                StreamReader reader = new StreamReader(arquivoXML);
                listaDescricao = (ListaDescricoesModel)serializer.Deserialize(reader);
                reader.Close();

                return listaDescricao;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void PersistirAtributos(ListaDescricoesModel listaDescricao)
        {
            try
            {
                string arquivoXML = ConfigurationManager.AppSettings["ArquivoXML"];
                XmlSerializer serializer = new XmlSerializer(typeof(ListaDescricoesModel));
                using (var stream = new StreamWriter(arquivoXML))
                {
                    serializer.Serialize(stream, listaDescricao);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
