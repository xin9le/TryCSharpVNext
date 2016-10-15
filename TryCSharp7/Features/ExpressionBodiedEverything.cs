using System;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/09/27/231311
    public class ExpressionBodiedEverything : IFeature
    {
        public void Execute()
        {
            var x = new Foo("Constructor");
            x[123] = "Setter Indexer";
            Console.WriteLine(x[456]);
            x.Property = "Setter Property";
            Console.WriteLine(x.Property);

            //--- for destructor call
            x = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        private class Foo
        {
            //--- accessor in property
            //--- Allows get only / set only
            public string Property
            {
                get => "Getter Property";
                set => Console.WriteLine(value);
            }

            //--- indexer
            public string this[int index]
            {
                get => $"{index} : Getter Indexer";
                set => Console.WriteLine($"{index} : {value}");
            }

            //--- constructor / destructor
            public Foo(string text) => Console.WriteLine(text);
            ~Foo() => Console.WriteLine("Destructor");
        }
    }
}