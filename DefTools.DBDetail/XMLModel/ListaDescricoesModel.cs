using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DefTools.DBDetail.XMLModel
{
    [Serializable()]
    public class ListaDescricoesModel
    {
        public ListaDescricoesModel() { listaDescricoesColuna = new List<DescricaoColunaModel>(); }
        
        [XmlElement("DescricaoColuna")]
        public List<DescricaoColunaModel> listaDescricoesColuna { get; set; }

        [XmlElement("DescricaoTabela")]
        public List<DescricaoTabelaModel> listaDescricaoTabelas { get; set; }
        
        [XmlElement("DescricaoParametro")]
        public List<DescricaoParametroModel> listaDescricoesParametro { get; set; }

        [XmlElement("DescricaoProcedure")]
        public List<DescricaoProcedureModel> listaDescricaoProcedure { get; set; }
    }

}
