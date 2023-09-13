let emailInput = document.querySelector('.collbtm form label input');
let emailDiv = document.querySelector('.collbtm form label div');
let emailBtn = document.querySelector('.collbtm form label button');
emailInput.addEventListener('click', function(){
    emailDiv.style.transform = 'translate(0px, calc((50% - 9px) - 11px)) scale(0.75)';
    emailDiv.style.transition = 'transform 0.2s ease';
})
emailInput.addEventListener('input', function(){
    if(emailInput.value !== ''){
        emailBtn.classList.remove('d-none');
    }
    else{
        emailBtn.classList.add('d-none');
    }
})
document.addEventListener('click', (e) => {
    if (e.target !== emailInput && emailInput.value == '') {
        emailDiv.style.transform = 'translate(0px, calc(50% - 11px)) scale(1)';
        emailDiv.style.transition = 'transform 0.2s ease';
    }
})