using System;
using System.Collections.Generic;
using System.Threading;

namespace DesignPatterns
{
    //猫的 public event Action CatCome 就是一个主题 （subject)。
    //老鼠的 cat.CatCome += this.RunAway 就是 subscribe 对 subject 的订阅。
    //最后的 public void CatComing() 就是对 subject 的推送， pubish了一条 猫来了。


    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("汤姆");
            Mouse mouse1 = new Mouse("杰瑞", cat);
            Mouse mouse2 = new Mouse("杰克", cat);
            cat.CatComing();
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
    #region 事件写法
    class Cat
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
            //?的意思是不为null就Invoke
            CatCome?.Invoke();
        }
    }

    class Mouse
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
    #endregion

    #region 观察者写法
    class CatObserverPattern
    {
        public List<Action> Subject = new List<Action>();   //定义一个主题

        private string name;

        public CatObserverPattern(string name)
        {
            this.name = name;
        }
        public void CatComing()
        {
            Console.WriteLine("猫" + name + "来了");

            Subject.ForEach(item => { item.Invoke(); });
        }
    }

    class MouseObserverPattern
    {
        private string name;

        public MouseObserverPattern(string name, CatObserverPattern cat)
        {
            this.name = name;

            cat.Subject.Add(RunAway);    //将 逃跑 方法注入到 subject 中
        }
        public void RunAway()
        {
            Console.WriteLine(name + "正在逃跑");
        }
    }
    #endregion


    class CatIL
    {
        Action CatCome;

        public void add_CatCome(Action value)
        {
            Action action = this.CatCome;
            Action action2 = null;

            do
            {
                action2 = action;
                Action value2 = (Action)Delegate.Combine(action2, value);
                action = Interlocked.CompareExchange(ref this.CatCome, value2, action2);
            }
            while ((object)action != action2);
        }

        public void remove_CatCome(Action value)
        {
            Action action = this.CatCome;
            Action action2 = null;

            do
            {
                action2 = action;
                Action value2 = (Action)Delegate.Remove(action2, value);
                action = Interlocked.CompareExchange(ref this.CatCome, value2, action2);
            }
            while ((object)action != action2);
        }

        private string name;

        public CatIL(string name)
        {
            this.name = name;
        }
        public void CatComing()
        {
            Console.WriteLine("猫" + name + "来了");
            CatCome?.Invoke();
        }
    }

    class MouseIL
    {
        private string name;

        public MouseIL(string name, CatIL cat)
        {
            this.name = name;
            cat.add_CatCome(this.RunAway);
        }
        public void RunAway()
        {
            Console.WriteLine(name + "正在逃跑");
        }
    }

}
