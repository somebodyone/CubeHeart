using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DLAM
{
    public class ElectLadder : MonoBehaviour,LinkInterface
    {
        public SpriteRenderer _light;
        public GameObject _lightnode;
        public Transform _midpos;
        private bool _iselect;
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                col.transform.position = _midpos.transform.position;
                transform.DOMoveY(transform.position.y+6, 7).SetEase(Ease.InQuad);
                Player player = col.GetComponent<Player>();
                player.EndGame();
            }
        }

        public void Link()
        {
            _light.color = Color.white;
            _lightnode.SetActive(true);
        }

        public void Disconnect()
        {
            _light.color = Color.gray;
            _lightnode.SetActive(false);
        }
    }
}

