
using System.Collections.Generic;
using System.Linq;
using Logic.World;

public class Angel : Creature
{
        
    private HeadPart _head;
    private TorsoPart _torso;
    private LegPart _legs;
    private List<BuildingType> _actionsList;

    public Angel(HeadPart head, TorsoPart torso, LegPart legs)
    {
        _head = head;
        _torso = torso;
        _legs = legs;

        BuildActionsList(head, torso, legs);

        GoBuildStuff();
    }

    private void BuildActionsList(HeadPart head, TorsoPart torso, LegPart legs)
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

    private void GoBuildStuff()
    {
        while (_actionsList.Any())
        {
            ExecuteNextAction();
        }

        Die();
    }
    public new void ExecuteNextAction()
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