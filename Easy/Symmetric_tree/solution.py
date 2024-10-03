from treeNode import TreeNode

"""https://leetcode.com/problems/symmetric-tree/description/"""
class Solution:
    def isSymmetric(self, root: TreeNode) -> bool:
        result = []
        queue = []

        queue.append(root)

        while len(queue) > 0:
            levelSize = len(queue)
            level = []

            for n in range(levelSize):
                node = queue.pop(0)

                if node is None:
                    level.append(None)
                else:
                    level.append(node.val)
                    queue.append(node.left)
                    queue.append(node.right)

            if self.isPalindrome(level) is False:
                return False

        return True

    def isPalindrome(self, arr) -> bool:
        back = -1
        size = len(arr)

        for i in range(0, int(size / 2)):
            if arr[i] != arr[size - i - 1]:
                return False
        return True
