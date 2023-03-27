using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class RotateTools : MonoBehaviour
    {
        public float _speed;
        
        void Update(){
            transform.localEulerAngles += new Vector3(0,0,_speed);
        }
    }
}

