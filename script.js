const ROOT_URL = "https://api.github.com";
const USERS_ENDPOINT = "users";
const REPOS_ENDPOINT = "repos";
const CACHE_TIME_LIMIT = 86400000; // 1 day
const username = "iiabady";
const reponame = "dump";

function setCache(projectsHtmlContent, description) {
	localStorage.setItem("data", JSON.stringify({
		projects: projectsHtmlContent,
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
	const projects = new Map();
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
		projects.set(language.name, languageProjectsData)
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

function createProjectHTML(project) {
	
}



(async () => {
	const cachedData = checkCahce();
	console.log();
	if (Date.now() < cachedData?.expire) {
		setDescription(cachedData.description);
		const projectsContainer = document.querySelector('.projects');
		projectsContainer.innerHTML = cachedData.projects;
		return;
	}
	const user = await getUser(username);
	const { description, contents_url } = await getRepo(reponame, username);
	const repoContents = await getRepoContents(contents_url);
	const languages = await getLanguages(repoContents);
	const projects = await getProjects(languages);
	let htmlContent = '';
	for (const [lang, langProjects] of projects) {
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
	setDescription(description);
	const projectsContainer = document.querySelector('.projects');
	projectsContainer.innerHTML = htmlContent;
	setCache(htmlContent, description);
})()