using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class Timer : MonoBehaviour
    {
        public int time;
        private static Timer ins;
        public static Timer Ins
        {
            get
            {
                if (ins == null)
                {
                    GameObject NetworkManager = new GameObject("LDTimer");
                    ins = NetworkManager.AddComponent<Timer>();
                }
                return ins;
            }
        }
    }
}
