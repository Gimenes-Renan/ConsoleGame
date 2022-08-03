using ConsoleGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Engine
{
    public class ConsoleGame
    {
        private readonly GameObjects _game;

        public ConsoleGame()
        {
            _game = new GameObjects();
        }

        public void Run()
        {
            AddHeroes();
            do
            {
                PreBattle();
                Battle();
                PostBattle();
            } while (_game.Pcs.Count > 0 && _game.Npcs.Count > 0);
            GameOver();
        }

        private void AddHeroes()
        {
            _game.AddHeroes();
        }

        private void PostBattle()
        {
            Console.WriteLine("Fim de batalha");
        }

        private void Battle()
        {
            do
            {
                TurnBegins();
            } while (_game.Pcs.Count > 0 && _game.Npcs.Count > 0);
        }

        private void PreBattle()
        {
            Console.WriteLine("Pré-batalha");
            _game.SetDifficulty();

            Console.WriteLine("Nível de dificuldade: {0}", _game.Difficulty);
            while (_game.Npcs.Count < _game.Difficulty)
            {
                Console.WriteLine("- Adicionado inimigo -");
                _game.Npcs.Add(GameObject.GenerateMonster());
            }
        }

        private void TurnBegins()
        {
            _game.Actions();
        }

        private void GameOver()
        {
            Console.WriteLine("Já era playboy!");
        }
    }
}
