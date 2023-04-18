using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class GameConfig
    {
        public static GameProgression GameProgression = GameProgression.Stop;

        public static Vector3[] StartPos = new Vector3[7]
        {
            new Vector3(0, 0, 0),
            new Vector3(59f, 8.67f, 0),
            new Vector3(124.1f, 28.6f, 0),
            new Vector3(171.9f,84.1f,0),
            new Vector3(202.2f,34.7f,0),
            new Vector3(229.8f,-14.7f,0),
            new Vector3(243.9f,-66.7f,0)
        };
    }

}
