using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 模板方法模式
    /// </summary>
    public class TemplateMethodPattern
    {
        //public static void Main()
        //{
        //    AbstractOrderService service = new OrderService();
        //    service.CreateOrder(10, "猪肉");

        //    /*
        //     运行结果
        //        打印参数
        //        下单成功,商品猪肉 * 10
        //     */
        //}
    }
    public abstract class AbstractOrderService
    {
        public void CreateOrder(int qty, string name)
        {
            Console.WriteLine("打印参数");
            DoCreate(qty, name);
        }
        protected abstract void DoCreate(int qty, string name);
    }
    public class OrderService : AbstractOrderService
    {
        protected override void DoCreate(int qty, string name)
        {
            Console.WriteLine($"下单成功,商品{name} * {qty}");
        }
    }
}
