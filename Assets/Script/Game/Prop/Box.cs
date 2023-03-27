using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class Box : MonoBehaviour
    {
        public Rigidbody2D _target;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "Player")
            {
                _target.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

