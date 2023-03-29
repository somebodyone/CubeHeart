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
        private ElectRobot[] _robots;
        private Player _player;
        private Laser _laser;
        private EndNode _endnode;
        private GameData _data => GamePresenter.Instance.GetData();

        public void CheckInit()
        {
            DLPlayer.lisioner.Update(this, UpdateGame);
        }
        
        public void EnterGame()
        {
            ResetGame();
            _game = Object.Instantiate(Res.Levels[_data.level]);
            _robots = _game.GetComponentsInChildren<ElectRobot>();
            _player = _game.GetComponentInChildren<Player>();
            _endnode = _game.GetComponentInChildren<EndNode>();
        }

        private void UpdateGame()
        {
            float mindistance = 5;
            for (int i = 0; i < _robots.Length; i++)
            {
                float distance = Vector3.Distance(_robots[i].transform.position, _laser.transform.position);
                if (distance < 5)
                {
                    if (distance < mindistance)
                    {
                        _laser.endnode = _robots[i];
                        mindistance = distance;
                    }
                }
            }
        }
        
        public void ResetGame()
        {
            if(_game)Object.Destroy(_game);
            _robots = null;
        }
    }
}