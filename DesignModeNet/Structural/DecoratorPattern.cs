using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    public class DecoratorPattern
    {
        //public static void Main()
        //{
        //    Console.WriteLine("正在制作：");
        //    AbstractFood food = new Hamburg();
        //    food.Operation();
        //    food = new Egg(food);
        //    food.Operation();
        //    food = new Beef(food);
        //    food.Operation();

        //    Console.WriteLine($"制作完成，请付{food.GetPrice()}元");

        //    /*
        //     运行结果：
        //        正在制作：
        //        加入原味汉堡
        //        加蛋
        //        加牛肉
        //        制作完成，请付21元
        //     */
        //}
    }
    public abstract class AbstractFood
    {
        protected double _price;
        public abstract void Operation();
        public double GetPrice() { return _price; }
    }
    public class Hamburg : AbstractFood
    {
        public override void Operation()
        {
            _price = 3;
            Console.WriteLine("加入原味汉堡");
        }
    }
    public abstract class HamburgDecorator : AbstractFood
    {
        protected AbstractFood _food;
    }
    public class Egg : HamburgDecorator
    {
        public Egg(AbstractFood food)
        {
            this._food = food;
        }
        public override void Operation()
        {
            this._price = this._food.GetPrice() + 3;
            Console.WriteLine("加蛋");
        }
    }
    public class Beef : HamburgDecorator
    {
        public Beef(AbstractFood food)
        {
            this._food = food;
        }
        public override void Operation()
        {
            this._price = this._food.GetPrice() + 15;
            Console.WriteLine("加牛肉");
        }
    }
}
