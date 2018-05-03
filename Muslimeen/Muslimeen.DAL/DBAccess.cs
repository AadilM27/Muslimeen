using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.ViewModels;
using TypeLib.Models;
using System.Data;
using System.Data.SqlClient;


namespace Muslimeen.BLL
{
    public class DBAccess
    {

        public List<uspGetQualification> GetQualification()
        {
            List<uspGetQualification> list = new List<uspGetQualification>();
            using (DataTable table = DBHelper.Select("uspGetQualification", CommandType.StoredProcedure))
            {
                if(table.Rows.Count > 0)
                {
                    foreach(DataRow row in table.Rows)
                    {
                        uspGetQualification quali = new uspGetQualification
                        {
                            QualificationID = row["QualificationID"].ToString(),
                            QualificationDescription = row["QualificationDescription"].ToString()
                        };
                        list.Add(quali);
                    }
                }
            }
            return list;
        }

        public bool AddUser(Member user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach(var prop in user.GetType().GetProperties())
            {
                if(prop.GetValue(user) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(user)));
                }
            }
            return DBHelper.NonQuery("usp", CommandType.StoredProcedure, parameters.ToArray());
        }

    }
}
