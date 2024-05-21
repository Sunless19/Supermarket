
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class AccountBLL
    {


        public ObservableCollection<Account> AccountsList { get; set; }

        public AccountBLL()
        {
            AccountsList = GetAllAccounts();
        }
        public ObservableCollection<Account> GetAllAccounts()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetAllAccounts", con);
                    ObservableCollection<Account> result = new ObservableCollection<Account>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Account account = new Account();
                        account.Username = reader.GetString(0);
                        account.Password = reader.GetString(1);
                        account.Role = reader.GetString(2);
                        result.Add(account);
                    }
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    // Gestionează orice excepții sau afișează un mesaj de eroare
                    Console.WriteLine("Error: " + ex.Message);
                    return null; // sau aruncă excepția mai departe
                }
            }
        }

        public Account VerifyUser(string username, string password)
        {
            ObservableCollection<Account> allAccounts = GetAllAccounts();

            foreach (var account in allAccounts)
            {
                if (account.Username == username && account.Password == password)
                {
                    Console.WriteLine("User verified successfully.");
                    return account;
                }
            }
            Console.WriteLine("User verification failed: Invalid username or password.");

            return null;
        }
    }
}
