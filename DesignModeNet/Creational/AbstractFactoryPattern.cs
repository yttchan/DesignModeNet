using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Creational
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    /// <remarks>
    /// 相比工厂模式，一个工厂类可以实例多种 不同的实例对象 创建方法
    /// </remarks>
    public class AbstractFactoryPattern
    {
        //public static void Main()
        //{
        //    IFoodFactory foodFactory_1 = new FoodFactory_1();
        //    AbstractChicken chicken_1 = foodFactory_1.CreateChicken();
        //    AbstractFish fish_1 = foodFactory_1.CreateFish();
        //    chicken_1.Info();
        //    fish_1.Info();
        //    //----
        //    IFoodFactory foodFactory_2 = new FoodFactory_2();
        //    AbstractChicken chicken_2 = foodFactory_2.CreateChicken();
        //    AbstractFish fish_2 = foodFactory_2.CreateFish();
        //    chicken_2.Info();
        //    fish_2.Info();

        //    /*
        //     运行结果：
        //        这是清远鸡..
        //        这是三文鱼..
        //        这是文昌鸡..
        //        这是草鱼..
        //     */
        //}
    }

    public interface IFoodFactory
    {
        AbstractChicken CreateChicken();
        AbstractFish CreateFish();
    }
    public class FoodFactory_1 : IFoodFactory
    {
        public AbstractChicken CreateChicken()
        {
            return new QingyuanChicken();
        }

        public AbstractFish CreateFish()
        {
            return new Salmon();
        }
    }
    public class FoodFactory_2 : IFoodFactory
    {
        public AbstractChicken CreateChicken()
        {
            return new WenchangChicken();
        }

        public AbstractFish CreateFish()
        {
            return new GrassCarp();
        }
    }
    public interface IFood
    {
        void Info();
    }
    public abstract class AbstractChicken : IFood
    {
        public abstract void Info();
    }
    public abstract class AbstractFish : IFood
    {
        public abstract void Info();
    }
    public class QingyuanChicken : AbstractChicken
    {
        public override void Info()
        {
            Console.WriteLine("这是清远鸡..");
        }
    }
    public class WenchangChicken : AbstractChicken
    {
        public override void Info()
        {
            Console.WriteLine("这是文昌鸡..");
        }
    }
    public class Salmon : AbstractFish
    {
        public override void Info()
        {
            Console.WriteLine("这是三文鱼..");
        }
    }
    public class GrassCarp : AbstractFish
    {
        public override void Info()
        {
            Console.WriteLine("这是草鱼..");
        }
    }
}
