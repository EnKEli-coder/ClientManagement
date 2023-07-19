
async function openClientInfo() {
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Clients/ClientInfo")
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error);
    }
}