using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  DLAM
{
    public class ReseverDot : MonoBehaviour
    {
        public SaveDot[] Dots;
        public static ReseverDot Ins;
        
        public void Awake()
        {
            Ins = this;
            Dots = transform.GetComponentsInChildren<SaveDot>();
        }
    }
}
