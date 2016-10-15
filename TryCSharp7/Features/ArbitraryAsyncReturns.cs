using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;



namespace TryCSharp7.Features
{
    //--- Learn more
    //--- http://blog.xin9le.net/entry/2016/07/28/212318
    public class ArbitraryAsyncReturns : IFeature
    {
        public void Execute()
        {
            //--- ValueTask
            var r1 = this.GetValueAsync().Result;
            Console.WriteLine(r1);

            //--- Custom Type
            var r2 = this.MyTaskTestAsync().Result;
            Console.WriteLine(r2);
        }


        //--- return type is NOT Task
        private async ValueTask<int> GetValueAsync()
        {
            await Task.Delay(200);
            return 123;
        }


        //--- return custom type
        private async MyTask<string> MyTaskTestAsync()
        {
            await Task.Delay(200);
            return "xin9le";
        }
    }


    #region MyTask
    [AsyncMethodBuilder(typeof(MyTaskBuilder<>))]
    internal class MyTask<T>
    {
        private Task<T> Task { get; }
        public T Result => this.Task.GetAwaiter().GetResult();
        internal MyTask(Task<T> task){ this.Task = task; }
    }


    internal class MyTaskBuilder<T>
    {
        private TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

        public static MyTaskBuilder<T> Create() => new MyTaskBuilder<T>();

        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine
            => stateMachine.MoveNext();

        public void SetStateMachine(IAsyncStateMachine stateMachine){}
        public void SetResult(T result) => this.tcs.SetResult(result);
        public void SetException(Exception exception) => this.tcs.SetException(exception);
        public MyTask<T> Task => new MyTask<T>(this.tcs.Task);

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
            => awaiter.OnCompleted(stateMachine.MoveNext);

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion 
            where TStateMachine : IAsyncStateMachine
            => awaiter.OnCompleted(stateMachine.MoveNext);
    }
    #endregion
}