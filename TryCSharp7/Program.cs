using System;
using TryCSharp7.Features;



namespace TryCSharp7
{
    class Program
    {
        static void Main()
        {
            var featrues = new IFeature[]
            {
                new BinaryLiterals(),
                new DigitSeparators(),
                new OutVariableDeclarations(),
                new LocalFunctions(),
                new RefLocalsAndRefReturns(),
                new Tuples(),
                new Deconstructions(),
                new TypeSwitch(),
                new ThrowExpressions(),
                new ExpressionBodiedEverything(),
                new ArbitraryAsyncReturns(),
                new Discards(),
            };

            foreach (var x in featrues)
            {
                Console.WriteLine($"----- {x.GetType().Name}");
                x.Execute();
                Console.WriteLine();
            }   
        }
    }
}