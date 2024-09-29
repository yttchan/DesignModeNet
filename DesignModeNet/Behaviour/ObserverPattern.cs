using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    public class ObserverPattern
    {
        //public static void Main()
        //{
        //    ISubject subject = new ConcreteSubject("你的月亮我的心");
        //    ConcreteObserver observer_1 = new ConcreteObserver("关谷", subject);
        //    ConcreteObserver observer_2 = new ConcreteObserver("吕子乔", subject);
            
        //    subject.Notify("一群母猪排队掉进水沟...");

        //    /*
        //     运行结果：
        //        关谷关注了公众号《你的月亮我的心》...
        //        吕子乔关注了公众号《你的月亮我的心》...
        //        公众号《你的月亮我的心》发表新文章！
        //        关谷收到消息，开始阅读：一群母猪排队掉进水沟...
        //        吕子乔收到消息，开始阅读：一群母猪排队掉进水沟...
        //     */
        //}
    }
    public interface IObserver
    {
        void Update(string message);
    }
    public class ConcreteObserver : IObserver
    {
        private ISubject _subject;
        private string _message;
        private string _name;
        public ConcreteObserver(string name, ISubject subject)
        {
            _name = name;
            _subject = subject;
            _subject.AddObserver(this);
            Console.WriteLine($"{name}关注了公众号《{subject.GetName()}》...");
        }
        public void Update(string message)
        {
            this._message = message;
            Read();
        }
        public void Read()
        {
            Console.WriteLine($"{_name}收到消息，开始阅读：{this._message}");
        }
    }
    public interface ISubject
    {
        string GetName();
        void AddObserver(ConcreteObserver item);
        void RemoveObserver(ConcreteObserver item);
        void Notify(string message);
    }
    public class ConcreteSubject : ISubject
    {
        private List<ConcreteObserver> list = new List<ConcreteObserver>();
        private string _name;
        public ConcreteSubject(string name) { _name = name; }
        public void AddObserver(ConcreteObserver item)
        { 
            list.Add(item);
        }
        public void RemoveObserver(ConcreteObserver item)
        {
            list.Remove(item);
        }
        public void Notify(string message)
        {
            Console.WriteLine($"公众号《{this._name}》发表新文章！");
            foreach (IObserver item in list)
            {
                item.Update(message);
            }
        }
        public string GetName()=> this._name;
    }
}
