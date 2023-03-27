using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public enum SawMoveDir
    {
        X,
        Y
    }
    public class Saw : MonoBehaviour
    {
        public SawMoveDir _movedir = SawMoveDir.X;
        public Vector3 _startpos;
        public Vector3 _endpos;
        public float _speed;
        private float _dir = 1;
        
        public  void Awake()
        {
           
        }

        public  void Update()
        {
            if (_movedir == SawMoveDir.X)
            {
                if (transform.position.x <= _startpos.x)
                {
                    _dir = 1;
                }else if (transform.position.x >= _endpos.x)
                {
                    _dir = -1;
                }
                transform.position += new Vector3(_speed*_dir, 0, 0);
            }
            else
            {
                if (transform.position.y <= _startpos.y)
                {
                    _dir = 1;
                }else if (transform.position.y >= _endpos.y)
                {
                    _dir = -1;
                }
                transform.position += new Vector3(0, _speed*_dir, 0);
            }

        }
    }
}

