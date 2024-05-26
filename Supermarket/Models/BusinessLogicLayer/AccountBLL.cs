
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
                        account.AccountId = (int)reader[3];
                        account.Name=reader.GetString(4);
                        account.isDeleted = (bool)reader[5];
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
        public void AddUser(Account account)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", account.AccountId);
                    cmd.Parameters.AddWithValue("@Name", account.Name);
                    cmd.Parameters.AddWithValue("@Password",account.Password);
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Role", account.Role);
                    cmd.Parameters.AddWithValue("@Deleted", false);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void EditUser(Account account)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EditUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", account.AccountId);
                    cmd.Parameters.AddWithValue("@Name", account.Name);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Role", account.Role);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void DeleteUser(Account account)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", account.AccountId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
