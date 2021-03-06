using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Logic.World;
using UnityEngine;

namespace Logic.Creatures.Parts
{
    public class BodyPartsGenerator : MonoBehaviour
    {
        // Cette classe g�n�re la liste des BodyParts pour chaque d�but de partie.
        // La liste est cr��e avec toutes les propri�t�s des BodyParts n�cessaires, i.e.
        // une cr�ature (angel) associ�e, et des actions � r�aliser (qui seront additionn�es
        // lorsque la cr�ature sera assembl�e.

        public int[] _angelTypeCounter = new int[7];
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
            BodyPartType partType = GetNextBodyPart();
            //Debug.Log($"Create {partType} type");
            
            BodyPart part = Factory(partType);
            part.actionsList = new List<BuildingType> {GetNextAction()};
            part.angelType = GetNextAngelType();
            return part;
        }


        private BodyPart Factory(BodyPartType partType)
        {
            BodyPart temp_body_part;
            temp_body_part = gameObject.AddComponent<BodyPart>();
            temp_body_part.partType = partType;
            return temp_body_part;
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
                case 0: return AngelType.Gimi;
                case 1: return AngelType.Frite;
                case 2: return AngelType.Dango;
                case 3: return AngelType.Asticot;
                case 4: return AngelType.Dango;
                case 5: return AngelType.La_main;
                case 6: return AngelType.Pumkin;
                default: return AngelType.Gimi;
            }
        }
        
        private BodyPartType GetNextBodyPart()
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
                case 1: return BodyPartType.Head;
                case 2: return BodyPartType.Body;
                default: return BodyPartType.Foot;
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
                case 1: return BuildingType.Pond;
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