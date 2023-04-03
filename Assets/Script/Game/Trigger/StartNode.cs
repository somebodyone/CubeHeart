using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class StartNode : LinkNode
    {
        public Transform _endnode;
        public void Update()
        {
            if (_endnode != null)
            {
                float angle = GameUtlis.Angle(start.position, _endnode.position);
                start.localEulerAngles = new Vector3(0, 0, angle);
            }
        }
        
        public override void Link()
        {
            
        }

        public override void Disconnect()
        {
            
        }
    }

}
