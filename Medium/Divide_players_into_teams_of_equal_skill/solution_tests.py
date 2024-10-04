import unittest
from solution import Solution
from parameterized import parameterized
from typing import List


class SolutionTests(unittest.TestCase):

    @parameterized.expand(
        [
            ([3,2,5,1,3,4], 22),
            ([3,4], 12),
            ([1,1,2,3], -1),
        ]
    )
    def test_divide_players(self, skill: List[int], expected: int):
        self.assertEqual(Solution().dividePlayers(skill), expected, "Fail")


if __name__ == "__main__":
    unittest.main()
