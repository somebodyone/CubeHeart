using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class MoveSpikes : MonoBehaviour
    {
        public Vector3 _start;
        public Vector3 _end;
        public float _speed;
        private float _waittime = 3;

        public  void Awake()
        {
            transform.position = _start;
            MoveStart();
        }

        private void MoveStart()
        {
            transform.DOMove(_end, _speed).OnComplete(() =>
            {
                // GameUtlis.Waits(_waittime, () =>
                // {
                //     transform.DOMove(_start, _speed).OnComplete(() =>
                //     {
                //         GameUtlis.Waits(_waittime, () =>
                //         {
                //             MoveStart();
                //         });
                //     });
                // });
            });
        }
        
    } 
}

