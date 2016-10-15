using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/05/11/030031
    public class Tuples : IFeature
    {
        public void Execute()
        {
            //--- you can name the return value as alias.
            (int sum, int count) tally(IEnumerable<int> list)
            {
                var s = 0;
                var c = 0;
                foreach (var x in list)
                {
                    s += x;
                    c++;
                }

                //--- same as `new ValueTuple<int, int>(s, c);`
                return (s, c);
            }

            var t1 = tally(new []{ 1, 2, 3 });
            Console.WriteLine($"({nameof(t1.sum)}, {nameof(t1.count)}) = {t1}");

            //--- rename alias when received.
            (int a, int b) t2 = t1;
            Console.WriteLine($"({nameof(t2.a)}, {nameof(t2.b)}) = {t2}");

            //--- tuple property can be given alias name when created.
            var t3 = (sum: t2.a, count: t2.b);
            Console.WriteLine($"({nameof(t3.sum)}, {nameof(t3.count)}) = {t3}");
        }
    }
}