using PSC.PT13.BSL.Entities;
using PSC.PT13.BSL.IService;
using PSC.PT13.BSL.ServiceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    protected void btnSearchOr_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            AccountEntity[] arrAccountEntity = objAccountService.Search(this.txtSearch.Text);
            this.GridView1.DataSource = arrAccountEntity;
            this.GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw new UILException("btnSearchOr_Click event occurs an error.[" + ex.Message + "]", ex, true);
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IAccountService accountService = null;
        try
        {
            var accountNo = Convert.ToString((GridView1.DataKeys[e.RowIndex].Values[0]));
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            //var accountNo = (row.FindControl("txtAccountNo") as TextBox).Text;
            accountService = Builder.AccountService();
            accountService.DeleteAccount(accountNo);
        }
        catch (Exception ex)
        {
            throw new UILException("OnRowDeleting event occurs an error.[" + ex.Message + "]", ex, true);
        }
        finally
        {
            this.BindGrid();
        }
        
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        catch (Exception ex)
        {
            throw new UILException("OnRowEditing event occurs an error.[" + ex.Message + "]", ex, true);
        }
        
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            decimal balance = 0;
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string accountNo = (row.FindControl("txtAccountNo") as TextBox).Text;
            string balanceStr = (row.FindControl("txtBalance") as TextBox).Text;
            decimal.TryParse(balanceStr, out balance);

            objAccountService = Builder.AccountService();
            objAccountService.UpdateAccount(accountNo, balance);
        }
        catch (Exception ex)
        {
            throw new UILException("OnRowUpdating event occurs an error.[" + ex.Message + "]", ex, true);
        }
        finally
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        catch (Exception ex)
        {
            throw new UILException("OnRowCancelingEdit event occurs an error.[" + ex.Message + "]", ex, true);
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
        catch (Exception ex)
        {
            throw new UILException("OnRowDataBound event occurs an error.[" + ex.Message + "]", ex, true);
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            var accountNo = txtAccountNo.Text;
            var balanceStr = txtBalance.Text;
            int accNo = 0;
            decimal balance = 0;
            var validateAccountNo = int.TryParse(accountNo, out accNo);
            var validateBalance = decimal.TryParse(balanceStr, out balance);

            if(!(validateAccountNo && validateBalance)) { return; }

            objAccountService = Builder.AccountService();
            if(!objAccountService.AddAccount(accountNo, balance))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Account Exist.');", true);
            }
        }
        catch (Exception ex)
        {
            throw new UILException("btnAdd_Click event occurs an error.[" + ex.Message + "]", ex, true);
        }
        finally
        {
            this.ClearTextBox();
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            AccountEntity[] arrAccountEntity = objAccountService.Search("");
            this.GridView1.DataSource = arrAccountEntity;
            this.GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw new UILException("BindGrid event occurs an error.[" + ex.Message + "]", ex, true);
        }
    }

    private void ClearTextBox()
    {
        txtAccountNo.Text = string.Empty;
        txtBalance.Text = string.Empty;
    }

    protected void btnSearchAnd_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            AccountEntity[] arrAccountEntity = objAccountService.SearchAccountAndBalance(txtAccoutNoSearch.Text, txtBalanceSearch.Text);
            this.GridView1.DataSource = arrAccountEntity;
            this.GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw new UILException("btnSearchAnd_Click event occurs an error.[" + ex.Message + "]", ex, true);
        }
    }
}