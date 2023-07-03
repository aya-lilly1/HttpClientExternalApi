using HttpClientExternalApi.Data;
using HttpClientExternalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientExternalApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpClientFactory _clientFactory;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger,IHttpClientFactory clientFactory, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public async Task<IActionResult>  Employee()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://hub.dummyapis.com/employee?noofRecords=10&idStarts=1001");
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadFromJsonAsync<Employee[]>();

                return View(employees);
            }
            return View();

            //var client = _clientFactory.CreateClient("hub");

            //try
            //{
            //    var employee = await client.GetFromJsonAsync<Employee[]>("employee?noofRecords=10&idStarts=1001");

            //    return View(employee);
            //}
            //catch (Exception ex)
            //{
            //    return NotFound();
            //}
            //return View();

        }

  
        public async Task<IActionResult> AddEmployee()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://hub.dummyapis.com/employee?noofRecords=10&idStarts=1001");
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadFromJsonAsync<Employee[]>();

                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest("Somthing Error");
               
        }


        }
}
