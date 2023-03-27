using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace DLBASE
{
    public class IFView
    {
        public GComponent contentPlane;
        protected GGraph mask;

        public void SetContentWith(string pakege, string name)
        {
            contentPlane = UIPackage.CreateObject(name, name).asCom;
        }
        
        public virtual void Init()
        {
            mask = new GGraph();
            mask.color = Color.black;
            mask.height = Screen.height;
            mask.width = Screen.width;
            GRoot.inst.AddChild(mask);
            InitData();
            InitCompent();
            InitAddlistioner();
        }

        protected virtual void InitCompent()
        {
            
        }

        protected virtual void InitAddlistioner()
        {
            
        }

        protected virtual void InitData()
        {
            
        }

        public virtual void Close()
        {
            mask.Dispose();
            contentPlane.Dispose();
        }
    }

}
