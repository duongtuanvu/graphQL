using HotChocolate.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;

namespace GraphQLDemo.Queries
{
    [ExtendObjectType("query")]
    public class EmployeeType
    {
        public Employee GetEmployee()
        {
            return new Employee { Id = 1, Name = "Test" };
        }

        public string GenerateToken()
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.Role, "user"),
                new Claim("usercountry","India")
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "https://auth.chillicream.com",
                audience: "https://graphql.chillicream.com",
                expires: DateTime.Now.AddHours(8),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MySuperSecretKey")), SecurityAlgorithms.HmacSha256),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public async Task<string> Test()
        {
            var stw = new Stopwatch();
            stw.Start();
            var lst = new List<int>();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 100000; i++)
            {
                //Task t = Task.Run(() =>
                //{
                //    lst.Add(i);
                //});
                //tasks.Add(t);
                tasks.Add(GetData(lst, i));
            }
            Task.WaitAll(tasks.ToArray());
            //await Task.WhenAll(tasks);
            stw.Stop();
            var ts = stw.Elapsed;
            Thread.Sleep(2000);
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00} | {4}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10, lst.Count());
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

        }
        private async Task GetData(List<int> lst, int s)
        {
            lst.Add(s);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
