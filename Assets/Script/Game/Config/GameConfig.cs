using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class GameConfig
    {
        public static GameProgression GameProgression = GameProgression.Stop;

        public static Vector3[] StartPos = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(59f, 8.67f, 0),
            new Vector3(124.1f, 28.6f, 0),
            new Vector3(177.4f,79.52f,0)
        };
    }

}
