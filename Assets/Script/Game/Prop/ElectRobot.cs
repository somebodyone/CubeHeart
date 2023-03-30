using System;
using DG.Tweening;
using DLAM;
using DragonBones;
using UnityEngine;
using Transform = UnityEngine.Transform;

public class ElectRobot : MonoBehaviour
{
    public int _dir=-1;
    public Transform _effect;
    public Transform start;
    private bool _electtric;//是否有电
    private UnityArmatureComponent _animation;
    private Rigidbody2D _rigidbody;
    private Vector3 _gravity => GravityPresenter.Instance.GetGravity();

    public void Start()
    {
        _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        GravityPresenter.Instance.lisioner.UpdateGravity(this, () =>
        {
            
        });
    }
    public void FixedUpdate()
    {
        _rigidbody.AddForce(_gravity*_rigidbody.mass*_dir); 
    }
    public void ShowPower()
    {
        _effect.gameObject.SetActive(true);
        _animation.animation.Play("power");
        _electtric = true;
    }

    public void ClosePower()
    {
        _effect.gameObject.SetActive(false);
        _animation.animation.Play("idle");
        _electtric = false;
    }

    public bool Iseleck
    {
        get => _electtric;
    }
}
