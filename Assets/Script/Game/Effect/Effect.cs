using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Effect : MonoBehaviour
    {
        public float _time = 1;
        
        void Update()
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
