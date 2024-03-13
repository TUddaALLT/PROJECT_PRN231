using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CLIENT_MVC.Utilities
{
    public class APIHelper
    {
        const string BaseUrl = "https://localhost:8080/api/";

        public async Task<IActionResult> RequestGetAsync<T>(string path)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + path);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody =  await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseBody);
                    return new OkObjectResult(responseData);
                }
                else
                {
                    throw new Exception("Get api failed");
                }
            }
        }

        public async Task<IActionResult> RequestPostAsync<T>(string path, T body)
        {
            using (var client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(body);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(BaseUrl + path, content);
                if(response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseBody);
                    return new OkObjectResult("Register successfull");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new BadRequestObjectResult("Bad request");
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }

        public async Task<IActionResult> RequestPutAsync<T>(string path, T body)
        {
            using (var client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(body);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(BaseUrl + path, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseBody);
                    return new OkObjectResult("Register successfull");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new BadRequestObjectResult("Bad request");
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
