using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
namespace Tasks
{

    public partial class Task4Working : Form
    {
        public string data;


        public class OrderDatas
        {
            public string symbol { get; set; } 

            public decimal price { get; set; }

            public int size { get; set; }

            public string buyOrSell { get; set; }

            public DateTime timestamp { get; set; }

        }

        private static void OrderData(string jsonData, RichTextBox richTextBox)
        {
            
            List<OrderDatas> orderDataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderDatas>>(jsonData);

            foreach (var order in orderDataList)
            {
                richTextBox.Text += $"Symbol: {order.symbol}, Buy or Sell: {order.buyOrSell}, Timestamp: {order.timestamp}, Size: {order.size}, Price: {order.price}" + "\n";
         
                
            }

            
           
        }


        static async Task<string> GetOrderBook(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    
                    throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }


        public Task4Working()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "Order Book Data:";
            richTextBox1.Clear();

            string apiUrl = "https://www.bitmex.com/api/v1/orderBook/L2?symbol=XBT&depth=25";

            try
            {
                
                string orderBookData = await GetOrderBook(apiUrl);


                OrderData(orderBookData, richTextBox1);
                
                
               // richTextBox1.Text += orderBookData;
             
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

    }
    }

