let myMap = new Map();
myMap.set("Германия", "Берлин");
myMap.set("Швеция", "Стокгольм");
myMap.set(1, "Москва");

let newArray = [];
for (let result of myMap) {
	newArray.push(result);
}
console.log(newArray);

let newArrayOfStrings = [];
Array.from(myMap, ([key, value]) =>
	newArrayOfStrings.push(`${key} - ${value}`)
);
console.log(newArrayOfStrings);
