using System;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/05/13/032231
    public class TypeSwitch : IFeature
    {
        public void Execute()
        {
            //--- extended 'is' - constant matching
            {
                var x = 123;

                var a = x is 123;
                var b = x is 456;
                var c = x == 'a';
              //var d = x is "123"; //--- Error!! : Cannot implicitly convert type 'string' to 'int'

                Console.WriteLine($"{nameof(a)} : {a}");
                Console.WriteLine($"{nameof(b)} : {b}");
                Console.WriteLine($"{nameof(c)} : {c}");
            }

            //--- extended 'is' - type matching
            {
                object x = "abc";
                if (x is string v)
                {
                    //--- do something using v
                    Console.WriteLine(v);
                }
                //--- v CAN'T be used here
            }

            //--- extended 'switch'
            {
                object x = 123;
                switch (x)
                {
                    case "123":
                        Console.WriteLine($"{x} : compare to constant string");
                        break;

                    case int v when 100 < v:
                        Console.WriteLine($"{v} : case guard");
                        break;

                    case int v:
                        Console.WriteLine($"{v} : NOT case guard");
                        break;

                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
        }
    }
}