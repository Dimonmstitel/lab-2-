namespace CatAndMouse.Models
{
    public enum State
    {
        Winner,
        Loser,
        Playing,
        NotInGame
    }

    public enum GameState
    {
        Start,
        End
    }

    public class Player
    {
        public string Name { get; set; }
        public int Location { get; set; } = -1;
        public State State { get; set; } = State.NotInGame;
        public int DistanceTraveled { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
            Location = -1;
        }

        public void Move(int steps, int fieldSize)
        {
            if (State == State.NotInGame)
            {
                int initialPos = ((steps - 1) % fieldSize + fieldSize) % fieldSize + 1;
                Location = initialPos;
                State = State.Playing;
            }
            else
            {
                int newZeroBased = ((Location - 1 + steps) % fieldSize + fieldSize) % fieldSize;
                Location = newZeroBased + 1;
                DistanceTraveled += System.Math.Abs(steps);
            }
        }
    }
}
