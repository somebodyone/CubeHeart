using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Car : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        

        public void OpenCar()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.velocity = Vector2.left;
        }

        public void CloseCar()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
