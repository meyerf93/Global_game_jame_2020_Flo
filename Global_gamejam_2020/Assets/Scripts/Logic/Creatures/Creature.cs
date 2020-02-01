namespace ClassLibrary1
{
    public class Creature
    {
        private const int maximum_moves = 3;
        private int _remaining_moves;
        public Creature()
        {
            _remaining_moves = maximum_moves;
        }

        protected void MakeMove()
        {
            _remaining_moves--;
            if (_remaining_moves == 0)
            {
                Die();
            }
        }
        
        public void Die()
        {}
        
        public void GoTo(int X, int Y)
        {}
        
    }
}