from typing import List

"""https://leetcode.com/problems/divide-players-into-teams-of-equal-skill"""
class Solution:
    def dividePlayers(self, skill: List[int]) -> int:
        skill.sort()

        product = 0
        reqTeamSkill = skill[0] + skill[len(skill) - 1]
       
        for p1 in range(0, int(len(skill) / 2)):
            n1 = skill[p1]
            n2 = skill[0 - p1 - 1]
            if n1 + n2 != reqTeamSkill:
                return -1

            product += n1 * n2
            
        return product
