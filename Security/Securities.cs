using DemoInfo.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoInfo.Security
{
    public class Securities
    {
        public static DalStoreProcedure dal = new DalStoreProcedure();
        public static EncryptionDecryptionProvider encryptionDecryption = new EncryptionDecryptionProvider();
        public bool AuthenticateUser(string email, string password)
        {
            DataSet ds;
            DataRow dr, msgType;
            string UserID;
            string msg;
            ds = dal.AuthnticateUser(email, password);
            msgType = ds.Tables[1].Rows[0];
            msg = msgType["MsgType"].ToString();
            if (msg == "ok")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    UserID = dr["UserID"].ToString();
                    if (HttpContext.Current.Session["UserID"] == null)
                    {
                        HttpContext.Current.Session.Add("UserID", UserID);
                    }
                    else
                    {
                        HttpContext.Current.Session["UserID"] = UserID;
                    }
                    //save information to cookie
                    SaveToCookie(UserID);

                    return true;
                }
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    HttpContext.Current.Session.Remove("UserID");
                }
                RemoveCookie();
            }
            return false;

        }
        private static void SaveToCookie(string userID)
        {

            var cookie = new HttpCookie("LoginSession");

            cookie.Value = encryptionDecryption.EncryptText(userID);
            cookie.Expires = DateTime.Now.AddMinutes(60);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static void RemoveCookie()
        {
            var cookie = new HttpCookie("LoginSession");
            cookie.Value = "";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public void Logout()
        {
            HttpContext.Current.Session["UserID"] = null;

            RemoveCookie();
        }

    }
}