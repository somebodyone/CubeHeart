using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Res
    {
        public static GameObject[] Levels;

        public static void LoadRes()
        {
            Levels = Resources.LoadAll<GameObject>("Perfabs/Level");
        }
    }
}
