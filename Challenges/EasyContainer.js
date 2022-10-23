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

// https://leetcode.com/problems/length-of-last-word/
LengthOfTheLastWordSolution();

function LengthOfTheLastWordSolution() {
    
    LengthOfTheLastWord("a");
    LengthOfTheLastWord("  fly to the moon   ");
    
    function LengthOfTheLastWord(sentence){
        let lastWordLength = 0;
        sentence = sentence.trimEnd();
        for (let i = sentence.length - 1; i >= 0; i--){
            const character = sentence[i];
            if (character === " "){
                return lastWordLength;
            }
            lastWordLength++;
        }
    }
}

// https://leetcode.com/problems/plus-one/submissions/
PlusOneSolution();
function PlusOneSolution(){
    
    PlusOne([1,2,3]);
    PlusOne([9]);
    
    function PlusOne(digits){
        for (let i = digits.length; i >= 0; i--){
            if (digits[i] < 9){
                digits[i] += 1;
                return digits;
            }
            
            digits[i] = 0;
        }
        
        let newArray = new Array(digits.length + 1).fill(0);
        return newArray[0] = 1;
        return newArray;
    }
}


// https://leetcode.com/problems/add-binary/
AddBinarySolution();
function AddBinarySolution(){

    AddBinary("1010", "1011");
    AddBinary("11", "1");
    
    function AddBinary(a, b) {

        let aLength = a.length - 1;
        let bLength = b.length - 1;
        let result = "";
        let carry = 0;
        
        while (aLength >= 0 || bLength >= 0){
            let aNumber = 0;
            let bNumber = 0;
            
            if (aLength >= 0){
                aNumber = a[aLength] !== undefined ? parseInt(a[aLength]) : 0
            }

            if (bLength >= 0){
                bNumber = b[bLength] !== undefined ? parseInt(b[bLength]) : 0;
            }

            const sum = aNumber + bNumber + carry;
            const res = sum % 2;
            carry = Math.floor(sum/2);

            result = res + result;
            
            bLength--;
            aLength--;
        }
        
        if (carry !== 0){
            result = carry + result;
        }
        
        return result;
    }
}

// https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/727/
RemoveDuplicatesSolution();
function RemoveDuplicatesSolution(){
    
    removeDuplicates([1,1,2]);
    removeDuplicates([0,0,1,1,1,2,2,3,3,4]);
    
    function removeDuplicates(nums) {
        if (nums.length == 1){
            return 1;
        }

        let k = 1;
        for (let i = 1; i < nums.length; i++) {
            const number = nums[i];
            if (nums[k - 1] != number){
                nums[k] = number;
                k++;
            }
            
            if (nums[k - 1] != number){
                nums[i] = "_";
            }
        }
        
        return k;
    };
}

// https://leetcode.com/problems/move-zeroes/
MoveZeroesSolution();
function MoveZeroesSolution(){

    MoveZeroes([0,1,0,3,12]);
    MoveZeroes([1,1,2]);
    MoveZeroes([0,0,1,1,1,2,2,3,3,4]);

    function MoveZeroes(nums) {
        
        let nonZeroes = 0;
        for (let i = 0; i < nums.length; i++) {
            if (nums[i] !== 0) {
                nums[nonZeroes] = nums[i];
                nonZeroes++;
            }
        }
        
        for (let i = nonZeroes; i < nums.length; i++) {
            nums[i] = 0;
        }
    };
}
