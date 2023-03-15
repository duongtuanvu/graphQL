using HotChocolate;

namespace GraphQLDemo
{
    public class MutationType
    {
        public Author CreateAuthor(Author author)
        {
            return new Author()
            {
                Id = 2,
                Name = " vudt_create"
            };
        }

        public Author UpdateAuthor(Author author)
        {
            if (author.Id == 1)
            {
                throw new Exception("error");
            }
            var authorDto = new Author()
            {
                Id = 1,
                Name = " vudt_update"
            };
            return null;
        }        
    }
}
