using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class SaveDot : MonoBehaviour
    {
        public int Level;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag== "Player")
            {
                Debug.Log("游戏结束");
            }
        }
    }
}

