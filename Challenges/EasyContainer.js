// https://leetcode.com/problems/valid-anagram/

isAnagram();

function isAnagram() {
    const [a, b] = ["rat", "car"]
    
    const s = Solution(a,b);
    
    function Solution(s, t){
        if (s.length !== t.length){
            return false;
        }

        const aDic = {};
        for (let i = 0; i < s.length; i++){
            const value = s[i];
            const valDic = aDic[value];
            if (valDic){
                aDic[value] += 1;
            }else{
                aDic[value] = 1;
            }
        }
        
        for (let i =0; i < t.length; i++){
            const value = t[i];
            if (!aDic[value]){
                return false;
            }
            
            aDic[value] -= 1;
            if (aDic[value] < 0){
                return false;
            }
        }
        
        return true;
    }
}

// https://leetcode.com/problems/same-tree/

SameTree();

function SameTree() {

    function Node(val, left, right) {
        this.val = (val === undefined ? 0 : val)
        this.left = (left === undefined ? null : left)
        this.right = (right === undefined ? null : right)
    }
    
    let treeA = new Node(0, new Node(1, undefined, undefined), new Node(2, undefined, undefined));
    let treeB = new Node(0, undefined, new Node(1, undefined, undefined));
    let treeC = new Node(1, new Node(2, undefined, undefined), new Node(3, undefined, undefined));
    let treeD = new Node(1, new Node(2, undefined, undefined), new Node(3, undefined, undefined));
    
    const test = isSameTree(treeC, treeD);
    console.log(test)

    function isSameTree(p, q){

        if (p == null && q == null){
            return true;
        }

        if (p == null || q == null){
            return false;
        }

        if (p.val != q.val){
            return false;
        }

        return isSameTree(p.left, q.left) && isSameTree(p.right, q.right)
    }
}

