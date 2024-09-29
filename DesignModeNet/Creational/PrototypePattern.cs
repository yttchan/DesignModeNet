using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Creational
{
    /// <summary>
    /// 原型模式
    /// </summary>
    public class PrototypePattern
    {
        //public static void Main()
        //{
        //    Product_A a = new Product_A("001", "A");
        //    a.Show();
        //    //-
        //    var b = (Product_A)a.Clone();
        //    b.Show();

        //    /*
        //     运行结果：
        //        001-A
        //        001-A
        //     */
        //}
    }
    public interface IPrototype
    {
        object Clone();
    }
    public class Product_A : IPrototype
    {
        private string _code;
        private string _name;
        public Product_A(string code, string name)
        {
            _code = code;
            _name = name;
        }
        public object Clone()
        {
            return new Product_A(this._code, this._name);
        }
        public void Show()
        {
            Console.WriteLine($"{_code}-{_name}");
        }
    }
}
