using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DLAM
{
    public class CameraTrigger : MonoBehaviour
    {
        public Vector3 _angle;
        public List<Stone> _stones;

        public void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag=="Player")
            {
                Camera.main.transform.DOLocalRotate(_angle, 5);
                if (_stones == null) return;
                for (int i = 0; i < _stones.Count; i++)
                {
                    _stones[i].StartPlay();
                }
            }
        }
    }
}

