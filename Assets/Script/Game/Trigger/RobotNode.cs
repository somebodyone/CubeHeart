using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotNode : MonoBehaviour
{
    public ElectRobot _robot;
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "RobotTrigger")
        {
            if (_robot.Iseleck)
            {

            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "RobotTrigger")
        {
        }
    }
}
