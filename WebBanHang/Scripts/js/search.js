
const form = document.querySelector(".search-header");
const selectGr = document.querySelector(".custom-select");
selectGr.onchange = function(e) {
	form.action = e.target.value;
}
console.log(form.action)
console.log(selectGr.value)