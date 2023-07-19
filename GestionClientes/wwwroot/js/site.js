// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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