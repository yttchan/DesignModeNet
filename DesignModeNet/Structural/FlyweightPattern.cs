using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 享元模式
    /// </summary>
    /// <remarks>
    /// 使用池化思想，将大量对象抽取外部状态，减少对象的创建开销
    /// </remarks>
    public class FlyweightPattern
    {
        //public static void Main()
        //{
        //    var factory = new PieceFactory();

        //    Random rnd = new Random();
        //    string[] keys = { "红", "白", "蓝" };
        //    int idx = 0;
        //    while (idx < 8)
        //    {
        //        var tmp = factory.GetPiece(keys[rnd.Next(0, keys.Length)]);

        //        tmp.Draw(rnd.Next(0, 2024), rnd.Next(0, 2024));
        //        idx++;
        //    }

        //    /*
        //     运行结果：
        //        在坐标[1337,1409]的地方 下蓝棋
        //        在坐标[1219,101]的地方 下白棋
        //        在坐标[888,1146]的地方 下白棋
        //        在坐标[1083,1035]的地方 下白棋
        //        在坐标[1171,500]的地方 下蓝棋
        //        在坐标[1105,18]的地方 下红棋
        //        在坐标[1420,417]的地方 下白棋
        //        在坐标[461,1816]的地方 下蓝棋
        //     */
        //}
    }
    public class PieceFactory
    {
        public Dictionary<string, Piece> _pool = new Dictionary<string, Piece>();
        public Piece GetPiece(string key)
        {
            if (!_pool.ContainsKey(key))
            {
                _pool.Add(key, new Piece(key));
            }
            return _pool[key];
        }
    }
    public class Piece
    {
        private string color;
        public Piece(string color)
        {
            this.color = color;
        }
        public void Draw(int x, int y)
        {
            Console.WriteLine($"在坐标[{x},{y}]的地方 下{color}棋 ");
        }
    }
}
