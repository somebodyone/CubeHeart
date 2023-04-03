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
        public List<SpriteRenderer> _updowns;
        public List<SpriteRenderer> _leftrights;
        private bool _isplayer;
        private bool _isclick = true;

        public void Awake()
        {
            switch (_dir)
            {
                case GravityDir.Down:
                    SetActive(_updowns, true);
                    _updowns[0].color = Color.gray;
                    _updowns[1].color = Color.white;
                    break;
                case GravityDir.Up:
                    SetActive(_updowns, true);
                    _updowns[1].color = Color.gray;
                    _updowns[0].color = Color.white;
                    break;
                case GravityDir.Left:
                    SetActive(_leftrights, true);
                    _leftrights[0].color = Color.gray;
                    _leftrights[1].color = Color.white;
                    break;
                case GravityDir.Right:
                    SetActive(_leftrights, true);
                    _leftrights[1].color = Color.gray;
                    _leftrights[0].color = Color.white;
                    break;
            }

            UpdateColor();
        }

        private void SetActive(List<SpriteRenderer> list,bool active)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].gameObject.SetActive(active);
            }
        }
        
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

                UpdateColor();
                GravityPresenter.Instance.SetRobotGravity(_dir);
                StartCoroutine(Wait(0.3f));
            }
        }

        public void UpdateColor()
        {
            switch (_dir)
            {
                case GravityDir.Down:
                    _updowns[0].color = Color.gray;
                    _updowns[1].color = Color.white;
                    break;
                case GravityDir.Up:
                    _updowns[1].color = Color.gray;
                    _updowns[0].color = Color.white;
                    break;
                case GravityDir.Left:
                    _leftrights[0].color = Color.gray;
                    _leftrights[1].color = Color.white;
                    break;
                case GravityDir.Right:
                    _leftrights[1].color = Color.gray;
                    _leftrights[0].color = Color.white;
                    break;
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

