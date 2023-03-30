using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class ElectLadder : MonoBehaviour,LinkInterface
    {
        public SpriteRenderer _light;
        private bool _iselect;
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                
            }
        }

        public void Link()
        {
            _light.color = Color.white;
        }

        public void Disconnect()
        {
            _light.color = Color.gray;
        }
    }
}

