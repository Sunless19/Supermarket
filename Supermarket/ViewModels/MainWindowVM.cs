using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class MainWindowVM
    {
        private ICommand startCommand;

        public void StartGame(object obj)
        {
            Login login = new Login();
            login.ShowDialog();
            
        }
        public ICommand StartCommand
        {
            get
            {
                if (startCommand == null)
                    startCommand = new RelayCommand(StartGame);
                return startCommand;
            }
        }
    }
}
