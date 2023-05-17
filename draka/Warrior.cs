using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draka
{
    internal class Warrior : Player
    {
        public Warrior(string name, int health, int damage) : base(name, health, damage) { }
        public override void Attack(Player target)
        {
            if (target is Ogr)
            {
                Console.WriteLine($"{Name} атакует {target.Name} и наносит {Damage * 2} урона!");
                target.Health -= Damage * 2;
            }           
            else
            {
                Console.WriteLine($"{Name} атакует {target.Name} и наносит {Damage} урона!");
                target.Health -= Damage;
            }
        }
        public override void Armor()
        {
            Console.WriteLine($"{Name} активирует броню и получает 30 дополнительных единиц здоровья!");
            Health += 30;
        }
    }
}
