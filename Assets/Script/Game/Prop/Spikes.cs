using System;
using System.Collections;
using System.Collections.Generic;
using DLAM;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class Spikes : Organ
    {
        private GamePresenter _levelmgr;
        
        private void Start()
        {
           
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag== "Player")
            {
                Debug.Log("游戏结束");
            }
        }
    }
}

