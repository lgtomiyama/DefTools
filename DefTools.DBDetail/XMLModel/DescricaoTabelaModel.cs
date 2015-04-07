using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DefTools.DBDetail.XMLModel
{
    [Serializable()]
    public class DescricaoTabelaModel
    {
        [XmlElement("NomeTabela")]
        public string NomeTabela { get; set; }

        [XmlElement("DescricaoEN")]
        public string DescricaoEN { get; set; }

        [XmlElement("DescricaoPT")]
        public string DescricaoPT { get; set; }

        [XmlElement("RegrasPT")]
        public List<string> RegrasPT { get; set; }
        
        [XmlElement("RegrasEN")]
        public List<string> RegrasEN { get; set; }

        [XmlIgnore]
        public string Descricao
        {
            get
            {
                switch (Global.idioma)
                {
                    case Global.Idioma.PTB:
                        return DescricaoPT;
                    case Global.Idioma.ENG:
                        return DescricaoEN;
                    default:
                        return DescricaoEN;
                }
            }
            set
            {
                switch (Global.idioma)
                {
                    case Global.Idioma.PTB:
                        DescricaoPT = value;
                        break;
                    case Global.Idioma.ENG:
                        DescricaoEN = value;
                        break;
                    default:
                        DescricaoEN = value;
                        break;
                }
            }
        }
        [XmlIgnore]
        public List<string> Regras
        {
            get
            {
                switch (Global.idioma)
                {
                    case Global.Idioma.PTB:
                        return RegrasPT;
                    case Global.Idioma.ENG:
                        return RegrasEN;
                    default:
                        return RegrasEN;
                }
            }
            set
            {
                switch (Global.idioma)
                {
                    case Global.Idioma.PTB:
                        RegrasPT = value;
                        break;
                    case Global.Idioma.ENG:
                        RegrasEN = value;
                        break;
                    default:
                        RegrasEN = value;
                        break;
                }
            }
        }
    }
}
