
using System;
using DG.Tweening;
using DLBASE;
using DragonBones;
using UnityEngine;
using Transform = UnityEngine.Transform;

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
        public Transform _left;
        public Transform _mid;
        public Transform _right;
        public Transform _smoke;
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;
        private UnityArmatureComponent _animation;
        private float _speed = 4;
        private PlayerAnimationType _animationtype;
        private float _x = 0.6f;
        private int _dir = 1;
        private float _speedscale = 1.4f;
        private bool _isground;
        public bool _ispause = true;
        private ListenerDelegate<EventObject> _dbDelegate;
        private GravityDir _gravitydir => GravityPresenter.Instance.GetDir();
        private Vector3 _gravity => GravityPresenter.Instance.GetGravity();

        public void Start()
        {
            _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
            _animation.animation.Play("idle");
            _animation.AddEventListener(EventObject.SOUND_EVENT, SoundEventCallback);
            _animationtype = PlayerAnimationType.Idle;
            GravityPresenter.Instance.lisioner.UpdateGravity(this,() =>
            {
                UpdateGravity();
            });
        }

        public void StartGame()
        {
            _rigidbody = transform.GetComponent<Rigidbody2D>();
            _boxCollider = transform.GetComponent<BoxCollider2D>();
            _boxCollider.enabled = true;
            _ispause = false;
            _rigidbody.isKinematic = false;
            gameObject.SetActive(true);
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

        private void SoundEventCallback(string type, EventObject eventobject)
        {
            if (_isground)
            {
                DLAudioManager.Instance.PlayAudio("Audio/walks");
                EffectManager.Instance.CreatRunEffect(_smoke.position);  
            }
        }

        public void Update()
        {
            if(_ispause)return;
            UpdateGround();
            UpdateDir();
            if(!_isground)return;
            if(Input.GetKey(KeyCode.D))
            {
                Vector3 speed = GetSpeed(KeyCode.D);
                if(Input.GetKey(KeyCode.W))
                {
                    if (_gravitydir == GravityDir.Down || _gravitydir == GravityDir.Up)
                    {
                        speed = GetSpeed(KeyCode.D) + GetSpeed(KeyCode.W)*_speedscale;
                    }
                    else
                    {
                        speed = GetSpeed(KeyCode.D)*_speedscale + GetSpeed(KeyCode.W);
                    }
                }
                else if(Input.GetKey(KeyCode.S))
                {
                    if (_gravitydir == GravityDir.Down || _gravitydir == GravityDir.Up)
                    {
                        speed = GetSpeed(KeyCode.D) + GetSpeed(KeyCode.S)*_speedscale;
                    }
                    else
                    {
                        speed = GetSpeed(KeyCode.D)*_speedscale + GetSpeed(KeyCode.S);
                    }

                }
                Move(speed,1);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                Vector3 speed = GetSpeed(KeyCode.A);
                if(Input.GetKey(KeyCode.W))
                {
                    if (_gravitydir == GravityDir.Down || _gravitydir == GravityDir.Up)
                    {
                        speed = GetSpeed(KeyCode.A) + GetSpeed(KeyCode.W)*_speedscale;
                    }
                    else
                    {
                        speed = GetSpeed(KeyCode.A)*_speedscale + GetSpeed(KeyCode.W);
                    }
                }
                else if(Input.GetKey(KeyCode.S))
                {
                    if (_gravitydir == GravityDir.Down || _gravitydir == GravityDir.Up)
                    {
                        speed = GetSpeed(KeyCode.A) + GetSpeed(KeyCode.S)*_speedscale;
                    }
                    else
                    {
                        speed = GetSpeed(KeyCode.A)*_speedscale + GetSpeed(KeyCode.S);
                    }
                }
                Move(speed,-1);
            }
            else if(Input.GetKey(KeyCode.W))
            {
                Vector3 speed = GetSpeed(KeyCode.W);
                if(Input.GetKey(KeyCode.A))
                {
                    speed = GetSpeed(KeyCode.W)*_speedscale + GetSpeed(KeyCode.A);
                }
                else if(Input.GetKey(KeyCode.D))
                {
                    speed = GetSpeed(KeyCode.W)*_speedscale + GetSpeed(KeyCode.D);
                }
                Move(speed,-1);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                Vector3 speed = GetSpeed(KeyCode.S);
                if(Input.GetKey(KeyCode.A))
                {
                    speed = GetSpeed(KeyCode.S)*_speedscale + GetSpeed(KeyCode.A);
                }
                else if(Input.GetKey(KeyCode.D))
                {
                    speed = GetSpeed(KeyCode.S)*_speedscale + GetSpeed(KeyCode.D);
                }
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
            _rigidbody?.AddForce(_gravity*_rigidbody.mass); 
        }

        private Vector3 _oldpos;
        public  void LateUpdate()
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
            Camera.main.transform.DOMove(pos, 0.1f);
        }

        private float _scale = 2;
        private void UpdateGround()
        {
            GravityDir dir = GravityPresenter.Instance.GetDir();
            Vector3 leftpos = _left.position;
            Vector3 rightpos = _right.position;
            Vector3 midpos = _mid.position;
            switch (dir)
            {
                case GravityDir.Down:
                    leftpos += Vector3.down*_scale;
                    rightpos += Vector3.down*_scale;
                    midpos += Vector3.down*_scale;
                    break;
                case GravityDir.Up:
                    leftpos += Vector3.up*_scale;
                    rightpos += Vector3.up*_scale;
                    midpos += Vector3.up*_scale;
                    break;
                case GravityDir.Left:
                    leftpos += Vector3.left*_scale;
                    rightpos += Vector3.left*_scale;
                    midpos += Vector3.left*_scale;
                    break;
                case GravityDir.Right:
                    leftpos += Vector3.right*_scale;
                    rightpos += Vector3.right*_scale;
                    midpos += Vector3.right*_scale;
                    break;
            }
            
           bool left = GameUtlis.IsRaycast(_left.position,leftpos,0.5f);
           bool mid = GameUtlis.IsRaycast(_mid.position,midpos,0.5f);
           bool right = GameUtlis.IsRaycast(_right.position,rightpos,0.5f);
           _isground = left || mid || right;
        }

        public void EndGame()
        {
            _ispause = true;
            _animation.animation.Play("idle");
            // _rigidbody.isKinematic = true;
            // _boxCollider.enabled = false;
            _rigidbody.velocity = Vector3.zero;
        }

        public Vector3 Position
        {
            set => transform.position = value;
        }
        
        public void OnDestroy()
        {
            GravityPresenter.Instance.lisioner.Remove(this);
        }
    }
}
