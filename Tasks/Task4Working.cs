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

        static void OrderData(string jsonData, RichTextBox richTextBox)
        {
            
            string output = "";
            List<OrderDatas> orderDataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderDatas>>(jsonData);

            foreach (var order in orderDataList)
            {
                output += $"Symbol: {order.symbol}, Buy or Sell: {order.buyOrSell}, Timestamp: {order.timestamp}, Size: {order.size}, Price: {order.price}" + "\n";
                
            }

            
            richTextBox.Invoke((MethodInvoker)(() =>
            {
                richTextBox.AppendText(output);
            }));
        }


        static async Task<string> GetOrderBook(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send a GET request to the API endpoint
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    // Handle the error if the request was not successful
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
            string apiUrl = "https://www.bitmex.com/api/v1/orderBook/L2?symbol=XBT&depth=25";

            try
            {
                // Call the GetOrderBook function to retrieve data
                string orderBookData = await GetOrderBook(apiUrl);


                OrderData(orderBookData, richTextBox1);
                // You can parse and process the order book data here
                richTextBox1.Text = "Order Book Data:";
                //richTextBox1.Text += orderBookData;
             
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

    }
    }

