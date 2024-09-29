using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 策略模式
    /// </summary>
    public class StrategyPattern
    {
        //public static void Main()
        //{
        //    var context = new OrderContext();
        //    context.SetStrategy(new DiscountStrategy(0.8));
        //    context.Buy(10);
        //    context.SetStrategy(new SubtractStrategy(4));
        //    context.Buy(10);

        //    /*
        //     运行结果：
        //        商品原价：10元
        //        您真正使用<8折券>,应支付：8元
        //        商品原价：10元
        //        您真正使用<无门槛4元现金券>,应支付：6元
        //     */
        //}
    }
    public class OrderContext
    {
        public IStrategy strategy;
        public void SetStrategy(IStrategy strategy) => this.strategy = strategy;

        public void Buy(double m)
        {
            Console.WriteLine($"商品原价：{m}元");
            Console.WriteLine($"您真正使用<{strategy.GetTitle()}>,应支付：{strategy.AlgorithmInterface(m)}元"); ;
        }
    }
    public interface IStrategy
    {
        string GetTitle();
        double AlgorithmInterface(double m);
    }
    /// <summary>
    /// 折扣
    /// </summary>
    public class DiscountStrategy : IStrategy
    {
        private double discount;
        public DiscountStrategy(double discount)
        {
            this.discount = discount;
        }
        public double AlgorithmInterface(double m)
        {
            return m * this.discount;
        }

        public string GetTitle()
        {
            return discount * 10 + "折券";
        }
    }
    /// <summary>
    /// 满减
    /// </summary>
    public class SubtractStrategy : IStrategy
    {
        private double discount;
        public SubtractStrategy(double discount)
        {
            this.discount = discount;
        }
        public double AlgorithmInterface(double m)
        {
            return Math.Max(m - discount, 0);
        }

        public string GetTitle()
        {
            return $"无门槛{discount}元现金券";
        }
    }
}
