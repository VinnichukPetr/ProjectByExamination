using Objects;
using Cell;
using Objects.Chest;
using Player;
using UnityEngine;

namespace Maze
{
    public class MazeSpawner : MonoBehaviour
    {
        [Header("Prefabs")] [SerializeField] private CellPrefab cellPrefab;
        [SerializeField] private CoinPrefab coinPrefab;
        [SerializeField] private BombPrefab bombPrefab;
        [SerializeField] private HealthRecoveryPrefab healthRecoveryPrefab;
        [SerializeField] private FreezeBombPrefab freezeBombPrefab;
        [SerializeField] private ChestPrefab chestPrefab;
        
        [Header("Transforms")] 
        [SerializeField] private Transform cellsTransform;
        [SerializeField] private Transform coinsTransform;
        [SerializeField] private Transform bombsTransform;
        [SerializeField] private Transform healthRecoversTransform;
        [SerializeField] private Transform freezeBombsTransform;
        [SerializeField] private Transform finishTransform;
        
        [Header("Maze")] 
        [SerializeField] private Vector3 cellSize = new Vector3(1, 0, 1);
        [SerializeField] private int lengthByX = 10;
        [SerializeField] private int lengthByZ = 10;

        [Header("Player")] 
        [SerializeField] private PlayerModel player;

        private void Start()
        {
            var countObjects = (lengthByX * lengthByZ) / 2;
            
            var maze = MazeGenerator.Generate(lengthByX, lengthByZ);
            var objectModels = ObjectGenerator.Generate(countObjects, lengthByX, lengthByZ);
            
            for (var x = 0; x < maze.Cells.GetLength(0); x++)
            {
                for (var z = 0; z < maze.Cells.GetLength(1); z++)
                {
                    var spawnPosition = new Vector3((x * cellSize.x), 0f, (z * cellSize.z));
                    var cell = Instantiate(cellPrefab, spawnPosition, Quaternion.identity, cellsTransform)
                        .GetComponent<CellPrefab>();

                    if (!maze.Cells[x, z].TurnGrass && !maze.Cells[x, z].TurnLeftWall &&
                        !maze.Cells[x, z].TurnBottomWall)
                    {
                        Destroy(cell.gameObject);
                    }
                    else
                    {
                        if (!maze.Cells[x, z].TurnGrass) Destroy(cell.grass);
                        if (!maze.Cells[x, z].TurnLeftWall) Destroy(cell.leftWall);
                        if (!maze.Cells[x, z].TurnBottomWall) Destroy(cell.bottomWall);
                    }
                }
            }

            foreach (var objectModel in objectModels)
            {
                var x = objectModel.PositionX;
                var z = objectModel.PositionZ;

                var spawnPosition = new Vector3((x * cellSize.x), 0.10f, (z * cellSize.z));

                switch (objectModel.Type)
                {
                    case TypeObject.Bomb:
                        Instantiate(bombPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f), bombsTransform); break;
                    case TypeObject.Coin:
                    {
                        Instantiate(coinPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f), coinsTransform);
                        player.MaxCoin++;
                    }break;
                    case TypeObject.HealthRecovery:
                        Instantiate(healthRecoveryPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f), healthRecoversTransform); break;
                    case TypeObject.FreezeBomb:
                        Instantiate(freezeBombPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f), freezeBombsTransform); break;
                    case TypeObject.Finish:
                    {
                        spawnPosition.y = 0.05f;
                        Instantiate(chestPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f), finishTransform); 
                    }break;
                        
                }
            }
        }
    }
}