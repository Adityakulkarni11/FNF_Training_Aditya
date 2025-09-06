function validateForm() {
    let messages = [];

    const username = document.getElementById("username").value.trim();
    const pin = document.getElementById("pin").value.trim();
    const state = document.getElementById("states").value;
    const validatePin = document.getElementById("validatePin").checked;
    //const testMe = document.getElementById("testMe").checked;
    const milk = document.getElementById("milk").checked;
    const butter = document.getElementById("butter").checked;
    const cheese = document.getElementById("cheese").checked;

    if (username.length < 6 || username.length > 8) {
        messages.push("Username not validated");
    }

    const hasLetters = /[a-zA-Z]/.test(pin);
    const hasNumbers = /[0-9]/.test(pin);
    if (validatePin && pin === "") {
        messages.push("Pin not validated (required)");
    } else if (pin !== "" && !(hasLetters && hasNumbers)) {
        messages.push("Pin not validated (must contain both letters and numbers)");
    }


    if (state === "") {
        messages.push("State not validated");
    }

    //messages.push("Test me is " + (testMe ? "checked" : "unchecked"));

    if (!(milk || butter || cheese)) {
        messages.push("Radio button not validated");
    }

    const output = document.getElementById("message");
    output.innerHTML = messages.length > 0 ? messages.join("<br>") : "Form validated successfully!";
    return false; 
}


