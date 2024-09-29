using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Creational
{
    /// <summary>
    /// 简单工厂模式
    /// </summary>
    public class SimpleFactoryPattern
    {
        //public static void Main()
        //{
        //    AbstractProduct product1 = ProductFactory.CreateProduct("phone");
        //    product1.Info();

        //    AbstractProduct product2 = ProductFactory.CreateProduct("computer");
        //    product2.Info();

        //    /*
        //     运行结果：
        //        this is phone
        //        this is computer
        //     */
        //}
    }
    public class ProductFactory
    {
        public static AbstractProduct CreateProduct(string type)
        {
            AbstractProduct product = null;
            switch (type)
            {
                case "phone":
                    product = new Phone();
                    break;
                case "computer":
                    product = new Computer();
                    break;
                default:
                    break;
            }
            return product;
        }
    }
    public abstract class AbstractProduct
    {
        public abstract void Info();
    }
    public class Phone : AbstractProduct
    {
        public override void Info()
        {
            Console.WriteLine("this is phone");
        }
    }
    public class Computer : AbstractProduct
    {
        public override void Info()
        {
            Console.WriteLine("this is computer");
        }
    }
}
