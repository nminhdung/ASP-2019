(function () {
	const links = document.querySelectorAll(".main-sidebar .nav-link");
	Array.from(links).forEach(function (item, index) {
		if (item.href.toLowerCase() == window.location.href.toLowerCase()) {
			item.classList.add("active");
		}
	})
}());
(function () {
	const inputImage = document.querySelector("[name='ImageUpload']");
	const image = document.querySelector("#avatar-source");
	inputImage.oninput = function(e) {
		if (e.target.files.length > 0) {
			const render = new FileReader();
			render.readAsDataURL(e.target.files[0]);
			render.onload = function (event) {
				image.src = event.target.result;
            }
        } 
    }
}());