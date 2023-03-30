using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Organ : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}
