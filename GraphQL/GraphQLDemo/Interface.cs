namespace GraphQLDemo
{
    public interface IRepository<T> where T : class
    {
        Author GetAuthor(int id);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public Author GetAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
