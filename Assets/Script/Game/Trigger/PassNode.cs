using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class PassNode : MonoBehaviour,LinkInterface
    {
        public Vector3 _nextlevelpos;
        public List<Transform> _pos;
        public List<float> _time;

        public GameObject _light;
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GamePresenter.Instance.SetNextLevel();
                GameManager.Instance.LoadGame(_nextlevelpos);
                Player player = col.GetComponent<Player>();
                player.EndGame();
                int count = 0;
                Move(player, count);
            }
        }
        
        private void Move(Player target,int count)
        {
            target.transform.DOMove(_pos[count].position, _time[count]).SetEase(Ease.Linear).OnComplete(() =>
            {
                count++;
                if (count > _pos.Count - 1)
                {
                    target.StartGame();
                    GameManager.Instance.RemoveLastGame();
                    return;
                }
                Move(target, count);
            });
        }

        public void Link()
        {
            _light.SetActive(true);
        }

        public void Disconnect()
        {
            _light.SetActive(false);
        }
    }
}
