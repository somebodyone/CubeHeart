﻿ using System;
 using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class PassNode : LinkNode
    {
        public GravityDir _dir = GravityDir.Up;
        public Vector3 _nextlevelpos;
        public GameObject _wall;
        public GameObject _light;
        private BoxCollider2D _boxCollider;

        public void Awake()
        {
            _boxCollider = transform.GetComponent<BoxCollider2D>();
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GamePresenter.Instance.SetNextLevel();
                GameManager.Instance.LoadGame();
                GravityPresenter.Instance.ResetGravity();
                GameManager.Instance.EndGame();
                GravityPresenter.Instance.SetGravity(_dir);
                _wall.SetActive(false);
                _boxCollider.enabled = false;
            }
        }
        public override void Link()
        {
            _light.SetActive(true);
            _boxCollider.enabled = true;
        }

        public override void Disconnect()
        {
            _light.SetActive(false);
            _boxCollider.enabled = false;
        }
    }
}
