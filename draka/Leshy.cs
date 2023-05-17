using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draka
{
    internal class Leshy : Player
    {
        public Leshy(string name, int health, int damage) : base(name, health, damage) { }
        public override void Attack(Player target)
        {
            if (target is Hunter)
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
    }
}