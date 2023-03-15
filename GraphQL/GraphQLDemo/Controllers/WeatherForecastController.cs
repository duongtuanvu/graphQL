using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace GraphQLDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get()
        {
            List<int> listData = new List<int>() { 6, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4, 7, 3, 3, 1, 7, 4, 3, 7, 2, 8, 5, 7, 4 };
            var count = 1000000;
            var s1 = new Stopwatch();
            var s2 = new Stopwatch();
            s1.Start();
            foreach (var index in TestYeild.GetListIdx1(listData, 7))
                Console.Write(index + " ");
            s1.Stop();


            s2.Start();
            foreach (var index in TestYeild.GetListIdx2(listData, 7))
                Console.Write(index + " ");
            s2.Stop();
            return Ok($"Yeild: {s2.Elapsed} - Normal: {s1.Elapsed}");
            //var graphQLClient = new GraphQLHttpClient("http://localhost:5214/graphql", new NewtonsoftJsonSerializer());
            //var testQuery = new MyGraphQLRequest
            //{
            //    Query = @"
            //            query ($id: Int!){
            //              list(id: $id, where: { authors: { some: { id: { eq: $id } } } }){
            //                date
            //                temperatureC
            //                summary
            //                authors{
            //                  ...Test1Fragment
            //                  name,
            //                  blogs{
            //                    ...TestFragment
            //                  }
            //                }    
            //              }
            //            }",
            //    Fragments = new List<Fragment>(){
            //        new Fragment(@"fragment TestFragment on Blog {
            //                        id
            //                      }"),
            //        new Fragment(@"fragment Test1Fragment on Author {
            //                          id
            //                        }")
            //    },
            //    //OperationName = "list",
            //    Variables = new
            //    {
            //        id = 2
            //    }
            //};
            //if (testQuery.Fragments.Any())
            //{
            //    testQuery.Query = String.Concat(testQuery.Query, string.Join(" ", testQuery.Fragments.Select(x => x.FragmentQuery)));
            //}
            //var graphQLResponse = await graphQLClient.SendQueryAsync<Tesst>(testQuery);
            //return Ok(graphQLResponse.Data);

            //var lst = new List<string>();
            //List<Task> tasks = new List<Task>();
            //for (int i = 0; i < 5; i++)
            //{
            //    tasks.Add(GetData(lst, i.ToString()));
            //}

            //await Task.WhenAll(tasks);
            //return Ok(lst);
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

        }

        //public async Task GetData(List<string> lst, string s)
        //{
        //    lst.Add(s);
        //}        
    }
}