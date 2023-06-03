function Comment() {
	this.author = prompt("Как вас зовут ?");
	if (this.author == null) {
		this.isEmpty = true;
		return;
	}

	this.text = prompt("Оставьте отзыв");
	if (this.text == null) {
		this.isEmpty = true;
		return;
	}

	this.date = new Date().toLocaleString();
}

function addComment() {
	const comment = new Comment();

	if (comment.isEmpty) {
		return;
	}

	let enableLikes = confirm("Разрешить пользователям оценивать ваш отзыв?");

	if (enableLikes) {
		const review = Object.create(comment);
		review.rate = 0;

		writeReview(review);
	} else {
		writeReview(comment);
	}
}

const writeReview = (review) => {
	let likeCounter = "";

	if (review.hasOwnProperty("rate")) {
		let commentId = Math.random();
		likeCounter +=
			'<button id="' +
			commentId +
			'" style="border: none" onclick="addLike(this.id)">' +
			`❤️ ${review.rate}</button>`;
	}
	document.getElementsByClassName("reviews")[0].innerHTML +=
		' <div class="review-    text">\n' +
		`<p> <i> <b>${review["author"]}</b> ${review["date"]}${likeCounter}</i></p>` +
		`<p>${review["text"]}</p>` +
		"</div>";
};

function addLike(id) {
	const element = document.getElementById(id);
	let array = element.innerText.split(" ");
	let resultNum = parseInt(array[array.length - 1], 10);
	resultNum++;
	array[array.length - 1] = resultNum;
	element.innerText = array.join(" ");
}

const slides = document.querySelectorAll(".slide");
let currentSlide = 0;

function showSlide() {
	slides.forEach((slide) => (slide.style.display = "none"));
	slides[currentSlide].style.display = "block";
}

function moveSlide(direction) {
	currentSlide += direction;
	if (currentSlide < 0) currentSlide = slides.length - 1;
	if (currentSlide >= slides.length) currentSlide = 0;
	showSlide();
}
showSlide();