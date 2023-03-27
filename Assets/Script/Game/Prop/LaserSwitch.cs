using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class LaserSwitch : MonoBehaviour
    {
        private Action<bool> _action;
        private bool _isopen = true;
        private Transform _switch;
        private float _oldpos;

        public  void Awake()
        {
            _switch = transform.GetComponentsInChildren<Transform>()[1];
            _oldpos = _switch.position.y;
        }

        public void Addlistioner(Action<bool> callback)
        {
            _action = callback;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _isopen = false;
            _switch.DOMoveY(_oldpos - 0.5f, 0.5f);
            _action?.Invoke(_isopen);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            _isopen = true;
            _switch.DOMoveY(_oldpos, 0.5f);
            _action?.Invoke(_isopen);
        }
    }
}
