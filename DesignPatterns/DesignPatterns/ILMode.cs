using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatterns
{
    class ILCat
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

        public ILCat(string name)
        {
            this.name = name;
        }
        public void CatComing()
        {
            Console.WriteLine("猫" + name + "来了");
            CatCome?.Invoke();
        }
    }

    class ILMouse
    {
        private string name;

        public ILMouse(string name, ILCat cat)
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
