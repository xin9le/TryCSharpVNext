using System;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/07/14/055902
    public class Deconstructions : IFeature
    {
        public void Execute()
        {
            //--- Deconstruct tuple
            {
                var t = (123, "abc");
                (int x1, string y1) = t;  //--- declare type explicitly
                (var x2, var y2) = t;     //--- declare a part of (or all) types by inference 
                var (x3, y3) = t;         //--- declare all types by inference

                Console.WriteLine($"Tuple : ({nameof(x1)}, {nameof(y1)}) = ({x1}, {y1})");
                Console.WriteLine($"Tuple : ({nameof(x2)}, {nameof(y2)}) = ({x2}, {y2})");
                Console.WriteLine($"Tuple : ({nameof(x3)}, {nameof(y3)}) = ({x3}, {y3})");
            }

            //--- Deconstruct custom type
            {
                var v = new Vector3 { X = 1, Y = 2, Z = 3 };
                var (x2, y2) = v;      //--- Vector3.Deconstruct method is called.
                var (x3, y3, z3) = v;  //--- Vector3Extensions.Deconstruct method is called.
                Console.WriteLine($"Custom Type : ({nameof(x2)}, {nameof(y2)}) = ({x2}, {y2})");
                Console.WriteLine($"Custom Type : ({nameof(x3)}, {nameof(y3)}, {nameof(z3)}) = ({x3}, {y3}, {z3})");
            }
        }
    }


    internal class Vector3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        //--- Special methods for Deconstructions
        public void Deconstruct(out int x, out int y)
        {
            x = this.X;
            y = this.Y;
        }
    }

        
    internal static class Vector3Extensions
    {
        //--- Special methods for Deconstructions
        //--- Deconstructions allows you to declare as extension method
        public static void Deconstruct(this Vector3 self, out int x, out int y, out int z)
        {
            x = self.X;
            y = self.Y;
            z = self.Z;
        }
    }
}