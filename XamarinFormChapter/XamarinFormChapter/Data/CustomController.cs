using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using XamarinFormChapter.Models;

namespace XamarinFormChapter.Data
{
    
    public class CustomController
    {
        string apiBaseUri = "http://192.168.1.250:8088/";
        string userName = "hp.codoc@yahoo.com.vn";
        string password = "P@ssw0rd";

        public ListResult GetRequest<T>(string token, string requestPath)
        {
            List<T> list = null;
            ListResult listResult = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //setup client
                    client.BaseAddress = new Uri(apiBaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    //make request
                    HttpResponseMessage response = client.GetAsync(requestPath).Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        list = JsonConvert.DeserializeObject<List<T>>(responseData);
                        listResult = new ListResult(list);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listResult;
        }

        public ListResult PostRequest<T>(string token, string requestPath, object para)
        {
            ListResult listResult = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //setup client
                    client.BaseAddress = new Uri(apiBaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    //make request
                    HttpResponseMessage response = client.PostAsync(requestPath, new StringContent(JsonConvert.SerializeObject(para), Encoding.UTF8, "application/json")).Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        listResult = JsonConvert.DeserializeObject<ListResult>(responseData);
                        listResult.ClassResult = JsonConvert.DeserializeObject<List<T>>(listResult.ClassResult.ToString());
                        listResult.PagingResult = JsonConvert.DeserializeObject<PagingResult>(listResult.PagingResult.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listResult;
        }

        public UpdateResult PostRequest(string token, string requestPath, object para)
        {
            UpdateResult updateResult = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //setup client
                    client.BaseAddress = new Uri(apiBaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    //make request
                    HttpResponseMessage response = client.PostAsync(requestPath, new StringContent(JsonConvert.SerializeObject(para), Encoding.UTF8, "application/json")).Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        updateResult = JsonConvert.DeserializeObject<UpdateResult>(responseData);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return updateResult;
        }

        public string GetAPIToken()
        {
            try
            {

                using (var client = new HttpClient())
                {
                    //setup client
                    client.BaseAddress = new Uri(apiBaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //setup login data
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password),
                 });

                    //send request
                    HttpResponseMessage responseMessage = client.PostAsync(apiBaseUri + "/Token", formContent).Result;

                    //get access token from response body
                    var responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                    var jObject = JObject.Parse(responseJson);
                    return jObject.GetValue("access_token").ToString();
                }

            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}