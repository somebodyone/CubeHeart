using System.Collections;
using System.Collections.Generic;
using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class DLAudioManager : DLSingleton<DLAudioManager>
    {
        private AudioSource _source;
        
        public void PlayAudio(string url)
        {
            if (_source == null)
            {
                GameObject go = new GameObject();
                go.name = "AudioSource";
                _source = go.AddComponent<AudioSource>();
            }
            _source.PlayOneShot(Resources.Load<AudioClip>(url));
        }
    }
}
