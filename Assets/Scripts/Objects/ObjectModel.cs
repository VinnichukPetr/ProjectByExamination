namespace Objects
{
    public class ObjectModel
    {
        public int PositionX;
        public int PositionZ;
        public TypeObject Type;
    }

    public enum TypeObject
    {
        Coin, 
        Bomb,
        HealthRecovery,
        FreezeBomb,
        Finish
    }
}