using System;
using DG.Tweening;
using UnityEngine;

namespace DLAM
{
    public class PassWall:MonoBehaviour
    {
        private SpriteRenderer _sprite;

        public void Awake()
        {
            _sprite = transform.GetComponent<SpriteRenderer>();
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                _sprite.DOFade(0, 1);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.tag == "Player")
            {
                _sprite.DOFade(1, 1);
            }
        }
    }
}