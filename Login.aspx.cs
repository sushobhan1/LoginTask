using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using System.Data;
using DemoInfo.Security;
using DemoInfo.DAL;

namespace DemoInfo
{
    public partial class Login : System.Web.UI.Page
    {
        private EncryptionDecryptionProvider encryptionDecryption;
        private DalStoreProcedure dal;
        private Securities securities;

        protected void Page_Load(object sender, EventArgs e)
        {
            encryptionDecryption = new EncryptionDecryptionProvider();
            dal = new DalStoreProcedure();
            securities = new Securities();
            if (!IsPostBack)
            {
                login.Visible = true;
                registerUser.Visible = false;
                gotoLogin.Visible = false;
                BindDistricts();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string encryptEmail, encryptPassword;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            encryptEmail = encryptionDecryption.EncryptText(email);
            encryptPassword = encryptionDecryption.EncryptText(password);
            bool usercheck = securities.AuthenticateUser(encryptEmail, encryptPassword);


            if (usercheck)
            {

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidLogin", "alert('Invalid username or password');", true);
            }
        }

        #region

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string encryptedEmail, encryptedPassword;
            string userNameRegister = txtUsernameRegister.Text;
            int districtId = int.Parse(ddlDistrict.SelectedValue);
            string email = txtEmailRegister.Text;
            string password = txtPasswordRegister.Text;
            encryptedEmail = encryptionDecryption.EncryptText(email);
            encryptedPassword = encryptionDecryption.EncryptText(password);
            DataSet register = dal.RegisterUser("[dbo].[Register.User]",
             new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = userNameRegister },
             new SqlParameter("@DistrictId", SqlDbType.Int) { Value = districtId },
             new SqlParameter("@UserEmail", SqlDbType.NVarChar) { Value = encryptedEmail },
             new SqlParameter("@PassWord", SqlDbType.NVarChar) { Value = encryptedPassword },
             new SqlParameter("@MsgType", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output }
             );
            string msgType = (string)register.Tables[0].Rows[0]["MsgType"];
            if (msgType == "success")
            {
                gotoLogin.Visible = true;
                registerUser.Visible = false;

                lblMsg.InnerText = "SuccessFully Register";

            }
            else
            {
                lblMsg.InnerText = "Registration Failed";
            }
        }
        #endregion
        protected void btnShowRegister_Click(object sender, EventArgs e)
        {
            login.Visible = false;
            registerUser.Visible = true;
            gotoLogin.Visible = false;
        }
        protected void btnShowLogin_Click(object sender, EventArgs e)
        {
            login.Visible = true;
            registerUser.Visible = false;
            gotoLogin.Visible = false;
        }

        protected void BindDistricts()
        {
            DataSet ds = dal.GetDistrict("[dbo].[Get.Districts]");
            ddlDistrict.DataSource = ds.Tables[0];
            ddlDistrict.DataTextField = "Text";
            ddlDistrict.DataValueField = "Value";
            ddlDistrict.DataBind();
        }
    }
}
