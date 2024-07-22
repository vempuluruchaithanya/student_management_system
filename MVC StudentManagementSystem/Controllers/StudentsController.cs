using Microsoft.AspNetCore.Mvc;
using MVC_StudentManagementSystem.Models;
using MVC_StudentManagementSystem.Models.DTO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace MVC_StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {

        private readonly IHttpClientFactory httpClientFactory;

        public StudentsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<StudentDto> response = new List<StudentDto>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7156/api/students");

                httpResponseMessage.EnsureSuccessStatusCode();

                 response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<StudentDto>>());

                
            }
            catch (Exception ex)
            {

                
            }
            return View(response);
        }

        [HttpGet]

        public IActionResult Add()
        {

        return View(); 
        
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentviewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {

                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7156/api/students"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };


            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();

            if (response is not null)
            {
                return RedirectToAction("Index", "Students");
            }

            return View();



        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<StudentDto>($"https://localhost:7156/api/students/{id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Edit(StudentDto request)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {

                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7156/api/students/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")


            };


            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();

            if(response is not null)
            {
                return RedirectToAction("Edit", "Students");
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Delete(StudentDto request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7156/api/students/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Students");


            }
            catch (Exception ex)
            {

            }

            return View("Edit");
        }

        


        }


    }

 



