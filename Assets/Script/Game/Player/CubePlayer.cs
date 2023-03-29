using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;
using DG.Tweening;

namespace DLAM
{
    /// <summary>
    /// 移动方向
    /// </summary>
    public enum MoveDir
    {
        Left,
        Right,
        Down,
        UP,
        Stop
    }
    
    public class CubePlayer : MonoBehaviour
    {
        private float _speed = 10;//移动速度
        private float _weidth = 0.5f;//方块宽度
        private float _movedistance = 0;//移动角度
        private bool _ismove = false;
        private bool _islook = true;
        private Vector3 _oldpos;
        private float _movespeed = 0.2f;
        private bool _isrowmove = false;//是否在移动
        private Vector3 _oldposition;//原始坐标
        private Vector3 _currentvector;//当前坐标
        private Rigidbody _rigidbody;
        private int _rowdir;//横向
        private int _coldir;//竖向
        private int _movedir;//移动方向
        private bool _isground;
        private bool _isrotate;
        
        public  void Awake()
        {
            _oldpos = transform.position;
            _rigidbody = transform.GetComponent<Rigidbody>();
        }
        
        
        public  void Update()
        {
            UpdateRotate();
            UpdateGround();
            if (_isground)
            {
                UpdatePosition();
            }
        }

        public  void LateUpdate()
        {
            if (!_isground)
            {
                CameraHeightMove();
            }
            CameraLineMove();
            _oldpos = transform.position;
        }

        private void UpdatePosition()
        {
            GravityDir dir = GravityPresenter.Instance.GetDir();
            switch (dir)
            {
                case GravityDir.Down:
                    TouchDown();
                    break;
                case GravityDir.Up:
                    TouchUp();
                    break;
                case GravityDir.Left:
                  
                    break;
                case GravityDir.Right:
                   
                    break;
            }
        }

        /// <summary>
        /// 首次移动
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="updir"></param>
        /// <param name="movedir"></param>
        private void OnMove(int dir,int updir,int movedir)
        {
            _islook = false;
            _ismove = true;
            _movedistance = 0;
            _currentvector = transform.position;
            Vector3 target = new Vector3(_currentvector.x + _weidth * dir, _currentvector.y - _weidth * updir,
                _currentvector.z);
            transform.RotateAround(target, new Vector3(0, 0, movedir), _speed);
        }

        private void AngleFull(int dir,int updir,int movedir)
        {
            if (_ismove)
            {
                StopRigidbody();
                _movedistance += _speed;
                if (_movedistance < 90)
                {
                    Vector3 target = new Vector3(_currentvector.x + _weidth * dir, _currentvector.y - _weidth * updir,
                        _currentvector.z);
                    transform.RotateAround(target, new Vector3(0, 0, movedir), _speed);
                }
                else
                {
                    _islook = true;
                    _ismove = false;
                    _movedistance = 0;
                }
            }
        }

        /// <summary>
        /// 重置数据
        /// </summary>
        private void ResetData()
        {
            _islook = true;
            _ismove = false;
            _movedistance = 0;
        }

        private void TouchDown()
        {
            if ((TouchPresenter.Instance.MoveDir== MoveDir.Right||Input.GetKey(KeyCode.D))
                &&_islook&&UpdateSpeed())
            {
                if (UpdateFrontWall(Vector3.right)) return;
                _rowdir = 1;
                _coldir = 1;
                _movedir = -1;
                OnMove(_rowdir, _coldir,_movedir);
            }else if ((TouchPresenter.Instance.MoveDir== MoveDir.Left||Input.GetKey(KeyCode.A))
                      &&_islook&&UpdateSpeed())
            {
                if (UpdateFrontWall(Vector3.left)) return;
                _rowdir = -1;
                _coldir = 1;
                _movedir = 1;
                OnMove(_rowdir, _coldir,_movedir);
            }
            AngleFull(_rowdir, _coldir,_movedir);
        }

        private void TouchUp()
        {
            if ((TouchPresenter.Instance.MoveDir== MoveDir.Right||Input.GetKey(KeyCode.D))
                &&_islook&&UpdateSpeed())
            {
                if (UpdateFrontWall(Vector3.right)) return;
                _rowdir = 1;
                _coldir = -1;
                _movedir = 1;
                StopRigidbody();
                OnMove(_rowdir, _coldir,_movedir);
            }else if ((TouchPresenter.Instance.MoveDir== MoveDir.Left||Input.GetKey(KeyCode.A))
                      &&_islook&&UpdateSpeed())
            {
                if (UpdateFrontWall(Vector3.left)) return;
                _rowdir = -1;
                _coldir = -1;
                _movedir = -1;
                StopRigidbody();
                OnMove(_rowdir, _coldir,_movedir);
            }
            AngleFull(_rowdir, _coldir,_movedir);
        }

        public void BeginRigidbody()
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
        }
        
        public void StopRigidbody()
        {
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
        }

        private void CameraHeightMove()
        {
            float distance = transform.position.y - _oldpos.y;
            Camera.main.transform.DOMoveY(Camera.main.transform.position.y + distance, 0.01f);
        }

        private void CameraLineMove()
        {
            float distance = transform.position.x - _oldpos.x;
            Camera.main.transform.DOMoveX(Camera.main.transform.position.x + distance, 0.01f);
        }

        private void UpdateRotate()
        {
            if (_rigidbody.velocity == Vector3.zero)
            {
                _isrotate = true;
            }
            else
            {
                _isrotate = false;
            }
        }

        private bool UpdateSpeed()
        {
            if (_rigidbody.velocity== Vector3.zero)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 前进方向是否有墙壁
        /// </summary>
        private bool UpdateFrontWall(Vector3 dir)
        {
            // Transform collider = GameUtlis.RayCastTarget(transform.position, dir);
            // if (collider!=null&&collider.tag == "Wall")
            // {
            //     return true;
            // }

            return false;
        }

        private void UpdateGround()
        {
            GravityDir dir = GravityPresenter.Instance.GetDir();
            Vector3 vector = Vector3.down;
            switch (dir)
            {
                case GravityDir.Down:
                    vector = Vector3.down;
                    break;
                case GravityDir.Up:
                    vector = Vector3.up;
                    break;
                case GravityDir.Left:
                    vector = Vector3.left;
                    break;
                case GravityDir.Right:
                    vector = Vector3.right;
                    break;
            }

            // Transform collider = GameUtlis.RayCastTarget(transform.position, vector);
            // if (collider == null)
            // {
            //     _isground = false;
            //     ResetData();
            //     BeginRigidbody();
            // }
            // else
            // {
            //     _isground = true;
            // }
        }
    }
}


