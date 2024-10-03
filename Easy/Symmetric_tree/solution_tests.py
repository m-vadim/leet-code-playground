import unittest
from solution import Solution
from treeNode import TreeNode
from parameterized import parameterized


class SolutionTests(unittest.TestCase):

    @parameterized.expand(
        [
            (
                TreeNode(
                    1, TreeNode(2, None, TreeNode(3)), TreeNode(2, None, TreeNode(3))
                ),
                False,
            ),
            (
                TreeNode(
                    1,
                    TreeNode(2, TreeNode(3), TreeNode(4)),
                    TreeNode(2, TreeNode(4), TreeNode(3)),
                ),
                True,
            ),
        ]
    )
    def test_tree_symmetry(self, root: TreeNode, expected: bool):
        self.assertEqual(Solution().isSymmetric(root), expected, "Fail")


if __name__ == "__main__":
    unittest.main()
