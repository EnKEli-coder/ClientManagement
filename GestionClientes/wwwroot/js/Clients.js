
async function openClientInfo(event) {
    let clientId = parseInt(event.currentTarget.id);
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Clients/ClientInfo",{
            clientId: clientId
        })
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error);
    }
}