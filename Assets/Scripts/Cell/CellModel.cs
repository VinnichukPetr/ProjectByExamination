namespace Cell
{
    public class CellModel
    {
        public int PositionX;
        public int PositionZ;

        public bool TurnLeftWall = true;
        public bool TurnBottomWall = true;
        public bool TurnGrass = true;

        public bool Visited = false;
    }
}