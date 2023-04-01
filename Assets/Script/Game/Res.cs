using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLAM
{
    public class Res
    {
        public static GameObject[] Levels;
        public static GameObject HomePage;
        public static GameObject Player;

        public static void LoadRes()
        {
            Levels = Resources.LoadAll<GameObject>("Perfabs/Level");
            HomePage = Resources.Load<GameObject>("Perfabs/主页");
            Player = Resources.Load<GameObject>("Perfabs/Game/Player");
        }
    }
}
