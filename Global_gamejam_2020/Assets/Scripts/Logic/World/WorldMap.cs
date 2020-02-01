using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = System.Random;

namespace Logic.World
{
    public class WorldMap : MonoBehaviour
    {
        public GameObject prefab_leaf;
        public GameObject prefab_stone;
        public GameObject prefab_water;
        
        private Random rand = new Random();
        private int randMin = 0;
        private int randMax = 0;
        
        public int number_of_resources_on_map = 30;

        public int CorruptionLevel { get; set; }

        private void Awake()
        {
            SpawnInitialResources();
        }

        private void SpawnInitialResources()
        {
            for (int i = 0; i < number_of_resources_on_map; i++)
            {
                SpawnNewResource(ResourceType.LEAF);
            }
        }
        public void SpawnNewResource(ResourceType type)
        {
            //GameObject temp;
        
            switch(type)
            {
                case ResourceType.LEAF:
                    Instantiate(prefab_leaf, GetRandomVector(), Quaternion.identity).transform.SetParent(transform);
                    break;
                case ResourceType.STONE:
                    Instantiate(prefab_stone, GetRandomVector(), Quaternion.identity).transform.SetParent(transform);
                    break;
                case ResourceType.WATER:
                    Instantiate(prefab_water, GetRandomVector(), Quaternion.identity).transform.SetParent(transform);
                    break;



            }
            //temp.transform.SetParent(transform);
            //Destroy(temp);
        }

        private Vector3 GetRandomVector()
        {
            return new Vector3(
                rand.Next(randMin, randMax),
                rand.Next(randMin, randMax),
                transform.position.z
                );
        }
    }
  
}