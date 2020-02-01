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

        public int[] _angelPartCounter = new int[9];
        public int[] _actionsCounter = new int[3];
        
        private List<BodyPart> listOfParts;

        private BodyPart BuildBodyPart(AngelType type, BuildingType actions)
        {
            var part = gameObject.AddComponent<HeadPart>();
            part.angelType = type;
            part.actionsList = new List<BuildingType>{actions};
            return part;
        }


        public BodyPart GetNextBodypart()
        {
            var part = gameObject.AddComponent<BodyPart>();
            part.actionsList = new List<BuildingType> {GetNextAction()};
            part.angelType = GetNextAngelType();
            return part;
        }

        private AngelType GetNextAngelType()
        {
            var minIndex = 0;
            var minValue = 9;
            for (var i = 0; i < _angelPartCounter.Length; i++)
            {
                if (_angelPartCounter[i] >= minValue) continue;
                minValue = _angelPartCounter[i];
                minIndex = i;
            }
            _angelPartCounter[minIndex]++;

            switch (minIndex)
            {
                case 1: return AngelType.Nayade;
                case 2: return AngelType.Treant;
                default: return AngelType.Fairy;
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

            for (int i = 0; i < _angelPartCounter.Length; i++)
            {
                _angelPartCounter[i] = 0;
            }
        }
    }
}