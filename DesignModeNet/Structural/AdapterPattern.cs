using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 适配器模式
    /// </summary>
    public class AdapterPattern
    {
        //public static void Main()
        //{
        //    //Usb接口的手机通过适配器，用TypeC数据线充电
        //    Usb usb = new TypeCToUsbAdapter();
        //    usb.Request();

        //    /*
        //     运行结果：
        //        用TypeC充电
        //     */
        //}
    }
   
    public class TypeCToUsbAdapter:Usb
    {
        private Lazy<TypeC> typeC = new Lazy<TypeC>();
        public override void Request()
        {
            typeC.Value.Request();
        }
    }
    public class Usb
    {
        public virtual void Request()
        {
            Console.WriteLine("用Usb充电");
        }
    }
    public class TypeC
    {
        public virtual void Request()
        {
            Console.WriteLine("用TypeC充电");
        }
    }
}
