using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;
using FairyGUI;

namespace DLAM
{
    public class SwitchDoor : Organ
    {
        public GravityDir _dir = GravityDir.Down;
        private bool _isplayer;
        private Player _player;

        public void FixedUpdate()
        {
            if ((Input.GetKey(KeyCode.Space)||TouchPresenter.Instance.OpenSkill)&&_isplayer)
            {
                GravityPresenter.Instance.SetGravity(_dir);
            }
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag== "Player")
            {
                _isplayer = true;
                _player = other.GetComponent<Player>();
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                _isplayer = false;
                _player = null;
            }
        }
    }
}

