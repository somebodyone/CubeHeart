
using UnityEngine;

namespace DLAM
{
    public class DirNode : MonoBehaviour
    {
        public bool _isend;
        public GravityDir _dir = GravityDir.Down;
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GravityPresenter.Instance.SetGravity(_dir);
            }
        }
    }
}
