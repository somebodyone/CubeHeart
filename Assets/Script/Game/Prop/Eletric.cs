using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DLBASE;

namespace DLAM
{
    public class Eletric : Organ
    {
        public float _start;
        public float _end;
        public Transform _target;
        public Transform _line;
        
        public Transform _door1;
        public Transform _door2;
        public Transform _wall;
        private bool _isplayer;
        private Player _player;

        public void FixedUpdate()
        {
            if ((Input.GetKey(KeyCode.Space)||TouchPresenter.Instance.OpenSkill)&&_isplayer)
            {
                OpenEletric();
            }
        }

        private void OpenEletric()
        { 
            _target.DOMoveY(_end, 15).SetEase(Ease.Linear).OnComplete(() =>
            {
                CloseEletric();
            });
            _line.DOScaleY(1, 15).SetEase(Ease.Linear);;
            _door1.gameObject.SetActive(true);
            _door2.gameObject.SetActive(true);
        }
        private void CloseEletric()
        {
            _door1.gameObject.SetActive(false);
            _door2.gameObject.SetActive(false);
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

