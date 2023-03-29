using System;
using UnityEngine;
using DLBASE;


namespace DLAM
{
    /// <summary>
    /// 重力方向
    /// </summary>
    public enum GravityDir
    {
        Left,
        Right,
        Up,
        Down
    }

    public class GravityPresenter:IPresenter<GravityPresenter>
    {
        public enum EventType
        {
            UpdateGravity
        }
        public class Lisioner:DLLisioner
        {
            public void UpdateGravity(object key,Action callback)
            {
                Add(key,EventType.UpdateGravity,callback);
            }
        }

        private Vector3 _gravity = new Vector3(0, -10, 0);
        private GravityDir _dir = GravityDir.Down;

        public Lisioner lisioner = new Lisioner();
        public override void OnInit()
        {
            
        }
        public void SetGravity(GravityDir dir)
        {
            _dir = dir;
            switch (_dir)
            {
                case GravityDir.Down:
                    _gravity = new Vector3(0, -10, 0);
                    break;
                case GravityDir.Up:
                    _gravity = new Vector3(0, 10, 0);
                    break;
                case GravityDir.Left:
                    _gravity = new Vector3(-10, 0, 0);
                    break;
                case GravityDir.Right:
                    _gravity = new Vector3(10, 0, 0);
                    break;
            }
            lisioner.Emit(EventType.UpdateGravity);
        }

        public Vector3 GetGravity()
        {
            return _gravity;
        }

        public GravityDir GetDir()
        {
            return _dir;
        }
    }
}
