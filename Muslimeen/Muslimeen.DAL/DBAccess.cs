using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.ViewModels;
using TypeLib.Models;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


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
                            QualificationID = Convert.ToString(row["QualificationID"]),
                            QualificationDescription = Convert.ToString(row["QualificationDescription"])
                        };
                        list.Add(quali);
                    }
                }
            }
            return list;
        }

        public bool AddMember(Member member)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach(var prop in member.GetType().GetProperties())
            {
                if(prop.GetValue(member) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(member)));
                }
            }
            return DBHelper.NonQuery("uspAddMember", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool AddScholarQualification(Scholar scholar)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in scholar.GetType().GetProperties())
            {
                if (prop.GetValue(scholar) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(scholar)));
                }
            }
            return DBHelper.NonQuery("uspAddScholarQualification", CommandType.StoredProcedure, parameters.ToArray());

        }

        public uspGetMember GetMember(string memberID)
        {
            uspGetMember getMember = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MemberID", memberID),
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMember", CommandType.StoredProcedure, pars))
            { 
                if(table.Rows.Count == 1)
                {

                    DataRow row = table.Rows[0];
                    getMember = new uspGetMember();

                    getMember.MemberID = Convert.ToString(row["MemberID"]);
                    getMember.MemberName = Convert.ToString(row["MemberName"]);
                    getMember.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getMember.MemberDOB = Convert.ToDateTime(row["MemberDOB"]);
                    getMember.Password = Convert.ToString(row["Password"]);
                    getMember.MemberType = Convert.ToChar(row["MemberType"]);
                    getMember.ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]);
                    getMember.Email = Convert.ToString(row["Email"]);
                    getMember.ContactNo = Convert.ToString(row["ContactNo"]);
                    if (!(row["MosqueID"] is DBNull))
                    {
                        getMember.MosqueID = Convert.ToInt32(row["MosqueID"]);
                    }
                    else
                    {
                        getMember.MosqueID = null;
                    }
                    if (!(row["ActivationExpiry"] is DBNull))
                    {
                        getMember.ActivationExpiry = Convert.ToDateTime(row["ActivationExpiry"]);
                    }
                    else
                    {
                        getMember.ActivationExpiry = null;
                    }
                    getMember.ActivationDate = Convert.ToDateTime(row["ActivationDate"]);
                        
                    
                }
            }
            return getMember;
        }

        public bool VerifyMember(uspVerifyMember uspVerifyMember)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var property in uspVerifyMember.GetType().GetProperties())
            {
                if (property.GetValue(uspVerifyMember) != null)
                {
                    parameters.Add(new SqlParameter("@" + property.Name.ToString(), property.GetValue(uspVerifyMember)));
                }
            }
            return DBHelper.NonQuery("uspVerifyMember", CommandType.StoredProcedure, parameters.ToArray());
        }
        public List<uspGetMosque> GetMosque()
        {
            List<uspGetMosque> list = new List<uspGetMosque>();
            using (DataTable table = DBHelper.Select("uspGetMosque", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetMosque mosque = new uspGetMosque
                        {
                            MosqueName = Convert.ToString(row["MosqueName"]),
                            MosqueType = Convert.ToString(row["MosqueType"]),
                            MosqueAddress=Convert.ToString(row["MosqueAddress"]),
                            MosqueSize=Convert.ToString(row["MosqueSize"]),
                            MosqueImage=Convert.ToString(row["MosqueImage"]),
                            LocationIMG=Convert.ToString(row["LocationIMG"]),
                            LocationLink=Convert.ToString(row["LocationLink"])
                            
                        };
                        list.Add(mosque);
                    }
                }
            }
            return list;
        }

        public List<uspGetAllMosques> GetAllMosques()
        {
            List<uspGetAllMosques> list = new List<uspGetAllMosques>();
            using (DataTable table = DBHelper.Select("uspGetAllMosques", CommandType.StoredProcedure))
            {
                if(table.Rows.Count > 0)
                {
                    foreach(DataRow row in table.Rows)
                    {
                        uspGetAllMosques mosque = new uspGetAllMosques
                        {
                            MosqueID = Convert.ToInt32(row["MosqueID"]),
                            MosqueName = Convert.ToString(row["MosqueName"])
                        };
                        list.Add(mosque);
                    }
                }
            }
            return list;
        }

        public uspGetModeratorDetails GetModeratorDetails(string memberID)
        {
            uspGetModeratorDetails getModerator = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MemberID", memberID)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetModeratorDetails", CommandType.StoredProcedure, pars))
            {
                if(table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    getModerator = new uspGetModeratorDetails();


                    getModerator.ModeratorID = Convert.ToString(row["ModeratorID"]);
                    getModerator.MemberName = Convert.ToString(row["MemberName"]);
                    getModerator.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getModerator.ContactNo = Convert.ToString(row["ContactNo"]);
                    getModerator.MemberDOB = Convert.ToDateTime(row["MemberDOB"]);
                    getModerator.Email = Convert.ToString(row["Email"]);
                    getModerator.MemberType = Convert.ToChar(row["MemberType"]);
                    getModerator.QualificationDescription = Convert.ToString(row["QualificationDescription"]);
                    if (!(row["MosqueID"] is DBNull))
                    {
                        getModerator.MosqueID = Convert.ToInt32(row["MosqueID"]);
                    }
                    else
                    {
                        getModerator.MosqueID = null;
                    }
                    getModerator.ActivationDate = Convert.ToDateTime(row["ActivationDate"]);
                    getModerator.Password = Convert.ToString(row["Password"]);
                    
                }
            }
            return getModerator;
        }

        public uspGetScholarDetails GetScholarDetails(string memberID)
        {
            uspGetScholarDetails getScholarDetails = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MemberID", memberID)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetScholarDetails", CommandType.StoredProcedure, pars))
            {
                if(table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    getScholarDetails = new uspGetScholarDetails();

                    getScholarDetails.ScholarID = Convert.ToString(row["ScholarID"]);
                    getScholarDetails.MemberName = Convert.ToString(row["MemberName"]);
                    getScholarDetails.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getScholarDetails.ContactNo = Convert.ToString(row["ContactNo"]);
                    getScholarDetails.MemberDOB = Convert.ToDateTime(row["MemberDOB"]);
                    getScholarDetails.Email = Convert.ToString(row["Email"]);
                    getScholarDetails.MemberType = Convert.ToChar(row["MemberType"]);
                    getScholarDetails.QualificationDescription = Convert.ToString(row["QualificationDescription"]);
                    if (!(row["MosqueID"] is DBNull))
                    {
                        getScholarDetails.MosqueID = Convert.ToInt32(row["MosqueID"]);
                    }
                    else
                    {
                        getScholarDetails.MosqueID = null;
                    }
                    getScholarDetails.ActivationDate = Convert.ToDateTime(row["ActivationDate"]);
                    getScholarDetails.Password = Convert.ToString(row["Password"]);
                    
                }
            }
            return getScholarDetails;
        }
    }
}
