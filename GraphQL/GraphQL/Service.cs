namespace GraphQLExam
{
    public interface IService
    {
        Author GetAuthor();
    }
    public class Service : IService
    {
        public Author GetAuthor()
        {
            return new Author()
            {
                Id = 1,
                Name = "Author"
            };
        }
    }
}
