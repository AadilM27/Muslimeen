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
        public bool AutoEmailService(string MemberEmail, string MemberType)
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
                MailAddress toAddress = new MailAddress(MemberEmail);
                //MailAddress ccAddress = new MailAddress("");

                //Passing values to smtp object
                dynamic message = new MailMessage(fromAddress, toAddress);

                message.IsBodyHtml = true;
                //message.CC.Add(ccAddress);
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
                                                            <a style=""font-size:15px;"" href=""https://www.google.co.za"">Verify now</a><br/><hr/>
                                                        </div>
                                                        <div style=""background-color:#256297; text-align:center; vertical-align:middle;"">
                                                            <h2>Thank you</h2>
                                                        </div>
                                                    </body>
                                                </html>
                                                ", MemberType);

                //Send email
                smtp.Send(message);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
