
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
    internal class ReceiptItemsBLL
    {

        public ReceiptItemsBLL()
        {
        }
        public void AddProductOnReceipt(ReceiptItems receiptItems)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddProductsOnReceipt", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adaugă parametrii pentru procedura stocată
                    cmd.Parameters.AddWithValue("@Barcode", receiptItems.Barcode);
                    cmd.Parameters.AddWithValue("@Quantity", receiptItems.Quantity);
                    cmd.Parameters.AddWithValue("@Subtotal", receiptItems.Subtotal);
                    cmd.Parameters.AddWithValue("@Deleted", receiptItems.Deleted);

                    // Deschide conexiunea și execută procedura stocată
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Tratează eroarea în mod corespunzător
                }
            }
        }

        public ObservableCollection<ReceiptItems> GetProductsOnReceipt()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetProductsOnReceipt", con);
                    ObservableCollection<ReceiptItems> result = new ObservableCollection<ReceiptItems>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader != null)
                        {
                            ReceiptItems product = new ReceiptItems();
                            product.Barcode = reader.GetString(0);
                            product.Quantity = (int)reader[1];
                            product.ReceiptId = (int)reader[2];
                            product.Subtotal = (decimal)reader[3];
                            result.Add(product);
                        }
                    }
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
