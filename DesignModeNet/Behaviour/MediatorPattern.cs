using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 中介者模式
    /// </summary>
    public class MediatorPattern
    {
        //public static void Main()
        //{
        //    ConcreteMediator mediator = new ConcreteMediator();
        //    var wang = new Colleague("汪小姐");
        //    var yeshu = new Colleague("爷叔");
        //    mediator.AddColleague(wang);
        //    mediator.AddColleague(yeshu);

        //    mediator.Send("你好！",yeshu);
        //    mediator.Send("Nice to meet you.", wang);
        //}
    }

    public interface IMediator
    {
        void Send(string msg, Colleague colleague);
    }
    public class ConcreteMediator : IMediator
    {
        private Dictionary<string, Colleague> _group = new Dictionary<string, Colleague>();
        public void AddColleague(Colleague colleague)
        {
            _group.TryAdd(colleague.Name, colleague);
        }
        public void Send(string msg, Colleague receiver)
        {
            if (_group.TryGetValue(receiver.Name, out _))
            {
                receiver.Notify(msg);
            }
        }
    }
    public class Colleague
    {
        public string Name { get; }
        public Colleague(string name)
        {
            Name = name;
        }
        public void Notify(string msg)
        {
            Console.WriteLine($"{Name}收到信息：{msg}");
        }
    }
}
