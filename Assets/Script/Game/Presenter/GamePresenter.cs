using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public enum GameProgression
    {
        Stop,
        GameIng
    }
    
    public class GamePresenter:IPresenter<GamePresenter>
    {
        private Transform _parent;
        private GameObject _level;
        private DLOpition<GameData> _opition;
        private GameData _data;

        public override void OnInit()
        {
            _opition = DLDataManager.GetOpition<GameData>();
            _data = _opition.data;
        }

        public int Level => _data.level;

        public bool NewGame
        {
            get => _data.newplayer;
            set
            {
                _data.newplayer = value;
            }
        }

        public GameData GetData()
        {
            return _data;
        }
    }
}

