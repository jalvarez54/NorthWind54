using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WFAWebApiClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData(
                ConfigurationManager.AppSettings["adressWebApiServer"].ToString());
        }
        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public Int16 UnitsInStock { get; set; }
            public Int16 UnitsOnOrder { get; set; }
            public bool Discontinued { get; set; }
            public Int16 ReorderLevel { get; set; }
        }
        private void GetData(string serverAdress)
        {
            labelServer.Text = serverAdress;

            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(serverAdress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            try
            {
                response = client.GetAsync("api/Product").Result;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                return;
            } 
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                dataGridView1.DataSource = products;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        private void buttonFetch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            GetData(textBoxServerAdress.Text);
        }
    }
}
