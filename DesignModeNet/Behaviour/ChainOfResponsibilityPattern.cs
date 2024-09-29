using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 责任链模式
    /// </summary>
    public class ChainOfResponsibilityPattern
    {
        //public static void Main()
        //{
        //    Handler handler = new Counselor("小郭");
        //    handler.Handle(18);

        //    /*
        //     运行结果：
        //        辅导员小郭收到请假条..
        //        辅导员小郭无权审批，正在抄送到院长..
        //        院长老王收到请假条..
        //        院长老王无权审批，正在抄送到校长..
        //        校长老董收到请假条..
        //        校长老董批准..
        //     */
        //}
    }

    public abstract class Handler
    {
        public string Name;
        public string Title;
        public int Scope;
        /// <summary>
        /// 直属领导
        /// </summary>
        public Handler Next;
        public abstract void Handle(int day);
    }
    public class Counselor : Handler
    {
        public Counselor(string name)
        {
            this.Name = name;
            this.Title = "辅导员";
            this.Scope = 7;
            this.Next = new Dean("老王");
        }
        public override void Handle(int day)
        {
            Console.WriteLine($"{Title}{Name}收到请假条..");
            if (day <= Scope)
            {
                Console.WriteLine($"{Title}{Name}批准..");
            }
            else if (Next != null)
            {
                Console.WriteLine($"{Title}{Name}无权审批，正在抄送到{Next.Title}.."); 
                Next.Handle(day);
            }
        }
    }
    public class Dean : Handler
    {
        public Dean(string name)
        {
            this.Name = name;
            this.Title = "院长";
            this.Scope = 15;
            this.Next = new Principal("老董");
        }

        public override void Handle(int day)
        {
            Console.WriteLine($"{Title}{Name}收到请假条..");
            if (day <= Scope)
            {
                Console.WriteLine($"{Title}{Name}批准..");
            }
            else if (Next != null)
            {
                Console.WriteLine($"{Title}{Name}无权审批，正在抄送到{Next.Title}..");
                Next.Handle(day);
            }
        }
    }
    public class Principal : Handler
    {
        public Principal(string name)
        {
            this.Name = name;
            this.Title = "校长";
            this.Scope = 90;
            this.Next = null;
        }
        public override void Handle(int day)
        {
            Console.WriteLine($"{Title}{Name}收到请假条..");
            if (day <= Scope)
            {
                Console.WriteLine($"{Title}{Name}批准..");
            }
            else if (Next != null)
            {
                Console.WriteLine($"{Title}{Name}无权审批，正在抄送到{Next.Title}..");
                Next.Handle(day);
            }
            else
            {
                Console.WriteLine("同学你请这么久的假，退学重修吧");
            }
        }
    }
}
