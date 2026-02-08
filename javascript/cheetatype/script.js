const text = document.querySelector(".text");
const generateNew = document.querySelector("#new");
const inputHandler = document.querySelector("#inputText");
text.textContent = "";
let timeStart;
let interval;
let currentWordIndex;
let currnetLetterIndex;
let currentWord;
let words;
generateNew.addEventListener("click", () => {
	generate();
});

generate();

inputHandler.addEventListener("keydown", (e) => {
	// if (!timeStart) interval = setTimeout(() => {
	// 	finishRace(currentWordIndex, timeStart, interval);
	// }, 60_000);
	timeStart ??= Date.now();
	let word = inputHandler.value;
	const isSpace = e.code === "Space";
	const isBackspace = e.code === "Backspace";
	const correctWord = currentWord.getAttribute("word");
	if (!isLetter(e.keyCode) && !isSpace && !isBackspace) {
		e.preventDefault();
		return;
	}

	if (isSpace) {
		if (correctWord === inputHandler.value) {
			e.preventDefault();
			currentWordIndex += 1;
			currnetLetterIndex = 0;
			inputHandler.value = "";
			currentWord = getWord(currentWordIndex);
			if (currentWordIndex === words.length) {
				inputHandler.setAttribute("disabled", "");
				finishRace(currentWordIndex, timeStart, interval);
			}
			return;
		}
	}

	if (isBackspace) {
		if (currnetLetterIndex > 0) currnetLetterIndex -= 1;
		const letter = getLetter(currentWord, currnetLetterIndex);
		letter.classList.remove("correct", "error");
	} else if (inputHandler.value.length >= correctWord.length) {
		e.preventDefault();
		return;
	} else {
		if (!e.ctrlKey) word += e.key;
		const letter = getLetter(currentWord, currnetLetterIndex);
		console.log(letter.textContent, word);
		console.log(letter.textContent.length, word.length);
		if (letter.textContent === word[currnetLetterIndex]) {
			letter.classList.add("correct");
		} else {
			letter.classList.add("error");
		}
		currnetLetterIndex += 1;
	}
});

async function generate() {
	inputHandler.removeAttribute("disabled");
	const text = document.querySelector(".text");
	text.textContent = "";
	const corpose = await generateAIText();

	setStatsHTML(getAvgWPM(), 0);

	words = corpose.split(" ");
	const wordNodes = [];
	words.forEach((w, iw) => {
		const letterNodes = [];
		const div = document.createElement("div");
		div.style.display = "inline-block";
		div.classList.add("word");
		div.setAttribute("wordIndex", iw);
		div.setAttribute("word", w);
		w.split("").forEach((l, il) => {
			const span = document.createElement("span");
			span.setAttribute("letterIndex", il);

			span.textContent = l;

			letterNodes.push(span);
		});
		div.append(...letterNodes);
		wordNodes.push(div);
	});

	text.append(...wordNodes);

	currentWordIndex = 0;
	currnetLetterIndex = 0;
	currentWord = getWord(currentWordIndex);
}

function isLetter(keyCode) {
	if ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 127)) {
		return true;
	}
	return false;
}

function getLetter(word, letterIndex) {
	return word.querySelector(`[letterindex="${letterIndex}"]`);
}

function getWord(wordIndex) {
	return document.querySelector(`[wordindex="${wordIndex}"]`);
}

function finishRace(enteredWords, start, interval) {
	clearInterval(interval);
	const milliElapsedTime = Date.now() - start;
	const secondsElapsedTime = Math.floor(milliElapsedTime / 1000);
	const wpm = Math.floor((enteredWords / secondsElapsedTime) * 60);
	generateNew.removeAttribute("hidden");
	console.log("Well Done! You've a WPM of", wpm);
	setAvgWPM(wpm);
	setStatsHTML(getAvgWPM(), wpm);
	timeStart = null;
}

function getTotalRounds() {
	return Number.parseInt(localStorage.getItem("rounds")) || 0;
}

function incrementTotalRounds() {
	const totalRounds = getTotalRounds();
	return localStorage.setItem("rounds", totalRounds + 1);
}

function getAvgWPM() {
	return Number.parseInt(localStorage.getItem("avg")) || 0;
}

function setAvgWPM(wpm) {
	incrementTotalRounds();
	const avgWPM = (getAvgWPM() + wpm) / getTotalRounds();
	localStorage.setItem("avg", avgWPM);
}

function setStatsHTML(avgWPMVal, roundWPMVal) {
	const roundWPM = document.querySelector("#roundWPM");
	const avgWPM = document.querySelector("#avgWPM");
	roundWPM.textContent = roundWPMVal;
	avgWPM.textContent = avgWPMVal;
}

async function generateAIText() {
	const data = await fetch("https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent", {
		headers: {
			"Content-Type": "application/json",
			"X-goog-api-key": "AIzaSyAoqWgwJO-hGaPxkqlF-UhbLRZwOgxiCWs",
		},
		body: JSON.stringify({
			contents: [
				{
					parts: [
						{
							text: "Generate one paragraph for my type race web application with the difficulty level of 'easy'. The length of text shall not exceed 300 characters and shall not contain special characters or break characters or periods. Don't include any text that has relevance with typing, it shall be random. Respond with the paragraph straightforwardly."
						}
					]
				}
			]
		}),
		method: "POST"
	});

	if (!data.ok) {
		throw new Error("Failed to fetch AI text");
	}

	const json = await data.json();

	const text = json["candidates"][0]["content"]["parts"][0]["text"];
	return text;
}
