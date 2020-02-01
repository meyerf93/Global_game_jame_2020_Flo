

using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;
using UnityEngine;
using UnityEngine.XR.WSA;
public class Monster : Creature
{
    public int amount_of_actions = 4;
    public WorldMap WorldMap;
    public GameObject currentTarget;
    private void Awake()
    {
        GoDestroyStuff();
    }

    private void GoDestroyStuff()
    {
        while (amount_of_actions > 0)
        {
            DestroyNextBuilding();
        }

        Die();
    }



    public void DestroyNextBuilding()
    {
        // Identify next building to destroy
        
        if (WorldMap.buildingsList.Any())
        {
            currentTarget = WorldMap.buildingsList[0];
        }
        

        // Go to location
        // Destroy building
    }
}
