using DLBASE;
using UnityEngine;

namespace DLAM
{
    public class EffectManager:DLSingleton<EffectManager>
    {
        public void CreatRunEffect(Vector3 pos)
        {
            GameObject effect = GameObject.Instantiate(Resources.Load<GameObject>("Perfabs/Effect/DustDirtyEffect"));
            effect.transform.position = pos;
        }

        public void CreatDieEffect(Vector3 pos)
        {
            GameObject effect = GameObject.Instantiate(Resources.Load<GameObject>("Perfabs/Effect/PlayerDieEffect"));
            effect.transform.position = pos;
        }
    }
}