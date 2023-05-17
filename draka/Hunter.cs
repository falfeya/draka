using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draka
{
    internal class Hunter : Player
    {
        public Hunter(string name, int health, int damage) : base(name, health, damage) { }
        public override void Attack(Player target)
        {
            if (target is Goblin)
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
        public override void BowAttack()
        {
            Console.WriteLine($"{Name} выпускает стрелу из лука и наносит 15 дополнительного урона!");
            Damage += 15;
        }
    }
}
