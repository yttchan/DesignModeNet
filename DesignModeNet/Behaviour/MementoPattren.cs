using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 备忘录模式
    /// </summary>
    /// <remarks>
    /// 应用在 git管理、快照
    /// </remarks>
    public class MementoPattren
    {
        //public static void Main()
        //{
        //    Originator originator = new Originator();
        //    Caretaker caretaker = new Caretaker();
        //    originator.SetState("版本一");
        //    originator.SetState("版本二");
        //    caretaker.AddMemento(originator.SaveMemento());
        //    originator.SetState("版本三");
        //    caretaker.AddMemento(originator.SaveMemento());
        //    originator.SetState("版本四");

        //    Console.WriteLine("第一次快照：" + caretaker.GetMemento(0).GetState());
        //    Console.WriteLine("第二次快照：" + caretaker.GetMemento(1).GetState());
        //    originator.SaveMementoState(caretaker.GetMemento(1));

        //    /*
        //     运行结果：
        //        当前版本：版本一
        //        当前版本：版本二
        //        当前版本：版本三
        //        当前版本：版本四
        //        第一次快照：版本二
        //        第二次快照：版本三
        //        回滚完成，当前版本：版本三
        //     */
        //}
    }
    /// <summary>
    /// 备忘录
    /// </summary>
    class Memento
    {
        private string _state;
        public Memento(string state)
        {
            this._state = state;
        }
        public string GetState() => this._state;
    }
    /// <summary>
    /// 原发器
    /// </summary>
    class Originator
    {
        private string _state;
        public void SetState(string state)
        {
            this._state = state;
            Console.WriteLine("当前版本：" + this._state);
        }
        public string GetState() => this._state;

        public Memento SaveMemento()
        {
            return new Memento(this._state);
        }
        public void SaveMementoState(Memento memento)
        {
            this._state = memento.GetState();
            Console.WriteLine("回滚完成，当前版本：" + this._state);
        }
    }
    /// <summary>
    /// 管理者
    /// </summary>
    class Caretaker
    {
        private List<Memento> _data = new List<Memento>();
        public void AddMemento(Memento memento) => _data.Add(memento);
        public Memento GetMemento(int idx) => idx >= _data.Count || idx < 0 ? null : _data[idx];
    }
}
