using System;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/04/15/021002
    public class BinaryLiterals : IFeature
    {
        public void Execute()
        {
            var bin = 0b1011;  //--- New!!
            var dec = 123;
            var hex = 0x1F;

            Console.WriteLine($"{nameof(bin)} : {bin}");
            Console.WriteLine($"{nameof(dec)} : {dec}");
            Console.WriteLine($"{nameof(hex)} : {hex}");
        }
    }
}