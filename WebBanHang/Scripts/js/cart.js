
var lstTr = document.querySelectorAll(".product")
function getTotal() {
    let total = 0;
    for (let i = 0; i < lstTr.length; i++) {
        let price = (Number(lstTr[i].querySelector(".price").dataset.value));
        let quantity = (Number(lstTr[i].querySelector(".quantity").value));
        if (quantity < 1) {
            lstTr[i].querySelector(".quantity").value = 1;
            quantity = 1;
        }
        let sum = price * quantity;
        total += sum;
    }

    const p = document.querySelector("#card-product");
    p.children[2].querySelector("strong").innerHTML =
        total.toLocaleString('en-US', { style: 'currency', currency: 'VND' });

}
function change(id, quantity, onSuccess) {

    $.ajax({
        type: "POST",
        url: '/Cart/ChangeQuantity',
        data: JSON.stringify({ id, quantity }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            console.log(result)
            onSuccess();
        }
        ,
        error: function (e) {
            console.log(e);
            Toast("Error", "Lỗi khi thêm sản phẩm", "Thông báo");
        }
    });
}
for (let i = 0; i < lstTr.length; i++) {
    let quantityInput = lstTr[i].querySelector('.quantity');
    let Id = Number(lstTr[i].querySelector(".productid").value);

    quantityInput.onchange = (e) => {
        let quantity = Number(e.target.value);
        if (quantity < 1) {
            quantityInput.value = 1;
            quantity = 1;
        }
        change(Id, quantity, getTotal);
    };
}