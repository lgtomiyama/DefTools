using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DefTools.DBDetail.DAO
{
    public class ProceduresInfoSQLDao
    {
        public static DataTable ListaProcedures()
        {
            try
            {
                DataTable _dt = new DataTable();
                string _connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();

                sb.Append("select NAME from sys.procedures");


                using (SqlConnection _cn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sb.ToString(), _cn))
                    {
                        _cn.Open();
                        _dt.Load(_cmd.ExecuteReader());
                    }
                }
                return _dt;
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
        }

        public static DataTable ListaDestalhesProcedures(string nomeProcedure)
        {
            try
            {
                DataTable dt = new DataTable();
                string connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT P.name AS PARAMETER_NAME, ");
                sb.Append("'' as DESCRIPTION, ");
                sb.Append("CASE WHEN TYPE_NAME(P.user_type_id) = 'CHAR' ");
                sb.Append("	THEN TYPE_NAME(P.user_type_id) + '(' + CONVERT(VARCHAR(80), P.max_length) + ')' ");
                sb.Append("WHEN TYPE_NAME(P.user_type_id) = 'VARCHAR' ");
                sb.Append("	THEN TYPE_NAME(P.user_type_id) + '(' + CONVERT(VARCHAR(80), P.max_length) + ')' ");
                sb.Append("ELSE TYPE_NAME(P.user_type_id) END AS TYPE , ");
                sb.Append("CASE WHEN P.is_output = 0 THEN 'NO' ELSE 'YES' END AS OUTPUT, ");
                sb.Append("isnull(P.default_value, '') as DEFAULT_VALUE ");
                sb.Append("FROM sys.objects AS SO ");
                sb.Append("INNER JOIN sys.parameters AS P ");
                sb.Append("	ON SO.OBJECT_ID = P.OBJECT_ID ");
                sb.Append("WHERE SO.OBJECT_ID IN ( SELECT OBJECT_ID ");
                sb.Append("						FROM sys.objects ");
                sb.Append("						WHERE TYPE IN ('P')) ");
                sb.Append("						AND SO.NAME = '" + nomeProcedure + "' ");
                sb.Append("						ORDER BY SO.name, P.parameter_id");



                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), cn))
                    {
                        cn.Open();
                        dt.Load(cmd.ExecuteReader());
                    }
                }

                foreach (DataColumn coluna in dt.Columns)
                {
                    if (coluna.ColumnName == "DESCRIPTION")
                    {
                        coluna.ReadOnly = false;
                        coluna.MaxLength = 900;
                        coluna.AllowDBNull = true;
                    }
                    else
                    {
                        coluna.ReadOnly = true;
                    }
                }
                
                return dt;
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
        }
        public static DataTable ListaGrantProcedures(string nomeProcedure)
        {
            try
            {
                DataTable dt = new DataTable();
                string connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT                                                                       ");
                sb.Append("    USER_NAME(grantee_principal_id) as principal_name, permission_name       ");
                sb.Append("FROM                                                                         ");
                sb.Append("    sys.database_permissions p                                               ");
                sb.Append("WHERE                                                                        ");
                sb.Append("    OBJECT_NAME(major_id) = '" + nomeProcedure + "'                          ");

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), cn))
                    {
                        cn.Open();
                        cmd.CommandTimeout = 10000000;
                        dt.Load(cmd.ExecuteReader());
                    }
                }

                return dt;
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
        }
    }
}
