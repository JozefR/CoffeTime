// https://leetcode.com/problems/valid-anagram/

var a = isAnagram();

function isAnagram(){
    const [a, b] = ["rat", "car"]
    
    var s = Solution(a,b);
    
    function Solution(s, t){
        if (s.length !== t.length){
            return false;
        }

        var aDic = {};
        for (var i = 0; i < s.length; i++){
            const value = s[i];
            const valDic = aDic[value];
            if (valDic){
                aDic[value] += 1;
            }else{
                aDic[value] = 1;
            }
        }
        
        for (var i =0; i < t.length; i++){
            var value = t[i];
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

