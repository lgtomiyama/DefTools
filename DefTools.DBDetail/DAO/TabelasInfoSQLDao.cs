using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DefTools.DBDetail.DAO
{
    public class TabelasInfoSQLDao
    {
        public static DataTable ListaTabelas()
        {
            try
            {
                DataTable _dt = new DataTable();
                string _connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT TABLE_NAME ");
                sb.Append("FROM INFORMATION_SCHEMA.TABLES ");
                sb.Append("WHERE TABLE_TYPE = 'BASE TABLE'");
                sb.Append("ORDER BY TABLE_NAME");

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

        public static DataTable ListaDestalhesTabelas(string nomeTabela)
        {
            try
            {
                DataTable _dt = new DataTable();
                string _connectionString = Global.ConnectionString;


                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COLUMN_NAME, ");
                sb.Append("'' AS COLUMN_DESCRIPTION , ");
                sb.Append("CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NULL ");
                sb.Append("	THEN DATA_TYPE ");
                sb.Append("	ELSE DATA_TYPE + '(' + CONVERT(VARCHAR(80), CHARACTER_MAXIMUM_LENGTH) + ')' ");
                sb.Append("END  AS DATA_TYPE , ");
                sb.Append("IS_NULLABLE ");
                sb.Append("FROM INFORMATION_SCHEMA.COLUMNS ");
                sb.Append("WHERE TABLE_NAME = '" + nomeTabela + "' ");
                sb.Append("ORDER BY ORDINAL_POSITION ");

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

        internal static string SchemaTabela(string nomeTabela)
        {
            try
            {
                DataTable _dt = new DataTable();
                DataTable dtCols;
                string _connectionString = Global.ConnectionString;
                using (SqlConnection _cn = new SqlConnection(_connectionString))
                {
                    _cn.Open();
                    dtCols = _cn.GetSchema("Tables", new[] { Global.banco, null, nomeTabela });
                }
                return dtCols.Rows[0]["TABLE_SCHEMA"].ToString();
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
        }
        public static DataTable DependenciasFK(string nomeTabela)
        {
            try
            {
                DataTable _dt = new DataTable();
                string _connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT                                                                        ");
                sb.Append("    COL_NAME(fc.parent_object_id, fc.parent_column_id) AS Coluna,             ");
                sb.Append("    OBJECT_NAME (f.referenced_object_id) AS TabelaOrigem,                     ");
                sb.Append("    COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS CampoOrigem ");
                sb.Append("FROM sys.foreign_keys AS f                                                    ");
                sb.Append("INNER JOIN sys.foreign_key_columns AS fc                                      ");
                sb.Append("ON f.OBJECT_ID = fc.constraint_object_id                                      ");
                sb.Append("WHERE OBJECT_NAME(f.parent_object_id) = '" + nomeTabela + "'   				 ");
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
        public static DataTable ChavesPrimarias(string nomeTabela)
        {
            try
            {
                DataTable _dt = new DataTable();
                string _connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT column_name                                                  ");
                sb.Append("FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE                            ");
                sb.Append("WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1");
                sb.Append("AND table_name = '" + nomeTabela + "'                               ");
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
        public static DataTable Permissoes(string nomeTabela)
        {
            try
            {
                DataTable _dt = new DataTable();
                string _connectionString = Global.ConnectionString;

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT p1.GRANTEE,                             ");
                sb.Append("( SELECT  PRIVILEGE_TYPE + ','                 ");
                sb.Append("	FROM INFORMATION_SCHEMA.TABLE_PRIVILEGES p2   ");
                sb.Append("		WHERE p2.GRANTEE = p1.GRANTEE             ");
                sb.Append("		AND P2.table_name = P1.table_name         ");
                sb.Append("	FOR XML PATH('')                              ");
                sb.Append(") AS PERMISSION                                ");
                sb.Append("	FROM INFORMATION_SCHEMA.TABLE_PRIVILEGES p1   ");
                sb.Append("	WHERE P1.table_name = '" + nomeTabela + "'    ");
                sb.Append("GROUP BY GRANTEE ,table_name                   ");
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
    }
}
