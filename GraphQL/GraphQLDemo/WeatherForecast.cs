namespace GraphQLDemo
{    
    public class Tesst
    {
        public List<WeatherForecast> List { get; set; }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }
        [UseFiltering]
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [GraphQLType(typeof(NonNullType<UploadType>))]
        public IFile File { get; set; }
        public ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
    }

    public class Blog
    {
        public int Id { get; set; }
    }
}