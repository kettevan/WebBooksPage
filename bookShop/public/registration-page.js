export function init() {
  var content = document.querySelector('#body')
	fetch('registration-page.html').then(function (response) {
		return response.text();
	}).then(function (html) {
    content.innerHTML = html;
    listen()
	});    
}
var uniqId = 100000

function listen() {


  const registerForm = document.getElementById("registration-form");
  const registerButton = document.getElementById("regisrtation-form-submit");

  var modal = document.getElementById("myModal");

  var span = document.getElementsByClassName("close")[0];


  span.onclick = function() {
    modal.style.display = "none";
  }

  window.onclick = function(event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }

  registerButton.addEventListener("click", (e) => {
      e.preventDefault();
      const firstName = registerForm.firstName.value;
      const lastName  = registerForm.lastName.value;
      const email = registerForm.email.value;
      const password = registerForm.password.value;
      localStorage.setItem('user', '')
      fetch('data/users.json').then((response) => {
        return response.json();
        }).then(json => {
            console.log(json)
            let user = findUser(json, email, password)
            if (user != false) {
              modal.style.display = "block";
            } else {
              console.log("add new user")
              var userId = uniqId
              var newUser = {
                firstName: firstName,
                email: email,
                id: userId.toString(),
                password: password,
                lastName: lastName
              }
              // var fs = require('fs');
              // // fs.writeFile('./data/users.json', json, 'utf8', callback);
              // fs.readFile('./data/users.json', 'utf8', function readFileCallback(err, data){
              //  if (err){
              //       console.log(err);
              //   } else {
              //     json.push(newUser)
              //     var data = JSON.stringify(json)
              //     console.log(data)
              //   }
              // })
           // }});
              console.log(newUser)
              localStorage.setItem('user', uniqId)
              uniqId = uniqId + 1
              location.hash = "#main"
            }})
          })
        }

function findUser(json, email, password) {
  var find = false
  json.map((userInfo,id) => { 
      if (userInfo["email"] === email) {
          find = userInfo
      }
  })
  return find;
}