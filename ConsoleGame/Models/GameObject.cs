using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Models
{
    internal class GameObject
    {
        public GameObject()
        {
            Itens = new();
        }

        public static GameObject GeneratePlayer()
        {
            var gameObject = new GameObject()
            {
                Hp = 6,
                ObjectType = ObjectType.Player,
                IsPlayerControlled = true,
            };

            gameObject.SetDifficulty();

            return gameObject;
        }

        public static GameObject GenerateMonster()
        {
            return new GameObject()
            {
                Hp = 2,
                ObjectType = ObjectType.Monster,
                IsPlayerControlled = false,
            };
        }

        public int Hp { get; set; }
        public int Gold { get; set; }
        public List<Item> Itens { get; set; }
        public int Difficulty { get; set; }
        public ObjectType ObjectType { get; set; }
        public bool IsPlayerControlled { get; set; }

        internal void SetDifficulty()
        {
            Console.WriteLine("Selecione a dificuldade de jogo: 1-1000");
            Difficulty = Convert.ToInt32(Console.ReadLine());
        }


        public bool IsAlive()
        {
            return Hp > 0;
        }

        public void ActionTurn()
        {
            if (IsPlayerControlled)
            {
                var option = SelectOption();
                switch (option)
                {
                    case 1:
                        Console.WriteLine(ObjectType + " -> Estou atacando!!");
                        break;
                    case 2:
                        Console.WriteLine(ObjectType + " -> Estou usando item!!");
                        break;
                    case 3:
                        Console.WriteLine(ObjectType + " -> Estou fugindo kkkkkkkkkkk!!");
                        break;
                }
            }
            else
            {
                Console.WriteLine(ObjectType + " -> Estou atacando!!");
            }
        }

        private int SelectOption()
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
    }

    public class Item
    {
        public Item()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public int Type { get; set; }
        public int Value { get; set; }
    }
}
