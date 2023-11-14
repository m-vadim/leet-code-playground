public class Solution {
	public IList<IList<int>> Permute(int[] nums) {
		return Permute(nums.Length, new List<int>(nums));
	}
	
	private static IList<IList<int>> Permute(int size, IList<int> numbersLeft) {
		if (numbersLeft.Count == 1) {
			return new List<IList<int>> { new List<int>(size) { numbersLeft[0] } };
		}
		
		var result = new List<IList<int>>();
		
		for (int i = 0; i < numbersLeft.Count; i++) {
			int num = numbersLeft[i];
			numbersLeft.RemoveAt(i);

			IList<IList<int>> mut = Permute(size, numbersLeft);
			foreach (IList<int> permutation in mut) {
				permutation.Add(num);
			}
			result.AddRange(mut);
			numbersLeft.Insert(i, num);
		}

		return result;
	}
}