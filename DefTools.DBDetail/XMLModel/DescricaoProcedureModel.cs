using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DefTools.DBDetail.XMLModel
{
    [Serializable()]
    public class DescricaoProcedureModel
    {
        [XmlElement("Procedure")]
        public string NomeProcedure { get; set; }

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
