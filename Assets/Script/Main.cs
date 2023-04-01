
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
            Physics2D.gravity = Vector3.zero;
            GameManager.Instance.LoadHomePage();
            DLDialogManager.Instance.OpenView<MainView>();
        }
    }
}