using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemo
{
    public static class TestYeild
    {
        // Dùng cách thông thường
        public static List<int> GetListIdx1(List<int> listData, int valueFind)
        {
            List<int> listIdx = new List<int>();
            for (int ii = 0; ii < listData.Count; ii++)
            {
                if (listData[ii] == valueFind)
                    listIdx.Add(ii);
            }
            return listIdx;
        }

        // Dùng từ khóa yield
        public static IEnumerable<int> GetListIdx2(List<int> listData, int valueFind)
        {
            for (int ii = 0; ii < listData.Count; ii++)
            {
                if (listData[ii] == valueFind)
                    yield return ii;
            }
        }
    }
}
