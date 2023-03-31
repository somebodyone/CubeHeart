using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class StartNode : MonoBehaviour,LinkInterface
    {
        public Transform _start;
        public ElectRobot _endnode;
        public void Update()
        {
            if (_endnode != null)
            {
                float angle = GameUtlis.Angle(_start.position, _endnode.start.position);
                _start.localEulerAngles = new Vector3(0, 0, angle);
            }
        }
        
        public void Link()
        {
            
        }

        public void Disconnect()
        {
            
        }
    }

}
