const validateText = (event) => {
    if (event.target.value.length > 2)
        document.querySelector(`[data-valmsg-for ="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for ="${event.target.id}"]`).innerHTML ="Invalid text length"
}

const validateEmail = (event) => {
    const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2}$/
    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for ="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for ="${event.target.id}"]`).innerHTML = "Invalid e-mail"
}

const validatePassword = (event) => {
    const regEx = /^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$/
    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for ="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for ="${event.target.id}"]`).innerHTML = "Invalid e-mail"
}
 