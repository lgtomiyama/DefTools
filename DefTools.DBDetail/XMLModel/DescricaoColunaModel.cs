using System.Xml.Serialization;
using System;

namespace DefTools.DBDetail.XMLModel
{
    [Serializable()]
    public class DescricaoColunaModel
    {
        [XmlElement("Coluna")]
        public string NomeColuna { get; set; }

        [XmlElement("DescricaoEN")]
        public string DescricaoEN { get; set; }

        [XmlElement("DescricaoPT")]
        public string DescricaoPT { get; set; }
        
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
    }
}
