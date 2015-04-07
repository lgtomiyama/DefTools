using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DefTools.DBDetail.Model
{
    public class TableInfoModel
    {
        public DataTable dtDetalheColunas { get; set; }
        public DataTable dtReferenciasFK { get; set; }
        public DataTable dtPermissoes { get; set; }
        public string nomeTabela { get; set; }
        public string descricaoTabela { get; set; }
        public string nomeBase { get; set; }
        public string schema { get; set; }
        public string chavesPrimarias { get; set; }

        public List<string> dtRegras { get; set; }
    }

}
