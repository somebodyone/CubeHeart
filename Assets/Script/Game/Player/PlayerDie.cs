using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class PlayerDie : MonoBehaviour
    {
        private Rigidbody2D[] _rigidbodys;
        private GravityDir _gravitydir => GravityPresenter.Instance.GetDir();
        private Vector3 _gravity => GravityPresenter.Instance.GetGravity();
        public void Start()
        {
            _rigidbodys = transform.GetComponentsInChildren<Rigidbody2D>();
        }
        
        public void FixedUpdate()
        {
            for (int i = 0; i < _rigidbodys.Length; i++)
            {
                _rigidbodys[i]?.AddForce(_gravity* _rigidbodys[i].mass); 
            }
        }
    }
}
