using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 命令模式
    /// </summary>
    public class CommandPattern
    {
        //public static void Main()
        //{
        //    var tv = new TV();
        //    var contral = new Contral();
        //    ICommand onCommand = new OnCommand(tv);
        //    contral.CommandExcute(onCommand);
        //    ICommand offCommand = new OffCommand(tv);
        //    contral.CommandExcute(offCommand);
        //    contral.CommandUndo(offCommand);

        //    Console.ReadKey();
        //    /*
        //     运行结果：
        //        电视打开了
        //        电视关闭了
        //        电视打开了
        //     */
        //}
    }
    public class TV
    {
        public void Off()
        {
            Console.WriteLine("电视关闭了");
        }
        public void On()
        {
            Console.WriteLine("电视打开了");
        }
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class OffCommand : ICommand
    {
        private TV _tv;
        public OffCommand(TV tv)
        {
            this._tv = tv;
        }
        public void Execute()
        {
            _tv.Off();
        }

        public void Undo()
        {
            _tv.On();
        }
    }
    public class OnCommand : ICommand
    {
        private TV _tv;
        public OnCommand(TV tv)
        {
            this._tv = tv;
        }
        public void Execute()
        {
            _tv.On();
        }

        public void Undo()
        {
            _tv.Off();
        }
    }
    public class Contral : IDisposable
    {
        private readonly Queue<Action> _queue = new Queue<Action>();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        public Contral()
        {
            _ = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    if (_queue.Count == 0)
                    {
                        await Task.Delay(500);
                        continue;
                    }
                    if (_queue.TryDequeue(out Action item))
                    {
                        item.Invoke();
                    }
                }
            }, _cts.Token);
        }

        public void Dispose()
        {
            _queue.Clear();
            _cts.Cancel();
            _cts.Dispose();
        }

        public void CommandExcute(ICommand command)
        {
            _queue.Enqueue(() => command.Execute());
        }
        public void CommandUndo(ICommand command)
        {
            _queue.Enqueue(() => command.Undo());
        }
    }
}
