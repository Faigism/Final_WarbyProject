let quiztext1 = document.querySelector('.textall .text1');
let quiztext2 = document.querySelector('.textall .text2');
function toggleTestimonials(){
    if (quiztext2.classList.contains("invisible")) {
        quiztext2.classList.remove('invisible');
        quiztext2.style.right = '0px';
        quiztext1.classList.add('invisible');
        quiztext1.style.right = '-100px';
    } 
    else{
        quiztext2.classList.add('invisible');
        quiztext2.style.right = '-100px';
        quiztext1.classList.remove('invisible');
        quiztext1.style.right = '0px';
    }
}
setInterval(toggleTestimonials, 4000);
