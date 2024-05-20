using System.Windows.Input;
using Supermarket.Helper;
using Supermarket.Views;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class CasherVM : BasePropertyChanged
    {
        public CasherVM() { }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(SearchWindow);
                return _searchCommand;
            }
        }

        public void SearchWindow(object obj)
        {
            // Deschiderea unei noi ferestre pentru căutare (creare)
            
        }

        private ICommand _newReceiptCommand;
        public ICommand NewReceiptCommand
        {
            get
            {
                if (_newReceiptCommand == null)
                    _newReceiptCommand = new RelayCommand(NewReceiptWindow);
                return _newReceiptCommand;
            }
        }

        public void NewReceiptWindow(object obj)
        {
            // Deschiderea unei noi ferestre pentru NewReceipt (creare)
            // Cod pentru deschiderea ferestrei NewReceipt
        }

        private ICommand _seeReceiptCommand;
        public ICommand SeeReceiptCommand
        {
            get
            {
                if (_seeReceiptCommand == null)
                    _seeReceiptCommand = new RelayCommand(SeeReceiptWindow);
                return _seeReceiptCommand;
            }
        }

        public void SeeReceiptWindow(object obj)
        {
            // Deschiderea unei noi ferestre pentru SeeReceipt (creare)
            
        }
    }
}