using System;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/06/29/234111
    public class OutVariableDeclarations : IFeature
    {
        public void Execute()
        {
            if (int.TryParse("123", out var value))
                Console.WriteLine(value);

            //--- you can use value after
            Console.WriteLine(value);
        }
    }
}