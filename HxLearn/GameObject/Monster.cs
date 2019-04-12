using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameObject
{
    class Monster:IDisposable,IComparer<Monster>
    {

        private int[] innerList;
        private List<string> list;

        public int Id { get; set; }
        public string Name { get; set; }

        public int Attack { get; set; }

        public int Defend { get; set; }

        public int HP { get; set; }
        public Monster( int id)
        {

        }

        public Monster()
        {
        }

        public void CreateDamage(Monster ms)
        {

        }

        public int this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                innerList[index] = value;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~Monster() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        public int Compare(Monster x, Monster y)
        {
            Console.WriteLine("Compare(" + x + "," + y + ")");
            return x.Attack - y.Attack;
        }
        #endregion

        public static Monster operator +(Monster m1, Monster m2)
        {
            return new Monster();
        }

        public static Monster operator +(GameObjectImpl m1, Monster m2)
        {
            return new Monster();
        }

        public static Monster operator +(Monster m1, GameObjectInterface m2)
        {
            return new Monster();
        }
    }

    class EliteMonster : Monster
    {
        public EliteMonster(int id) : base(id)
        {

        }

        //public static explicit operator EliteMonster(int id)
        //{
        //     return new EliteMonster(id);
        //}

        public static implicit operator EliteMonster(int id)
        {
            return new EliteMonster(id);
        }

    }
}
