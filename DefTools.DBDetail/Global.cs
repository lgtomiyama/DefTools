using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DefTools.DBDetail
{
    public static class Global
    {

        public static Idioma idioma { get; set; }
        public const string nomeSistema = "DBDetail";

        #region Banco
        public static string servidor { get; set; }

        public static int autenticacao { get; set; }

        public static string usuarioBanco { get; set; }


        public static string senha { get; set; }

        public static string banco { get; set; }

        public static DataTable listaBancos { get; set; }

        public static bool windowsLogon { get; set; }

        public static string ConnectionString
        {
            get
            {
                if (windowsLogon)
                    return "server=" + servidor + ";Integrated Security=SSPI;Initial Catalog=" + banco + ";";
                else
                    return "server=" + servidor + ";User Id=" + usuario + ";" + "pwd=" + senha + ";Initial Catalog=" + banco + ";";
            }
            set
            {
                ConnectionString = value;
            }
        }
#endregion
        #region Linguagem


        public static string colunaEntidade
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Tabela: ";
                    case Global.Idioma.ENG:
                        return "Entity: ";
                    default:
                        return "Entity: ";
                }
            }
        }

        public static string colunaNomeProc
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Nome do Procedimento: ";
                    case Global.Idioma.ENG:
                        return "Procedure Name: ";
                    default:
                        return "Procedure Name: ";
                }
            }
        }


        public static string colunaDescProc
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Descrição / Implementação: ";
                    case Global.Idioma.ENG:
                        return "Description / Implementation: ";
                    default:
                        return "Description / Implementation: ";
                }
            }
        }

        public static string colunaParam 
        {
            get 
            {
                switch (idioma) 
                {
                    case Global.Idioma.PTB:
                        return "Parâmetro:";
                    case Global.Idioma.ENG:
                        return "Parameter:";
                    default:
                        return "Parameter:";
                }
            }
        }

        public static string colunaParamType
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Tipo:";
                    case Global.Idioma.ENG:
                        return "Type:";
                    default:
                        return "Type:";
                }
            }
        }

        public static string descricao
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Descrição: ";
                    case Global.Idioma.ENG:
                        return "Description: ";
                    default:
                        return "Description: ";
                }
            }
        }

        public enum Idioma
        {
            PTB,
            ENG
        }

        public static string BaseDeDados
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Banco de dados: ";
                    case Global.Idioma.ENG:
                        return "Database: ";
                    default:
                        return "Database: ";
                }
            }
        }

        public static string Esquema
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Schema: ";
                    case Global.Idioma.ENG:
                        return "Schema: ";
                    default:
                        return "Schema: ";
                }
            }
        }

        public static string aceitaNulo
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Aceita Nulo: ";
                    case Global.Idioma.ENG:
                        return "Allows null: ";
                    default:
                        return "Allows null: ";
                }
            }
        }

        public static string tipoDados
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Tipo de Dados: ";
                    case Global.Idioma.ENG:
                        return "Data type: ";
                    default:
                        return "Data type: ";
                }
            }
        }

        public static string descricaoColuna
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Descrição Coluna: ";
                    case Global.Idioma.ENG:
                        return "Column description: ";
                    default:
                        return "Column description: ";
                }
            }
        }

        public static string Coluna
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Coluna: ";
                    case Global.Idioma.ENG:
                        return "Column: ";
                    default:
                        return "Column: ";
                }
            }
        }

        internal static string getIsNullable(string YesNo)
        {
            if (YesNo.Equals("Yes"))
            {
                if (idioma == Idioma.PTB)
                    return "Sim";
                else
                    return "Yes";
            }
            else
            {
                if (idioma == Idioma.PTB)
                    return "Não";
                else
                    return "No";
            }
        }

        public static string origemColunaFk
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Coluna da origem: ";
                    case Global.Idioma.ENG:
                        return "Column on origin table: ";
                    default:
                        return "Origin database/table: ";
                }
            }
        }

        public static string origemTabelaFk
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Origem: ";
                    case Global.Idioma.ENG:
                        return "Origin database/table: ";
                    default:
                        return "Origin database/table: ";
                }
            }
        }

        public static string chavePrimaria
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Chave Primaria: ";
                    case Global.Idioma.ENG:
                        return "Primary Key: ";
                    default:
                        return "Primary Key: ";
                }
            }
        }

        public static string usuario
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Usuário: ";
                    case Global.Idioma.ENG:
                        return "User: ";
                    default:
                        return "User: ";
                }
            }
        }

        public static string permissao
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Permissão: ";
                    case Global.Idioma.ENG:
                        return "Permission: ";
                    default:
                        return "Permission: ";
                }
            }
        }

        public static string grant
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Permissões: ";
                    case Global.Idioma.ENG:
                        return "Grant: ";
                    default:
                        return "Grant: ";
                }
            }
        }

        public static string chaveEstrangeira
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Chave Estrangeira: ";
                    case Global.Idioma.ENG:
                        return "Foreign key: ";
                    default:
                        return "Foreign key: ";
                }
            }
        }


        public static string regrasNegocio
        {
            get
            {
                switch (idioma)
                {
                    case Global.Idioma.PTB:
                        return "Regras de negócio: ";
                    case Global.Idioma.ENG:
                        return "Business rules: ";
                    default:
                        return "Business rules: ";
                }
            }
        }
        #endregion
    }
}
