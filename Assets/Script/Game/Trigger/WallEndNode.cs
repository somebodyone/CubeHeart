using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class WallEndNode : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;

        public void Awake()
        {
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.tag == "Player")
            {
                GameManager.Instance.StartGame();
                GameManager.Instance.RemoveLastGame();
            }
        }

        public void StartGame()
        {
            _boxCollider2D.isTrigger = false;
        }
    }
}
