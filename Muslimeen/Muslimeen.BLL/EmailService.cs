using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Muslimeen.BLL
{
    public class EmailService
    {
        public void AutoEmailService(string memberEmail, string memberType, string linkToGo, string emailType, string userName, string newPassword)
        {
            try
            {
                //Assign the smtp credentials for gmail
                SmtpClient smtp = new SmtpClient();
                if (true)
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("nextechgrp@gmail.com", "nextechgrp786");
                    smtp.Timeout = 20000;
                }

                MailAddress fromAddress = new MailAddress("nextechgrp@gmail.com", "Muslimeen");
                MailAddress toAddress = new MailAddress(memberEmail);
                //MailAddress ccAddress = new MailAddress("");

                //Passing values to smtp object
                dynamic message = new MailMessage(fromAddress, toAddress);

                message.IsBodyHtml = true;
                //message.CC.Add(ccAddress);


                if (emailType == "Registration") // Send when user registers on Muslimee.
                {
                    message.Subject = "Muslimeen Registration";
                    message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Welcome <br/> To <br/>Muslimeen</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:center;"">
                                                            <hr/>
                                                            <h3>Congratulations you are now a {0} of Muslimeen.</h3><br/><br/><p>Click below to verify your registration</p><br/>
                                                            <a style=""font-size:15px;"" href=""{1}"">Verify now</a><br/><hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", memberType, linkToGo);

                    //Send email
                    smtp.Send(message);

                }
                else if (emailType == "ProfileUpdate") // send when User Updates his profile.
                {
                    string ComputerName = Environment.MachineName.ToString();
                    string UserLoggedInName = Environment.UserName.ToString();
                    string hostName = Dns.GetHostName();
                    string myIP = Dns.GetHostEntry(hostName).AddressList[1].ToString();
                    string iPAddress = myIP;
                    string DateUpdated = Convert.ToString(DateTime.Now.ToLocalTime());
                    message.Subject = "Muslimeen - Profile Updated";
                    message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen Profile <br/>Update</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/>
                                                            <h3 tyle=""text-align:center;"">Your profile has been updated.</h3><br/><h4>Details:</h4>
                                                                <ul style=""text-align:left;""><li><b>Computer Name:&emsp;</b>{0}</li><li><b>OS User:&nbsp;&nbsp;&emsp;&emsp;&emsp;&emsp;</b>{1}</li>
                                                                    <li><b>IP Address:&emsp;&emsp;&emsp;<b/>{2}</li><li><b>Date Updated:&emsp;&emsp;</b>{3}</li></ul><br/><br/>
                                                                    <p>*If you did not do this, Please notify the Muslimeen team ASAP.</p>
                                                                <hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", ComputerName, UserLoggedInName, iPAddress, DateUpdated);

                    //Send email
                    smtp.Send(message);

                }
                else if (emailType == "ForgotPassword") // send when user forgets Password.
                {

                    message.Subject = "Muslimeen - Reset Password";
                    message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen Password<br/>Reset Request</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/><br/>
                                                            <h3>You have requested to reset your password</h3><br/><h5>Below are your new login credentials:</h5>
                                                             <ul style=""text-align:left;""><li><b>User Name: </b>{0}</li><li><b>New Password: </b>{1}</li></ul><br/><br/><p>*Please make sure that you change your password again to keep your account secured</p><br/><hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", userName, newPassword);

                    //Send email
                    smtp.Send(message);

                }
                else if (emailType == "AcceptedScholars")
                {
                    message.Subject = "Muslimeen - Scholar Registration";
                    message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen Scholar<br/>Registration</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/>
                                                            <h4 tyle=""text-align:center; padding:0;"">Greetings {0}</h4>
                                                                <p>Your Registration for Scholar has been accepted.<br/><br/>You may now login as a scholar and: </p>
                                                                    <ul style=""text-align:left;""><li>Add Articles</li><li>Get your mosques sallah times</li>
                                                                    <li>Get Events from your mosque and other mosques</li><li>Read Articles from other scholars</li></ul>
                                                                    <br/><br/>
                                                                <hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", userName);

                    //Send email
                    smtp.Send(message);

                }
                else if (emailType == "RejectedScholars")
                {
                    message.Subject = "Muslimeen - Scholar Registration";
                    message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen Scholar<br/>Registration</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/>
                                                            <h4 tyle=""text-align:center; padding:0;"">Greetings {0}</h4>
                                                                <p>Your Registration for Scholar has been denied.<br/><br/>We suggest registering as a Member and: </p>
                                                                    <ul style=""text-align:left;""><li>Get access to Islamic knowledge</li><li>Get your mosques sallah times</li>
                                                                    <li>Get Events from your mosque and other mosques</li><li>Read Articles from scholars</li></ul>
                                                                    <br/><br/>
                                                                <hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", userName);

                    //Send email
                    smtp.Send(message);
                }
            }
            catch (Exception)
            {

            }
        }

        public bool DisableEnableMember(string memberEmail, string userName)
        {
            SmtpClient smtp = new SmtpClient();
            if (true)
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("nextechgrp@gmail.com", "nextechgrp786");
                smtp.Timeout = 20000;
            }

            MailAddress fromAddress = new MailAddress("nextechgrp@gmail.com", "Muslimeen");
            MailAddress toAddress = new MailAddress(memberEmail);
            //MailAddress ccAddress = new MailAddress("");

            //Passing values to smtp object
            dynamic message = new MailMessage(fromAddress, toAddress);

            message.IsBodyHtml = true;
            //message.CC.Add(ccAddress);

            message.Subject = "Muslimeen Membership";
            message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen<br/>Membership</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/>
                                                            <h4 tyle=""text-align:center; padding:0;"">Greetings {0}</h4>
                                                                <p>Your Muslimeen Membership has been deactivated.<br/><br/>You will no longer be able to access your account.</p>
                                                                    <br/><br/>
                                                                <hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", userName);//Send email
            smtp.Send(message);

            return true;
        }

        public bool AddMosque(string repID, string repName, string mosqueID, string repPass, string repEmail)
        {
            SmtpClient smtp = new SmtpClient();
            if (true)
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("nextechgrp@gmail.com", "nextechgrp786");
                smtp.Timeout = 20000;
            }

            MailAddress fromAddress = new MailAddress("nextechgrp@gmail.com", "Muslimeen");
            MailAddress toAddress = new MailAddress(repEmail);
            //MailAddress ccAddress = new MailAddress("");

            //Passing values to smtp object
            dynamic message = new MailMessage(fromAddress, toAddress);

            message.IsBodyHtml = true;
            //message.CC.Add(ccAddress);

            message.Subject = "Muslimeen Mosque Rep Membership";
            message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen<br/>Mosque Rep Membership</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/>
                                                            <h4 tyle=""text-align:center; padding:0;"">Greetings {0}</h4>
                                                                <p>You have been successfully regsitered as a Mosque rep.<br/><br/>We welcome you to muslimeen, your details are as follows: </p>
                                                                    <br/>
                                                                    <ul style=""text-align:left;""><li><b>User Name:</b> {1}</li><li><b>Mosque ID:</b> {2}</li>
                                                                    <li><b>Your temporary password:</b> {3}</li></ul>
                                                                <br/>
                                                                <p>*We recommend you change your password after logging in for the first time.</p>
                                                                <hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", repName, repID, mosqueID, repPass);//Send email
            smtp.Send(message);

            return true;
        }

        public bool AddMod(string modID, string modName , string modEmail, string modPass)
        {
            try
            {
                //Assign the smtp credentials for gmail
                SmtpClient smtp = new SmtpClient();
                if (true)
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("nextechgrp@gmail.com", "nextechgrp786");
                    smtp.Timeout = 20000;
                }

                MailAddress fromAddress = new MailAddress("nextechgrp@gmail.com", "Muslimeen");
                MailAddress toAddress = new MailAddress(modEmail);
                //MailAddress ccAddress = new MailAddress("");

                //Passing values to smtp object
                dynamic message = new MailMessage(fromAddress, toAddress);

                message.IsBodyHtml = true;
                //message.CC.Add(ccAddress);


                    message.Subject = "Muslimeen Mosque Rep Membership";
                    message.Body = String.Format(@"
                                                <html lang=""en"" style=""height:100%"">    
                                                    <body>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h1 style=""font-weight:bolder; font-size:25px;"">Muslimeen<br/>Muslimeen Moderater Membership</h1>
                                                        </div>
                                                        <div style=""background-color:#ffffff; text-align:left;"">
                                                            <hr/>
                                                            <h4 tyle=""text-align:center; padding:0;"">Greetings {0}</h4>
                                                                <p>You have been successfully regsitered as a Moderater<br/><br/>We welcome you to muslimeen, your details are as follows: </p>
                                                                    <br/>
                                                                    <ul style=""text-align:left;""><li><b>User Name:</b> {1}</li>
                                                                    <li><b>Your temporary password:</b> {2}</li></ul>
                                                                <br/>
                                                                <p>*We recommend you change your password after logging in for the first time.</p>
                                                                <hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", modName, modID, modPass);//Send email
                    smtp.Send(message);

            }
            catch
            {

            }

            return true;
        }
    }
}
