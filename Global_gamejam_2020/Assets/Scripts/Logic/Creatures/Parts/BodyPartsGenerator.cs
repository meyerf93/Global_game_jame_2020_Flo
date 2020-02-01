using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Logic.World;
using UnityEngine;

namespace Logic.Creatures.Parts
{
    public class BodyPartsGenerator : MonoBehaviour
    {
        // Cette classe génère la liste des BodyParts pour chaque début de partie.
        // La liste est créée avec toutes les propriétés des BodyParts nécessaires, i.e.
        // une créature (angel) associée, et des actions à réaliser (qui seront additionnées
        // lorsque la créature sera assemblée.

        public int[] _angelTypeCounter = new int[9];
        public int[] _actionsCounter = new int[3];
        public int[] _partCounter = new int[3];
        
        private List<BodyPart> listOfParts;

        // private BodyPart BuildBodyPart(AngelType type, BuildingType actions)
        // {
        //     var partType = GetNextBodyPart();
        //     
        //     var part = gameObject.AddComponent<BodyPart>();
        //     switch (partType)
        //     {
        //         case "head":
        //             part = gameObject.AddComponent<HeadPart>();
        //             break;
        //         case "torso":
        //             part = gameObject.AddComponent<TorsoPart>();
        //             break;
        //         case "leg":
        //             part = gameObject.AddComponent<LegPart>();
        //             break;
        //     }
        //     part.angelType = type;
        //     part.actionsList = new List<BuildingType>{actions};
        //     return part;
        // }


        public BodyPart GetNextBodypart()
        {
            var partType = GetNextBodyPart();
            Debug.Log($"Create {partType} type");
            
            var part = Factory(partType);
            part.actionsList = new List<BuildingType> {GetNextAction()};
            part.angelType = GetNextAngelType();
            return part;
        }


        private BodyPart Factory(string partType)
        {
            switch (partType)
            {
                case "head" :
                    return gameObject.AddComponent<HeadPart>();
                case "torso":
                    return gameObject.AddComponent<TorsoPart>();
                case "leg":
                    return gameObject.AddComponent<LegPart>();
            }

            return null;
        }

        private AngelType GetNextAngelType()
        {
            var minIndex = 0;
            var minValue = 9;
            for (var i = 0; i < _angelTypeCounter.Length; i++)
            {
                if (_angelTypeCounter[i] >= minValue) continue;
                minValue = _angelTypeCounter[i];
                minIndex = i;
            }
            _angelTypeCounter[minIndex]++;

            switch (minIndex)
            {
                case 1: return AngelType.Nayade;
                case 2: return AngelType.Treant;
                default: return AngelType.Fairy;
            }
        }
        
        private string GetNextBodyPart()
        {
            var minIndex = 0;
            var minValue = 3;
            for (var i = 0; i < _partCounter.Length; i++)
            {
                if (_partCounter[i] >= minValue) continue;
                minValue = _partCounter[i];
                minIndex = i;
            }
            _partCounter[minIndex]++;

            switch (minIndex)
            {
                case 1: return "head";
                case 2: return "leg";
                default: return "torso";
            }
        }

        private BuildingType GetNextAction()
        {
            var minIndex = 0;
            var minValue = 9;
            for (var i = 0; i < _actionsCounter.Length; i++)
            {
                if (_actionsCounter[i] >= minValue) continue;
                minValue = _actionsCounter[i];
                minIndex = i;
            }
            
            _actionsCounter[minIndex]++;

            switch (minIndex)
            {
                case 1: return BuildingType.Pound;
                case 2: return BuildingType.Rock;
                default: return BuildingType.Tree;
            }
        }
        public void Reset()
        {
            for (int i = 0; i < _actionsCounter.Length; i++)
            {
                _actionsCounter[i] = 0;
            }

            for (int i = 0; i < _angelTypeCounter.Length; i++)
            {
                _angelTypeCounter[i] = 0;
            }
        }
    }
}