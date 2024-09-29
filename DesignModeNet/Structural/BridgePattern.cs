using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 桥接模式
    /// </summary>
    /// <remarks>
    /// 平时如果我们实现N种颜色M种物品，那么需要写N * M个类，通过桥接模式解耦和，将创建N + M个类即可
    /// </remarks>
    public class BridgePattern
    {
        //public static void Main()
        //{
            
        //    IColor green = new Green();
        //    AbstractAnything hair = new Hair();
        //    hair.SetColor(green);
        //    hair.Operation();

        //    IColor red = new Red();
        //    AbstractAnything balloon = new Balloon();
        //    balloon.SetColor(red);
        //    balloon.Operation();

        //    /*
        //     运行结果：
        //        正在给头发涂上绿色..
        //        正在给气球涂上红色..
        //     */
        //}
    }
    public abstract class AbstractAnything
    {
        protected string _name;
        protected IColor _color;
        public AbstractAnything(string name)
        {
            _name = name;
        }
        public virtual void SetColor(IColor color)
        {
            this._color = color;
        }

        public virtual void Operation()
        {
            _color.ToPaint(this._name);
        }

    }
    public class Hair : AbstractAnything
    {
        public Hair() : base("头发") { }
    }

    public class Balloon : AbstractAnything
    {
        public Balloon() : base("气球") { }
    }

    public interface IColor
    {
        void ToPaint(string name);
    }
    public class Red : IColor
    {
        public void ToPaint(string name)
        {
            Console.WriteLine($"正在给{name}涂上红色..");
        }
    }
    public class Green : IColor
    {
        public void ToPaint(string name)
        {
            Console.WriteLine($"正在给{name}涂上绿色..");
        }
    }
}
