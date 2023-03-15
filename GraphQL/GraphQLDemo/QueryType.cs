using HotChocolate.Authorization;
using HotChocolate.Language;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace GraphQLDemo
{
    [ExtendObjectType("query")]
    public class QueryType
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        //[Authorize(Roles = new[] { "user" })]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Danh sách")]
        public async Task<IQueryable<WeatherForecast>> List()
        {
            try
            {
                ////const int COUNT = 50;
                //const int COUNT = 50000;
                //HashSet<int> intHashSet = new HashSet<int>();
                //Stopwatch stopWatch = new Stopwatch();
                //for (int i = 0; i < COUNT; i++)
                //{
                //    intHashSet.Add(i);
                //}
                //stopWatch.Start();
                //for (int i = 0; i < COUNT; i++)
                //{
                //    intHashSet.Contains(i);
                //}
                //stopWatch.Stop();
                //var ssssss = stopWatch.Elapsed;

                //stopWatch.Reset();
                //List<int> intList = new List<int>();
                //for (int i = 0; i < COUNT; i++)
                //{
                //    intList.Add(i);
                //}
                //stopWatch.Start();
                //for (int i = 0; i < COUNT; i++)
                //{
                //    intList.Contains(i);
                //}
                //stopWatch.Stop();
                //var sss = stopWatch.Elapsed;

                //HashSet <int> hashset1 = new HashSet<int>() {
                //    5,2,3,4
                //};
                //hashset1.Add(3);

                int i = 10;
                string s1 = "hello ";
                //string s2 = s1;
                //s2 += "world";
                var img = new TestImage()
                {
                    No = "10"
                };
                var images = new List<TestImage>()
                {
                    new TestImage(){ No = "1", ImageHash = "hash"},
                    new TestImage(){ No = "1", ImageHash = "hash"}
                };
                TestReferenceType(images, i, s1, img);
                //var images2 = images;
                //images2.Add(
                //    new TestImage() { No = "2", ImageHash = "hash2" }
                //);
                var dicImages = new Dictionary<string, TestImage>();
                dicImages.Add("1", new TestImage() { No = "2", ImageHash = "hash" });
                dicImages.Add("2", new TestImage() { No = "2", ImageHash = "hash1" });
                if (images.Any(x => dicImages.ToList().Any(d => d.Value.No == x.No && d.Value.ImageHash != x.ImageHash)))
                {
                    var s = "ok";
                }


                using (var scope = new TransactionScope())
                {
                    //await TestTask();
                }
                var lst = new List<WeatherForecast>()
                {
                    new WeatherForecast()
                    {
                        Date = DateTime.Now,
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                        Authors = new List<Author>() {
                            new Author()
                            {
                                Id = 1,
                                Name = "Author1",
                                Blogs = new List<Blog>()
                                {
                                    new Blog(){Id  = 1}
                                }
                            },
                            new Author()
                            {
                                Id = 2,
                                Name = "Author2"
                            }
                        }
                    },
                    new WeatherForecast()
                    {
                        Date = DateTime.Now,
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                        Authors = new List<Author>() {
                            new Author()
                            {
                                Id = 3,
                                Name = "Author3",
                                Blogs = new List<Blog>()
                                {
                                    new Blog(){Id  = 3}
                                }
                            },
                            new Author()
                            {
                                Id = 4,
                                Name = "Author4"
                            }
                        }
                    },
                    new WeatherForecast()
                    {
                        Date = DateTime.Now,
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                        Authors = new List<Author>() {
                            new Author()
                            {
                                Id = 5,
                                Name = "Author3",
                                Blogs = new List<Blog>()
                                {
                                    new Blog(){Id  = 5}
                                }
                            },
                            new Author()
                            {
                                Id = 6,
                                Name = "Author4"
                            }
                        }
                    }
                }.AsQueryable();
                //var edges = lst.Select(x => new Edge<WeatherForecast>(x, x.Summary.ToString())).ToList();
                //var pageInfo = new ConnectionPageInfo(false, false, null, null);
                //var connection = new Connection<WeatherForecast>(edges, pageInfo,
                //                ct => ValueTask.FromResult(0));

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public WeatherForecast? Get(List<int>? id)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Authors = new List<Author>() { new Author()
                {
                    Id = 1,
                    Name = "Author"
                }}
            }).FirstOrDefault();
        }

        public async Task TestTask()
        {
            await Task.Delay(5000).ConfigureAwait(true);
            //return Task.CompletedTask;
        }

        private void TestReferenceType(List<TestImage> lst, int i, string s, TestImage img)
        {
            img.ImageHash = "Hesolosoly";
            s += "world";
            i = i + 10;
            lst.Add(
                    new TestImage() { No = "2", ImageHash = "hash2" }
                );
        }
    }

    public class TestImage
    {
        public string? No { get; set; }
        public string? ImageHash { get; set; }
    }
}
