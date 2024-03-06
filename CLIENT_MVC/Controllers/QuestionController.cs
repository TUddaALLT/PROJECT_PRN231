
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CLIENT_MVC.Controllers
{
    public class QuestionController : Controller
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";

        public QuestionController( )
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:8080/api/Question";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage respone = await client.GetAsync("https://localhost:8080/api/Question");
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var list = JsonSerializer.Deserialize<List<Question>>(strData, options) ?? new List<Question>();
            ViewBag.Questions = list;
            return View();
        }

        


    }
}