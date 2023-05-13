function filterLivestreams(input) {
	input = input.toLowerCase();
	let elements = document.getElementsByClassName("video-container");
	for (let i = 0; i < elements.length; i++) {
		let element = elements[i].getElementsByTagName("h3")[0];
		let videoDescription = element.innerText.toLowerCase();
		if (!videoDescription.includes(input)) {
			elements[i].style.display = "none";
		} else {
			elements[i].style.display = "inline-block";
		}
	}
}

function handleSession() {
	let userData = new Map();
	userData.set("agent", window.navigator.userAgent);

	let age = prompt("Пожалуйста, введите ваш возраст");
	userData.set("age", age);
	if (age >= 18) {
		let dateNow = new Date().toLocaleString();
		userData.set("startDate", dateNow);
		alert("Приветствуем на LifeSpot! " + dateNow);
	} else {
		alert(
			"Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены"
		);
		window.location.href = "http://www.google.com";
	}
	for (let result of userData) {
		console.log(result);
	}
	return userData;
}
