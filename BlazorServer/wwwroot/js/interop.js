function register() {
    const container = document.getElementById('container');
    container.classList.add("active");
}

function login() {
    const container = document.getElementById('container');
    container.classList.remove("active");
}

function dropdownProfile() {
    if (document.querySelectorAll(".icon-button-profile")[0].classList.contains(
        'active')) {
        document.querySelectorAll(".icon-button-profile")[0].classList.remove(
            'active');
    }

    document.querySelectorAll(".profiledd")[0].classList.toggle('active');
}