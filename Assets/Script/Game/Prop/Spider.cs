using System;
using DG.Tweening;
using UnityEngine;

namespace DLAM
{
    public class Spider : MonoBehaviour
    {
        private int _dir = 1;
        private GravityDir _gravity => GravityPresenter.Instance.GetDir();
        
        public void UpdateGravity()
        {
            switch (_gravity)
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
    }
}

