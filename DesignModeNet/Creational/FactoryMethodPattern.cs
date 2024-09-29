using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Creational
{
    /// <summary>
    /// 工厂方法
    /// </summary>
    /// <remarks>
    /// 相比简单工厂，增加了具体实例对象的工厂，不再使用通过传参switch的方式，满足开放扩展，关闭修改原则
    /// </remarks>
    public class FactoryMethodPattern
    {

        //public static void Main()
        //{
        //    IAnimalFactory factory1 = new CatFactory();
        //    IAnimal animal1 = factory1.Create();
        //    animal1.Info();

        //    IAnimalFactory factory2 = new DogFactory();
        //    IAnimal animal2 = factory2.Create();
        //    animal2.Info();

        //    /*
        //     运行结果：
        //        This is a cat
        //        This is a dog
        //     */
        //}
    }

    public interface IAnimalFactory
    {
        IAnimal Create();
    }
    public class CatFactory : IAnimalFactory
    {
        public IAnimal Create()
        {
            return new Cat();
        }
    }
    public class DogFactory : IAnimalFactory
    {
        public IAnimal Create()
        {
            return new Dog();
        }
    }
    public interface IAnimal
    {
        void Info();
    }
    public class Cat : IAnimal
    {
        public void Info()
        {
            Console.WriteLine("This is a cat");
        }
    }
    public class Dog : IAnimal
    {
        public void Info()
        {
            Console.WriteLine("This is a dog");
        }
    }
}
