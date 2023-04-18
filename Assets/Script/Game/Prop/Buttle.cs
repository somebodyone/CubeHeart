using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Buttle : MonoBehaviour
    {
        public int dir;
        private float speed = 0.1f;
        private float distance;
        private float maxdistance = 100;
        private float _distance;
        
        public void Update()
        {
            transform.position += new Vector3(speed, 0, 0)*dir;
            _distance += speed;
            if (_distance > maxdistance)
            {
                Destroy(gameObject);
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player"||col.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
}
