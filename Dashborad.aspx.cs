using DemoInfo.DAL;
using DemoInfo.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoInfo
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private EncryptionDecryptionProvider encryptionDecryption;
        private DalStoreProcedure dal;
        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Visible = false;
            main.Visible = false;
            div1.Visible = false;
            DataRow dr;
            string isActive, userName, email, decryptedEmail, password, decryptedPassword, districtName, districtId, UserId;
            encryptionDecryption = new EncryptionDecryptionProvider();
            dal = new DalStoreProcedure();
            HttpCookie cookie = Request.Cookies["LoginSession"];
            string cookieValue = cookie.Value;
            string decryptedCookieValue = encryptionDecryption.DecryptText(cookieValue);
            if (!IsPostBack)
            {
                if (decryptedCookieValue != null && decryptedCookieValue != "")
                {
                    DataSet userInfo = dal.GetUserData(decryptedCookieValue);
                    if (userInfo.Tables.Count > 0)
                    {
                        dr = userInfo.Tables[0].Rows[0];
                        isActive = dr["IsActive"].ToString();
                        userName = dr["UserName"].ToString();
                        email = dr["UserEmail"].ToString();
                        password = dr["Password"].ToString();
                        districtName = dr["DistrictName"].ToString();
                        districtId = dr["DistrictID"].ToString();
                        decryptedEmail = encryptionDecryption.DecryptText(email);
                        decryptedPassword = encryptionDecryption.DecryptText(password);
                        UserId = dr["UserID"].ToString();


                        if (isActive == "1")
                        {
                            form1.Visible = true;
                            userID.Value = UserId;
                            name.InnerHtml = userName;
                            txtUsernameEdit.Text = userName;
                            txtEmailEdit.Text = decryptedEmail;
                            txtPasswordEdit.Text = decryptedPassword;
                            DataSet ds = dal.GetDistrict("[dbo].[Get.Districts]");
                            ddlDistrict.DataSource = ds.Tables[0];
                            ddlDistrict.DataTextField = "Text";
                            ddlDistrict.DataValueField = "Value";
                            ddlDistrict.DataBind();
                            ddlDistrict.Items.Insert(0, new ListItem(districtName, districtId));
                            main.Visible = false;
                        }
                        else
                        {
                            div1.Visible = true;
                            form1.Visible = false;
                        }
                    }

                }
                else
                {
                    main.Visible = true;
                    form1.Visible = false;
                }
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string encryptedEmail, encryptedPassword;
            string userNameEdit = txtUsernameEdit.Text;
            int districtId = int.Parse(ddlDistrict.SelectedValue);
            string email = txtEmailEdit.Text;
            string password = txtPasswordEdit.Text;
            encryptedEmail = encryptionDecryption.EncryptText(email);
            encryptedPassword = encryptionDecryption.EncryptText(password);
            string userDataID = userID.Value;
            DataSet updateUserDataSet = dal.UpdateUserData(userDataID, userNameEdit, districtId, encryptedEmail, encryptedPassword);
            string msgType = (string)updateUserDataSet.Tables[0].Rows[0]["MsgType"];
            if (msgType == "updated")
            {
                msgUpdate.InnerHtml = "Updated Successfully";
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string userDataID = userID.Value;
            DataSet deleteUser = dal.DeleteUserData(userDataID);
            string msgType = (string)deleteUser.Tables[0].Rows[0]["MsgType"];
            if (msgType == "success")
            {
                msgUpdate.InnerHtml = "User Delete Successfully";
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}