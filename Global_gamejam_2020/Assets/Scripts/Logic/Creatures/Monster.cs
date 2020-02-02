using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;
using UnityEngine;

public class Monster : Creature
{
    public int amount_of_actions = 4;
    [SerializeField] WorldMap worldMap;
    public Building currentTarget;
    private void Awake()
    {
        GoDestroyStuff();
    }

    private void Start()
    {
        worldMap = FindObjectOfType<WorldMap>();
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
        // Identify next building to destroy

        List<Building> list = worldMap.buildingsList;
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