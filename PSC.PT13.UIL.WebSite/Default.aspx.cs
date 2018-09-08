using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using PSC.PT13.BSL.IService;
using PSC.PT13.BSL.Entities;
using PSC.PT13.BSL.ServiceFactory; 
using PSC.PT13.Helper;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            
            objAccountService = Builder.AccountService();
            AccountEntity[] arrAccountEntity = objAccountService.SearchAccount(this.txtAccountNo1.Text);
            this.grdResult.DataSource = arrAccountEntity;
            this.grdResult.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ErrorMessage.DecodeMessage(ex.Message));
        }
        finally
        {
            if (objAccountService != null) objAccountService.Dispose();
        }
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            objAccountService.OpenNewAccount(this.txtAccountNo2.Text);
        }
        catch(Exception ex)
        {
            throw new Exception(ErrorMessage.DecodeMessage(ex.Message));
        }
        finally
        {
            if (objAccountService != null) objAccountService.Dispose();
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            objAccountService.CloseAccount(this.txtAccountNo3.Text);
        }
        catch (Exception ex)
        {
            throw new Exception(ErrorMessage.DecodeMessage(ex.Message));
        }
        finally
        {
            if (objAccountService != null) objAccountService.Dispose();
        }
    }
    protected void btnDeposit_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            objAccountService.Deposit(this.txtAccountNo4.Text, Convert.ToDecimal(this.txtMoney4.Text)); 
        }
        catch (Exception ex)
        {
            throw new Exception(ErrorMessage.DecodeMessage(ex.Message));
        }
        finally
        {
            if (objAccountService != null) objAccountService.Dispose();
        }
    }
    protected void btnWithdraw_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            objAccountService.Withdraw(this.txtAccountNo5.Text, Convert.ToDecimal(this.txtMoney5.Text));
        }
        catch (Exception ex)
        {
            throw new Exception(ErrorMessage.DecodeMessage(ex.Message));
        }
        finally
        {
            if (objAccountService != null) objAccountService.Dispose();
        }
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        IAccountService objAccountService = null;
        try
        {
            objAccountService = Builder.AccountService();
            objAccountService.Transfer(this.txtAccountNo6.Text, this.txtAccountNo7.Text, Convert.ToDecimal(this.txtMoney6.Text));
        }
        catch (Exception ex)
        {
            throw new Exception(ErrorMessage.DecodeMessage(ex.Message));
        }
        finally
        {
            if (objAccountService != null) objAccountService.Dispose();
        }
    }
}