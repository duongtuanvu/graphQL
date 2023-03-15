using GraphQL;

namespace GraphQLDemo
{
    public class MyGraphQLRequest : GraphQLRequest
    {
        public List<Fragment> Fragments { get; set; } = new List<Fragment>();        
    }
    public class Fragment
    {
        public Fragment(string fragmentQuery)
        {
            FragmentQuery = fragmentQuery;
        }

        public string FragmentQuery { get; set; }
    }

}
