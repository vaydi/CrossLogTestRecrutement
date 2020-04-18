using System;
using System.Drawing;
using System.Web.UI.WebControls;
using Crosslog.TestRecrutement.Library;
using Crosslog.TestRecrutement.Library.BusinessEntity;
using Crosslog.TestRecrutement.Library.Factory;

namespace Crosslog.TestRecrutement.WebSite
{
    public partial class Customer : System.Web.UI.Page
    {
        private static CustomerListEntity _customerList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ClearTextBox();

            FillGridView();
        }

        protected void btRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCustomerID.Text == "")
                    return;

                CustomerEntity customer = new CustomerEntity
                   {
                       City = txtCity.Text,
                       ZipCode = txtZipCode.Text,
                       Phone = txtPhone.Text,
                       Email = txtEmail.Text,
                       CustomerId = int.Parse(lblCustomerID.Text),
                       Address = txtAddress.Text,
                       LastName = txtLastName.Text,
                       FirstName = txtFirstName.Text
                   };

                bool isUpdate = UnityFactory.Instance.Get<ICustomerBusiness>().UpdateCustomer(customer);

                if (isUpdate)
                {
                    lblMessage.ForeColor = Color.ForestGreen;
                    lblMessage.Text = "Customer have been successfully updated";
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Update Customer is failed";
                }
            }
            catch (Exception exception)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = exception.Message;
            }
        }

        protected void grdOrders_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdOrders, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_customerList == null) return;

            try
            {
                ClearTextBox();
                int index = grdOrders.SelectedRow.RowIndex;

                FillTextBox(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillTextBox(int index)
        {
            lblCustomerID.Text = _customerList[index].CustomerId.ToString();
            txtLastName.Text = _customerList[index].LastName;
            txtFirstName.Text = _customerList[index].FirstName;
            txtAddress.Text = _customerList[index].Address;
            txtCity.Text = _customerList[index].City;
            txtEmail.Text = _customerList[index].Email;
            txtCountryCode.Text = _customerList[index].ZipCode;
            txtZipCode.Text = _customerList[index].ZipCode;
            txtPhone.Text = _customerList[index].Phone;
        }

        private void FillGridView()
        {
            try
            {
                _customerList = UnityFactory.Instance.Get<ICustomerBusiness>().GetCustomers();

                grdOrders.DataSource = _customerList;
                grdOrders.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearTextBox()
        {
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCountryCode.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
    }
}