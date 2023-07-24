
async function openClientInfo(event) {
    let clientId = parseInt(event.currentTarget.id)
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Clients/ClientInfo", {
            clientId:clientId
        }, {
            header: { "Content-Type": "application/json"}
        })
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

async function renderClientsDetails(clientId) {
    let modalContent = document.querySelector(".client-info-modal .content")
    try {
        let response = await axios.post("/Clients/ClientDetails", {
            clientId: clientId
        }, {
            header: { "Content-Type": "application/json" }
        })
        modalContent.innerHTML = response.data
    } catch (error) {
        console.log(error)
    }
}

async function allowEdit() {
    let form = document.querySelector("#client-info-form")
    let formfields = form.getElementsByClassName('client-form-field')
    for (var i = 0; i < formfields.length; i++) {
        formfields[i].disabled = false;
    }
    form.classList.add("editable")
}

async function updateClient(clientId) {
    let form = document.querySelector("#client-info-form")
    let name = form.querySelector("#name-input").value
    let consultantId = form.querySelector("#number-input").value
    let consultantType = form.querySelector("#type-select").value
    let address = form.querySelector("#direction-input").value
    let email = form.querySelector("#email-input").value
    let password = form.querySelector("#password-input").value
    let telephone = form.querySelector("#phone-input").value
    let observations = form.querySelector("#observations-textarea").value

    let response = await axios.post("/Clients/UpdateClient", {
        ID: clientId,
        ConsultantID: consultantId,
        Name: name,
        ConsultantType: consultantType,
        Telephone: telephone,
        Email: email,
        Address: address,
        Password: password,
        Observations: observations 
    }, {
        header: { "Content-Type": "application/json" }
    })

    cerrarModal()
    showClientsModule()
}

async function cancelEdit(clientId) {
    await renderClientsDetails(clientId)
}

async function openNewModal() {
    let container = document.querySelector(".container")

    try {
        let response = await axios.post("/Clients/OpenNewClient")
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
} 