namespace LeetCode;

// https://leetcode.com/problems/candy/
public class SequencesSolution {
	public int Candy(int[] ratings) {
		if (ratings.Length == 1) {
			return 1;
		}

		Span<int> ratingsSpan = ratings.AsSpan();
		Queue<Seq> ss = FindSequences(ratings);

		var lastChild = new ChildCandies(ratings[0], 1);

		int sum = 0;
		while (ss.Count > 0) {
			Seq sequence = ss.Dequeue();

			if (sequence.Dir != Direction.Desc) {
				SequenceSum seqSum = CalculateSequence(ratingsSpan, sequence, lastChild);
				lastChild = seqSum.LastChild;
				sum += seqSum.Sum;
				continue;
			}

			int count = sequence.Count;
			while (ss.Count > 0 && ss.TryPeek(out Seq nextSeq) && nextSeq.Dir == Direction.Desc) {
				ss.Dequeue();
				count += nextSeq.Count;
			}

			SequenceSum declineChainSum =
				CalculateDescSequenceSum(lastChild, ratingsSpan.Slice(sequence.StartIndex, count));
			lastChild = declineChainSum.LastChild;
			sum += declineChainSum.Sum;
		}

		return sum;
	}

	private SequenceSum CalculateSequence(Span<int> ratingsSpan, Seq sequence, ChildCandies prevSequenceLastChild) {
		return sequence.Dir == Direction.Asc
			? CalculateAscSequenceSum(prevSequenceLastChild, ratingsSpan.Slice(sequence.StartIndex, sequence.Count))
			: CalculateDescSequenceSum(prevSequenceLastChild, ratingsSpan.Slice(sequence.StartIndex, sequence.Count));
	}

	private Queue<Seq> FindSequences(int[] rating) {
		Seq currentSeq = null;
		Queue<Seq> ss = new();

		int lastIndex = rating.Length - 1, head = 0;

		for (int i = 0; i <= lastIndex; i++) {
			int current = rating[i];
			int next = i != lastIndex ? rating[i + 1] : -1;

			currentSeq ??= new Seq(head, GetDir(current, next));

			if (current != next && i != lastIndex) {
				if (currentSeq.Dir == Direction.Unknown) {
					currentSeq.Dir = GetDir(current, next);
				}
				else if (GetDir(current, next) != currentSeq.Dir) {
					currentSeq.Complete(i - head + 1);
					ss.Enqueue(currentSeq);
					currentSeq = null;
					head = i + 1;
				}
			}

			if (i == lastIndex && currentSeq != null) {
				currentSeq.Complete(i - head + 1);
				ss.Enqueue(currentSeq);
			}
		}

		return ss;
	}

	private static SequenceSum CalculateAscSequenceSum(ChildCandies lastChild, Span<int> sequence) {
		int sum = 0, candies = 0;
		if (sequence[0] > lastChild.Rating) {
			candies = lastChild.Candies + 1;
		}
		else {
			candies = 1;
		}

		ChildCandies prev = lastChild;

		for (var index = 0; index < sequence.Length; index++) {
			int rating = sequence[index];
			if (index != 0) {
				if (rating == prev.Rating) {
					candies = 1;
				}
				else {
					candies += 1;
				}
			}

			sum += candies;
			prev = new ChildCandies(rating, candies);
		}

		return new SequenceSum(sum, new ChildCandies(sequence[^1], candies));
	}

	private static SequenceSum CalculateDescSequenceSum(ChildCandies lastChildOfPreviousSequence, Span<int> sequence) {
		int candies = 1, lastIndex = sequence.Length - 1, sum = 0;
		ChildCandies prev = new ChildCandies(sequence[^1], 1);

		for (int i = lastIndex; i >= 0; i--) {
			int rating = sequence[i];

			if (rating == prev.Rating) {
				candies = 1;
				sum += candies;
			}
			else if (rating > prev.Rating) {
				candies = prev.Candies + 1;
				sum += candies;
			}
			else {
				candies = 1;
				sum += candies;
				if (candies == prev.Candies) {
					sum += 1;
				}
			}

			prev = new ChildCandies(rating, candies);
		}

		if (prev.Rating != lastChildOfPreviousSequence.Rating) {
			if (lastChildOfPreviousSequence.Rating > prev.Rating &&
			    lastChildOfPreviousSequence.Candies <= prev.Candies) {
				sum += (prev.Candies - lastChildOfPreviousSequence.Candies + 1);
			}

			if (lastChildOfPreviousSequence.Rating < prev.Rating &&
			    lastChildOfPreviousSequence.Candies >= prev.Candies) {
				sum += (lastChildOfPreviousSequence.Candies - prev.Candies + 1);
			}
		}

		return new SequenceSum(sum, new ChildCandies(sequence[^1], 1));
	}

	private static Direction GetDir(int first, int second) {
		if (first > second) {
			return Direction.Desc;
		}

		if (first < second) {
			return Direction.Asc;
		}

		return Direction.Unknown;
	}
}

internal record ChildCandies(int Rating, int Candies);

internal record SequenceSum(int Sum, ChildCandies LastChild);

internal enum Direction {
	Asc,
	Desc,
	Unknown
}

internal class Seq {
	public Seq(int from, Direction dir) {
		StartIndex = from;
		Dir = dir;
	}

	public int StartIndex { get; }
	public Direction Dir { get; set; }
	public int Count { get; private set; }

	public void Complete(int count) {
		Count = count;
	}
}