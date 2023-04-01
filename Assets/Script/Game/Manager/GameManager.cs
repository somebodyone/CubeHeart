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
        public Dictionary<int, GameObject> _gamedic = new Dictionary<int, GameObject>();
        private GameObject _homepage;
        private ElectRobot[] _robots;
        private Player _player;
        private StartNode _startnode;
        private EndNode _endnode;
        private LineRenderer _line;
        private PassNode _passnode;
        private PlayerNode _playerNode;
        private List<ElectRobot> _robotlist = new List<ElectRobot>();
        private List<Transform> _nodelist = new List<Transform>();
        private GameData _data => GamePresenter.Instance.GetData();

        public void CheckInit()
        {
            DLPlayer.lisioner.Update(this, UpdateGame);
        }

        public void LoadHomePage()
        {
            ResetGame();
            _homepage = Object.Instantiate(Res.HomePage);
        }
        
        public void LoadGame(Vector3 vector)
        {
            _game = Object.Instantiate(Res.Levels[_data.level]);
            _game.transform.position = vector;
            _gamedic[_data.level] = _game;
            _robots = _game.GetComponentsInChildren<ElectRobot>();
            _player = _game.GetComponentInChildren<Player>();
            _endnode = _game.GetComponentInChildren<EndNode>();
            _startnode = _game.GetComponentInChildren<StartNode>();
            _line = _game.GetComponentInChildren<LineRenderer>();
            _passnode = _game.GetComponentInChildren<PassNode>();
            _playerNode = _game.GetComponentInChildren<PlayerNode>();
        }

        public void RemoveLastGame()
        {
            if (_gamedic.ContainsKey(_data.level - 1))
            {
                Object.Destroy(_gamedic[_data.level-1]);
                _gamedic.Remove(_data.level - 1);
            }
        }

        public void LoadPlayer()
        {
            _player = Object.Instantiate(Res.Player).GetComponent<Player>();
            _player.Position = _playerNode.transform.position;
        }

        public void StartGame()
        {
            GameConfig.GameProgression = GameProgression.GameIng;
            _player.StartGame();
        }

        private void UpdateGame()
        {
            if (_startnode == null) return;
            _robotlist.Clear();
            _nodelist.Clear();
            _nodelist.Add(_startnode.transform);
            LineRobotNode(_startnode.transform);
            LineEndNode();
            if (_nodelist.Count > 1)
            {
                _startnode._endnode = _nodelist[1];
            }
            else
            {
                _startnode._endnode = null;
            }
            for (int i = 0; i < _robots.Length; i++)
            {
                ElectRobot robot = _robots[i];
                if (!IsHaveNode(robot))
                {
                    _robots[i].Disconnect(); 
                }
            }
            _line.positionCount = _nodelist.Count;
            _line.SetPosition(0,_startnode.transform.position);
            for (int i = 1; i < _nodelist.Count; i++)
            {
                ElectRobot robot = _nodelist[i].GetComponent<ElectRobot>();
                EndNode endnode = _nodelist[i].GetComponent<EndNode>();
                if (endnode)
                {
                    endnode.Link();
                    _passnode.Link();
                }
                if (robot)
                {
                    robot.Link();
                    _line.SetPosition(i,robot.start.position);
                }
                else
                {
                    _line.SetPosition(i,_nodelist[i].position);
                }
            }
        }

        /// <summary>
        /// 链接最终节点
        /// </summary>
        private void LineEndNode()
        {
            float distance = 0;
            if (_robots.Length <= 0)
            {
                distance = Vector3.Distance(_startnode.transform.position, _endnode.transform.position);
                if (distance < 10)
                {
                    _nodelist.Add(_endnode.transform);
                }
                else
                {
                    _endnode.Disconnect();
                    _passnode.Disconnect();
                }
                return;
            }
            if (_robotlist.Count <= 0)
            {
                _endnode.Disconnect();
                _passnode.Disconnect();
                return;
            }
            distance = Vector3.Distance(_robotlist[_robotlist.Count-1].transform.position, _endnode.transform.position);
            if (distance < 10)
            {
                _nodelist.Add(_endnode.transform);
            }
            else
            {
                _endnode.Disconnect();
                _passnode.Disconnect();
            }
        }

        private void LineRobotNode(Transform startnode)
        {
            float mindistance = 10;
            ElectRobot node = null;
            for (int i = 0; i < _robots.Length; i++)
            {
                if(IsHaveNode(_robots[i]))continue;
                float distance = Vector3.Distance(_robots[i].transform.position, startnode.position);
                if (distance < mindistance)
                {
                    mindistance = distance;
                    node = _robots[i];
                }
            }

            if (node)
            {
                _robotlist.Add(node);
                _nodelist.Add(node.transform);
                LineRobotNode(node.transform);
            }
        }

        private bool IsHaveNode(ElectRobot node)
        {
            for (int i = 0; i < _robotlist.Count; i++)
            {
                if (_robotlist[i] == node)
                {
                    return true;
                }
            }

            return false;
        }

        public void ResetGame()
        {
            if(_game)Object.Destroy(_game);
            if(_homepage)Object.Destroy(_homepage);
            _robots = null;
        }
    }
}