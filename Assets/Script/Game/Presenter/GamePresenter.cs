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

        public void SetNextLevel()
        {
            _data.level++;
            _opition.SetDirty(true);
        }

        public GameData GetData()
        {
            return _data;
        }
    }
}

