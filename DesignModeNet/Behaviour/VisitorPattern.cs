using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 访问者模式
    /// </summary>
    public class VisitorPattern
    {
        //public static void Main()
        //{
        //    IVisitor vipUser = new VipUser();
        //    IVisitor normalUser = new NormalUser();
        //    IProduct meter = new Meter("东北大米", 35);
        //    IProduct egg = new Egg("初生蛋", 22);

        //    meter.Accept(vipUser);
        //    meter.Accept(normalUser);

        //    egg.Accept(vipUser);
        //    egg.Accept(normalUser);

        //    /*
        //     运行结果：
        //        会员用户：东北大米 一份 28 元！
        //        普通用户：东北大米 一份 35 元！
        //        会员用户：初生蛋 一份 17.6 元！
        //        普通用户：初生蛋 一份 22 元！
        //     */
        //}
    }
    public interface IVisitor
    {
        void VisitProduct(IProduct product);
    }
    public class VipUser : IVisitor
    {
        public void VisitProduct(IProduct product)
        {
            Console.WriteLine($"会员用户：{product.Name} 一份 {product.Price * 0.8} 元！");
        }
    }
    public class NormalUser : IVisitor
    {
        public void VisitProduct(IProduct product)
        {
            Console.WriteLine($"普通用户：{product.Name} 一份 {product.Price} 元！");
        }
    }

    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        void Accept(IVisitor visitor);
    }
    public class Meter : IProduct
    {
        public Meter(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; }

        public double Price { get; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitProduct(this);
        }

    }
    public class Egg : IProduct
    {
        public Egg(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; }

        public double Price { get; }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitProduct(this);
        }
    }
}
