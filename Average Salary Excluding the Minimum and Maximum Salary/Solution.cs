namespace LeetCode;

// https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary/
public class Solution {
	public double Average(int[] salary) {
		int minSalary = salary[0], maxSalary = 0, sum = 0;

		foreach (int personSalary in salary) {
			sum += personSalary;
			if (minSalary > personSalary) {
				minSalary = personSalary;
			}

			if (maxSalary < personSalary) {
				maxSalary = personSalary;
			}
		}

		return (double) (sum - maxSalary - minSalary) / (salary.Length - 2);
	}
}