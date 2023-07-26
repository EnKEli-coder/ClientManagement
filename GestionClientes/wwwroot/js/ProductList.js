let productItems = document.querySelector(".product-item");

//productItems.foreach(item => {
//    item.addEventListener('Focus', function handleFocus(event) {
//        itemFocus(event)
//    })
//})


function itemFocus(e) {
    let item = e.currentTarget.closest(".product-item")
    if (item != null) {
       
    }
}

function itemBlur(e) {
    if (!e.currentTarget.contains(e.relatedTarget) || e.relatedTarget === null) {
        console.log("Fuera de elemento")
    }
}