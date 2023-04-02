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
        private GButton _test;
        private Controller _controller;
        
        public override void OnInit() 
        {
            SetContentWith("Main","MainView");
        }

        protected override void InitCompent()
        {
            _start = contentPlane.GetChild("_start").asButton;
            _test = contentPlane.GetChild("_testbtn").asButton;
            _controller = contentPlane.GetController("game");
        }

        protected override void InitAddlistioner()
        {
            _test.onClick.Add(() =>
            {
                
            });
            
            _start.onClick.Add(() =>
            {
                GameManager.Instance.CheckInit();
                GameManager.Instance.ResetGame();
                GameManager.Instance.LoadGame(Vector3.zero);
                GameManager.Instance.LoadPlayer();
                GameManager.Instance.StartGame();
                _controller.SetSelectedPage("gameing");
            });
        }
    }
}
