const girlsPowerToplami = item => (item / 2.0) + 3;

const girlsPower = (arr) => {
    return arr.map(girlsPowerToplami);
};

let sampleArray = [2, 3, 4];
console.log(`[${array}] ==> [${girlsPower(array)}]`);
