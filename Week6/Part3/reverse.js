//First

function reverseString(str) {
    var splitString = str.split("");
    var reverseArray = splitString.reverse();
    var joinArray = reverseArray.join(""); // var joinArray = ["o", "l", "l", "e", "h"].join("");
    return joinArray;
}
//Second

function reverseStringSecond(str) {
    return str.split("").reverse().join("");
}

//Third 
function reverseStringThird(str) {
    var tempString = "";
    for (var i = str.length - 1; i >= 0; i--) {
        tempString += str[i];
    }
    return tempString;
}
//Fourth
function reverseStringFourth(str) {
    return (str === '') ? '' : reverseString(str.substr(1)) + str.charAt(0);
}



//First Way
console.log('***************************');
console.log("First Way ");
console.log(reverseString("Ayça"));

//Second Way
console.log('***************************');
console.log("Second Way ");
console.log(reverseStringSecond('Ayça'));

//Third Way
console.log('***************************');
console.log("Third Way ");
console.log(reverseStringThird('Ayça'));

//Fourth Way
console.log('***************************');
console.log("Fourth Way ");
console.log(reverseStringFourth('Ayça'));