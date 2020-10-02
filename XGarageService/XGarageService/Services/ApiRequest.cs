using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XGarageService.Services
{
    public class ApiRequest<TResponse>
    {
        string path { get; set; }
        object requestobject  { get; set; }
        public ApiRequest(string urlpath, object Request = null)
        {
            path = urlpath;
            requestobject = Request;
        }
        
        string URL
        {
            get
            {
                UriBuilder ub = new UriBuilder(Constants.BaseAddress.TrimEnd('/') + '/');
                ub.Path +=path.TrimStart('/').TrimEnd('/');
                return ub.Uri.AbsoluteUri;
            }
        }
        public async Task<string> GetString()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            using (StreamReader sr = new StreamReader(await httpClient.GetStreamAsync(URL)))
            {
                return sr.ReadToEnd();
            }
        }

        public async Task<TResponse> Get()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            using (StreamReader sr = new StreamReader(await httpClient.GetStreamAsync(URL)))
            {
                var content = sr.ReadToEnd();
                if (string.IsNullOrEmpty(content))
                    return default(TResponse); 
                TResponse result = JsonConvert.DeserializeObject<TResponse>(content);
                return result;
            }
        }
        public async Task<TResponse> Post()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            var stringContent = new StringContent(JsonConvert.SerializeObject(requestobject), UnicodeEncoding.UTF8, "application/json");
            var msg = await httpClient.PostAsync(URL, stringContent);
            var strm = await msg.Content.ReadAsStreamAsync();
            using (StreamReader sr = new StreamReader(strm))
            {
                var content = sr.ReadToEnd();
                TResponse result = JsonConvert.DeserializeObject<TResponse>(content);
                return result;
            }
        }
        public async Task<string> PostToString()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            var stringContent = new StringContent(JsonConvert.SerializeObject(requestobject), UnicodeEncoding.UTF8, "application/json");
            var msg = await httpClient.PostAsync(URL, stringContent);
            var strm = await msg.Content.ReadAsStreamAsync();
            using (StreamReader sr = new StreamReader(strm))
            {
                return sr.ReadToEnd();
            }
        }

        public async Task<byte[]> GetImage()
        {

            UriBuilder ub = new UriBuilder(Constants.BaseAddress.TrimEnd('/') + '/');
            ub.Path += path.TrimStart('/').TrimEnd('/');

            //ServicePointManager.DefaultConnectionLimit = 100;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            try
            {
                return await httpClient.GetByteArrayAsync(ub.Uri.AbsoluteUri);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
       
    }
}
