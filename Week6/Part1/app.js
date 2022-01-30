const { cleanTheDog, dogGrooming } = require('./kopekBakımUtility');
const { Dog } = require('./kopek');

console.log(`Köpek adı : ${Dog.name} \n Köpek boyu : ${Dog.height} `);

cleanTheDog();

console.log(`Köpek ilgi saati : ${dogGrooming}`)
