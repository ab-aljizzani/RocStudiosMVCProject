const burger = document.querySelector('#burger');
const menu = document.querySelector('#menu');
const sidemenu = document.querySelector('#sidemenu');
const img = document.querySelector('#portfolio');
const services = document.querySelector('#services');
const footer = document.querySelector('#footer');
const sidebar = document.querySelector('#sidebar');
const sidebarmenu = document.querySelector('#sidebarmenu');
const sp = document.querySelector("#cl2");

services.querySelectorAll('a').forEach((item) => {
    item.addEventListener("click", (event) => {
        sidebar.classList.toggle("-translate-x-full");
    })
    sp.addEventListener("click", (event) => {
        sidebar.classList.toggle("-translate-x-full");
    })
});

burger.addEventListener('click', () => {
    sidebarmenu.classList.toggle("translate-x-full");
});

sidemenu.querySelectorAll('a').forEach(function callback(item, index) {
    item.addEventListener("click", (event) => {
        var elems = sidemenu.querySelectorAll('li');
        for (var i = 0; i < elems.length; i++) {
            var elem = elems[index];
            elems[i].classList.remove('border-l-4');
            elems[i].classList.remove('border-primary');

            elem.classList.add('border-l-4');
            elem.classList.add('border-primary');
        }

    });
});

menu.querySelectorAll('a').forEach(function callback(item, index) {
    item.addEventListener("click", (event) => {
        var elems = menu.querySelectorAll('li');
        for (var i = 0; i < elems.length; i++) {
            var elem = elems[index];
            elems[i].classList.remove('border-b-4');
            elems[i].classList.remove('border-primary');

            elem.classList.add('border-b-4');
            elem.classList.add('border-primary');
        }

    });
});

footer.querySelectorAll('a').forEach(function callback(item, index) {
    item.addEventListener("click", (event) => {
        var elems = menu.querySelectorAll('li');
        for (var i = 0; i < elems.length; i++) {
            var elem = elems[index];
            elems[i].classList.remove('border-b-4');
            elems[i].classList.remove('border-primary');

            elem.classList.add('border-b-4');
            elem.classList.add('border-primary');
        }

    });
});

var port_modal = document.getElementById("myModal");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 

img.querySelectorAll('img').forEach((item) => {
    item.addEventListener("click", (event) => {

        document.getElementById("modolImg").src = item.src;
        port_modal.style.display = "block";

        // When the user clicks on <span> (x), close the modal
        span.onclick = function() {
            port_modal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function(event) {
            if (event.target == port_modal) {
                port_modal.style.display = "none";
            }
        }

    });
})