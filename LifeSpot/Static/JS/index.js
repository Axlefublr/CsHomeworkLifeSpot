let userData = new Map();
userData.set("agent", window.navigator.userAgent);

let age = prompt("Пожалуйста, введите ваш возраст");
userData.set("age", age);

let dateNow;
if (age >= 18) {
	dateNow = new Date().toLocaleString();
	alert("Приветствуем на LifeSpot! " + dateNow);
} else {
	alert(
		"Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены"
	);
	window.location.href = "http://www.google.com";
}

userData.set("startDate", dateNow);

for (let result of userData) {
	console.log(result);
}
