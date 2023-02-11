using System.Collections.Generic;
using Cell;

namespace Maze
{
    public static class MazeGenerator
    {
        public static MazeModel Generate(int lengthByX, int lengthByZ)
        {
            var maze = new MazeModel();
            var cells = new CellModel[lengthByX, lengthByZ];

            for (var x = 0; x < cells.GetLength(0); x++)
            {
                for (var z = 0; z < cells.GetLength(1); z++)
                {
                    cells[x, z] = new CellModel { PositionX = x, PositionZ = z };
                }
            }

            GenerateWall(cells);

            maze.Cells = cells;
            return maze;
        }

        private static void GenerateWall(CellModel[,] cells)
        {
            var current = cells[0, 0];
            current.Visited = true;

            var stack = new Stack<CellModel>();

            do
            {
                var unvisitedNeighbours = new List<CellModel>();

                var x = current.PositionX;
                var z = current.PositionZ;


                if (x > 0 && !cells[x - 1, z].Visited) unvisitedNeighbours.Add(cells[x - 1, z]);
                if (z > 0 && !cells[x, z - 1].Visited) unvisitedNeighbours.Add(cells[x, z - 1]);
                if (x < cells.GetLength(0) - 2 && !cells[x + 1, z].Visited) unvisitedNeighbours.Add(cells[x + 1, z]);
                if (z < cells.GetLength(1) - 2 && !cells[x, z + 1].Visited) unvisitedNeighbours.Add(cells[x, z + 1]);

                if (unvisitedNeighbours.Count > 0)
                {
                    var chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                    RemoveWall(current, chosen);


                    chosen.Visited = true;
                    stack.Push(chosen);
                    current = chosen;
                }
                else
                {
                    current = stack.Pop();
                }
            } while (stack.Count > 0);

            for (var x = 0; x < cells.GetLength(0); x++)
            {
                cells[x, (cells.GetLength(1) - 1)].TurnLeftWall = false;
                cells[x, (cells.GetLength(1) - 1)].TurnGrass = false;
            }

            for (var z = 0; z < cells.GetLength(1); z++)
            {
                cells[(cells.GetLength(0) - 1), z].TurnBottomWall = false;
                cells[(cells.GetLength(0) - 1), z].TurnGrass = false;
            }
        }

        private static void RemoveWall(CellModel current, CellModel chosen)
        {
            if (current.PositionX == chosen.PositionX)
            {
                if (current.PositionZ > chosen.PositionZ)
                {
                    current.TurnBottomWall = false;
                }
                else
                {
                    chosen.TurnBottomWall = false;
                }
            }
            else
            {
                if (current.PositionX > chosen.PositionX)
                {
                    current.TurnLeftWall = false;
                }
                else
                {
                    chosen.TurnLeftWall = false;
                }
            }
        }
        
        
    }
}   