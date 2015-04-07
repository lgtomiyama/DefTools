using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DefTools.DBDetail.Model
{
    public class ProcedureInfoModel
    {
        public string nomeProcedure { get; set; }
        public DataTable dtParam { get; set; }
        public string descricaoProcedure { get; set; }
        public DataTable dtPermissoes { get; set; }
    }
}
