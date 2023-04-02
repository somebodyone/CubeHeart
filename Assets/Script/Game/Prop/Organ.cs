
using UnityEngine;

namespace DLAM
{
    //尖刺
    public class Organ : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GameManager.Instance.ResetGame();
                GameManager.Instance.LoadGame();
                GameManager.Instance.LoadPlayer();
                GameManager.Instance.StartGame();
            }
        }
    }
}
