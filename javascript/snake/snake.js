const canvas = document.getElementById('snake');
const ctx = canvas.getContext('2d');
const score = document.getElementById('score');

	// grid size
	const grid = 10;

	// food
	let food = {
		x: Math.floor(Math.random() * 17 + 1) * grid,
		y: Math.floor(Math.random() * 15 + 3) * grid,
		draw: () => {
			ctx.fillStyle = 'red';
			ctx.fillRect(food.x, food.y, grid - 1, grid - 1);
		}
	}

	// snake
	let snake = {
		directon: 'R',
		cells: [],
		initCells: 4,
		init: () => {
			for (let i = 0; i < snake.initCells; i++) {
				snake.cells[i] = { x: 10 * grid, y: 9 * grid };
			}
		},
		draw: () => {
			for (let i = 0; i < snake.cells.length; i++) {

				if (snake.cells[i].x > canvas.height) snake.cells[i].x = 0;
				else if (snake.cells[i].x < 0) snake.cells[i].x = canvas.height - grid;
				if (snake.cells[i].y > canvas.width) snake.cells[i].y = 0;
				else if (snake.cells[i].y < 0) snake.cells[i].y = canvas.width - grid;


				ctx.fillStyle = i === 0 ? 'purple' : 'white';
				ctx.fillRect(snake.cells[i].x, snake.cells[i].y, grid - 1, grid - 1)
			}

			let dx = snake.cells[0].x;
			let dy = snake.cells[0].y;

			if (snake.directon === 'R') dx += grid
			if (snake.directon === 'L') dx -= grid
			if (snake.directon === 'U') dy -= grid
			if (snake.directon === 'D') dy += grid

			
			if (dx == food.x && dy == food.y) {
				food.x = Math.floor(Math.random() * 29 + 1) * grid
				food.y = Math.floor(Math.random() * 27 + 3) * grid
			} else {
				snake.cells.pop();
			}

			snake.checkCollision(dx, dy);

			snake.cells.unshift({ x: dx, y: dy });
		},
		checkCollision: (dx, dy) => {
			for (var i = 0; i < snake.cells.length; i++) {
				if (dx === snake.cells[i].x && dy === snake.cells[i].y) {
					snake.cells = [];
					snake.init();
					window.alert('You just lost you fking loser.')
					score.innerHTML = `Score: 0`;
				}
			}
		}
	}

	snake.init()

	// controller
	document.addEventListener('keydown', (e) => {
		const key = e.key;
		switch (key) {
			case 'ArrowUp':
				if (snake.directon === 'D') return;
				snake.directon = 'U';
				break;
			case 'ArrowDown':
				if (snake.directon === 'U') return;
				snake.directon = 'D'
				break;
			case 'ArrowRight':
				if (snake.directon === 'L') return;
				snake.directon = 'R'
				break;
			case 'ArrowLeft':
				if (snake.directon === 'R') return;
				snake.directon = 'L'
				break;
			default:
				break;
		}
	})

	function draw() {
		score.innerText = `Score: ${snake.cells.length - 4}`
		ctx.fillStyle = 'rgb(66, 116, 77)';
		ctx.fillRect(0, 0, canvas.width, canvas.height);
		snake.draw();
		food.draw();
	}

	setInterval(draw, 1000 / 15);