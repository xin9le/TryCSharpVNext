using System;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/09/25/000040
    public class ThrowExpressions : IFeature
    {
        public void Execute()
        {
            try { ParseAsInt("abc"); }       catch (Exception ex) { Console.WriteLine(ex.GetType()); }
            try { Assert(null); }            catch (Exception ex) { Console.WriteLine(ex.GetType()); }
            try { var x = this.Name; }       catch (Exception ex) { Console.WriteLine(ex.GetType()); }
            try { var x = this.SayHello(); } catch (Exception ex) { Console.WriteLine(ex.GetType()); }
        }


        //---- in conditional operators (?:)
        private int ParseAsInt(string value)
            => int.TryParse(value, out var result)
            ?  result
            :  throw new ArgumentException(nameof(value));


        //--- in null-coalescing operators (??)
        private object Assert(object x)
            => x ?? throw new ArgumentNullException(nameof(x));


        //--- in expression-bodied property
        public string Name => throw new NotImplementedException();
        public string SayHello() => throw new NotImplementedException();
    }
}