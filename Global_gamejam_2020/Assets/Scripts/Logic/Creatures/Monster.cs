using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;
using UnityEngine;

public class Monster : Creature
{
    public int amount_of_actions = 4;
    public Building currentTarget;

    private WorldMap map;
    private void Awake()
    {
        
    }

    public void GoDestroyStuff()
    {
        while (amount_of_actions > 0)
        //while (true)
        {
            DestroyNextBuilding();
            amount_of_actions--;
        }
        Die();
    }



    public void DestroyNextBuilding()
    {
        // Identify next building to destroy

        var buildings = map.buildingsList;
        if (buildings.Any())
        {
            
            Debug.Log("Evil destroy building!");
            currentTarget = buildings[0];
            map.DestroyBuilding(currentTarget);
        }
        
        // Go to location
        // Destroy building
    }

    public void SetWorldMap(WorldMap worldMap)
    {
        map = worldMap;
    }
}