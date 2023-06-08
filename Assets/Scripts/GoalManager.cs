using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager singleton;

    public int holyWaterNeeded;
    public int holyWaterCollected;
    public bool canEnter;

    private void Awake()
    {
        singleton = this;
    }

    public void CollectHolyWater()
    {
        holyWaterCollected++;
        if(holyWaterCollected >= holyWaterNeeded)
        {
            canEnter = true;
        }
    }
}
