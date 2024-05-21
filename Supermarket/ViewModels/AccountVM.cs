using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class AccountVM
    {
        private AccountBLL _accountBLL;

        public AccountVM()
        {
            _accountBLL = new AccountBLL();
            AccountList=_accountBLL.GetAllAccounts();
        }

        public ObservableCollection<Account> AccountList
        {
            get => _accountBLL.AccountsList;
            set=>_accountBLL.AccountsList = value;
        }

        #region Commands

        #endregion
    }
}
