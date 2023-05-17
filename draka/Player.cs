using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draka
{
    abstract class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public abstract void Attack(Player target);
        public virtual void Heal()
        {
            // лечение не доступно для всех классов персонажей и монстров
            Console.WriteLine($"{Name} не может быть вылечен.");
        }
        public virtual void Armor()
        {
            // броня не доступна для всех классов персонажей и монстров
            Console.WriteLine($"{Name} не может использовать броню.");
        }
        public virtual void BowAttack()
        {
            //лук не доступен для всех классов персонажей и монстров
            Console.WriteLine($"{Name} не может использовать лук.");
        }
    }
}
