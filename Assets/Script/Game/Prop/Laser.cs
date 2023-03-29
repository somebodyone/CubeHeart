using System;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class Laser : MonoBehaviour
    {
        public Transform _start;
        public ElectRobot endnode;
        public Transform _target;
        public Vector3 _endpos ;
        private LineRenderer _lineRenderer;
        private int _time = 0;
        private int _id=0;

        public void Start()
        {
            _endpos = transform.position;
            _lineRenderer = transform.GetComponent<LineRenderer>();
            _lineRenderer.enabled = true;
        }

        public void Update()
        {
            if (endnode != null)
            {
                float angle = GameUtlis.Angle(_start.position, endnode.start.position);
                _target.localEulerAngles = new Vector3(0, 0, angle);
                _endpos = endnode.start.position;
            }
            _lineRenderer.SetPosition(0,transform.position);
            _lineRenderer.SetPosition(1,_endpos);
        }
    }
}
