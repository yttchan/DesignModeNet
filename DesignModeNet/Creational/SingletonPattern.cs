using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Creational
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class SingletonPattern
    {
        //public static void Main()
        //{
        //    var s1 = SingletonEntity.GetSingleton();
        //    var s2 = SingletonEntity.GetSingleton();

        //    Console.WriteLine(s1.GetHashCode());
        //    Console.WriteLine(s2.GetHashCode());

        //    /*
        //     运行结果：
        //        43942917
        //        43942917
        //     */
        //}
    }

    public class SingletonEntity
    {
        private static Lazy<SingletonEntity> _singleton = new Lazy<SingletonEntity>();

        public static SingletonEntity GetSingleton() 
        {
            return _singleton.Value;
        }
    }
}
