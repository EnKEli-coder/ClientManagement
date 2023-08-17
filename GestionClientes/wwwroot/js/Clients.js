
async function buscarClientes(e) {
    var listContainer = document.querySelector(".clients-view #list-frame")
    var delayTimer
    var busqueda = e.target.value.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
    clearTimeout(delayTimer);
    delayTimer = setTimeout(function () {
        let response = await axios.post("/Clients/GetClientsList",
            {
                busqueda
            })
        listContainer.innerHTML = response.data;
    }, 200);
}
async function openClientInfo(clientId) {
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Clients/ClientModalDetails", {
            clientId:clientId
        }, {
            header: { "Content-Type": "application/json"}
        })
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

async function renderClientDetails(clientId) {
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

async function updateClient(clientId, e) {
    e.preventDefault();
    let form = document.querySelector("#client-info-form")
    let name = form.querySelector("#name-input").value
    let consultantId = form.querySelector("#number-input").value
    let consultantType = form.querySelector("#type-select").value
    let address = form.querySelector("#direction-input").value
    let email = form.querySelector("#email-input").value
    let password = form.querySelector("#password-input").value
    let telephone = form.querySelector("#phone-input").value
    let observations = form.querySelector("#observations-textarea").value
    try {
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
    } catch (error) {
        console.log(error);
    }
    cerrarModal()
    await showClientsModule()
}

async function cancelEdit(clientId) {
    await renderClientDetails(clientId)
}

async function openNewClient() {
    let container = document.querySelector(".container")

    try {
        let response = await axios.post("/Clients/OpenNewClient")
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
} 

async function addSubmittedState() {
    let form = document.querySelector("#client-info-form")
    let inputs = form.querySelectorAll("input, select, textarea")

    inputs.forEach(input => {
        input.classList.add("submitted")
    })
}

async function saveNewClient(e) { 
    e.preventDefault()
    let form = document.querySelector("#client-info-form")
    let name = form.querySelector("#name-input").value
    let consultantId = form.querySelector("#number-input").value
    let consultantType = form.querySelector("#type-select").value
    let address = form.querySelector("#direction-input").value
    let email = form.querySelector("#email-input").value
    let password = form.querySelector("#password-input").value
    let telephone = form.querySelector("#phone-input").value
    let observations = form.querySelector("#observations-textarea").value

    let response = await axios.post("/Clients/SaveNewClient", {
        ID: 0,
        ConsultantID: consultantId == "" ? null : consultantId,
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
    await showClientsModule()
}

async function openClientHistory(clientId, clientName, e) {
    e.stopPropagation()
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Clients/ClientModalOrders", {
            ClientId: clientId,
            ClientName: clientName
        }, {
            header: { "Content-Type": "application/json" }
        })
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

async function renderClientOrders(clientId, clientName) {
    let modalContent = document.querySelector(".client-info-modal .content")
    try {
        let response = await axios.post("/Clients/ClientOrders", {
            ClientId: clientId,
            ClientName: clientName
        }, {
            header: { "Content-Type": "application/json" }
        })
        modalContent.innerHTML = response.data
    } catch (error) {
        console.log(error)
    }
}