using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;
using UnityEngine;

public class Monster : Creature
{
    public int amount_of_actions = 4;
    public WorldMap worldMap;
    public Building currentTarget;
    private List<Building> list;
    private void Awake()
    {
        list = new List<Building>();
        GoDestroyStuff();
    }

 
    private void GoDestroyStuff()
    {
        while (amount_of_actions > 0)
        //while (true)
        {
            DestroyNextBuilding();
        }
        Die();
    }



    public void DestroyNextBuilding()
    {

        list = worldMap.buildingsList;
        if (list.Any())
        {
            
            Debug.Log("Evil destroy building!");
            currentTarget = list[0];
            worldMap.DestroyBuilding(currentTarget);
        }
        
        // Go to location
        // Destroy building
    }
}