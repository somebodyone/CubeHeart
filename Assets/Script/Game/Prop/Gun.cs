
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class Gun : MonoBehaviour
    {
        private string _buttle = "Perfabs/Game/Bullet";
        public int _dir=-1;
        public float _speed = 1;
        private float[] _timeconfig = {20, 20, 20,1000};
        private float _currenttime = 0;
        private int _id = 0;

        public void Awake()
        {
            DLPlayer.lisioner.FiexdUpdate(this, () => CheckUpdate());
        }

        public void CheckUpdate()
        {
            _currenttime += _speed;
            if (_currenttime > _timeconfig[_id])
            {
                _currenttime = 0;
                _id++;
                CreatBubblets();
                if (_id >= _timeconfig.Length)
                {
                    _id = 0;
                }
            }
        }

        private void CreatBubblets()
        {
            GameObject go = BulletPool.Instance.GetObj(_buttle);
            Buttle buttle = go.GetComponent<Buttle>();
            buttle.dir = (int)transform.localScale.x*_dir;
            buttle.transform.localScale = new Vector3(_dir, 1, 1)*buttle.transform.localScale.x;
            go.transform.parent = transform;
            go.transform.localPosition = Vector3.zero;
        }

        public void OnDestroy()
        {
            DLPlayer.lisioner.Remove(this);
        }
    }
}
