using System.Security.AccessControl;

/// <summary>
/// https://leetcode.com/problems/spiral-matrix/
/// </summary>
public class Solution {
	public IList<int> SpiralOrder(int[][] matrix) {
		int rows = matrix.Length;
		int columns = matrix[0].Length;

		var list = new List<int>();
		var start = new MatrixPos(0, 0);
		var current = new MatrixPos(0, 0);
		var dir = Direction.Right;
		int horizontal = columns - 1, vertical = rows - 1;
		int iterations = rows * columns;

		while (iterations > 0) {
			if (Direction.Horizontal.HasFlag(dir)) {
				for (int i = 0; i < horizontal; i++) {
					//Console.WriteLine();
					list.Add(matrix[current.Row][current.Col]);
					
					current = Move(current, dir);
					iterations--;
				}
				dir = UpdateDirection(dir);
			}
			else {
				for (int i = 0; i < vertical; i++) {
					list.Add(matrix[current.Row][current.Col]);
					current = Move(current, dir);
					iterations--;
				}
				dir = UpdateDirection(dir);
			}

			if (current == start) {
				horizontal -= 2;
				vertical -= 2;
				if (horizontal == 0) {
					horizontal = 1;
				}
				
				start = new MatrixPos(start.Row + 1, start.Col + 1);
				current = start;
			}
		}
		
		// do {
		// 	
		// 	
		// 	
		// 	
		// } while (current != start);


		// while (TryIterate(new MatrixPos(rowIndex, colIndex), start, out MatrixPos next)) {
		// 	Console.WriteLine(matrix[next.Row][next.Col]);
		// }
		//
		return list;
	}

	private Direction UpdateDirection(Direction currentDirection) {
		return currentDirection switch {
			Direction.Right => Direction.Down,
			Direction.Down => Direction.Left,
			Direction.Left => Direction.Up,
			Direction.Up => Direction.Right
		};
	}

	private MatrixPos Move(MatrixPos current, Direction direction) {
		return direction switch {
			Direction.Right => new MatrixPos(current.Row, current.Col + 1),
			Direction.Down => new MatrixPos(current.Row + 1, current.Col),
			Direction.Left => new MatrixPos(current.Row, current.Col - 1),
			Direction.Up => new MatrixPos(current.Row - 1, current.Col)
		};
	}
}


[Flags]
internal enum Direction {
	Right = 0,
	Left = 2,
	Down = 4,
	Up = 8,
	Horizontal = Right | Left,
	Vertical = Down | Up
}

internal record Limit(int LastRow, int LastColumn);

internal record MatrixPos(int Row, int Col);