document.addEventListener("DOMContentLoaded", () => { 
    mountLayout();
    setAxios();
});

function setAxios() {
    axios.defaults.headers.post['RequestVerificationToken'] = $('[name="__RequestVerificationToken"]').val();
    axios.defaults.headers.put['RequestVerificationToken'] = $('[name="__RequestVerificationToken"]').val();
}

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

function showErrorToast(message = 'Ocorreu um erro inesperado') {
    const successToast = document.querySelector('#error-toast');
    if (successToast) {
        const messageElement = successToast.querySelector('#error-message');
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