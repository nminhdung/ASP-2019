(function () {
 const links= document.querySelectorAll(".main-sidebar .nav-link");
 Array.from(links).forEach(function(item,index){
	if(item.href.toLowerCase()== window.location.href.toLowerCase()){
		item.classList.add("active");
	}
  })	
}())