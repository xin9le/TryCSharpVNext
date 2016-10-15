using System;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/04/27/031218
    public class RefLocalsAndRefReturns : IFeature
    {
        public void Execute()
        {
            var a = 1;
            ref var d = ref PassThrough(ref a);

            Console.WriteLine($"Before : ({nameof(a)}, {nameof(d)}) = ({a}, {d})");
            d = 2;
            Console.WriteLine($"After  : ({nameof(a)}, {nameof(d)}) = ({a}, {d})");
        }

        private ref int PassThrough(ref int b)
        {
            ref var c = ref b;
            return ref c;
        }
    }
}