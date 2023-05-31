namespace LeetCode;

public class SolutionDoWhileNotReady {
	public int Candy(int[] seq) {
		int sum = 0;

		for (int i = 0; i < seq.Length; i++) {
			int smallerLeft = 0;
			int smallerRight = 0;
			int y = i - 1;
			
			while (y >= 0 && seq[y] < seq[y + 1]) {
				smallerLeft++;
				y--;
			}

			int y2 = i + 1;
			while (y2 < seq.Length && seq[y2] < seq[y2 - 1]) {
				smallerRight++;
				y2++;
			}
			
			sum += (1 + Math.Max(smallerLeft, smallerRight));
		}

		return sum;
	}

	private bool Do(int[] seq, int[] candies) {
		int last = seq.Length - 1;

		int index = 0;
		bool somethingChanged = false;
		while (index <= last) {
			int prev = index == 0 ? 0 : index - 1;
			int nextIndex = index == last ? last : index + 1;

			int rating = seq[index];
			int prevRating = seq[prev];
			int nextRating = seq[nextIndex];

			if (rating > prevRating && candies[index] <= candies[prev]) {
				candies[index] = candies[prev] + 1;
				somethingChanged = true;
			}
			else if (rating > nextRating && candies[index] <= candies[nextIndex]) {
				candies[index] = candies[nextIndex] + 1;
				somethingChanged = true;
			}

			index++;
		}

		return somethingChanged;
	}
}