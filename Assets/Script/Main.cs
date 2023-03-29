
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
            Res.LoadRes();
        }

        public void Start()
        {
            GameManager.Instance.CheckInit();
            GameManager.Instance.EnterGame();
        }
    }
}