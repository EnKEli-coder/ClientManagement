
async function buscarOrdenes(e) {
    var listContainer = document.querySelector(".orders-view #order-list")
    var delayTimer
    var busqueda = e.target.value.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
    clearTimeout(delayTimer);
    delayTimer = setTimeout(async function () {
        let response = await axios.post("/Orders/GetOrdersList",
            {
                Busqueda: busqueda
            })
        listContainer.innerHTML = response.data;
    }, 200);
}

async function openNewOrder() {
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Orders/OpenNewOrder")
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

async function openClientNewOrder(e, id) {
    e.stopPropagation()
    let container = document.querySelector(".container")
    let modal = document.querySelector("#modal")
    try {
        let response = await axios.post("/Orders/OpenNewClientOrder", {
            ClientId: id
        })
        if (modal != null) {
            cerrarModal();
        }
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

function quantitySustract(e) {
    e.stopPropagation()
    let quantity =  e.currentTarget.closest("#quantity-controler").querySelector("#quantity")
    let value = parseInt(quantity.innerText)

    if (value > 1) {
        quantity.innerText = value - 1;
    }
    calcularTotal()

}

function quantityAdd(e) {
    let quantity = e.currentTarget.closest("#quantity-controler").querySelector("#quantity")
    let value = parseInt(quantity.innerText)
    quantity.innerText = value + 1;
    calcularTotal()
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

            var monto = Number(precio) * Number(cantidad)
            subtotal += monto
        })

        descuento = subtotal < 500 ? subtotal * .3 : subtotal < 1000 ? subtotal * .35 : subtotal * .4
        total = subtotal - descuento

        subtotalSpan.innerText = formatter.format(subtotal)
        subtotalSpan.dataset.value = subtotal
        descuentoSpan.innerText = "-" + formatter.format(descuento)
        descuentoSpan.dataset.value = descuento
        totalSpan.innerText = formatter.format(total)
        totalSpan.dataset.value = total
    }, 100);
}

async function submitOrder() {
    let inputs = document.querySelectorAll(".order-modal input")

    inputs.forEach(input => {
        input.classList.add("submitted")
    })
}

async function AddNewOrder(e) {
    e.preventDefault()
    let form = document.querySelector("#order-form")
    let folio = form.querySelector("#number-input").value
    let client = form.querySelector("#client-select").value
    let campaign = form.querySelector("#campaign-select").value
    let state = form.querySelector("#state-select").value
    let products = document.querySelectorAll(".order-modal .product-item")
    var subtotal = document.querySelector("#subtotal-amount").dataset.value
    var descuento = document.querySelector("#discount-amount").dataset.value
    var total = document.querySelector("#total-amount").dataset.value

    const pedido = {
        Folio: folio,
        IdClient: client,
        Campaign: Number(campaign),
        State: state,
        Products: []
    }

    products.forEach(product => {
        let clave = product.querySelector("#key-input").value
        let descripcion = product.querySelector("#description-input").value
        let cantidad = product.querySelector("#quantity").innerHTML
        let precio = product.querySelector("#price-input").value

        const item = {
            Key: clave,
            Description: descripcion,
            Quantity: Number(cantidad),
            Price: Number(precio)
        }

        pedido.Products.push(item)
    })

    try {
        let response = await axios.post("/Orders/AddNewOrder", {
            Folio: Number(folio),
            ClientId: Number(client),
            Campaign: Number(campaign),
            Subtotal: subtotal,
            Discount: descuento,
            Total: total,
            State: state,
            Products: pedido.Products
        })
        console.log(response)
    } catch (error) {
        console.log(error)
    }

    cerrarModal()
    await showOrdersModule();
}
async function showOrderDetails(id) {
    let container = document.querySelector(".container")
    let modal = document.querySelector("#modal")
    try {
        let response = await axios.post("/Orders/OpenOrderDetails", {
            OrderId: Number(id)
        })
        if (modal != null) {
            cerrarModal()
        }
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

async function updateOrder(e,id) {
    e.preventDefault()
    let form = document.querySelector("#order-form")
    let folio = form.querySelector("#number-input").value
    let client = form.querySelector("#client-select").value
    let campaign = form.querySelector("#campaign-select").value
    let state = form.querySelector("#state-select").value
    let products = document.querySelectorAll(".order-modal .product-item")
    var subtotal = document.querySelector("#subtotal-amount").dataset.value
    var descuento = document.querySelector("#discount-amount").dataset.value
    var total = document.querySelector("#total-amount").dataset.value

    const pedido = {
        Folio: folio,
        IdClient: client,
        Campaign: Number(campaign),
        State: state,
        Products: []
    }

    products.forEach(product => {
        let clave = product.querySelector("#key-input").value
        let descripcion = product.querySelector("#description-input").value
        let cantidad = product.querySelector("#quantity").innerHTML
        let precio = product.querySelector("#price-input").value

        const item = {
            Key: clave,
            Description: descripcion,
            Quantity: Number(cantidad),
            Price: Number(precio)
        }

        pedido.Products.push(item)
    })

    try {
        let response = await axios.post("/Orders/UpdateOrder", {
            Id: id,
            Folio: Number(folio),
            ClientId: Number(client),
            Campaign: Number(campaign),
            Subtotal: subtotal,
            Discount: descuento,
            Total: total,
            State: state,
            Products: pedido.Products
        })
        console.log(response)
    } catch (error) {
        console.log(error)
    }

    cerrarModal()
    await showOrdersModule();
}

function removeProduct(e) {
    let item = e.currentTarget.parentNode
    item.remove()
    calcularTotal()
    toggleSaveButton()
}

function toggleSaveButton() {
    let btnSave = document.querySelector("#btn-save");
    let products = document.querySelectorAll(".product-item")

    if (products.length > 0) {
        btnSave.disabled = false
    } else {
        btnSave.disabled = true
    }
}

async function deleteOrder(e, id) {
    e.stopPropagation()
    let li = e.currentTarget.parentNode
    try {
        const response = await axios.post("/Orders/DeleteOrder", {
            OrderId: id
        })
        
        li.parentNode.removeChild(li)
    } catch (error) {
        console.log(error)
    }
}