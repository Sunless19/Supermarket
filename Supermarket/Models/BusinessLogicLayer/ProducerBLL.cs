using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ProducerBLL
    {
        public ObservableCollection<Producer> ProducerList { get; set; }

        public ProducerBLL()
        {
            ProducerList = new ObservableCollection<Producer>();

        }
        public ObservableCollection<Producer> GetProducerDetails()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetProducerDetails", con);
                    ObservableCollection<Producer> result = new ObservableCollection<Producer>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Producer producer= new Producer();
                        producer.ProducerId = (int)reader[0];
                        producer.Name = reader.GetString(1);
                        result.Add(producer);
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
        public void AddMethod(object obj)
        {

        }
        public void UpdateMethod(object obj)
        {

        }
        public void DeleteMethod(object obj)
        {
        }
    }
}
