using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DLAM
{
    public class MoveSaw : MonoBehaviour
    {
        public Transform _start;
        public Transform _end;
        public float _movespeed;

        public void Start()
        {
            Move();
        }

        public void Move()
        {
            transform.DOMove(_end.position, _movespeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOMove(_start.position, _movespeed).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Move();
                });
            });
        }
    }
}

