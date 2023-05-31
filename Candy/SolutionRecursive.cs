namespace LeetCode;

// https://leetcode.com/problems/candy/
public class SolutionRecursive {
	public int Candy(int[] ratings) {
		if (ratings.Length == 1) {
			return 1;
		}

		var neighbor = new Child(ratings[0], 1);

		int index = 1;
		while (index < ratings.Length) {
			int rating = ratings[index];
			int candies = CandiesToAssign(rating, neighbor.Rating, neighbor.Candies);

			neighbor = new Child(rating, neighbor);
			neighbor.SetCandies(candies);

			index++;
		}

		int count = 0;
		while (neighbor != null) {
			count += neighbor.Candies;
			neighbor = neighbor.PreviousInLine;
		}

		return count;
	}

	private int CandiesToAssign(int rating, int neighborRating, int neighborCandies) {
		if (rating > neighborRating) {
			return neighborCandies + 1;
		}

		return 1;
	}
}

internal sealed class Child {
	public Child(int rating, int candies) {
		Rating = rating;
		Candies = candies;
	}

	public Child(int rating, Child previousInLine) {
		Rating = rating;
		PreviousInLine = previousInLine;
	}

	public int Candies { get; private set; }
	public int Rating { get; }
	public Child PreviousInLine { get; }

	public void SetCandies(int candies) {
		Candies = candies;
		if (PreviousInLine != null && PreviousInLine.Rating > Rating && PreviousInLine.Candies <= candies) {
			PreviousInLine.SetCandies(candies + 1);
		}
	}
}