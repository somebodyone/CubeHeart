using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class SwitchCar : MonoBehaviour
    {
        public Car _car;
        private Player _player;
        private bool _isplayer;
        private bool _isopen = false;
        
        public void FixedUpdate()
        {
            if ((Input.GetKey(KeyCode.Space)||TouchPresenter.Instance.OpenSkill)&&_isplayer)
            {
                _isopen = !_isopen;
                if (_isopen)
                {
                    OpenCar();
                }
                else
                {
                    CloseCar();
                }
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
        
        public void OpenCar()
        {
            _car.OpenCar();
        }

        public void CloseCar()
        {
            _car.CloseCar();
        }
    }
}
