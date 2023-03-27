using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class CameraFlow : MonoBehaviour
    {
        public Player _target;
        public Vector3 _offset = new Vector3(0,0,10);
        

        void Update()
        {
            if (_target == null)
            {
                // _target = SysManager.GetSys<GameSys>().GetGame<Game>().LevelMgr.GetPlayer();
            }
            else
            {
                //让目标跟随
                // Vector3 targetPos = _target.transform.position - _offset;
                // this.transform.position = Vector3.Lerp(transform.position, targetPos, 5 * Time.deltaTime);
            }
        }
    }

}
