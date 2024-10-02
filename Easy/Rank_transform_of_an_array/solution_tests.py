import unittest
from typing import List
from solution import Solution
from parameterized import parameterized

class SolutionTests(unittest.TestCase):
	
	@parameterized.expand([
        ([40, 10, 20, 30], [4, 1, 2, 3]),
        ([100,100,100], [1, 1, 1]),
    ])
	def test_array_rank(self, arr: List[int], expected: List[int]): 
		ranked = Solution().arrayRankTransform(arr)
		self.assertEqual(ranked, expected, 'Ranking is incorrect')

if __name__ == '__main__':
    unittest.main()