const burger = document.querySelector('#burger');
const sidebar = document.querySelector('#sidebar');
const menu = document.querySelector('#menu');

burger.addEventListener('click', () => {
    sidebar.classList.toggle("-translate-x-full");

})

menu.querySelectorAll('a').forEach((item) => {
    item.addEventListener("click", (event) => {
        menu.querySelectorAll('a').forEach((item) => {
            if (item.classList.contains('border-r-4')) {
                item.classList.remove('border-r-4');
                item.classList.add('rounded');
            }
        });
        if (item.classList.contains('border-r-4')) {
            item.classList.remove('border-r-4');
            item.classList.add('rounded');
        } else {
            item.classList.add('border-r-4');
            item.classList.add('border-secodary');
            item.classList.remove('rounded');
        }
    });
});

