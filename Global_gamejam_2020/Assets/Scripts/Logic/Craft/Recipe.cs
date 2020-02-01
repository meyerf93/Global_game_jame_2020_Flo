
using System.Collections.Generic;
using Logic.World;


public class Recipe
{
    public List<ResourceType> Ingredients { get; set; }
    public BodyPart BodyPart { get; set; }



    public Recipe(ResourceType res1, ResourceType res2, ResourceType res3, BodyPart part)
    {
        Ingredients = new List<ResourceType>(3) {res1, res2, res3};
        this.BodyPart = part;
    }

}
