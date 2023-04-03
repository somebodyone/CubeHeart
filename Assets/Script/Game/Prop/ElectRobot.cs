using System;
using DG.Tweening;
using DLAM;
using DragonBones;
using UnityEngine;
using Transform = UnityEngine.Transform;

namespace DLAM
{
    public enum RobotDir
    {
        Collom,//横
        Row//竖
    }
    
    public class ElectRobot : MonoBehaviour, LinkInterface
    {
        public RobotDir _robotdir = RobotDir.Row;
        public int _dir = -1;
        public Transform _effect;
        public Transform start;
        private bool _electtric; //是否有电
        private UnityArmatureComponent _animation;
        private Rigidbody2D _rigidbody;
        private float _gravity => GravityPresenter.Instance.GetRobotGravity();
        private GravityDir _gravitydir => GravityPresenter.Instance.GetRobotDir();

        public void Start()
        {
            _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
            _rigidbody = transform.GetComponent<Rigidbody2D>();
            GravityPresenter.Instance.lisioner.UpdateRobotGravity(this, UpdateGravity);
            UpdateGravity();
        }

        public void UpdateGravity()
        {
            if (GameConfig.GameProgression != GameProgression.GameIng) return;
            int gravity = _gravity > 0 ? 1 : -1;
            float dir = 0;
            switch (_robotdir)
            {
                case RobotDir.Collom:
                    dir = 90  * gravity * _dir;
                    break;
                case RobotDir.Row:
                    dir = 90 + gravity * _dir*90;
                    break;
            }
            transform.DOLocalRotate(new Vector3(0,0,dir), 1);
        }

        public void FixedUpdate()
        {
            if (GameConfig.GameProgression != GameProgression.GameIng) return;
            Vector3 dir = new Vector3(0, 0, 0);
            switch (_robotdir)
            {
                case RobotDir.Collom:
                    dir = new Vector3(_gravity, 0, 0);
                    break;
                case RobotDir.Row:
                    dir = new Vector3(0, _gravity, 0);
                    break;
            }
            _rigidbody.AddForce(dir * _rigidbody.mass * _dir);
        }

        public void Link()
        {
            _effect.gameObject.SetActive(true);
            _animation.animation.Play("power");
            _electtric = true;
        }

        public void Disconnect()
        {
            _effect.gameObject.SetActive(false);
            _animation.animation.Play("idle");
            _electtric = false;
        }

        public void OnDestroy()
        {
            GravityPresenter.Instance.lisioner.Remove(this);
        }
    }
}