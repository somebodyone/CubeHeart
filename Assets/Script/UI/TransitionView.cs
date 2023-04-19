using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;
using FairyGUI;

namespace DLAM
{
    public class TransitionView : DLDialog
    {
        private Transition _transition;
        protected override bool _showmask => false;

        public override void OnInit()
        {
            SetContentWith("Transition","TransitionView");
        }

        protected override void InitCompent()
        {
            _transition = contentPlane.GetTransition("move");
            DLPlayer.timer.SetTimer("Transition",1, () =>
            {
                GameManager.Instance.ResetGame();
                GameManager.Instance.LoadGame();
                GravityPresenter.Instance.ResetGravity();
                GameManager.Instance.LoadPlayer();
                GameManager.Instance.StartGame();
            });
            _transition.Play(0,0, () =>
            {
                Close();
            });
        }
    }
}
