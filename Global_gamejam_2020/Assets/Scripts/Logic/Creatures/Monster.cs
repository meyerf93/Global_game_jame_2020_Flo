
public class Monster : Creature
{
    public int amount_of_actions = 4;

    public Monster()
    {
        GoDestroyStuff();
    }

    private void GoDestroyStuff()
    {
        while (amount_of_actions > 0)
        {
            DestroyNextBuilding();
        }

        Die();
    }

    public void DestroyNextBuilding()
    {
        // Identify next building to destroy
        // Go to location
        // Destroy building
    }
}
