using System;
using System.Collections.Generic;
using Logic.World;

[Serializable]
public class Recipe
{
    public List<ResourceType> Resources { get; set; }
    public BodyPart PartOfBody { get; set; }
    
    public Recipe(ResourceType res1, ResourceType res2, ResourceType res3, BodyPart part)
    {
        Resources = new List<ResourceType>(3) {res1, res2, res3};
        PartOfBody = part;
    }
}
