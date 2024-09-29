using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 外观（门面）模式
    /// </summary>
    public class FacadePattern
    {
        //public static void Main()
        //{
        //    var computer = new Computer();
        //    computer.Start();
        //    computer.ShutDown();
        //    /*
        //     运行结果：
        //        CPU 开启
        //        磁盘 开启
        //        内存 开启
        //        CPU 关闭
        //        磁盘 关闭
        //        内存 关闭
        //     */
        //}
    }
    /// <summary>
    /// 计算机
    /// </summary>
    public class Computer : ISwitch
    {
        private CPU _cpu;
        private Disk _disk;
        private Memory _memory;
        public Computer()
        {
            this._cpu = new CPU();
            this._disk = new Disk();
            this._memory = new Memory();
        }

        public void ShutDown()
        {
            _cpu.ShutDown();
            _disk.ShutDown();
            _memory.ShutDown();
        }

        public void Start()
        {
            _cpu.Start();
            _disk.Start();
            _memory.Start();
        }
    }
    public interface ISwitch
    {
        void Start();
        void ShutDown();
    }
    public class CPU : ISwitch
    {
        public void ShutDown()
        {
            Console.WriteLine("CPU 关闭");
        }

        public void Start()
        {
            Console.WriteLine("CPU 开启");
        }
    }
    public class Disk : ISwitch
    {
        public void ShutDown()
        {
            Console.WriteLine("磁盘 关闭");
        }

        public void Start()
        {
            Console.WriteLine("磁盘 开启");
        }

    }
    public class Memory : ISwitch
    {
        public void ShutDown()
        {
            Console.WriteLine("内存 关闭");
        }

        public void Start()
        {
            Console.WriteLine("内存 开启");
        }
    }
}
