using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace draka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //создание персонажей
            var mage = new Mage("Маг", 100, 20);
            var warrior = new Warrior("Воин", 120, 15);
            var hunter = new Hunter("Охотник", 80, 25);

            //создание монстров
            var goblin = new Goblin("Гоблин", 60, 10);
            var ogr = new Ogr("Огр", 150, 25);
            var leshy = new Leshy("Леший", 90, 15);

            var characters = new List<Player> { mage, warrior, hunter };
            var monsters = new List<Player> { goblin, ogr, leshy };
            bool gameOver = false;
            bool allMonstersDead = false;
            bool allMagesDead = false;

            while (!gameOver)
            {
                //вывод состояния персонажей и монстров
                Console.WriteLine("\nПерсонажи:");
                foreach (var character in characters)
                {
                    Console.WriteLine($"{character.Name}: {character.Health} хп");
                }

                Console.WriteLine("\nМонстры:");
                foreach (var monster in monsters)
                {
                    Console.WriteLine($"{monster.Name}: {monster.Health} хп");
                }

                Console.WriteLine("\nВыберите персонажа для атаки, лечения или использования брони:");
                for (int i = 0; i < characters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {characters[i].Name}");
                }
                int selectedCharacterIndex = int.Parse(Console.ReadLine()) - 1;
                var selectedCharacter = characters[selectedCharacterIndex];

                Console.WriteLine("\nВыберите монстра для атаки:");
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name}");
                }
                int selectedMonsterIndex = int.Parse(Console.ReadLine()) - 1;
                var selectedMonster = monsters[selectedMonsterIndex];

                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Использовать лечение");
                Console.WriteLine("3. Использовать броню");
                Console.WriteLine("4. Использовать лук");
                int selectedAction = int.Parse(Console.ReadLine());
                if (selectedAction == 1)
                {
                    selectedCharacter.Attack(selectedMonster); //атака персонажа

                    //проверка здоровья монстра
                    if (selectedMonster.Health <= 0)
                    {
                        monsters.Remove(selectedMonster);
                        Console.WriteLine($"{selectedMonster.Name} покинул игру!");
                    }
                    if (monsters.Count == 0)
                    {
                        allMonstersDead = true;
                        Console.WriteLine("Поздравляем! Вы победили!");
                    }
                    if (allMonstersDead || allMagesDead)
                    {
                        gameOver = true;
                    }
                }
                else if (selectedAction == 2 && selectedCharacter is Mage)
                {
                    //лечение мага
                    ((Mage)selectedCharacter).Heal();
                }
                else if (selectedAction == 3 && selectedCharacter is Warrior)
                {
                    //воин надел броню
                    ((Warrior)selectedCharacter).Armor();
                }
                else if (selectedAction == 4 && selectedCharacter is Hunter)
                {
                    //атака луком
                    ((Hunter)selectedCharacter).BowAttack();
                }
                //ход монстра
                var random = new Random();
                int randomCharacterIndex = random.Next(0, characters.Count);
                var randomCharacter = characters[randomCharacterIndex];
                int randomMonsterIndex = random.Next(0, monsters.Count);
                var randomMonster = monsters[randomMonsterIndex];
                randomMonster.Attack(randomCharacter); //атака монстра

                //проверка здоровья персонажа
                if (randomCharacter.Health <= 0)
                {
                    characters.Remove(randomCharacter);
                    Console.WriteLine($"{randomCharacter.Name} покинул игру!");
                }
                if (characters.Count == 0)
                {
                    Console.WriteLine("К сожалению, вы проиграли!");
                    gameOver = true;
                }
            }
            Console.WriteLine("Игра окончена. Нажмите любую клавишу, чтобы выйти...");
            Console.ReadKey();
        }
    }
}
