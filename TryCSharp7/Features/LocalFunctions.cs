using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/04/17/235920
    public class LocalFunctions : IFeature
    {
        public void Execute()
        {
            foreach (var x in repeat(12.3, 4))
                Console.WriteLine(x);

            //--- 1. Local functions everywhere! Of course, it can also be defined under return statement.
            //--- 2. Local functions is same as usual funtion, so it also allows you to use generics and yield etc.
            IEnumerable<T> repeat<T>(T x, int count)
                where T : struct
            {
                for (int i = 0; i < count; i++)
                    yield return x;
            }
        }
    }
}