export function init() {
    var content = document.querySelector('#body')
	fetch('login-page.html').then(function (response) {
		return response.text();
	}).then(function (html) {
		content.innerHTML = html;
		listen();
	});    
}


function listen() {
    const loginForm = document.getElementById("login-form");
    const loginButton = document.getElementById("login-form-submit");
    const loginErrorMsg = document.getElementById("login-error-msg");
    const registrationBtn =  document.querySelector('.registrationBtn')

    loginButton.addEventListener("click", (e) => {
        e.preventDefault();
        const email = loginForm.email.value;
        const password = loginForm.password.value;
        localStorage.setItem('user', '')
        fetch('data/users.json').then((response) => {
            return response.json();
        }).then(json => {
            console.log(json)
            let user = findUser(json, email, password)
            console.log(user)
            if(user != false) {
                loginErrorMsg.style.opacity = 0;
                localStorage.setItem('user', user["id"]);
                location.hash = '#main';
            } else {
                console.log("false")
                loginErrorMsg.style.opacity = 1;
            }
        })})
    
    registrationBtn.addEventListener("click", (e)=> {
        location.hash = "#registration"
        return false;
    })
}

function findUser(json, email, password) {
    var find = false
    json.map((userInfo,id) => { 
        if (userInfo["email"] === email && userInfo["password"] === password) {
            console.log("shemodis??")
            find = userInfo
        }
    })
    return find;
}



