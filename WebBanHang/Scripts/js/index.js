
const toastContainer = document.createElement("div");
toastContainer.style.position="absolute";
toastContainer.style.top='25%';
toastContainer.style.right='0';


toastContainer.style.zIndex='99999';
document.body.appendChild(toastContainer);
function initToast(type,message,title){
	const div = document.createElement("div");
	div.classList.add("toast","fade","show");
	div.setAttribute("role","alert");
	div.setAttribute("aria-label","assertive");
	div.setAttribute("aria-atomic","true");
     function handleClose(){
		toastContainer.removeChild(div)
	}
	setTimeout(()=>{
			handleClose();
	},3000)
	div.innerHTML=`
   <div class="toast-header">
    <i class="fas fa-bell mr-3"></i>
    <strong class="me-auto">${title != "" ? title : "Thông báo:"}</strong>
    <small></small>
    <button type="button" class="btn-close btn" data-bs-dismiss="toast" aria-label="Close" onclick="handleClose()">
    <i class="fa fa-times"></i>
    </button>
  </div>
  <div class="toast-body">
    ${message}
  </div>`
  return div;
}

function Toast(type,message,title){
	const div = initToast(type,message,title);
	toastContainer.appendChild(div);
	
}