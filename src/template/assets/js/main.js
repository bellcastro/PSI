document.addEventListener("DOMContentLoaded", () => { 
    mountLayout();
});

function mountLayout() {
    const width = document.body.offsetWidth;
    const toggler = document.querySelector('.navbar-toggler')
    const nav = document.querySelector('#nav-bar-wrapper')
    if (toggler && nav) {
        if (width < 798) {
            toggler.style.display = 'flex'
            nav.classList.add('collapse')
            return;
        }

        toggler.style.display = 'none'
        nav.classList.remove('collapse')
    }
}

function showSuccessToast (message = 'Sua operação foi realizada!') {
    const successToast = document.querySelector('#success-toast');
    if (successToast) {
        const messageElement = successToast.querySelector('#success-message');
        if (messageElement) {
            messageElement.innerText = message;
        }
        const toast = new bootstrap.Toast(successToast)
        setTimeout(() => {
            toast.show();
            setTimeout(() => {
                toast.hide()
            }, 5000);
        }, 300);
    }
}