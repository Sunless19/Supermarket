
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
    internal class ReceiptBLL
    {

        public ReceiptBLL() { }

        public int AddReceipt(Receipt receipt)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddReceipt", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReleaseDate", receipt.Date);
                    cmd.Parameters.AddWithValue("@CasherID", receipt.CasherID);
                    cmd.Parameters.AddWithValue("@Total", receipt.Total);
                    cmd.Parameters.AddWithValue("@Deleted", receipt.Deleted);

                    con.Open();
                    int newReceiptId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    return newReceiptId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return -1; // Return a negative value to indicate an error
                }
            }
        }


    }
}
