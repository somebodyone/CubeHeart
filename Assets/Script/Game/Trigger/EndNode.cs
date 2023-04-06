using UnityEngine;

namespace DLAM
{
    public class EndNode:LinkNode
    {
        public SpriteRenderer _light;
        private bool islink = false;
        
        public override void Link()
        {
            _light.color = Color.white;
        }

        public override void Disconnect()
        {
            _light.color = Color.gray;
        }
    }
}