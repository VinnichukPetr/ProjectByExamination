using System;
using System.Collections.Generic;

namespace Objects
{
    public static class ObjectGenerator
    {
        public static IEnumerable<ObjectModel> Generate(int count, int lengthByX, int lengthByZ)
        {
            var objects = new List<ObjectModel>();

            var countBomb = Convert.ToInt32(count * 0.1);
            var countFreezeBomb = Convert.ToInt32(count * 0.1);
            var countHealthRecovery = Convert.ToInt32(count * 0.1);

            countBomb = countBomb > 0 ? countBomb : 1;
            countFreezeBomb = countFreezeBomb > 0 ? countFreezeBomb : 1;
            countHealthRecovery = countHealthRecovery > 0 ? countHealthRecovery : 1;
            
            var counter = 0;
            while(counter < count-1)
            {
                var x = UnityEngine.Random.Range(0, lengthByX - 1);
                var z = UnityEngine.Random.Range(0, lengthByZ - 1);

                if (!CheckerPosition(objects, x, z, lengthByX, lengthByZ)) continue;

                var type = TypeObject.Coin;

                if (counter <= countBomb) type = TypeObject.Bomb;
                else if (counter <= countBomb + countFreezeBomb) type = TypeObject.FreezeBomb;
                else if (counter <= countBomb + countFreezeBomb + countHealthRecovery) type = TypeObject.HealthRecovery;
                else type = TypeObject.Coin;
                
                objects.Add(CreateObject(x, z, type));
                counter++;
            }
            
            objects.Add(CreateObject(lengthByX - 2, lengthByZ - 2, TypeObject.Finish));
            
            return objects;
        }
        
        private static bool CheckerPosition(IEnumerable<ObjectModel> objectModels, int x, int z, int maxX, int maxZ)
        { 
            var isIdentity = true;
            
            if (x == 0 && z == 0) return false;
            if (x == maxX - 2 && z == maxZ - 2) return false;
            
            foreach (var objectModel in objectModels)
            {
                if (objectModel == null) continue;
                
                if (x == objectModel.PositionX && z == objectModel.PositionZ) isIdentity = false;
            }
            
            return isIdentity;
        }

        private static ObjectModel CreateObject(int x, int z, TypeObject type) => new ObjectModel()
        {
            PositionX = x,
            PositionZ = z,
            Type = type
        };
    }
}