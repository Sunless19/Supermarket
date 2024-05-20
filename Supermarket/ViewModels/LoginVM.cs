using Microsoft.Win32;
using Supermarket.DBContext;
using Supermarket.Helper;
using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class LoginVM : BasePropertyChanged
    {
        
        private AccountBLL _accountBLL;
        private string _username;
        private string _password;

        public LoginVM()
        {
            _accountBLL = new AccountBLL(new supermarketDBContext());
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        #region Commands

        private ICommand createAccount;
        public ICommand CreateAccount
        {
            get
            {
                if (createAccount == null)
                    createAccount = new RelayCommand(ToRegister);
                return createAccount;
            }
        }
        public void ToRegister(object obj)
        {
            Register register = new Register();
            register.ShowDialog();
        }
        private ICommand connect;

        public void Connect(object obj)
        {
            var account = _accountBLL.VerifyUser(Username, Password);
            if (account != null)
            {
                if(account.Role=="Administrator")
                {
                    Administrator administrator = new Administrator();
                    administrator.ShowDialog();
                }
                else if(account.Role== "Casier")
                {
                    Casher casher = new Casher();
                    casher.ShowDialog();
                }
            }
            else
                MessageBox.Show("Username or password inncorect.","Autentification",MessageBoxButton.OK,MessageBoxImage.Error);
        }
        public ICommand Login
        {
            get
            {
                if (connect == null)
                    connect = new RelayCommand(Connect);
                return connect;
            }
        }
        #endregion

    }
}
