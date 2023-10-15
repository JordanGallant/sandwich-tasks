using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;


using System.Security.Cryptography;
using System.Threading;
using System.Text.Json;

namespace Tasks
{

    public class OrderBookItem
    {
        public string Symbol { get; set; }
        public int Level { get; set; }
        public int BidSize { get; set; }
        public decimal BidPrice { get; set; }
        public int AskSize { get; set; }
        public decimal AskPrice { get; set; }
        public DateTime Timestamp { get; set; }
    }


    public class BitMEXApi
    {

        private const string domain = "https://testnet.bitmex.com";
        public string apiKey; // tried using user-secrets to avoid having the API keys in 
        public string apiSecret; // tried using user-secrets to avoid having the API keys in
        private int rateLimit;

        public BitMEXApi()
        {
            Secrets secret = new Secrets();
            this.apiKey = secret.GetAPIKEY();
            this.apiSecret = secret.GETAPISECRET();
            this.rateLimit = 5000;
        }
        private string BuildQueryData(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            StringBuilder b = new StringBuilder();
            foreach (var item in param)
                b.Append(string.Format("&{0}={1}", item.Key, WebUtility.UrlEncode(item.Value)));

            try { return b.ToString().Substring(1); }
            catch (Exception) { return ""; }
        }

        private string BuildJSON(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            var entries = new List<string>();
            foreach (var item in param)
                entries.Add(string.Format("\"{0}\":\"{1}\"", item.Key, item.Value));

            return "{" + string.Join(",", entries) + "}";
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private long GetExpires()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600; // set expires one hour in the future
        }

        private string Query(string method, string function, Dictionary<string, string> param = null, bool auth = false, bool json = false)
        {
            string paramData = json ? BuildJSON(param) : BuildQueryData(param);
            string url = "/api/v1" + function + ((method == "GET" && paramData != "") ? "?" + paramData : "");
            string postData = (method != "GET") ? paramData : "";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(domain + url);
            webRequest.Method = method;

            if (auth)
            {
                string expires = GetExpires().ToString();
                string message = method + url + expires + postData;
                byte[] signatureBytes = hmacsha256(Encoding.UTF8.GetBytes(apiSecret), Encoding.UTF8.GetBytes(message));
                string signatureString = ByteArrayToString(signatureBytes);

                webRequest.Headers.Add("api-expires", expires);
                webRequest.Headers.Add("api-key", apiKey);
                webRequest.Headers.Add("api-signature", signatureString);
            }

            try
            {
                if (postData != "")
                {
                    webRequest.ContentType = json ? "application/json" : "application/x-www-form-urlencoded";
                    var data = Encoding.UTF8.GetBytes(postData);
                    using (var stream = webRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream str = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(str))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                using (HttpWebResponse response = (HttpWebResponse)wex.Response)
                {
                    if (response == null)
                        throw;

                    using (Stream str = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(str))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public List<OrderBookItem> GetOrderBook(string symbol, int depth)
        {
            var param = new Dictionary<string, string>();
            Console.WriteLine(param);
            param["symbol"] = symbol;
            param["depth"] = depth.ToString();
            string res = Query("GET", "/orderBook", param);
            Console.WriteLine(res);
            List<OrderBookItem> orderBookList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderBookItem>>(res);
            return orderBookList;
        }
        private byte[] hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }

    }

   















    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //testing outputs    
        {
            Secrets secret = new Secrets();
            BitMEXApi bma = new BitMEXApi();

            string apiKey = secret.GetAPIKEY();
            string apiSecret = secret.GETAPISECRET();
            richTextBox1.Text = "API_KEY: " + apiKey + "\n" + "API_SECRET: " + apiSecret + "\n" + bma + "\n\n";
            richTextBox1.Text += bma.GetOrderBook("XBT", 25);
        }
    }
}
