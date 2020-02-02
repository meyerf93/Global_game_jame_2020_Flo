using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = System.Random;
using Logic.Creatures;

namespace Logic.World
{
    public class WorldMap : MonoBehaviour
    {
        public Vector3 SpawnPositionAngel;
        public GameObject prefab_leaf;
        public GameObject prefab_stone;
        public GameObject prefab_water;
        
        public Building prefab_tree;
        public Building prefab_rock;
        public Building prefab_pond;
        
        public List<Angel> prefab_angel;
        public Monster prefab_monster;

        public GameObject buildingsManager;
        public List<Building> buildingsList = new List<Building>();
        
        public GameObject resourcesManager;
        public GameObject monstersManager;
        
        private Random rand = new Random();
        private int x_boundary = 25;
        private int y_boundary = 15;
        
        public int number_of_resources_on_map = 30;
        public int number_of_initial_buildings = 10;
        public int number_of_initial_monstesr = 5;
        public List<Monster> monster_on_map;
        public List<Angel> angel_on_map;
        
        public int CorruptionLevel { get; set; }

        public ScoreBar _scoreBar;

        private void Awake()
        {
            monster_on_map = new List<Monster>();
            SpawnInitialResources();
            SpawnInitialBuildings(); 
            SpawnInitialMonsters();
        }
        

        private void Start()
        {
            //_scoreBar = FindObjectOfType<ScoreBar>();
            
        }

        private void SpawnInitialMonsters()
        {
            for (int i = 0; i < number_of_initial_monstesr; i++)
            {
                SpawnMonster();
            }
        }
        private void SpawnMonster()
        {
            Monster temp_monster = Instantiate(prefab_monster, GetRandomVector(), Quaternion.identity);
            temp_monster.transform.SetParent(transform);
            temp_monster.SetWorldMap(this);
            temp_monster.DestroyNextBuilding();
            monster_on_map.Add(temp_monster);
        }

        public void SpwanAngel(Angel angel)
        {
            foreach(Angel temp_angel in prefab_angel)
            {
                if(temp_angel._head.angelType == angel._head.angelType)
                {
                    Angel temp_angel_instance = Instantiate(temp_angel, SpawnPositionAngel, Quaternion.identity);
                    temp_angel_instance.transform.SetParent(transform);
                    copy_angel(temp_angel_instance, angel);
                    angel_on_map.Add(temp_angel_instance);
                }
            }
        }
            
        private void copy_angel(Angel first, Angel second)
        {
            first._head.angelType = second._head.angelType;
            first._head.partType = second._head.partType;
            first._head.actionsList = second._head.actionsList;
            first._head.ui = second._head.ui;
            first._head.change_ui();

            first._torso.angelType = second._torso.angelType;
            first._torso.partType = second._torso.partType;
            first._torso.actionsList = second._torso.actionsList;
            first._torso.ui = second._torso.ui;
            first._torso.change_ui();

            first._legs.angelType = second._legs.angelType;
            first._legs.partType = second._legs.partType;
            first._legs.actionsList = second._legs.actionsList;
            first._legs.ui = second._legs.ui;
            first._legs.change_ui();
        }

        private void SpawnInitialBuildings()
        {
            for (int i = 0; i < number_of_initial_buildings; i++)
            {
                SpawnBuilding(BuildingType.Tree);
                SpawnBuilding(BuildingType.Pond);
                SpawnBuilding(BuildingType.Rock);
            }
        }

        private void SpawnBuilding(BuildingType type)
        {
            Building newBuilding;
            switch ( type)
            {
                case BuildingType.Tree:
                    newBuilding = Instantiate(prefab_tree, GetRandomVector(), Quaternion.identity);
                    newBuilding.transform.SetParent(buildingsManager.transform);
                    buildingsList.Add(newBuilding);
                    break; 
                case BuildingType.Pond:
                    newBuilding = Instantiate(prefab_pond, GetRandomVector(), Quaternion.identity);
                    newBuilding.transform.SetParent(buildingsManager.transform);
                    buildingsList.Add(newBuilding);
                    break;

                case BuildingType.Rock:
                    newBuilding = Instantiate(prefab_rock, GetRandomVector(), Quaternion.identity);
                    newBuilding.transform.SetParent(buildingsManager.transform);
                    buildingsList.Add(newBuilding);
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

        public void DestroyBuilding(Building currentTarget)
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