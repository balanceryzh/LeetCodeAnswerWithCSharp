using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class Cat
    {
        public event Action CatCome;   //声明一个事件

        private string name;

        public Cat(string name)
        {
            this.name = name;
        }
        public void CatComing()
        {
            Console.WriteLine("猫" + name + "来了");
            CatCome?.Invoke();
        }
    }

    public class Mouse
    {
        private string name;

        public Mouse(string name, Cat cat)
        {
            this.name = name;
            cat.CatCome += this.RunAway;        //Mouse 注册 CatCome 主题
        }
        public void RunAway()
        {
            Console.WriteLine(name + "正在逃跑");
        }
    }
}
