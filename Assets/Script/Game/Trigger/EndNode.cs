using UnityEngine;

namespace DLAM
{
    public class EndNode:MonoBehaviour,LinkInterface
    {
        public SpriteRenderer _light;
        private bool islink = false;
        public void Link()
        {
            _light.color = Color.white;
        }

        public void Disconnect()
        {
            _light.color = Color.gray;
        }
    }
}