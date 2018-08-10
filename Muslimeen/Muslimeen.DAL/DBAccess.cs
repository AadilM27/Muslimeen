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
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
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

            foreach (var prop in member.GetType().GetProperties())
            {
                if (prop.GetValue(member) != null)
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
                if (table.Rows.Count == 1)
                {

                    DataRow row = table.Rows[0];
                    getMember = new uspGetMember();

                    getMember.MemberID = Convert.ToString(row["MemberID"]);
                    getMember.MemberName = Convert.ToString(row["MemberName"]);
                    getMember.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getMember.MemberDOB = Convert.ToDateTime(row["MemberDOB"]).Date;
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
                        getMember.ActivationExpiry = Convert.ToDateTime(row["ActivationExpiry"]).Date;
                    }
                    else
                    {
                        //don't parse it
                    }
                    getMember.ActivationDate = Convert.ToDateTime(row["ActivationDate"]).Date;


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
        public uspGetMosque GetMosque(int mosqueID)
        {
            int count = 0;
            uspGetMosque mosque = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@mosqueID",mosqueID),
                new SqlParameter("@Count",count),

            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMosque",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                   
                    mosque = new uspGetMosque();
                    mosque.MosqueName = row["MosqueName"].ToString();
                    mosque.MosqueStreet = row["MosqueStreet"].ToString();
                    mosque.MosqueSuburb = row["MosqueSuburb"].ToString();
                    mosque.MosqueType = row["MosqueType"].ToString();
                    mosque.MosqueSize = row["MosqueSize"].ToString();
                    mosque.MosqueQuote = row["MosqueQuote"].ToString();
                    mosque.MemberCount = int.Parse(row["MemberCount"].ToString());
                    Byte[] bytes = (Byte[])row["MosqueImage"]; //Make byets in to base64String.
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    mosque.MosqueImage = "data:image/jpg;base64," + base64String;

                   


                }//end if
            }//end using
            return mosque;
        }//End GetMosque

        public List<uspGetAllMosques> GetAllMosques()
        {
            List<uspGetAllMosques> list = new List<uspGetAllMosques>();
            using (DataTable table = DBHelper.Select("uspGetAllMosques", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
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
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    getModerator = new uspGetModeratorDetails();


                    getModerator.ModeratorID = Convert.ToString(row["ModeratorID"]);
                    getModerator.MemberName = Convert.ToString(row["MemberName"]);
                    getModerator.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getModerator.ContactNo = Convert.ToString(row["ContactNo"]);
                    getModerator.MemberDOB = Convert.ToDateTime(row["MemberDOB"]).Date;
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
                    getModerator.ActivationDate = Convert.ToDateTime(row["ActivationDate"]).Date;
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
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    getScholarDetails = new uspGetScholarDetails();

                    getScholarDetails.ScholarID = Convert.ToString(row["ScholarID"]);
                    getScholarDetails.MemberName = Convert.ToString(row["MemberName"]);
                    getScholarDetails.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getScholarDetails.ContactNo = Convert.ToString(row["ContactNo"]);
                    getScholarDetails.MemberDOB = Convert.ToDateTime(row["MemberDOB"]).Date;
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
                    getScholarDetails.ActivationDate = Convert.ToDateTime(row["ActivationDate"]).Date;
                    getScholarDetails.Password = Convert.ToString(row["Password"]);

                }
            }
            return getScholarDetails;
        }
        //Adding Article...
        public bool AddArticle(InsertArticle article)
        {
            List<SqlParameter> par = new List<SqlParameter>();
            foreach (var p in article.GetType().GetProperties())
            {
                if (p.GetValue(article) != null)
                {
                    par.Add(new SqlParameter("@" + p.Name.ToString(), p.GetValue(article)));
                }
            }
            return DBHelper.NonQuery("uspInsertArticle", CommandType.StoredProcedure, par.ToArray());
        }
        public bool UpdateMember(UpdateMember updateMember)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            foreach (var prop in updateMember.GetType().GetProperties())
            {
                if (prop.GetValue(updateMember) != null)
                {
                    pars.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(updateMember)));
                }
            }
            return DBHelper.NonQuery("uspUpdateMember", CommandType.StoredProcedure, pars.ToArray());
        }

        public bool UpdateMemberPassword(UpdateMemberPassword updateMemberPassword)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            foreach (var prop in updateMemberPassword.GetType().GetProperties())
            {
                if (prop.GetValue(updateMemberPassword) != null)
                {
                    pars.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(updateMemberPassword)));
                }
            }
            return DBHelper.NonQuery("uspUpdateMemberPassword", CommandType.StoredProcedure, pars.ToArray());
        }

        public Zakaah GetZakaah()
        {
            Zakaah zk = new Zakaah();
            using (DataTable table = DBHelper.Select("uspGetZakaah", CommandType.StoredProcedure))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    {
                        zk.ZakaahID = Convert.ToInt32(row["ZakaahID"]);
                        zk.ZakaahDesc = Convert.ToString(row["ZakaahDesc"]);
                        zk.ZakaahConditions = Convert.ToString(row["ZakaahConditions"]);
                        zk.CalculationDesc = Convert.ToString(row["CalculationDesc"]);
                        zk.ZakaahPermissible = Convert.ToString(row["ZakaahPermissible"]);
                        zk.CautionsOfZakaah = Convert.ToString(row["CautionsOfZakaah"]);
                        zk.AssetsOfZakaah = Convert.ToString(row["AssetsOfZakaah"]);
                        zk.ApplicableZakaah = Convert.ToString(row["ApplicableZakaah"]);
                    };
                }
            }
            return zk;
        }


        //Get All Topics 
        public List<uspGetTopics> GetTopics()
        {
            List<uspGetTopics> list = new List<uspGetTopics>();
            using (DataTable tbl = DBHelper.Select("uspGetTopics", CommandType.StoredProcedure))
            {
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        uspGetTopics tops = new uspGetTopics
                        {
                            TopicID = Convert.ToInt32(row["TopicID"]),
                            TopicDescription = Convert.ToString(row["TopicDescription"])
                        };
                        list.Add(tops);
                    }
                }
            }
            return list;
        }
        public List<uspGetOrganizations> GetOrganization()
        {
            List<uspGetOrganizations> list = new List<uspGetOrganizations>();
            using (DataTable table = DBHelper.Select("uspOrganizations", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetOrganizations org = new uspGetOrganizations
                        {
                            OrgName = Convert.ToString(row["OrgName"]),
                            Address = Convert.ToString(row["Address"]),
                            OrgImageUrl = Convert.ToString(row["OrgImageUrl"]),
                            ContactNo = Convert.ToString(row["ContactNo"])

                        };
                        list.Add(org);
                    }
                }
            }
            return list;
        }

        public List<uspGetAllPendingScholars> GetAllPendingScholars()
        {
            List<uspGetAllPendingScholars> scholarsList = new List<uspGetAllPendingScholars>();
            using (DataTable table = DBHelper.Select("uspGetAllPendingScholars", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetAllPendingScholars scholar = new uspGetAllPendingScholars();

                        scholar.MemberID = Convert.ToString(row["MemberID"]);
                        scholar.MemberName = Convert.ToString(row["MemberName"]);
                        scholar.MemberLastName = Convert.ToString(row["MemberLastName"]);
                        scholar.MemberDOB = Convert.ToDateTime(row["MemberDOB"]).Date;
                        scholar.Password = Convert.ToString(row["Password"]);
                        scholar.MemberType = Convert.ToChar(row["MemberType"]);
                        scholar.ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]);
                        scholar.Email = Convert.ToString(row["Email"]);
                        scholar.ContactNo = Convert.ToString(row["ContactNo"]);
                        if (!(row["MosqueID"] is DBNull))
                        {
                            scholar.MosqueID = Convert.ToInt32(row["MosqueID"]);
                        }
                        else
                        {
                            scholar.MosqueID = null;
                        }
                        if (!(row["ActivationExpiry"] is DBNull))
                        {
                            scholar.ActivationExpiry = Convert.ToDateTime(row["ActivationExpiry"]).Date;
                        }
                        else
                        {

                        }
                        scholar.ActivationDate = Convert.ToDateTime(row["ActivationDate"]);

                        scholarsList.Add(scholar);
                    }
                }
            }
            return scholarsList;
        }

        //Pending Articles
        public List<Article> GetPendingArticle()
        {
            List<Article> list = new List<Article>();

            using (DataTable table = DBHelper.Select("uspGetPendingArticle", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Article art = new Article
                        {
                            ArticleID = Convert.ToInt32(row["ArticleID"]),
                            ArticleTitle = Convert.ToString(row["ArticleTitle"]),
                            ArticleContent = Convert.ToString(row["ArticleContent"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]),
                            Status = Convert.ToChar(row["Status"]),
                            RejectionReason = Convert.ToString(row["RejectionReason"]),
                            Active = Convert.ToChar(row["Active"]),
                            RemovalReason = Convert.ToString(row["RemovalReason"]),
                            ScholarID = Convert.ToString(row["ScholarID"]),
                            ModeratorID = Convert.ToString(row["ModeratorID"]),
                            TopicID = Convert.ToInt32(row["TopicID"])
                        };
                        list.Add(art);
                    }
                }
            }
            return list;
        }

        public bool RejectReg(uspRejectReg reject)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var property in reject.GetType().GetProperties())
            {
                if (property.GetValue(reject) != null)
                {
                    parameters.Add(new SqlParameter("@" + property.Name.ToString(), property.GetValue(reject)));
                }
            }
            return DBHelper.NonQuery("uspRejectReg", CommandType.StoredProcedure, parameters.ToArray());
        }



        public List<uspGetMosques> GetMosques(string suburb, string mosqueType)
        {
            List<uspGetMosques> list = new List<uspGetMosques>();

            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@suburb", suburb),
                new SqlParameter("@mosqueType", mosqueType)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMosques",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetMosques mosque = new uspGetMosques();

                        mosque.MosqueID = Convert.ToInt32(row["MosqueID"]);
                        mosque.MosqueName = row["MosqueName"].ToString();
                        mosque.MosqueStreet = row["MosqueStreet"].ToString();
                        mosque.MosqueSuburb = row["MosqueSuburb"].ToString();
                        mosque.MosqueType = row["MosqueType"].ToString();
                        mosque.MosqueSize = row["MosqueSize"].ToString();

                        Byte[] bytes = (Byte[])row["MosqueImage"]; //Make byets in to base64String.
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        mosque.MosqueImage = "data:image/jpg;base64," + base64String;

                        list.Add(mosque);
                    }
                }//end if
            }//end using
            return list;
        }//End GetMosques

        public List<uspGetAllMosqueSuburbs> GetAllMosqueSuburbs()
        {
            List<uspGetAllMosqueSuburbs> list = new List<uspGetAllMosqueSuburbs>();
            uspGetAllMosqueSuburbs suburbs = null;

            using (DataTable table = DBHelper.Select("uspGetAllMosqueSuburbs",
                    CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        suburbs = new uspGetAllMosqueSuburbs
                        {


                            MosqueSuburb = row["MosqueSuburb"].ToString(),


                        };
                        list.Add(suburbs);
                    }
                }//end if
            }//end using
            return list;
        }//End GetAllSuburbs


        public List<uspGetMosqueEvents> GetMosqueEvents(int MosqueID)
        {
            List<uspGetMosqueEvents> list = new List<uspGetMosqueEvents>();
            uspGetMosqueEvents events = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MosqueID",MosqueID),




            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMosqueEvents",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        events = new uspGetMosqueEvents
                        {

                            EventTitle = row["EventTitle"].ToString(),
                            EventDate = Convert.ToDateTime(row["EventDate"].ToString()),
                            EventDescription = row["EventDescription"].ToString(),
                            EventStartTime = row["EventStartTime"].ToString(),
                            EventEndTime = row["EventEndTime"].ToString(),
                            Speaker = row["Speaker"].ToString()


                        };
                        list.Add(events);
                    }
                }//end if
            }//end using
            return list;
        }//End GetMosqueEvents
        public List<uspGetMosqueEventsDateRange> GetMosqueEventsDateRange(int MosqueID, DateTime StartDate, DateTime EndDate)
        {
            List<uspGetMosqueEventsDateRange> list = new List<uspGetMosqueEventsDateRange>();
            uspGetMosqueEventsDateRange events = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MosqueID",MosqueID),
                new SqlParameter("@StartDate",StartDate),
                new SqlParameter("@EndDate",EndDate),


            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMosqueEventsDateRange",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        events = new uspGetMosqueEventsDateRange
                        {
                            EventID = int.Parse(row["EventID"].ToString()),
                            EventTitle = row["EventTitle"].ToString(),
                            EventDate = Convert.ToDateTime(row["EventDate"].ToString()),
                            EventDescription = row["EventDescription"].ToString(),
                            EventStartTime = row["EventStartTime"].ToString(),
                            EventEndTime = row["EventEndTime"].ToString(),
                            Speaker = row["Speaker"].ToString()


                        };
                        list.Add(events);
                    }
                }//end if
            }//end using
            return list;
        }//End GetMosqueEventsDateRange

        public uspGetSpecificDayPrayerTimes GetSpecficDayPrayerTimes(int mosqueID, DateTime date)
        {

            uspGetSpecificDayPrayerTimes time = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@mosqueID",mosqueID),
                 new SqlParameter("@prayerDate",date)

            };
            using (DataTable table = DBHelper.ParamSelect("uspGetSpecificDayPrayerTimes",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count ==5)
                {

                    time = new uspGetSpecificDayPrayerTimes
                    {

                        PrayerDate = Convert.ToDateTime(table.Rows[0]["PrayerDate"].ToString().Substring(0, 10)),
                        FajrA = table.Rows[0][2].ToString(),
                        FajrJ = table.Rows[0][3].ToString(),
                        DhuhrA = table.Rows[1][2].ToString(),
                        DhuhrJ = table.Rows[1][3].ToString(),
                        AsrA = table.Rows[2][2].ToString(),
                        AsrJ = table.Rows[2][3].ToString(),
                        MagribA = table.Rows[3][2].ToString(),
                        MagribJ = table.Rows[3][3].ToString(),
                        EishaA = table.Rows[4][2].ToString(),
                        EishaJ = table.Rows[4][3].ToString(),


                    };


                }//end if
            }//end using
            return time;
        }//End GetMosque

        public bool InsertPrayer(Prayer prayer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in prayer.GetType().GetProperties())
            {
                if (prop.GetValue(prayer) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(prayer)));
                }
            }
            return DBHelper.NonQuery("uspInsertPrayer", CommandType.StoredProcedure,
                parameters.ToArray());
        }


        public bool InsertPrayerType(PrayerType type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in type.GetType().GetProperties())
            {
                if (prop.GetValue(type) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(type)));
                }
            }
            return DBHelper.NonQuery("uspInsertPrayerType", CommandType.StoredProcedure,
                parameters.ToArray());
        }
        public bool UpdatePrayerType(PrayerType type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in type.GetType().GetProperties())
            {
                if (prop.GetValue(type) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(type)));
                }
            }
            return DBHelper.NonQuery("uspUpdatePrayerType", CommandType.StoredProcedure,
                parameters.ToArray());
        }


        public List<uspGetMosquePrayerTimes> GetMosquePrayerTimes(int mosqueID, DateTime StartDate, DateTime EndDate)
        {
            List<uspGetMosquePrayerTimes> list = new List<uspGetMosquePrayerTimes>();
            uspGetMosquePrayerTimes times = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MosqueID",mosqueID),
                 new SqlParameter("@StartDate",StartDate),
                  new SqlParameter("@EndDate",EndDate),

            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMosquePrayerTimes",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        times = new uspGetMosquePrayerTimes
                        {

                            PrayerDate = Convert.ToDateTime(row["PrayerDate"]),
                            PrayerDescription = row["PrayerDescription"].ToString(),
                            AdhaanTime = row["AdhaanTime"].ToString(),
                            JamaatTime = row["JamaatTime"].ToString()




                        };
                        list.Add(times);
                    }
                }//end if
            }//end using
            return list;
        }//End GetMosquePrayerTimes


        public List<uspGetAllPendingModeraters> GetAllPendingModeraters()
        {
            List<uspGetAllPendingModeraters> moderatersList = new List<uspGetAllPendingModeraters>();
            using (DataTable table = DBHelper.Select("uspGetAllPendingModeraters", CommandType.StoredProcedure))

            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        uspGetAllPendingModeraters moderater = new uspGetAllPendingModeraters();

                        moderater.MemberID = Convert.ToString(row["MemberID"]);
                        moderater.MemberName = Convert.ToString(row["MemberName"]);
                        moderater.MemberLastName = Convert.ToString(row["MemberLastName"]);
                        moderater.MemberDOB = Convert.ToDateTime(row["MemberDOB"]).Date;
                        moderater.Password = Convert.ToString(row["Password"]);
                        moderater.MemberType = Convert.ToChar(row["MemberType"]);
                        moderater.ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]);
                        moderater.Email = Convert.ToString(row["Email"]);
                        moderater.ContactNo = Convert.ToString(row["ContactNo"]);
                        if (!(row["MosqueID"] is DBNull))
                        {
                            moderater.MosqueID = Convert.ToInt32(row["MosqueID"]);
                        }
                        else
                        {
                            moderater.MosqueID = null;
                        }
                        moderater.ActivationExpiry = Convert.ToDateTime(row["ActivationExpiry"]).Date;
                        moderater.ActivationDate = Convert.ToDateTime(row["ActivationDate"]);

                        moderatersList.Add(moderater);
                    }
                }
            }
            return moderatersList;
        }




        public bool InsertEvent(Event mosqueEvent)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in mosqueEvent.GetType().GetProperties())
            {
                if (prop.GetValue(mosqueEvent) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(mosqueEvent)));
                }
            }
            return DBHelper.NonQuery("uspInsertEvent", CommandType.StoredProcedure,
                parameters.ToArray());
        }
        public bool UpdateEvent(Event mosqueEvent)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in mosqueEvent.GetType().GetProperties())
            {
                if (prop.GetValue(mosqueEvent) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(mosqueEvent)));
                }
            }
            return DBHelper.NonQuery("uspUpdateEvent", CommandType.StoredProcedure,
                parameters.ToArray());
        }
        public uspGetSpecificEvent GetSpecificEvent(int EventID)
        {

            uspGetSpecificEvent events = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@EventID",EventID),

            };
            using (DataTable table = DBHelper.ParamSelect("uspGetSpecificEvent",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    events = new uspGetSpecificEvent
                    {
                        EventTitle = row["EventTitle"].ToString(),
                        EventDate = Convert.ToDateTime(row["EventDate"].ToString()),
                        EventDescription = row["EventDescription"].ToString(),
                        EventStartTime = row["EventStartTime"].ToString(),
                        EventEndTime = row["EventEndTime"].ToString(),
                        Speaker = row["Speaker"].ToString()

                    };


                }//end if
            }//end using
            return events;
        }//End GetSpecificEvent

        public bool RemoveEvent(Event mosqueEvent)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in mosqueEvent.GetType().GetProperties())
            {
                if (prop.GetValue(mosqueEvent) != null)
                {
                    if (prop.Name.ToString() == "EventID")
                        parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(mosqueEvent)));
                }
            }
            return DBHelper.NonQuery("uspRemoveEvent", CommandType.StoredProcedure,
                parameters.ToArray());
        }

        public Article GetArticle(int articleID)
        {
            Article art = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ArticleID", articleID)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetArticle",
                         CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    art = new Article
                    {
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        ArticleTitle = Convert.ToString(row["ArticleTitle"]),
                        ArticleContent = Convert.ToString(row["ArticleContent"])
                    };
                }
            }
            return art;
        }


        public List<uspGetAcceptedArticle> GetAcceptedArticle()
        {
            List<uspGetAcceptedArticle> list = new List<uspGetAcceptedArticle>();

            using (DataTable table = DBHelper.Select("uspGetAcceptedArticle", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetAcceptedArticle art = new uspGetAcceptedArticle
                        {
                            ArticleTitle = Convert.ToString(row["ArticleTitle"]),
                            ArticleContent = Convert.ToString(row["ArticleContent"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]).Date,
                            ScholarID = Convert.ToString(row["ScholarID"]),
                            ModeratorID = Convert.ToString(row["ModeratorID"]),
                           
                        };
                        list.Add(art);
                    }
                }
            }
            return list;
        }

        public bool AcceptArticle(AcceptArticle acceptArticle)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var property in acceptArticle.GetType().GetProperties())
            {
                if (property.GetValue(acceptArticle) != null)
                {
                    parameters.Add(new SqlParameter("@" + property.Name.ToString(), property.GetValue(acceptArticle)));
                }
            }
            return DBHelper.NonQuery("uspUpdateAcceptArticle", CommandType.StoredProcedure, parameters.ToArray());
        }

        //Rejected Articles
        public List<Article> GetRejectedArticle()
        {
            List<Article> list = new List<Article>();

            using (DataTable table = DBHelper.Select("uspGetRejectedArticles", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Article art = new Article
                        {
                            ArticleID = Convert.ToInt32(row["ArticleID"]),
                            ArticleTitle = Convert.ToString(row["ArticleTitle"]),
                            //ArticleContent = Convert.ToString(row["ArticleContent"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]), 
                            RejectionReason = Convert.ToString(row["RejectionReason"]),   
                            RemovalReason = Convert.ToString(row["RemovalReason"]),
                            ScholarID = Convert.ToString(row["ScholarID"]),
                            ModeratorID = Convert.ToString(row["ModeratorID"]),
                        };
                        list.Add(art);
                    }
                }
            }
            return list;
        }

        public List<uspGetNotifications> GetNotifications (DateTime todaysDate, DateTime date)
        {
            List<uspGetNotifications> list = new List<uspGetNotifications>();
            uspGetNotifications notice = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@DateToday", todaysDate),
                new SqlParameter("@SubDate", date)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetNotifications",
                         CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    notice = new uspGetNotifications
                    {
                        NoticeID = Convert.ToInt32(row["NoticeID"]),
                        NoticeDate = Convert.ToDateTime(row["NoticeDate"]),
                        NoticeDescription = Convert.ToString(row["NoticeDescription"]),
                        NoticeTitle = Convert.ToString(row["NoticeTitle"])
                };
                    list.Add(notice);
                }
            }
            return list;
        }
        public List<uspViewLatestArticles> ViewLatestArticles(DateTime dateToday, DateTime date)
        {
            List<uspViewLatestArticles> list = new List<uspViewLatestArticles>();
            uspViewLatestArticles article = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@dateToday", dateToday),
                new SqlParameter("@date", date)
            };
            using (DataTable table = DBHelper.ParamSelect("uspViewLatestArticles",
                         CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    article = new uspViewLatestArticles
                    {
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        ArticleTitle = Convert.ToString(row["ArticleTitle"]),
                        DateCreated = Convert.ToDateTime(row["DateCreated"]),
                        Names = Convert.ToString(row["Names"])
                    };
                    list.Add(article);
                }
            }
            return list;
        }

        public Notice GetNotice(int NoticeID)
        {
            Notice notice = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NoticeID", NoticeID)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetNotice",
                         CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    notice = new Notice
                    {
                        NoticeID = Convert.ToInt32(row["NoticeID"]),
                        NoticeTitle = Convert.ToString(row["NoticeTitle"]),
                        NoticeDescription = Convert.ToString(row["NoticeDescription"]),
                        NoticeDate = Convert.ToDateTime(row["NoticeDate"])
                    };
                }
            }
            return notice;
        }

        public Event GetEventwithID(int EventID)
        {
            Event events = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@EventID",EventID)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetSpecificEvent",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    events = new Event
                    {
                 
                        EventDate = Convert.ToDateTime(row["EventDate"].ToString()),
                        EventDescription = row["EventDescription"].ToString(),
                        EventStartTime = row["EventStartTime"].ToString(),
                        EventEndTime = row["EventEndTime"].ToString(),
                        Speaker = row["Speaker"].ToString()


                    };
                }
            }
            return events;
        }

        public List<uspGetAcceptedScholars> GetAcceptedScholars()
        {
            List<uspGetAcceptedScholars> list = new List<uspGetAcceptedScholars>();
            using (DataTable table = DBHelper.Select("uspGetAcceptedScholars", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetAcceptedScholars scholar = new uspGetAcceptedScholars
                        {
                            MemberID = Convert.ToString(row["MemberID"]),
                            MemberName = Convert.ToString(row["MemberName"]),
                            MemberLastName = Convert.ToString(row["MemberLastName"]),
                            MemberDOB = Convert.ToDateTime(row["MemberDOB"]),                          
                            Email = Convert.ToString(row["Email"]),
                            ContactNo = Convert.ToString(row["ContactNo"])
                        };
                        list.Add(scholar);
                    }
                }
            }
            return list;
        }
        public List<uspGetAcceptedScholars> GetRejectedScholars()
        {
            List<uspGetAcceptedScholars> list = new List<uspGetAcceptedScholars>();
            using (DataTable table = DBHelper.Select("uspGetRejectedScholars", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetAcceptedScholars scholar = new uspGetAcceptedScholars
                        {
                            MemberID = Convert.ToString(row["MemberID"]),
                            MemberName = Convert.ToString(row["MemberName"]),
                            MemberLastName = Convert.ToString(row["MemberLastName"]),
                            MemberDOB = Convert.ToDateTime(row["MemberDOB"]),                           
                            Email = Convert.ToString(row["Email"]),
                            ContactNo = Convert.ToString(row["ContactNo"])
                        };
                        list.Add(scholar);
                    }
                }
            }
            return list;
        }

        //public List<uspViewLatestArticles> ViewLatestArticles(DateTime dateToday, DateTime date)
        //{
        //    List<uspViewLatestArticles> list = new List<uspViewLatestArticles>();
        //    using (DataTable table = DBHelper.Select("uspViewLatestArticles", CommandType.StoredProcedure))
        //    {
        //        if (table.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in table.Rows)
        //            {
        //                uspViewLatestArticles article = new uspViewLatestArticles
        //                {
        //                    ArticleTitle = Convert.ToString(row["ArticleTitle"]),
        //                    DateCreated = Convert.ToDateTime(row["DateCreated"]),
        //                    Names = Convert.ToString(row["Names"])
        //                };
        //                list.Add(article);
        //            }
        //        }
        //    }
        //    return list;
        //}

        public uspGetSelectedPendingArticle GetSelectedPendingArticle(int articleID)
        {
            uspGetSelectedPendingArticle pen = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ArticleID", articleID)
            };

            using (DataTable tbl = DBHelper.ParamSelect("uspGetSelectedPendingArticle", CommandType.StoredProcedure, pars))
            {
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];
                    pen = new uspGetSelectedPendingArticle();

                    pen.ArticleTitle = Convert.ToString(row["ArticleTitle"]);
                    pen.ArticleContent = Convert.ToString(row["ArticleContent"]);
                    pen.DateCreated = Convert.ToDateTime(row["DateCreated"]).Date;   
                }
            }
            return pen;
        }

        public bool AddMosque(uspAddMosque addMosque)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in addMosque.GetType().GetProperties())
            {
                if (prop.GetValue(addMosque) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(addMosque)));
                }
            }
            return DBHelper.NonQuery("uspAddMosque", CommandType.StoredProcedure, parameters.ToArray());

        }

        public List<uspGetMosqueReports> GetMosqueReports()
        {
            List<uspGetMosqueReports> list = new List<uspGetMosqueReports>();

            using (DataTable table = DBHelper.Select("uspGetMosqueReports", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetMosqueReports msq = new uspGetMosqueReports
                        {
                            MosqueName = Convert.ToString(row["MosqueName"]),
                            MosqueStreet = Convert.ToString(row["MosqueStreet"]),
                            MosqueSuburb = Convert.ToString(row["MosqueSuburb"]),
                            MosqueType = Convert.ToString(row["MosqueType"]),
                            MosqueSize = Convert.ToString(row["MosqueSize"]),
                            
                        };
                        list.Add(msq);
                    }
                }
            }
            return list;
        }
        public List<uspGetEventReports> GetEventReports()
        {
            List<uspGetEventReports> list = new List<uspGetEventReports>();

            using (DataTable table = DBHelper.Select("uspGetEventReports", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetEventReports eve = new uspGetEventReports
                        {
                            EventTitle = Convert.ToString(row["EventTitle"]),
                            EventStartTime = Convert.ToString(row["EventStartTime"]),
                            EventEndTime = Convert.ToString(row["EventEndTime"]),
                            Speaker = Convert.ToString(row["Speaker"]),
                            EventDescription = Convert.ToString(row["EventDescription"]),
                            EventDate = Convert.ToDateTime(row["EventDate"])

                        };
                        list.Add(eve);
                    }
                }
            }
            return list;
        }

        public uspGetMember GetMosqueRep(int mosqueID)
        {
            uspGetMember getMember = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@mosqueID", mosqueID),
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetMosqueRep", CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {

                    DataRow row = table.Rows[0];
                    getMember = new uspGetMember();

                    getMember.MemberID = Convert.ToString(row["MemberID"]);
                    getMember.MemberName = Convert.ToString(row["MemberName"]);
                    getMember.MemberLastName = Convert.ToString(row["MemberLastName"]);
                    getMember.MemberDOB = Convert.ToDateTime(row["MemberDOB"]).Date;
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
                        getMember.ActivationExpiry = Convert.ToDateTime(row["ActivationExpiry"]).Date;
                    }
                    else
                    {
                        //don't parse it
                    }
                    getMember.ActivationDate = Convert.ToDateTime(row["ActivationDate"]).Date;


                }
            }
            return getMember;
        }

        public uspGetSelectedRejectedArticle uspGetSelectedRejectedArticle(int articleID)
        {
            uspGetSelectedRejectedArticle pen = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ArticleID", articleID)
            };

            using (DataTable tbl = DBHelper.ParamSelect("uspGetSelectedRejectedArticle", CommandType.StoredProcedure, pars))
            {
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];
                    pen = new uspGetSelectedRejectedArticle();

                    pen.ArticleTitle = Convert.ToString(row["ArticleTitle"]);
                    pen.ArticleContent = Convert.ToString(row["ArticleContent"]);
                    pen.DateCreated = Convert.ToDateTime(row["DateCreated"]).Date;
                    pen.RejectionReason = Convert.ToString(row["RejectionReason"]);
                }
            }
            return pen;
        }
    }
}

