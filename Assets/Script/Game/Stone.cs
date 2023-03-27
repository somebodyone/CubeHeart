using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Stone : MonoBehaviour
    {
        public Vector3 _forece;
        private Rigidbody2D _rigidbody;
        public void Awake()
        {
            _rigidbody = transform.GetComponent<Rigidbody2D>();
        }

        public void StartPlay()
        {
            _rigidbody.AddForce(_forece,ForceMode2D.Force);
        }
    }
}

