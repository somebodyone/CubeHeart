
using System;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class Main:MonoBehaviour
    {
        public void Awake()
        {
            DLPlayer.CheckInit();
        }
    }
}