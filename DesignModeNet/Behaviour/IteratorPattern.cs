using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 迭代器模式
    /// </summary>
    public class IteratorPattern
    {
        //public static void Main()
        //{
        //    var list = new ConcreteAggregate<string>();
        //    list.Add("小明");
        //    list.Add("小红");
        //    list.Add("小军");
        //    var iterator = list.GetIterator();
        //    while (!iterator.IsDone())
        //    {
        //        Console.WriteLine(iterator.Next());
        //    }

        //    /*
        //     运行结果：
        //        小明
        //        小红
        //        小军
        //     */
        //}
    }
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool IsDone();
    }
    /// <summary>
    /// 具体迭代器
    /// </summary>
    public class ConcreteIterator<T> : IIterator<T>
    {
        IAggregate<T> _data;
        int idx = 0;
        public ConcreteIterator(IAggregate<T> item)
        {
            _data = item;
        }
        public T First()
        {
            return _data.Get(0);
        }
        public T Next()
        {
            return IsDone() ? default : _data.Get(idx++);
        }
        public bool IsDone()
        {
            return idx >= _data.Count();
        }


    }
    public interface IAggregate<T>
    {
        IIterator<T> GetIterator();
        int Count();
        void Add(T item);
        T Get(int idx);
    }
    /// <summary>
    /// 具体收集器
    /// </summary>
    public class ConcreteAggregate<T> : IAggregate<T>
    {
        //这里应该使用T[]数组作为内部变量，这里为了简单演示使用List
        private List<T> _data = new List<T>();
        public void Add(T item)
        {
            _data.Add(item);
        }
        public int Count()
        {
            return _data.Count;
        }
        public T Get(int idx)
        {
            return _data[idx];
        }
        public IIterator<T> GetIterator()
        {
            return new ConcreteIterator<T>(this);
        }
    }
}
