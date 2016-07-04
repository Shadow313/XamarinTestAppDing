using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace TestApp
{
    class RestService
    {
        HttpClient client;
        const String Username = "user";
        const String Password = "password";
        const String RestUrl = "http://192.168.0.70:8080/sven";
        public List<ListEntry> items { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*public async Task<List<ListEntry>> RefreshDataAsync()
        {
            items = new List<ListEntry>();
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ListEntry>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return items;
        }*/

        public async Task<List<ListEntry>> RefreshDataAsync()
        {
            List<ListEntry> items = null;
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ListEntry>>(content);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(@"Error", e.Message);
            }
            return items;
        }

        public async Task SaveListEntryAsync(ListEntry item, bool isNewItem)
        {
            var uri = new Uri(string.Format(RestUrl, item.Id));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var uri = new Uri(string.Format(RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
}
