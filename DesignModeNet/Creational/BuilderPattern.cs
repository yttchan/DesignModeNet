using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Creational
{
    /// <summary>
    /// 生成器模式
    /// </summary>
    public class BuilderPattern
    {
        //public static void Main()
        //{
        //    Director director = new Director();
        //    //-

        //    AbstractCarBuilder build_1 = new BaomaBuilder();
        //    director.Construct(build_1);
        //    Car car_1 = build_1.GetResult();
        //    car_1.Show();

        //    AbstractCarBuilder build_2 = new BenChiBuilder();
        //    director.Construct(build_2);
        //    Car car_2 = build_2.GetResult();
        //    car_2.Show();

        //    /*
        //     运行结果：
        //        该车（宝马）的部件有：A,B,C,D
        //        该车（奔驰）的部件有：A,C,E,F
        //     */
        //}
    }
    public class Director
    {
        public void Construct(AbstractCarBuilder builder)
        {
            builder.BuildPart();
        }
    }
    public abstract class AbstractCarBuilder
    {
        public abstract void BuildPart();
        public abstract Car GetResult();
    }
    public class BaomaBuilder : AbstractCarBuilder
    {
        private Car _car = null;
        public override void BuildPart()
        {
            _car ??= new Car("宝马");
            _car.AddPart("A");
            _car.AddPart("B");
            _car.AddPart("C");
            _car.AddPart("D");
        }
        public override Car GetResult()
        {
            return _car;
        }
    }
    public class BenChiBuilder : AbstractCarBuilder
    {
        private Car _car = null;
        public override void BuildPart()
        {
            _car ??= new Car("奔驰");
            _car.AddPart("A");
            _car.AddPart("C");
            _car.AddPart("E");
            _car.AddPart("F");
        }
        public override Car GetResult()
        {
            return _car;
        }
    }
    public class Car
    {
        private Lazy<List<string>> _partList = new Lazy<List<string>>();
        private string _name;
        public Car(string name)
        {
            this._name = name;
        }
        public void AddPart(string part)
        {
            _partList.Value.Add(part);
        }
        public void Show()
        {
            Console.WriteLine($"该车（{_name}）的部件有：{string.Join(",", _partList.Value)}");
        }
    }
}
