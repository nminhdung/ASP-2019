function getTotal() {
    var total = 0;
    const lstTr = document.querySelectorAll(".product")
    for (let i = 0; i < lstTr.length; i++) {
        let price = (Number(lstTr[i].querySelector(".price").dataset.value));
        let quantity = (Number(lstTr[i].querySelector(".quantity").value));
        let sum = price * quantity;
        total += sum;
    }

    const p = document.querySelector("#card-product");
    p.children[2].querySelector("strong").innerHTML =
        total.toLocaleString('en-US', { style: 'currency', currency: 'VND' });
    
}