using System;
using System.Collections.Generic;
using System.Linq;
using DLBASE;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DLAM
{
    public class GameManager:DLSingleton<GameManager>
    {
        public enum EventType
        {
            UpdateGravity
        }
        public class Lisioner:DLLisioner
        {
            public void UpdateGravity(object key,Action callback)
            {
                Add(key,EventType.UpdateGravity,callback);
            }
        }
        public Lisioner lisioner = new Lisioner();
        private GameObject _game;
        private List<ElectRobot> _robots = new List<ElectRobot>();
        private Player _player;
        private Laser _laser;
        private GameData _data => GamePresenter.Instance.GetData();

        public void EnterGame()
        {
            ResetGame();
            _game = Object.Instantiate(Res.Levels[_data.level]);
            _robots = _game.GetComponentsInChildren<ElectRobot>().ToList();
            _player = _game.GetComponentInChildren<Player>();
        }
        
        public void ResetGame()
        {
            if(_game)Object.Destroy(_game);
            _robots?.Clear();
        }
    }
}