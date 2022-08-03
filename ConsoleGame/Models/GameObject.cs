using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Models
{
    public class GameObject
    {
        private readonly Random random;
        public GameObject()
        {
            Itens = new();
            random = new();
        }

        public static GameObject GeneratePlayer()
        {
            var gameObject = new GameObject()
            {
                Hp = 6,
                Atk = 2,
                ObjectType = ObjectType.Player,
                IsPlayerControlled = true,
            };
            return gameObject;
        }

        public static GameObject GenerateMonster()
        {
            return new GameObject()
            {
                Hp = 2,
                Atk = 1,
                ObjectType = ObjectType.Monster,
                IsPlayerControlled = false,
            };
        }

        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Gold { get; set; }
        public List<Item> Itens { get; set; }
        public int Difficulty { get; set; }
        public ObjectType ObjectType { get; set; }
        public bool IsPlayerControlled { get; set; }

        public bool IsAlive()
        {
            return Hp > 0;
        }

        public void ActionTurn(List<GameObject> enemies)
        {
            if (enemies.Count == 0) return;

            if (IsPlayerControlled)
            {
                var option = SelectOption();
                switch (option)
                {
                    case 1:
                        Attack(enemies);
                        break;
                    case 2:
                        UseItem();
                        break;
                    case 3:
                        Flee();
                        break;
                }
            }
            else
            {
                Attack(enemies);
            }
        }

        public void Flee()
        {
            Console.WriteLine(ObjectType + " -> Estou fugindo kkkkkkkkkkk!!");
        }

        public void UseItem()
        {
            Console.WriteLine(ObjectType + " -> Estou usando item!!");
        }

        public void Attack(List<GameObject> enemies)
        {
            var target = enemies[random.Next(enemies.Count - 1)];

            Console.WriteLine(ObjectType + " ATK -> " + target.ObjectType);
            target.Hp -= Atk;

            Console.WriteLine($"O ataque foi de: {Atk} e o {target.ObjectType}: {target.Hp} HP");

            if (target.Hp <= 0)
                target.Die(enemies);
        }

        private void Die(List<GameObject> list)
        {
            Console.WriteLine($"O {ObjectType} morreu...");
            list.Remove(this);
        }

        public int SelectOption()
        {
            ShowOptions();
            return Convert.ToInt32(Console.ReadLine());
        }

        private void ShowOptions()
        {
            Console.WriteLine("Suas opções são:");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Usar item de cura (se tiver)");
            Console.WriteLine("3 - Fugir para curar (bundãoooooooo!!)");
        }

        public override string ToString()
        {
            return $"{ObjectType} - HP: {Hp} - ATK: {Atk}";
        }
    }
}
