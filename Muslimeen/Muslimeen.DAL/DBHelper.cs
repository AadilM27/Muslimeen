﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Muslimeen.BLL
{
    internal class DBHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["conMuslimeen"].ConnectionString;

        #region ParamSelect()
        internal static DataTable ParamSelect(string commandName, CommandType cmdType,
            SqlParameter[] pars)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return table;
        }
        #endregion ParamSelect()
        #region NonQuery()
        public static bool NonQuery(string commandName, CommandType cmdType,
            SqlParameter[] pars)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                       
                    }
                }
            }
            return result > 0;
        }
        #endregion NonQuery()

        #region Query()
        public static bool Query(string commandName, CommandType cmdType)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = commandName;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
            }
            catch
            {
               
            }
            return result > 0;
        }
        #endregion Query()
        #region Select()
        public static DataTable Select(string commandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return table;
        }
        #endregion Select()
    }



}

