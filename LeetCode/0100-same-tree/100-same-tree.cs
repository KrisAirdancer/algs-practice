/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    
    /**
     * IDEA:
     * - Use recursion to traverse all nodes in the two trees simulataneously. The recursive
     *   function should take in the current TreeNode of each tree (each is incremented in the 
     *   previous recursive call). At the start of each recursive call, check if the two 
     *   TreeNodes that were passed in are the same. If they are, continue with the recursion;
     *   otherwise, return false. If the whole tree is searched without a premature return, 
     *   the trees are the same, return true.
     * 
     * PERFORMANCE:
     * - Time Complexity: O(N) - Since we have to loop over all nodes in the tree, we conduct
     *                    N steps, where N is the number of nodes in the smaller of the two
     *                    trees (we return early if the trees don't match, so we won't ahve
     *                    to search the larger of the two trees). Thus, O(N) complexity.
     * - Memory Complexity: O(N) - Recursively traversing to the deepest level of the tree
     *                      will add log(N) calls to the call stack. However, since we have
     *                      to store the trees, which takes O(2N) space, the overall complexity
     *                      is O(N).
     */
    public bool IsSameTree(TreeNode p, TreeNode q) {
        
        return recursiveIsSameTree(p, q);
    }
    
    private bool recursiveIsSameTree(TreeNode p, TreeNode q) {
        
        // BASE CASE 2: End of branch reached, return.
        if (p == null && q == null) { return true; } // Both are null; therefore, trees are still equivalent.
        
        if (p == null || q == null) { return false; } // Only one is null; therefore, trees are not equivalent.
        
        // BASE CASE 2: Nodes are not equal; therefore, trees are not equal.
        if (p.val != q.val) { return false; }
        
        // RECURSIVE CASE: Check both left and right branches.
        return recursiveIsSameTree(p.left, q.left) && recursiveIsSameTree(p.right, q.right);
    }
}