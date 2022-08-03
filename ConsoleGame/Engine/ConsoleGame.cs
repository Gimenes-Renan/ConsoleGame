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
        private readonly GameObjects _gameObjects;
        private readonly GameObject _player;

        public ConsoleGame()
        {
            _gameObjects = new GameObjects();
            _player = GameObject.GeneratePlayer();
        }

        public void Run()
        {
            do
            {
                TurnBegins();
            } while (_player.IsAlive());
            GameOver();
        }

        private void TurnBegins()
        {
            Console.WriteLine("Inicio do turno:");
            if (_gameObjects.Objects.Count <= _player.Difficulty)
            {
                _gameObjects.Objects.Add(GameObject.GenerateMonster());
            }
            _player.ActionTurn();
            _gameObjects.Objects.ForEach(e => e.ActionTurn());
            _player.Hp--;
        }

        private void GameOver()
        {
            Console.WriteLine("Já era playboy!");
        }
    }

    internal class GameObjects
    {
        public GameObjects()
        {
            Objects = new();
        }

        public List<GameObject> Objects { get; set; }
    }
}
