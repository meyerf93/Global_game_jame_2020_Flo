using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Logic.World
{
    public class WorldMap : MonoBehaviour
    {
        public int CorruptionLevel { get; set; }
        public List<Resource> availableResources = new List<Resource>();
        
          
        public void SpawnNewResource()
        {
            // get position on map
            var newResource = gameObject.AddComponent<Resource>();
            availableResources.Add(newResource);
        }
    }
  
}