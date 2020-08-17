using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class ObserverCat
    {
        public List<Action> Subject = new List<Action>();   //定义一个主题

        private string name;

        public ObserverCat(string name)
        {
            this.name = name;
        }
        public void CatComing()
        {
            Console.WriteLine("猫" + name + "来了");

            Subject.ForEach(item => { item.Invoke(); });
        }
    }

    class ObserverMouse
    {
        private string name;

        public ObserverMouse(string name, ObserverCat cat)
        {
            this.name = name;

            cat.Subject.Add(RunAway);    //将 逃跑 方法注入到 subject 中
        }
        public void RunAway()
        {
            Console.WriteLine(name + "正在逃跑");
        }
    }
}
