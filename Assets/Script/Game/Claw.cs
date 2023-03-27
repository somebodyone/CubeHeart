using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public enum ClawEnum
    {
        Up,
        Collow
    }
    
    public class Claw : MonoBehaviour
    {
        public SpriteRenderer _rope;
        public Transform _root;
        public float _start;
        public float _end;
        public ClawEnum _clawenum;

        public float _startheight = 0.4f;
        public float _endheight = 3f;
        public float _waittime = 0;

        public void Awake()
        {
        }

        public void MoveEnd()
        {
            DOTween.To(()=> _rope.size, x=> _rope.size = x, new Vector2(0.18f,_endheight), 0.4f).SetUpdate(true);
            _root.DOLocalMoveY(_end, 0.4f).OnComplete(() =>
            {
            });
        }

        public void MoveStart()
        {
            DOTween.To(()=> _rope.size, x=> _rope.size = x, new Vector2(0.18f,_startheight), 2f).SetUpdate(true);
            _root.DOLocalMoveY(_start, 2F).OnComplete(() =>
            {
                MoveEnd();
            });
        }
    }
}
