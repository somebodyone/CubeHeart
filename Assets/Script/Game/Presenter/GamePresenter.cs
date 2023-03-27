using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class GamePresenter:IPresenter<GamePresenter>
    {
        private Transform _parent;
        private GameObject _level;
        private DLOpition<GameData> _opition;
        private GameData _gamedata;
        
        public override void OnInit()
        {
            _opition = DLDataManager.GetOpition<GameData>();
            _gamedata = _opition.data;
        }

        public GameData GetData()
        {
            return _gamedata;
        }
    }
}

