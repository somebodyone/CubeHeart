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
            UpdateGravity,
            UpdateRobotGravity
        }
        public class Lisioner:DLLisioner
        {
            public void UpdateGravity(object key,Action callback)
            {
                Add(key,EventType.UpdateGravity,callback);
            }
            public void UpdateRobotGravity(object key,Action callback)
            {
                Add(key,EventType.UpdateRobotGravity,callback);
            }
        }

        private Vector3 _gravity = new Vector3(0, -10, 0);
        public float _robotgravity = -10;
        private GravityDir _dir = GravityDir.Down;
        private GravityDir _robotdir = GravityDir.Down;

        public Lisioner lisioner = new Lisioner();
        public override void OnInit()
        {
            
        }

        public void ResetGravity()
        {
            _gravity = new Vector3(0, -10, 0);
            _robotgravity = -10;
            UpdateGravity();
        }

        public void UpdateGravity()
        {
            lisioner.Emit(EventType.UpdateGravity);
            lisioner.Emit(EventType.UpdateRobotGravity);
        }

        public void SetRobotGravity(GravityDir dir)
        {
            _robotdir = dir;
            switch (_robotdir)
            {
                case GravityDir.Down:
                    _robotgravity = -10;
                    break;
                case GravityDir.Up:
                    _robotgravity = 10;
                    break;
                case GravityDir.Left:
                    _robotgravity = -10;
                    break;
                case GravityDir.Right:
                    _robotgravity = 10;
                    break;
            }
            lisioner.Emit(EventType.UpdateRobotGravity);
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

        public float GetRobotGravity()
        {
            return _robotgravity;
        }

        public GravityDir GetRobotDir()
        {
            return _robotdir;
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
