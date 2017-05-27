namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2017/05/28/020129
    public class Discards : IFeature
    {
        public void Execute()
        {
            this.OutVariable(out var _);
            this.OutVariable(out _);

            this.OutVariable2(out var _, out var _);
            this.OutVariable2(out _, out _);

            var (name, _) = ("xin9le", 32);
            var (_, _) = ("xin9le", 32);
        }



        private void OutVariable(out int value)
            => value = 123;


        private void OutVariable2(out int x, out string y)
        {
            x = 123;
            y = "abc";
        }


        private void TypeSwitch()
        {
            switch ("abc")
            {
                case string _:
                    break;
                
                //--- following code occurs compile error
                //--- Not supported under C# 7 
                //case _:
                //    break;
            }
        }
    }
}