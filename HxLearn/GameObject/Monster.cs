using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameObject
{
    class Monster
    {
        private int[] innerList;
        private List<string> list;

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

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
