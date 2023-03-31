using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class PassNode : MonoBehaviour,LinkInterface
    {
        public List<Transform> _pos;

        public GameObject _light;
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                
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
