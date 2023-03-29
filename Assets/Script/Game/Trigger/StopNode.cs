using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{

    public class StopNode : Organ
    {
        public MoveDir _dir;
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("游戏结束");
            }
        }
    }
}

