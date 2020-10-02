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
    public class RestService 
    {
        public List<Models.Order> Items { get; private set; }
        public RestService()
        {
          
        }
        
        public async Task<List<Models.Order>> PostOrderAsync()
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(Constants.PostOrderPATH);
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var resp = await request.GetResponseAsync();
            try
            {
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    var content = sr.ReadToEnd();
                    Console.WriteLine(content);
                    //Items = JsonConvert.DeserializeObject<List<Models.ProductWihPicture>>(content);
                }
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            return Items; 
       }
    }
}
