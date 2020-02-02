using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;
using UnityEngine;
using Pathfinding;
using Random = System.Random;

public class Monster : Creature
{
    public int amount_of_actions = 4;

    public Building currentTarget;
    public AIPath AIPath;
    public AIDestinationSetter DestinationSetter;
    private WorldMap map;
    private Random rand = new Random();
    
    private List<Building> buildings = new List<Building>();

    private void Awake()
    {
        AIPath = GetComponent<AIPath>();
        DestinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tree") || other.CompareTag("Pond") || other.CompareTag("Rock"))
        {
            Debug.Log($"Trigger collison with {other}");
            map.DestroyBuilding(other.transform);
            //Destroy(other.gameObject);
            amount_of_actions--;
            Die();
        }
    }
    
    public void DestroyNextBuilding()
    {

        if (buildings.Any())
        {
            Debug.Log("Evil destroy building!");
            int randIdx = rand.Next(0, buildings.Count - 1);
            currentTarget = buildings[randIdx];
            DestinationSetter.target = currentTarget.transform;

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