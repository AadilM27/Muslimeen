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
                    if (!(row["MosqueImage"] is DBNull))
                    {
                        mosque.MosqueImage = row["MosqueImage"].ToString(); ; //Make byets in to base64String.
                    }
                    else
                    {
                        mosque.MosqueImage = "";
                    }
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
        public List<Organization> GetOrganization()
        {
            List<Organization> list = new List<Organization>();
            using (DataTable table = DBHelper.Select("uspOrganizations", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Organization org = new Organization();

                        org.OrganizationID = Convert.ToInt32(row["OrganizationID"]);
                        org.Name = Convert.ToString(row["Name"]);
                        org.WebsiteAddress = Convert.ToString(row["WebsiteAddress"]);
                        org.ContactNo = Convert.ToString(row["ContactNo"]);
                        org.Active = Convert.ToChar(row["Active"]);

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
                        if (!(row["MosqueImage"] is DBNull))
                        {
                            mosque.MosqueImage = row["MosqueImage"].ToString();
                        }
                        else
                        {
                            mosque.MosqueImage = "";
                        }
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
                            EventID = Convert.ToInt32(row["EventID"].ToString()),
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
                if (table.Rows.Count == 5)
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
                        EventID = Convert.ToInt32(row["EventID"].ToString()),
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
                        ArticleContent = Convert.ToString(row["ArticleContent"]),
                        DateCreated =Convert.ToDateTime(row["DateCreated"]),
                        ScholarID= Convert.ToString(row["ScholarID"])
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

        public bool RejectArticle(RejectArticle rejectArticle)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var property in rejectArticle.GetType().GetProperties())
            {
                if (property.GetValue(rejectArticle) != null)
                {
                    parameters.Add(new SqlParameter("@" + property.Name.ToString(), property.GetValue(rejectArticle)));
                }
            }
            return DBHelper.NonQuery("uspUpdateRejectArticle", CommandType.StoredProcedure, parameters.ToArray());
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
                            ScholarID = Convert.ToString(row["ScholarID"]),
                            ModeratorID = Convert.ToString(row["ModeratorID"]),
                        };
                        list.Add(art);
                    }
                }
            }
            return list;
        }

        public List<uspGetNotifications> GetNotifications(DateTime todaysDate, DateTime date)
        {
            List<uspGetNotifications> list = new List<uspGetNotifications>();
            uspGetNotifications notice = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@DateToday", todaysDate),
                new SqlParameter("@SubDate", date)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetSpecificNotifications",
                         CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    foreach(DataRow row in table.Rows)
                    {
                        notice = new uspGetNotifications
                        {
                            NoticeID = Convert.ToInt32(row["NoticeID"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]),
                            NoticeDescription = Convert.ToString(row["NoticeDescription"]),
                            NoticeTitle = Convert.ToString(row["NoticeTitle"])
                        };
                        list.Add(notice);
                    }
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
                    foreach (DataRow row in table.Rows)
                    {
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
                        DateCreated = Convert.ToDateTime(row["DateCreated"])
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

                            MemberName = Convert.ToString(row["MemberName"]),
                            MemberLastName = Convert.ToString(row["MemberLastName"]),
                            MemberDOB = Convert.ToDateTime(row["MemberDOB"]),
                            ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]),
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

                            MemberName = Convert.ToString(row["MemberName"]),
                            MemberLastName = Convert.ToString(row["MemberLastName"]),
                            MemberDOB = Convert.ToDateTime(row["MemberDOB"]),
                            ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]),
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
                    string dateCreated = Convert.ToDateTime(row["DateCreated"]).ToString("dd MMM yyyy HH:mm:ss tt");
                    pen.DateCreated = Convert.ToDateTime(dateCreated);
                    pen.ScholarName = Convert.ToString(row["Scholar Name"]);
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

        public bool AddModeraterQualification(Moderater moderater)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in moderater.GetType().GetProperties())
            {
                if (prop.GetValue(moderater) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(moderater)));
                }
            }
            return DBHelper.NonQuery("uspAddModeraterQualification", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool AddZakaahOrganization(uspAddZakaahOrg organization)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in organization.GetType().GetProperties())
            {
                if (prop.GetValue(organization) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(organization)));
                }
            }
            return DBHelper.NonQuery("uspAddZakaahOrganization", CommandType.StoredProcedure, parameters.ToArray());

        }

        public Organization GetSelectedZakaahOrg(int organizationID)
        {
            Organization org = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@OrganizationID", organizationID)
            };

            using (DataTable tbl = DBHelper.ParamSelect("uspGetSelectedOrg", CommandType.StoredProcedure, pars))
            {
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];
                    org = new Organization();

                    org.OrganizationID = Convert.ToInt32(row["OrganizationID"]);
                    org.Name = Convert.ToString(row["Name"]);
                    org.WebsiteAddress = Convert.ToString(row["WebsiteAddress"]);
                    if (!(row["Image"] is DBNull))
                    {
                        org.Image = row["Image"].ToString();
                    }
                    else
                    {
                        org.Image = "";
                    }
                    org.ContactNo = Convert.ToString(row["ContactNo"]);
                    org.PhysicalAddress = Convert.ToString(row["PhysicalAddress"]);
                    org.Active = Convert.ToChar(row["Active"]);
                }
            }
            return org;
        }

        public bool UpdateZakaahOrg(uspUpdateZakaahOrg updateZakaahOrg)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            foreach (var prop in updateZakaahOrg.GetType().GetProperties())
            {
                if (prop.GetValue(updateZakaahOrg) != null)
                {
                    pars.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(updateZakaahOrg)));
                }
            }
            return DBHelper.NonQuery("uspUpdateZakaahOrg", CommandType.StoredProcedure, pars.ToArray());
        }

        public bool AddNotice(Notice notice)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            foreach (var prop in notice.GetType().GetProperties())
            {
                if (prop.GetValue(notice) != null)
                {
                    pars.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(notice)));
                }
            }
            return DBHelper.NonQuery("uspAddNotice", CommandType.StoredProcedure, pars.ToArray());
        }

        public bool UpdateNotice(Notice notice)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in notice.GetType().GetProperties())
            {
                if (prop.GetValue(notice) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(notice)));
                }
            }
            return DBHelper.NonQuery("uspUpdateNotice", CommandType.StoredProcedure,
                parameters.ToArray());

        }

        public List<Notice> GetAllNotices()
        {
            List<Notice> list = new List<Notice>();

            using (DataTable table = DBHelper.Select("uspGetAllNotices", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Notice eve = new Notice
                        {
                            NoticeID = Convert.ToInt32(row["NoticeID"]),
                            NoticeTitle = Convert.ToString(row["NoticeTitle"]),
                            NoticeDescription = Convert.ToString(row["NoticeDescription"]),
                            MemberID = Convert.ToString(row["MemberID"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]),
                            DateExpiry = Convert.ToDateTime(row["DateExpiry"]),
                            Active = Convert.ToChar(row["Active"])
                        };
                        list.Add(eve);
                    }
                }
            }
            return list;
        }

        public Notice GetSelectedNotice(int noticeID)
        {
            Notice notice = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NoticeID", noticeID)
            };

            using (DataTable tbl = DBHelper.ParamSelect("uspGetSelectedNotice", CommandType.StoredProcedure, pars))
            {
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];
                    notice = new Notice
                    {
                        NoticeID = Convert.ToInt32(row["NoticeID"]),
                        NoticeTitle = Convert.ToString(row["NoticeTitle"]),
                        NoticeDescription = Convert.ToString(row["NoticeDescription"]),
                        MemberID = Convert.ToString(row["MemberID"]),
                        DateCreated = Convert.ToDateTime(row["DateCreated"]),
                        DateExpiry = Convert.ToDateTime(row["DateExpiry"]),
                        Active = Convert.ToChar(row["Active"])
                    };
                }
            }
            return notice;
        }

        public List<Article> GetLearnArticle()
        {
            List<Article> list = new List<Article>();
            using (DataTable table = DBHelper.Select("uspGetLearnArticle", CommandType.StoredProcedure))
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

        public uspGetSelectedLearnArticle GetSelectedLearnArticle(int articleID)
        {
            uspGetSelectedLearnArticle pen = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ArticleID", articleID)
            };

            using (DataTable tbl = DBHelper.ParamSelect("uspGetSelectedLearnArticle", CommandType.StoredProcedure, pars))
            {
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];

                    pen = new uspGetSelectedLearnArticle();

                    pen.ArticleTitle = Convert.ToString(row["ArticleTitle"]);
                    pen.ArticleContent = Convert.ToString(row["ArticleContent"]);
                    pen.DateCreated = Convert.ToDateTime(row["DateCreated"]).Date;
                    pen.ScholarName = Convert.ToString(row["Scholar Name"]);
                }
            }
            return pen;
        }

        public List<CounterCalender> GetCounterCalender()
        {
            List<CounterCalender> list = new List<CounterCalender>();
            using (DataTable table = DBHelper.Select("uspGetCounterCalender", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        CounterCalender cc = new CounterCalender
                        {
                            ID = Convert.ToString(row["ID"]),
                            Val = Convert.ToString(row["Val"])
                        };
                        list.Add(cc);
                    }
                }
            }
            return list;
        }

        public bool UpdateIslamicDate(uspUpdateIslamicDate updateIslamicDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in updateIslamicDate.GetType().GetProperties())
            {
                if (prop.GetValue(updateIslamicDate) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(updateIslamicDate)));
                }
            }
            return DBHelper.NonQuery("uspUpdateIslamicDate", CommandType.StoredProcedure,
                parameters.ToArray());
        }

        public bool UpdateCountDown(uspUpdateCountDown updateCountDown)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in updateCountDown.GetType().GetProperties())
            {
                if (prop.GetValue(updateCountDown) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(updateCountDown)));
                }
            }
            return DBHelper.NonQuery("uspUpdateCountDown", CommandType.StoredProcedure,
                parameters.ToArray());
        }
        public List<RejectedArticlesReport> GetRejectedArticlesReport()
        {
            List<RejectedArticlesReport> list = new List<RejectedArticlesReport>();
            using (DataTable table = DBHelper.Select("uspGetRejectedArticles", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        RejectedArticlesReport reject = new RejectedArticlesReport
                        {

                            ArticleTitle = Convert.ToString(row["ArticleTitle"]),
                            ArticleContent = Convert.ToString(row["ArticleContent"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]),
                            RejectionReason = Convert.ToString(row["RejectionReason"]),
                            ScholarID = Convert.ToString(row["ScholarID"]),
                            ModeratorID = Convert.ToString(row["ModeratorID"]),

                        };
                        list.Add(reject);
                    }
                }
            }
            return list;
        }

        //Update Article
        public bool UpdateArticle(UpdateArticle Art)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in Art.GetType().GetProperties())
            {
                if (prop.GetValue(Art) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(Art)));
                }
            }
            return DBHelper.NonQuery("uspUpdateArticle", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool UpdateMosque(Mosques mosque)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in mosque.GetType().GetProperties())
            {
                if (prop.GetValue(mosque) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(mosque)));
                }
            }
            return DBHelper.NonQuery("uspUpdateMosque", CommandType.StoredProcedure,
                parameters.ToArray());
        }

        public List<Mosques> GetMosques()
        {
            List<Mosques> list = new List<Mosques>();

            using (DataTable table = DBHelper.Select("uspGetAllMosqueDetails",
                    CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Mosques mosque = new Mosques();

                        mosque.MosqueID = Convert.ToInt32(row["MosqueID"]);
                        mosque.MosqueName = row["MosqueName"].ToString();
                        mosque.MosqueStreet = row["MosqueStreet"].ToString();
                        mosque.MosqueSuburb = row["MosqueSuburb"].ToString();
                        mosque.MosqueType = row["MosqueType"].ToString();
                        mosque.MosqueSize = row["MosqueSize"].ToString();
                        if (!(row["MosqueImage"] is DBNull))
                        {
                            mosque.MosqueImage = row["MosqueImage"].ToString();
                        }
                        else
                        {
                            mosque.MosqueImage = "/Content/Images/ImageUnavailable.jpg";
                        }
                        mosque.YearEstablished = Convert.ToDateTime(row["YearEstablished"]);
                        mosque.Active = Convert.ToChar(row["Active"]);

                        list.Add(mosque);
                    }
                }
            }
            return list;
        }

        public Mosques GetSpecificMosque(int mosqueID)
        {
            Mosques mosque = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MosqueID", mosqueID)
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetSpecificMosque",
                    CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    mosque = new Mosques
                    {
                        MosqueID = Convert.ToInt32(row["MosqueID"]),
                        MosqueName = Convert.ToString(row["MosqueName"]),
                        MosqueStreet = Convert.ToString(row["MosqueStreet"]),
                        MosqueSuburb = Convert.ToString(row["MosqueSuburb"]),
                        MosqueSize = Convert.ToString(row["MosqueSize"]),
                        MosqueImage = Convert.ToString(row["MosqueImage"]),
                        MosqueQuote = Convert.ToString(row["MosqueQuote"]),
                        MosqueType = Convert.ToString(row["MosqueType"]),
                        YearEstablished = Convert.ToDateTime(row["YearEstablished"]),
                        Active = Convert.ToChar(row["Active"])
                    };
                }
            }
            return mosque;
        }

        public List<Member> GetAllMembers()
        {
            List<Member> list = new List<Member>();
            using (DataTable table = DBHelper.Select("uspGetAllMembers", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Member member = new Member();

                        member.MemberID = row["MemberID"].ToString();
                        member.MemberName = row["MemberName"].ToString();
                        member.MemberLastName = row["MemberLastName"].ToString();
                        member.MemberDOB = Convert.ToDateTime(row["MemberDOB"]);
                        member.Password = Convert.ToString(row["Password"]);
                        member.MemberType = Convert.ToChar(row["MemberType"]);
                        member.ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]);
                        member.Email = Convert.ToString(row["Email"]);
                        if (!(row["ContactNo"] is DBNull))
                        {
                            member.ContactNo = Convert.ToString(row["ContactNo"]);
                        }
                        else
                        {
                            member.ContactNo = "";
                        }

                        if (!(row["MosqueID"] is DBNull))
                        {
                            member.MosqueID = Convert.ToInt32(row["MosqueID"]);
                        }
                        else
                        {
                            member.MosqueID = null;
                        }

                        if (!(row["ActivationExpiry"] is DBNull))
                        {
                            member.ActivationExpiry = Convert.ToDateTime(row["ActivationExpiry"]);
                        }
                        else
                        {
                            member.ActivationExpiry = null;
                        }
                        member.ActivationDate = Convert.ToDateTime(row["ActivationDate"]);

                        list.Add(member);
                    }
                }
            }
            return list;

        }

        public List<ActiveType> GetAllActiveTypes()
        {
            List<ActiveType> list = new List<ActiveType>();

            using (DataTable table = DBHelper.Select("uspGetAllActiveTypes",
                    CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        ActiveType activeType = new ActiveType();

                        activeType.ActiveTypeID = Convert.ToChar(row["ActiveTypeID"]);
                        activeType.ActiveDescription = Convert.ToString(row["ActiveDescription"]);

                        list.Add(activeType);
                    }
                }
            }
            return list;
        }

        public List<uspGetForumTopics> GetForumTopics()
        {
            List<uspGetForumTopics> list = new List<uspGetForumTopics>();
            using (DataTable table = DBHelper.Select("uspGetForumTopics", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspGetForumTopics ft = new uspGetForumTopics
                        {
                            ForumTopicID = Convert.ToInt32(row["ForumTopicID"]),
                            TopicSubject = Convert.ToString(row["TopicSubject"]),
                            TopicCreateDate = Convert.ToDateTime(row["TopicCreateDate"]),
                            TopicCreateName = Convert.ToString(row["TopicCreateName"])

                        };
                        list.Add(ft);
                    }
                }
            }
            return list;
        }
        
        public List<uspGetPostings> GetPostings(int ForumTopicID)
        {
            List<uspGetPostings> list = new List<uspGetPostings>();

            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@forumTopicID", ForumTopicID)
                
            };
            using (DataTable table = DBHelper.ParamSelect("uspGetPostings",
                    CommandType.StoredProcedure, pars))
            {
                foreach (DataRow row in table.Rows)
                {

                    uspGetPostings post = new uspGetPostings();

                            post.PostID = Convert.ToInt32(row["PostID"]);
                            post.PostContent = Convert.ToString(row["PostContent"]);
                            post.PostCreateDate = Convert.ToDateTime(row["PostCreateDate"]);
                            post.PostCreateName = Convert.ToString(row["PostCreateName"]);
                            post.ForumTopicID = Convert.ToInt32(row["ForumTopicID"]);


                        list.Add(post);
                }
            }
            return list;
        }

        public bool UpdateMemberActiveStatus(uspUpdateMemberActiveStatus updateMemberActiveStatus)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in updateMemberActiveStatus.GetType().GetProperties())
            {
                if (prop.GetValue(updateMemberActiveStatus) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(updateMemberActiveStatus)));
                }
            }
            return DBHelper.NonQuery("uspUpdateMemberActiveStatus", CommandType.StoredProcedure,
                parameters.ToArray());
        }

        public bool InsertForumTopics(ForumTopics topic)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in topic.GetType().GetProperties())
            {
                if (prop.GetValue(topic) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(topic)));
                }
            }
            return DBHelper.NonQuery("uspInsertForumTopics", CommandType.StoredProcedure, parameters.ToArray());
        }
        public bool InsertPostings(uspGetPostings post)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in post.GetType().GetProperties())
            {
                if (prop.GetValue(post) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(post)));
                }
            }
            return DBHelper.NonQuery("uspInsertPostings", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool DeleteForumTopics(ForumTopics topic)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in topic.GetType().GetProperties())
            {
                if (prop.GetValue(topic) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(topic)));
                }
            }
            return DBHelper.NonQuery("uspDeleteForumTopic", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool DeletePostings(uspGetPostings post)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in post.GetType().GetProperties())
            {
                if (prop.GetValue(post) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(post)));
                }
            }
            return DBHelper.NonQuery("uspDeletePostings", CommandType.StoredProcedure, parameters.ToArray());
        }

        public List<uspReportGetAllMembers> ReportGetAllMembers(string reportType)
        {
            List<uspReportGetAllMembers> list = new List<uspReportGetAllMembers>();
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ReportType", reportType)

            };
            using (DataTable table = DBHelper.ParamSelect("uspReportGetAllMembers", CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspReportGetAllMembers details = new uspReportGetAllMembers();

                        details.MemberID = Convert.ToString(row["User Name"]);
                        details.MemberName = Convert.ToString(row["Name"]);
                        details.MemberLastName = Convert.ToString(row["Last Name"]);
                        details.MemberDOB = Convert.ToDateTime(row["Date of Birth"]);
                        details.MemberType = Convert.ToChar(row["Member Type"]);
                        details.ActiveTypeID = Convert.ToChar(row["Active"]);
                        details.Email = Convert.ToString(row["Email Address"]);
                        details.ContactNo = Convert.ToString(row["Contact Number"]);
                        if (!(row["Mosque"] is DBNull))
                        {
                            details.MosqueID = Convert.ToInt32(row["Mosque"]);
                        }
                        else
                        {
                            details.MosqueID = null;
                        }
                        details.ActivationDate = Convert.ToDateTime(row["Date Registered"]);
                        
                        list.Add(details);

                    }
                }
            }
            return list;
        }

        public List<uspReportGetAllMosques> ReportGetAllMosques()
        {
            List<uspReportGetAllMosques> list = new List<uspReportGetAllMosques>();
            using (DataTable table = DBHelper.Select("uspReportGetAllMosques", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        uspReportGetAllMosques mosque = new uspReportGetAllMosques();

                        mosque.MosqueID = Convert.ToInt32(row["MosqueID"]);
                        mosque.MosqueName = Convert.ToString(row["MosqueName"]);
                        mosque.MosqueStreet = Convert.ToString(row["MosqueStreet"]);
                        mosque.MosqueSuburb = Convert.ToString(row["MosqueSuburb"]);
                        mosque.MosqueType = Convert.ToString(row["MosqueType"]);
                        mosque.YearEstablished = Convert.ToDateTime(row["YearEstablished"]);
                        mosque.MosqueSize = Convert.ToString(row["MosqueSize"]);
                        mosque.Active = Convert.ToChar(row["Active"]);
                        mosque.MemberID = Convert.ToString(row["MemberID"]);

                        list.Add(mosque);
                    }
                }
            }
            return list;
        }
    }
}
