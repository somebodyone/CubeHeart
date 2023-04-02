 using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class PassNode : MonoBehaviour,LinkInterface
    {
        public GravityDir _dir = GravityDir.Down;
        public Vector3 _nextlevelpos;
        public GameObject _wall;

        public GameObject _light;
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GamePresenter.Instance.SetNextLevel();
                GameManager.Instance.LoadGame(_nextlevelpos);
                Player player = col.GetComponent<Player>();
                player.EndGame();
                GravityPresenter.Instance.SetGravity(_dir);
                _wall.SetActive(false);
            }
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
