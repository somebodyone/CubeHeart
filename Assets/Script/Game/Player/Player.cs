
using System;
using DG.Tweening;
using DLBASE;
using DragonBones;
using UnityEngine;

namespace DLAM
{
    public enum PlayerAnimationType
    {
        Walk,
        Idle,
        Jump
    }
    
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private UnityArmatureComponent _animation;
        private float _speed = 4;
        private PlayerAnimationType _animationtype;
        private float _x = 0.6f;
        private int _dir = 1;
        private float _speedscale = 1.4f;
        private bool _isground;
        private bool _isgameover;
        private GravityDir _gravitydir => GravityPresenter.Instance.GetDir();
        private Vector3 _gravity => GravityPresenter.Instance.GetGravity();

        public void Start()
        {
            _rigidbody = transform.GetComponent<Rigidbody2D>();
            _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
            _animation.animation.Play("idle");
            _animationtype = PlayerAnimationType.Idle;
            GravityPresenter.Instance.lisioner.UpdateGravity(this,() =>
            {
                UpdateGravity();
            });
        }

        public void UpdateGravity()
        {
            switch (_gravitydir)
            {
                case GravityDir.Down:
                    transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
                    break;
                case GravityDir.Up:
                    transform.DOLocalRotate(new Vector3(0, 0, 180), 1);
                    break;
                case GravityDir.Left:
                    transform.DOLocalRotate(new Vector3(0, 0, -90), 1);
                    break;
                case GravityDir.Right:
                    transform.DOLocalRotate(new Vector3(0, 0, 90), 1);
                    break;
            }
        }

        private void UpdateDir()
        {
            switch (GravityPresenter.Instance.GetDir())
            {
                case GravityDir.Down:
                    _dir = 1;
                    break;
                case GravityDir.Up:
                    _dir = -1;
                    break;
                case GravityDir.Left:
                    _dir = 1;
                    break;
                case GravityDir.Right:
                    _dir = -1;
                    break;
            }
        }

        private Vector3 GetSpeed(KeyCode key)
        {
            Vector3 speed = Vector3.zero;
            switch (key)
            {
                case KeyCode.A:
                    speed = Vector3.left;
                    break;
                case KeyCode.D:
                    speed= Vector3.right;
                    break;
                case KeyCode.S:
                    speed= Vector3.down;
                    break;
                case KeyCode.W:
                    speed = Vector3.up;
                    break;
            }
            return speed;
        }

        private void Move(Vector3 speed,int dir)
        {
            _rigidbody.velocity = speed * _speed;
            if (_animationtype!= PlayerAnimationType.Walk)
            {
                _animation.animation.Play("walk");
                _animationtype = PlayerAnimationType.Walk;
                transform.localScale = new Vector3(dir*_dir*_x, _x, _x);
            }
        }
        public void Update()
        {
            if(_isgameover)return;
            UpdateGround();
            UpdateDir();
            if(!_isground)return;
            if(Input.GetKey(KeyCode.D))
            {
                Vector3 speed = GetSpeed(KeyCode.D);
                if(Input.GetKey(KeyCode.W))
                {
                    speed = GetSpeed(KeyCode.D) + GetSpeed(KeyCode.W)*_speedscale;
                }
                else if(Input.GetKey(KeyCode.S))
                {
                    speed = GetSpeed(KeyCode.D) + GetSpeed(KeyCode.S)*_speedscale;
                }
                Move(speed,1);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                
                Vector3 speed = GetSpeed(KeyCode.A);
                if(Input.GetKey(KeyCode.W))
                {
                    speed = GetSpeed(KeyCode.A) + GetSpeed(KeyCode.W)*_speedscale;
                }
                else if(Input.GetKey(KeyCode.S))
                {
                    speed = GetSpeed(KeyCode.A) + GetSpeed(KeyCode.S)*_speedscale;
                }
                Move(speed,-1);
            }else if(Input.GetKey(KeyCode.W))
            {
                Vector3 speed = GetSpeed(KeyCode.W)*_speedscale;
                Move(speed,-1);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                Vector3 speed = GetSpeed(KeyCode.S)*_speedscale;
                Move(speed,1);
            }
            else
            {
                if (_animationtype!= PlayerAnimationType.Idle)
                {
                    _animation.animation.Play("idle");
                    _animationtype = PlayerAnimationType.Idle;
                    _rigidbody.velocity = Vector3.zero;
                }
            }
        }

        public void FixedUpdate()
        {
            _rigidbody.AddForce(_gravity*_rigidbody.mass); 
        }

        private Vector3 _oldpos;
        public  void LateUpdate()
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
            Camera.main.transform.DOMove(pos, 0.1f);
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

            _isground = GameUtlis.RayCastTarget(transform.position, vector);
        }

        public void EndGame()
        {
            _isgameover = true;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
            transform.DOMoveY(transform.position.y+6, 7).SetEase(Ease.InQuad);
        }
        
        public void OnDestroy()
        {
            GravityPresenter.Instance.lisioner.Remove(this);
        }
    }
}
