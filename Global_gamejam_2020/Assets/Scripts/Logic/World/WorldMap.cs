using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        
        public GameObject prefab_tree;
        //public GameObject prefab_rock;
        public GameObject prefab_pond;
        
        public GameObject prefab_angel;
        public GameObject prefab_monster;

        public GameObject buildingsManager;
        public List<GameObject> buildingsList = new List<GameObject>();
        
        public GameObject resourcesManager;
        public GameObject monstersManager;
        
        private Random rand = new Random();
        private int x_boundary = 25;
        private int y_boundary = 15;
        
        public int number_of_resources_on_map = 30;
        public int number_of_initial_buildings = 10;

        public int CorruptionLevel { get; set; }

        public ScoreBar _scoreBar;

        private void Awake()
        {
            SpawnInitialResources();
            SpawnInitialBuildings(); 
            SpawnMonster();
        }
        

        private void Start()
        {
            //_scoreBar = FindObjectOfType<ScoreBar>();
            
        }

        private void SpawnMonster()
        {
            Instantiate(prefab_monster, GetRandomVector(), Quaternion.identity).transform.SetParent(transform);
        }
            
        

        private void SpawnInitialBuildings()
        {
            for (int i = 0; i < number_of_initial_buildings; i++)
            {    
                SpawnBuilding(BuildingType.Tree);
                SpawnBuilding(BuildingType.Pond);
            }
        }

        private void SpawnBuilding(BuildingType type)
        {
            switch ( type)
            {
                case BuildingType.Tree:
                    var newBuilding = Instantiate(prefab_tree, GetRandomVector(), Quaternion.identity);
                    newBuilding.transform.SetParent(buildingsManager.transform);
                    buildingsList.Add(newBuilding);
                    break; 
                case BuildingType.Pond:
                    Instantiate(prefab_pond, GetRandomVector(), Quaternion.identity).transform.SetParent(buildingsManager.transform);
                    break;

                case BuildingType.Rock:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            _scoreBar.ScoreIncrease(type);
        }
        private void SpawnInitialResources()
        {
            for (int i = 0; i < number_of_resources_on_map; i++)
            {
                SpawnNewResource(ResourceType.STONE);
                SpawnNewResource(ResourceType.LEAF);
                SpawnNewResource(ResourceType.WATER);
            }
        }
        public void SpawnNewResource(ResourceType type)
        {
            switch(type)
            {
                case ResourceType.LEAF:
                    Instantiate(prefab_leaf, GetRandomVector(), Quaternion.identity).transform.SetParent(resourcesManager.transform);
                    break;
                case ResourceType.STONE:
                    Instantiate(prefab_stone, GetRandomVector(), Quaternion.identity).transform.SetParent(resourcesManager.transform);
                    break;
                case ResourceType.WATER:
                    Instantiate(prefab_water, GetRandomVector(), Quaternion.identity).transform.SetParent(resourcesManager.transform);
                    break;
            }
        }

        private Vector3 GetRandomVector()
        { var temp = new Vector3(
                rand.Next(-x_boundary, x_boundary),
                rand.Next(-y_boundary, y_boundary),
                transform.position.z
            );
            return temp;
        }

        public void DestroyBuilding(GameObject currentTarget)
        {
            Destroy(currentTarget);
            var buildingTag = currentTarget.gameObject.tag;
            switch (buildingTag)
            {
                case "Tree":
                    _scoreBar.ScoreDecrease(BuildingType.Tree);
                    break;
                case "Pond":
                    _scoreBar.ScoreDecrease(BuildingType.Pond);
                    break;
                case "Rock":
                    _scoreBar.ScoreDecrease(BuildingType.Rock);
                    break;
            }
        }
    }
}