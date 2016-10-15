using System;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/04/16/160712
    public class DigitSeparators : IFeature
    {
        public void Execute()
        {
            var bin = 0b1100_1010; //--- separate by 4 bit
            var dec = 12_345_678;  //--- separate like currency
            var hex = 0x33_ff_cc;  //--- RGB separation

            Console.WriteLine($"{nameof(bin)} : {bin}");
            Console.WriteLine($"{nameof(dec)} : {dec}");
            Console.WriteLine($"{nameof(hex)} : {hex}");
        }
    }
}