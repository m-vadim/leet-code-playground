from typing import List


class Solution:
    def arrayRankTransform(self, arr: List[int]) -> List[int]:
        sorted = list(arr)
        sorted.sort()

        dict = {}
        rank = 1
        prev = None
        for el in sorted:
            if prev != el:
                dict[el] = rank
                rank += 1
                prev = el

        for index, num in enumerate(arr):
            arr[index] = dict[num]

        return arr
