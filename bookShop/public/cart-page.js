export function init() {
    console.log(localStorage.getItem('user'))
    var content = document.querySelector('#body')
	fetch('cart-page.html').then(function (response) {
        console.log(response)
		return response.text();
	}).then(function (html) {
        content.innerHTML = html;
        var contentForRender = document.getElementById('bookItems')
        render(contentForRender);
        //listen(contentForRender)
	}); 
}

function detailsClick(e) {
   
    console.log(e.target.id)
    var id = e.target.id

    location.href = "#details?id=" + id
}

function render(contentForRender) { 
    fetch('data/cart.json').then((response) => {
        return response.json();
    }).then(json => {
        console.log(json)
        let component = json.map((bookInfo,id) => { 
            console.log(bookInfo["category"])
            var bookImagesrc = "./assets/images/bookImages/" + bookInfo["imageName"]
            return `
            <div class="column">
                <div class="card">
                    <img src="${bookImagesrc}" style="width:100%">
                    <h3>${bookInfo["name"]}</h3>
                    <p class="price">$${bookInfo["price"]}</p>
                    <p><button id="${bookInfo["id"]}" value="${bookInfo["id"]}">View Details</button></p>
                </div>
            </div>
            `
        }).join('')
        contentForRender.innerHTML = `
        <div class="row">
            ${component}
        </div>
        `;
            
        })
    }




