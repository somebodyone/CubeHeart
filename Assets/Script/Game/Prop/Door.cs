using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public enum DoorCtrlEnum
    {
        Rotate,
        Move
    }
    public class Door : MonoBehaviour
    {
       
        public DoorCtrlEnum _doorCtrlEnum;
        public Vector3 _start;
        public Vector3 _end;
        private bool _isplayer;
        private Player _player;
        private bool _isopen;
        private Transform _target;
        private Transform _shoot;
        private Vector3 _oldangle;
        
        
        public  void Awake()
        {
            _target = transform.GetComponentsInChildren<Transform>()[1];
            _shoot = transform.GetComponentsInChildren<Transform>()[2];
            _oldangle = _shoot.localEulerAngles;
        }

        public  void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Space)||TouchPresenter.Instance.OpenSkill)&&_isplayer)
            {
                _isopen = !_isopen;
                if (_isopen)
                {
                    OpenEletric();
                }
                else
                {
                    CloseEletric();
                }
            }
        }

        private void CloseEletric()
        {
            _target.DOLocalMove(_start, 0.5f).SetEase(Ease.Linear);
            _shoot.DOLocalRotate(_oldangle, 0.5f);
        }
        
        private void OpenEletric()
        { 
            _target.DOLocalMove(_end, 0.5f).SetEase(Ease.Linear);
            _shoot.DOLocalRotate(_oldangle + new Vector3(0, 0, 90), 0.5f);
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "Player")
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
