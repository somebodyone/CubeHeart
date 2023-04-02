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
        Collom,
        Row
    }
    
    public class ElectRobot : MonoBehaviour, LinkInterface
    {
        public RobotDir _robotdir = RobotDir.Collom;
        public int _dir = -1;
        public Transform _effect;
        public Transform start;
        private bool _electtric; //是否有电
        private UnityArmatureComponent _animation;
        private Rigidbody2D _rigidbody;
        private Vector3 _gravity => GravityPresenter.Instance.GetRobotGravity();
        private GravityDir _gravitydir => GravityPresenter.Instance.GetRobotDir();

        public void Start()
        {
            _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
            _rigidbody = transform.GetComponent<Rigidbody2D>();
            GravityPresenter.Instance.lisioner.UpdateRobotGravity(this, UpdateGravity);
        }

        public void UpdateGravity()
        {
            if (GameConfig.GameProgression != GameProgression.GameIng) return;
            int angle = _dir == 1 ? 0 : 180;
            switch (_gravitydir)
            {
                case GravityDir.Down:
                    transform.DOLocalRotate(new Vector3(0, 0, 0 + angle), 1);
                    break;
                case GravityDir.Up:
                    transform.DOLocalRotate(new Vector3(0, 0, 180 + angle), 1);
                    break;
                case GravityDir.Left:
                    transform.DOLocalRotate(new Vector3(0, 0, -90 + angle), 1);
                    break;
                case GravityDir.Right:
                    transform.DOLocalRotate(new Vector3(0, 0, 90 + angle), 1);
                    break;
            }
        }

        public void FixedUpdate()
        {
            if (GameConfig.GameProgression != GameProgression.GameIng) return;
            _rigidbody.AddForce(_gravity * _rigidbody.mass * _dir);
        }

        public bool Iseleck
        {
            get => _electtric;
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