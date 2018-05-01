using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TypeLib.ViewModels;
using TypeLib.Models;



namespace Muslimeen.DAL
{
    public class DBAccess
    {

        public List<uspGetQualification> GetQualification()
        {
            List<uspGetQualification> list = new List<uspGetQualification>();
            using (DataTable table = DBHelper.Select("uspGetQualification",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetQualification qualification = new uspGetQualification
                        {
                            QualificationID = (row["QualificationID"]).ToString(),
                            QualificationDescription = row["QualificationDescription"].ToString()
                        };
                        list.Add(qualification);
                    }
                }
            }
            return list;
        }
    }

    
}
