let productItems = document.querySelector(".product-item");

const formatter = new Intl.NumberFormat('es-MX', {
    style: 'currency',
    currency: 'MXN',
});

async function addProductItem() {
    let container = document.querySelector(".products-list")
    try {
        let response = await axios.post("/Orders/AddNewProduct")
        container.insertAdjacentHTML("afterbegin", response.data)
    } catch (error) {
        console.log(error)
    }
}

function calcularTotal() {
    var productos = document.querySelectorAll(".product-item")
    var subtotalSpan = document.querySelector("#subtotal-amount")
    var descuentoSpan = document.querySelector("#discount-amount")
    var totalSpan = document.querySelector("#total-amount")
    var delayTimer
    var subtotal = 0
    var descuento = 0
    var total = 0
    clearTimeout(delayTimer)
    delayTimer = setTimeout(function () {
        productos.forEach(producto => {

            var precio = producto.querySelector("#price-input").value
            var cantidad = producto.querySelector("#quantity").innerHTML

            var monto = Number(precio)*Number(cantidad)
            subtotal += monto
        })

        descuento = subtotal < 500 ? subtotal * .3 : subtotal < 1000 ? subtotal * .35 : subtotal * .4
        total = subtotal - descuento

        subtotalSpan.innerText = formatter.format(subtotal)
        descuentoSpan.innerText = "-"+formatter.format(descuento)
        totalSpan.innerText = formatter.format(total)
    }, 100);
}