using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;
using UnityEngine;
using Pathfinding;
public class Monster : Creature
{
    public int amount_of_actions = 4;

    public Building currentTarget;
    public AIPath AIPath;
    public AIDestinationSetter DestinationSetter;
    public WorldMap map;
    public List<Building> buildings;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger collison with {other}");
        Destroy(other.gameObject);
    }

    private void Start()
    {
        AIPath = GetComponent<AIPath>();
        DestinationSetter = GetComponent<AIDestinationSetter>();
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

        if (buildings.Any())
        {
            
            //Debug.Log("Evil destroy building!");
            currentTarget = buildings[0];
            //DestinationSetter.transform = currentTarget.transform;
            //GoTo(currentTarget);
            //DestinationSetter.target = currentTarget.transform;
            //map.DestroyBuilding(currentTarget);
        }
        
        // Go to location
        // Destroy building
    }

     

    public void SetWorldMap(WorldMap worldMap)
    {
        map = worldMap;
        buildings = map.buildingsList;

    }
}