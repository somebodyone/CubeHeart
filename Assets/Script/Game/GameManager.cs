using System;
using DLBASE;
using UnityEngine;

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
        private GameObject _game;
        private GameData _data => GamePresenter.Instance.GetData();
        public Lisioner lisioner = new Lisioner();

        public void LoadLevel()
        {
            int level = _data.level;
            
            
        }
    }
}