using System;
using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class RobotNode : MonoBehaviour
    {
        public GravityDir _dir = GravityDir.Down;
        private bool _isplayer;
        private bool _isclick = true;

        public void FixedUpdate()
        {
            if ((Input.GetKey(KeyCode.Space)||TouchPresenter.Instance.OpenSkill)&&_isplayer&&_isclick)
            {
                _isclick = false;
                if (_dir == GravityDir.Down)
                {
                    _dir = GravityDir.Up;
                }else if (_dir == GravityDir.Up)
                {
                    _dir = GravityDir.Down;
                }
                else if (_dir == GravityDir.Left)
                {
                    _dir = GravityDir.Right;
                }else if (_dir == GravityDir.Right)
                {
                    _dir = GravityDir.Left;
                }
                GravityPresenter.Instance.SetRobotGravity(_dir);
                StartCoroutine(Wait(0.3f));
            }
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            _isclick = true;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag== "Player")
            {
                _isplayer = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                _isplayer = false;
            }
        }

        public void OnDestroy()
        {
            DLPlayer.lisioner.Remove(this);
        }
    }
}

