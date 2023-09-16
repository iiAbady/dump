const ROOT_URL = "https://api.github.com";
const USERS_ENDPOINT = "users";
const REPOS_ENDPOINT = "repos";
const CACHE_TIME_LIMIT = 86400000; // 1 day
const username = "iiabady";
const reponame = "dump";
const inputElement = document.querySelector('input#query');



function setCache(projects, description) {
	localStorage.setItem("data", JSON.stringify({
		projects: JSON.stringify(projects),
		description,
		expire: Date.now() + CACHE_TIME_LIMIT
	}));
}

function checkCahce() {
	return JSON.parse(localStorage.getItem("data"));
}

async function getUser(username) {
	const response = await fetchResource(`${USERS_ENDPOINT}/${username}`);
	const userData = await getResourceData(response);
	return userData;
}

async function getRepo(reponame, username) {
	const response = await fetchResource(`${REPOS_ENDPOINT}/${username}/${reponame}`);
	const repoData = await getResourceData(response);
	return repoData;
}

async function getRepoContents(contentsUrl) {
	contentsUrl = contentsUrl.replace(/{.*?}/g, "");
	const repoContentsResponse = await fetch(contentsUrl);
	const repoContentsData = await repoContentsResponse.json();
	return repoContentsData;
}

function getLanguages(repoContents) {
	return repoContents.filter(lang => lang.size === 0);
}

async function getProjects(languages) {
	const projects = {};
	for (const language of languages) {
		const languageProjectsResponse = await fetch(language.url);
		const languageProjectsData = await getResourceData(languageProjectsResponse);
		for (const [index, folderProject] of languageProjectsData.filter(project => project.size === 0).entries()) {
			try {
			const readmeProjectResponse = await fetch(`${(folderProject.url).replace(/\?ref=main/, '')}/README.md?ref=main`)
			const readmeProjectData = await readmeProjectResponse.json();
			languageProjectsData[index].readme = atob(readmeProjectData.content);
			} catch (error) {
				console.error("README doesn't exits.");
			}
		}
		projects[language.name] = languageProjectsData;
	}
	return projects;
}

async function fetchResource(endpoint) {
	const response = await fetch(`${ROOT_URL}/${endpoint}`);
	return response;
}

async function getResourceData(response) {
	const resourceData = await response.json();
	return resourceData;
}


function setDescription(description) {
	const paragraph = document.querySelector('p.description');
	paragraph.textContent = description;
}

function createHtmlContent(projects) {
	let htmlContent = '';
	for (const [lang, langProjects] of Object.entries(projects)) {
		for (const project of langProjects) {
				htmlContent += `
			<div class="project">
			<div class="tag">${lang}</div>
			<h3>Title: <span>${project.name}</span></h3>
			<h3>Description: <span>${project.readme ?? "N/A"}</span></h3>
			<h3>Link: <a href="${project.html_url}">Click Here</a></h3>
			</div>
		`
		}
	}
	return htmlContent;
}

function setProjects(htmlContent) {
	const projectsContainer = document.querySelector('.projects');
	projectsContainer.innerHTML = htmlContent;
}

function filterProjects(query) {
	/*I know this is very shitty way to do filtering,
	but I thought I had to make the code look as dump as possible ;')
	*/ 
	const { projects } = checkCahce();
	if (!projects) return;
	const parsedProjects = JSON.parse(projects);
	if (query === '') return parsedProjects;
	const filteredProjects = {};
	for (const langProject in parsedProjects) {
		const langFilteredProjects = [];
		for (const project of parsedProjects[langProject]) {
			if (project.name.toLowerCase().includes(query.toLowerCase()))
				langFilteredProjects.push(project);
		}
		filteredProjects[langProject] = langFilteredProjects;
	}
	return filteredProjects;
}



function searchProjects(e) {
	const {target: { value: query }} = e;
	const filteredProjects = filterProjects(query);
	const htmlContent = createHtmlContent(filteredProjects);
	setProjects(htmlContent);
}

inputElement.addEventListener("input", searchProjects);


(async () => {
	const cachedData = checkCahce();
	if (Date.now() < cachedData?.expire) {
		setDescription(cachedData.description);
		const parsedProjects = JSON.parse(cachedData.projects);
		const htmlContent = createHtmlContent(parsedProjects);
		setProjects(htmlContent);
		return;
	}
	const user = await getUser(username);
	const { description, contents_url } = await getRepo(reponame, username);
	const repoContents = await getRepoContents(contents_url);
	const languages = await getLanguages(repoContents);
	const projects = await getProjects(languages);
	const htmlContent = createHtmlContent(projects);
	setDescription(description);
	const projectsContainer = document.querySelector('.projects');
	projectsContainer.innerHTML = htmlContent;
	setCache(projects, description);
})()