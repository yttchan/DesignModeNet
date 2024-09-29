using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 状态模式
    /// </summary>
    public class StatePattern
    {
        //public static void Main()
        //{
        //    var context = new Context(2);
        //    context.Request();
        //    context.Request();
        //    context.Request();

        //    /*
        //     运行结果：
        //        成功购买1瓶饮料..
        //        成功购买1瓶饮料..
        //        饮料机缺货状态中，需补货！
        //     */
        //}
    }
    /// <summary>
    /// 饮料机
    /// </summary>
    public class Context
    {
        private IState state;
        private int count;
        public Context(int count)
        {
            this.count = count;
            this.state = count > 0 ? new StateA() : new StateB();
        }
        public void Request()
        {
            state.Handle(this);
        }
        public void SetCount(int count) => this.count = count;
        public int GetCount() => this.count;
        public void SetState(IState state) => this.state = state;
        public IState GetState() => this.state;
    }
    public interface IState
    {
        void Handle(Context context);
    }
    /// <summary>
    /// 有货
    /// </summary>
    public class StateA : IState
    {
        public void Handle(Context context)
        {
            var count = context.GetCount();
            if (count >= 1)
            {
                Console.WriteLine("成功购买1瓶饮料..");
                context.SetCount(count - 1);
            }

            if (context.GetCount() == 0)
            {
                context.SetState(new StateB());
            }
        }
    }
    /// <summary>
    /// 无货
    /// </summary>
    public class StateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("饮料机缺货状态中，需补货！");
        }
    }
}
