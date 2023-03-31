using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;
using FairyGUI;

namespace DLAM
{
    public class MainView : DLDialog
    {
        private GButton _start;
        public override void OnInit()
        {
            SetContentWith("Main","MainView");
        }

        protected override void InitCompent()
        {
            _start = contentPlane.GetChild("_start").asButton;
        }

        protected override void InitAddlistioner()
        {
            _start.onClick.Add(() =>
            {
                GameManager.Instance.StartGame();
            });
        }
    }
}
