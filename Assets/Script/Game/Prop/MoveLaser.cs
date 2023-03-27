using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;
using DG.Tweening;

namespace DLAM
{
    public class MoveLaser : MonoBehaviour
    {
        public Vector3 _dir = Vector3.down;
        public bool _ismove;
        public Vector3 _start;
        public Vector3 _end;
        public float _speed;
        private LineRenderer _line;
        private float _waittime;
        
        

        public  void Awake()
        {
            _line = transform.GetComponent<LineRenderer>();
            MoveStart();
        }

        public  void Update()
        {
            Vector3 target = GameUtlis.RayCastTargetLaser(transform.localPosition, _dir);
            _line.SetPosition(0,transform.position);
            _line.SetPosition(1,target);
        }
        
        private void MoveStart()
        {
            if (!_ismove) return;
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
                //     }).SetEase(Ease.Linear);
                // });
            }).SetEase(Ease.Linear);
        }
    } 
}

