using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Behaviour
{
    /// <summary>
    /// 解析器
    /// </summary>
    /// <remarks>
    /// 应用在表达式树
    /// </remarks>
    public class InterpreterPattern
    {
        //public static void Main()
        //{
        //    AbstractExpression text1 = new TerminalExpression("李华是个好人");
        //    AbstractExpression not = new NotExpression(text1);
        //    Console.WriteLine(not.Interpret("李华"));

        //    AbstractExpression text2 = new TerminalExpression("旺财不是一只狗");
        //    AbstractExpression or = new OrExpression(text1, text2);
        //    Console.WriteLine(or.Interpret("狗"));

        //    /*
        //     运行结果：
        //        False
        //        True
        //     */
        //}
    }
    public abstract class AbstractExpression
    {
        public abstract bool Interpret(string context);
    }
    /// <summary>
    /// 包含（终端表达式）
    /// </summary>
    public class TerminalExpression : AbstractExpression
    {
        private string _data;
        public TerminalExpression(string data)
        {
            this._data = data;
        }
        public override bool Interpret(string context)
        {
            return _data.Contains(context);
        }
    }
    /// <summary>
    /// 或运算（非终端表达式）） 
    /// </summary>
    public class OrExpression : AbstractExpression
    {
        AbstractExpression _left;
        AbstractExpression _right;
        public OrExpression(AbstractExpression left, AbstractExpression right)
        {
            this._left = left;
            this._right = right;
        }
        public override bool Interpret(string context)
        {
            return this._left.Interpret(context) || this._right.Interpret(context);
        }
    }
    /// <summary>
    /// 非运算（非终端表达式）
    /// </summary>
    public class NotExpression : AbstractExpression
    {
        AbstractExpression _item;
        public NotExpression(AbstractExpression item)
        {
            this._item = item;
        }
        public override bool Interpret(string context)
        {
            return !_item.Interpret(context);
        }
    }
}
