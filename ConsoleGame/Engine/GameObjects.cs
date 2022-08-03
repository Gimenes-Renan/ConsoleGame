using ConsoleGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Engine
{
    public class GameObjects
    {
        public GameObjects()
        {
            Pcs = new();
            Npcs = new();
        }
        public int Difficulty { get; set; }
        public List<GameObject> Pcs { get; set; }
        public List<GameObject> Npcs { get; set; }

        public void Actions()
        {
            if (Pcs.Count == 0)
                return;

            Console.WriteLine("Inicio do turno:");
            DrawGameObjects();

            Pcs.ForEach(p => p.ActionTurn(Npcs));
            Npcs.ForEach(e => e.ActionTurn(Pcs));
        }

        internal void SetDifficulty()
        {
            Console.WriteLine("Selecione a dificuldade de jogo: 1-1000");
            Difficulty = Convert.ToInt32(Console.ReadLine());
        }

        private void DrawGameObjects()
        {
            Console.WriteLine("=====================================");
            Pcs.ForEach(player => Console.WriteLine(player.ToString()));
            Console.WriteLine("=====================================");
            Npcs.ForEach(monster => Console.WriteLine(monster.ToString()));
            Console.WriteLine("=====================================");
        }

        internal void AddHeroes()
        {
            Pcs.Add(GameObject.GeneratePlayer());
        }
    }
}
