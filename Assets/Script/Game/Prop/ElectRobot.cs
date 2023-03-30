using System;
using DG.Tweening;
using DLAM;
using DragonBones;
using UnityEngine;
using Transform = UnityEngine.Transform;

public class ElectRobot : MonoBehaviour,LinkInterface
{
    public int _dir=-1;
    public Transform _effect;
    public Transform start;
    private bool _electtric;//是否有电
    private UnityArmatureComponent _animation;
    private Rigidbody2D _rigidbody;
    private Vector3 _gravity => GravityPresenter.Instance.GetGravity();
    private GravityDir _gravitydir => GravityPresenter.Instance.GetDir();
    public void Start()
    {
        _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        GravityPresenter.Instance.lisioner.UpdateGravity(this, UpdateGravity);
    }
    
    public void UpdateGravity()
    {
        switch (_gravitydir)
        {
            case GravityDir.Down:
                transform.DOLocalRotate(new Vector3(0, 0, 0)*_dir, 1);
                break;
            case GravityDir.Up:
                transform.DOLocalRotate(new Vector3(0, 0, 180)*_dir, 1);
                break;
            case GravityDir.Left:
                transform.DOLocalRotate(new Vector3(0, 0, -90)*_dir, 1);
                break;
            case GravityDir.Right:
                transform.DOLocalRotate(new Vector3(0, 0, 90)*_dir, 1);
                break;
        }
    }
    
    public void FixedUpdate()
    {
        _rigidbody.AddForce(_gravity*_rigidbody.mass*_dir); 
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
