
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class StockBLL
    {
        public StockBLL()
        {

        }

        public ObservableCollection<Stock> GetStockProducts() 
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetStockProducts", con);
                    ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != null)
                        {
                            Stock stock = new Stock();
                            stock.BarCode = reader.GetString(1);
                            stock.Quantity = (int)reader[2];
                            stock.Unit = reader.GetString(3);
                            stock.ExpirationDate = (DateTime)reader[4];
                            stock.SelllingPrice = (decimal)reader[5];
                            result.Add(stock);
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
        public void UpdateStock(string Barcode,int Quantity)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UpdateStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adaugă parametrii
                    cmd.Parameters.AddWithValue("@Barcode", Barcode);
                    cmd.Parameters.AddWithValue("@QuantityChange", Quantity);

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
    }
}
