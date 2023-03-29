using System;
using DG.Tweening;
using DLAM;
using DragonBones;
using UnityEngine;
using Transform = UnityEngine.Transform;

public class ElectRobot : MonoBehaviour
{
    public Transform _effect;
    public Transform start;
    private bool _electtric;//是否有电
    private Rigidbody2D _rigidbody;
    private UnityArmatureComponent _animation;

    public void Awake()
    {
        _animation = transform.GetComponentInChildren<UnityArmatureComponent>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    public void ShowEffect()
    {
        _effect.gameObject.SetActive(true);
        _animation.animation.Play("power");
        _electtric = true;
    }

    public void StopEffect()
    {
        _effect.gameObject.SetActive(false);
        _animation.animation.Play("idle");
        _electtric = false;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            _rigidbody.isKinematic = false;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    public bool Iseleck
    {
        get => _electtric;
    }
}
