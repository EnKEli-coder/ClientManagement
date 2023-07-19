
async function showClientsModule() {
    try {
        let main = document.querySelector(".main");
        let response = await axios.post("/Clients/ClientsView")
        main.innerHTML = response.data;
    } catch (error) {
        console.log(error);
    }
}

async function showOrdersModule() {
    try {
        let main = document.querySelector(".main");
        let response = await axios.post("/Orders/OrdersView")
        main.innerHTML = response.data;
    } catch (error) {
        console.log(error);
    }
}

function cerrarModal() {
    var container = document.querySelector(".container");
    var modal = document.querySelector(".modal");

    modal.innerHTML = "";
    container.removeChild(modal);
}