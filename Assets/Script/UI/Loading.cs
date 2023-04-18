using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DLAM
{
    public class Loading : MonoBehaviour
    {
        private UIPanel _panel;
        private GComponent _view;
        private GProgressBar _progressBar;
        
        
        public void Start()
        {
            _panel = GetComponent<UIPanel>();
            _view = _panel.ui;
            _progressBar = _view.GetChild("slider").asProgress;
            _progressBar.value = 100;
            _progressBar.TweenValue(0, 2).OnComplete(() =>
            {
                SceneManager.LoadScene("Main");
            });
        }
    }
}
