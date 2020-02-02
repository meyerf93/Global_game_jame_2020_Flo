
using System;
using System.Collections.Generic;
using System.Linq;
using Logic.World;

[Serializable]
public class Angel : Creature
{
    public WorldMap world;
    public BodyPart _head;
    public BodyPart _torso;
    public BodyPart _legs;
    private List<BuildingType> _actionsList = new List<BuildingType>();
    
    public void SetBodyParts(BodyPart head, BodyPart torso, BodyPart legs)
    {
        _head = head;
        _torso = torso;
        _legs = legs;
        BuildActionsList(head, torso, legs);
    }

    private void BuildActionsList(BodyPart head, BodyPart torso, BodyPart legs)
    {
        // Aggregate actions from parts
        _actionsList.AddRange(head.actionsList);
        _actionsList.AddRange(torso.actionsList);
        _actionsList.AddRange(legs.actionsList);

        // Build synergy
        if (head.angelType == torso.angelType)
        {
            // Add bonus action
        }
    }

    public void GoBuildStuff()
    {
        while (_actionsList.Any())
            ExecuteNextAction();
        Die();
    }

    private new void ExecuteNextAction()
    {
        var nextBuilding = _actionsList[0];
        _actionsList.RemoveAt(0);
        CreateBuilding(nextBuilding);
    }
    
    private void CreateBuilding(BuildingType nextBuilding)
    {
        // Define new building location on map
        // Go to location
        // Build
    }
}
