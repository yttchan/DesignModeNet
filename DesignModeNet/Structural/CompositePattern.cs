using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModeNet.Structural
{
    /// <summary>
    /// 组合模式
    /// </summary>
    public class CompositePattern
    {
        //public static void Main()
        //{
        //    AbstractFile root = new Folder(".Net设计模式文件夹");

        //    AbstractFile file_1 = new File("普通文件");
        //    root.Add(file_1);
        //    AbstractFile folder_1 = new Folder("结构型文件夹");
        //    root.Add(folder_1);
        //    AbstractFile folder_2 = new Folder("创建型");
        //    root.Add(folder_2);
        //    //-----------
        //    folder_1.Add(new File("CompositePattern.cs"));
        //    folder_1.Add(new File("BridgePattern.cs"));
        //    folder_2.Add(new File("SingletonPattern.cs"));
            
        //    //
        //    Print(root);


        //    /*
        //     运行结果：
        //        .Net设计模式文件夹
        //        普通文件
        //        结构型文件夹
        //        CompositePattern.cs
        //        BridgePattern.cs
        //        创建型
        //        SingletonPattern.cs
        //     */
        //}

        public static void Print(AbstractFile root)
        {
            root.PrintName();

            var childrenList = root.GetChildrenList();
            if (childrenList == null) return;
            foreach (var item in childrenList)
            {
                Print(item);
            }
        }
    }
    public abstract class AbstractFile
    {
        protected string name;
        protected List<AbstractFile> childrenFileList;

        public void PrintName()
        {
            Console.WriteLine(name);
        }
        public abstract void Add(AbstractFile file);
        public abstract void Remove(AbstractFile file);

        public List<AbstractFile> GetChildrenList()
        {
            return childrenFileList;
        }
    }

    /// <summary>
    /// 文件夹
    /// </summary>
    public class Folder : AbstractFile
    {
        public Folder(string name)
        {
            this.name = name;
            this.childrenFileList = new List<AbstractFile>();
        }
        public override void Add(AbstractFile file)
        {
            this.childrenFileList.Add(file);
        }
        public override void Remove(AbstractFile file)
        {
            this.childrenFileList.Remove(file);
        }
    }
    /// <summary>
    /// 文件
    /// </summary>
    public class File : AbstractFile
    {
        public File(string name)
        {
            this.name = name;
        }
        public override void Add(AbstractFile file)
        {
            throw new NotImplementedException();
        }
        public override void Remove(AbstractFile file)
        {
            throw new NotImplementedException();
        }
    }
}
