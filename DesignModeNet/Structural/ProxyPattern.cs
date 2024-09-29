using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 代理模式
    /// </summary>
    /// 它跟装饰器的区别，代理和实体之间一般是一层关系的，装饰器是多层嵌套
    public class ProxyPattern
    {
        //public static void Main()
        //{
        //    var rr = new RealRequest();
        //    var proxy =new  ProxyRequest(rr);

        //    proxy.Request();

        //    /*
        //     运行结果：
        //        打印请求参数  
        //        真实的请求..
        //        打印请求结果
        //     */
        //}
    }
    public interface IRequest
    {
        void Request();
    }
    public class RealRequest : IRequest
    {
        public void Request()
        {
            Console.WriteLine("真实的请求..");
        }
    }
    public class ProxyRequest : IRequest
    {
        private readonly RealRequest _rr;
        public ProxyRequest(RealRequest rr)
        {
            _rr = rr;
        }
        public void Request()
        {
            Console.WriteLine("打印请求参数");
            _rr.Request();
            Console.WriteLine("打印请求结果");
        }
    }
}
