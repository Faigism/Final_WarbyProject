let burgermenu = document.querySelector('.mobile-top-header .mobile-top-menu div');
let menusec = document.querySelector('.mobile-burgermenu');
let menuclose = document.querySelector('.menu-hdr .in6button');

let menutryon = document.querySelector('.menubg1');
let menueyeglasses = document.querySelector('.menubg2');
let menusunglasses = document.querySelector('.menubg3');
let menucontacts = document.querySelector('.menubg4');
let menuaccessories = document.querySelector('.menubg5');
let menuprescription = document.querySelector('.menubg6');

let menudiv1 = document.querySelector('.menubg1 .menubgdiv');
let menudiv2 = document.querySelector('.menubg1 .menudiv');
let menu2div1 = document.querySelector('.menubg2 .menubgdiv');
let menu2div2 = document.querySelector('.menubg2 .menudiv');
let menu3div1 = document.querySelector('.menubg3 .menubgdiv');
let menu3div2 = document.querySelector('.menubg3 .menudiv');
let menu4div1 = document.querySelector('.menubg4 .menubgdiv');
let menu4div2 = document.querySelector('.menubg4 .menudiv');
let menu5div1 = document.querySelector('.menubg5 .menubgdiv');
let menu5div2 = document.querySelector('.menubg5 .menudiv');
let menu6div1 = document.querySelector('.menubg6 .menubgdiv');
let menu6div2 = document.querySelector('.menubg6 .menudiv');
const allMenuDivs = [menudiv1, menudiv2, menu2div1, menu2div2, menu3div1, menu3div2, menu4div1, menu4div2, menu5div1, menu5div2, menu6div1, menu6div2];
let item1 = document.querySelectorAll('.menu');
let menudivspan = document.querySelector('.menubg1 .bgspan');
let menu2divspan = document.querySelector('.menubg2 .bgspan');
let menu3divspan = document.querySelector('.menubg3 .bgspan');
let menu4divspan = document.querySelector('.menubg4 .bgspan');
let menu5divspan = document.querySelector('.menubg5 .bgspan');
let menu6divspan = document.querySelector('.menubg6 .bgspan');
const menuDivSpans = [menudivspan, menu2divspan, menu3divspan, menu4divspan, menu5divspan, menu6divspan];
let menubtn = document.querySelector('.bgbtn1');
let menubtn2 = document.querySelector('.bgbtn2');
let menubtn3 = document.querySelector('.bgbtn3');
let menubtn4 = document.querySelector('.bgbtn4');
const menuBtns = [menubtn, menubtn2, menubtn3, menubtn4];
function hideDivs(elements) {
    elements.forEach(element => element.classList.add('d-none'));
}

function showSpans(spans) {
    spans.forEach(span => span.classList.remove('d-none'));
}

function toggleButtons(buttons, shouldHide) {
    buttons.forEach(button => button.classList.toggle('d-none', shouldHide));
}

burgermenu.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    menusec.classList.remove('d-none');
    if (!menusec.classList.contains('d-none')) {
        document.body.style.overflow = 'hidden';
    }
    item1.forEach(item => {
        item.addEventListener('click', ()=>{
            if (item.classList.contains('menubg1')) {
                hideDivs([menu2div1, menu2div2, menu3div1, menu3div2, menu4div1, menu4div2, menu5div1, menu5div2, menu6div1, menu6div2]);
                showSpans([menu2divspan, menu3divspan, menu4divspan, menu5divspan, menu6divspan]);
            } else if (item.classList.contains('menubg2')) {
                hideDivs([menudiv1, menudiv2, menu3div1, menu3div2, menu4div1, menu4div2, menu5div1, menu5div2, menu6div1, menu6div2]);
                showSpans([menudivspan, menu3divspan, menu4divspan, menu5divspan, menu6divspan]);
                toggleButtons([menubtn3, menubtn4], true);
                toggleButtons([menubtn, menubtn2], false);
            } else if (item.classList.contains('menubg3')) {
                hideDivs([menudiv1, menudiv2, menu2div1, menu2div2, menu4div1, menu4div2, menu5div1, menu5div2, menu6div1, menu6div2]);
                showSpans([menudivspan, menu2divspan, menu4divspan, menu5divspan, menu6divspan]);
                toggleButtons([menubtn3, menubtn4], true);
                toggleButtons([menubtn, menubtn2], false);
            } else if (item.classList.contains('menubg4')) {
                hideDivs([menudiv1, menudiv2, menu2div1, menu2div2, menu3div1, menu3div2, menu5div1, menu5div2, menu6div1, menu6div2]);
                showSpans([menudivspan, menu2divspan, menu3divspan, menu5divspan, menu6divspan]);
                toggleButtons([menubtn3, menubtn4], true);
                toggleButtons([menubtn, menubtn2], false);
            } else if (item.classList.contains('menubg5')) {
                hideDivs([menudiv1, menudiv2, menu2div1, menu2div2, menu3div1, menu3div2, menu4div1, menu4div2, menu6div1, menu6div2]);
                showSpans([menudivspan, menu2divspan, menu3divspan, menu4divspan, menu6divspan]);
                toggleButtons([menubtn3, menubtn4], true);
                toggleButtons([menubtn, menubtn2], false);
            }
            else{
                hideDivs([menudiv1, menudiv2, menu2div1, menu2div2, menu3div1, menu3div2, menu4div1, menu4div2, menu5div1, menu5div2]);
                showSpans([menudivspan, menu2divspan, menu3divspan, menu4divspan, menu5divspan]);
                toggleButtons([menubtn3, menubtn4], true);
                toggleButtons([menubtn, menubtn2], false);
            }
        })
    });
    menuclose.onclick = function () {
        menusec.classList.add('d-none');
        menuDivSpans.forEach(span => span.classList.remove('d-none'));
        toggleButtons([menubtn3, menubtn4], true);
        toggleButtons([menubtn, menubtn2], false);
        allMenuDivs.forEach(div => div.classList.add('d-none'));
        if (menusec.classList.contains('d-none')) {
            document.body.style.overflow = 'auto';
        }
    }
    document.addEventListener('click', (e) => {
        const target = e.target;
        if (menusec.contains(target)) {
            menuDivSpans.forEach(span => span.classList.remove('d-none'));
            toggleButtons([menubtn3, menubtn4], true);
            toggleButtons([menubtn, menubtn2], false);
            allMenuDivs.forEach(div => div.classList.add('d-none'));
        }
    })
})

menutryon.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();

    menudiv1.classList.remove('d-none');
    menudiv2.classList.remove('d-none');
    menudivspan.classList.add('d-none');
    menubtn.onclick = function () {
        menubtn.classList.add('d-none');
        menubtn2.classList.add('d-none');
        menubtn3.classList.remove('d-none');
        menubtn4.classList.remove('d-none');
    }
    menubtn2.onclick = function () {
        menubtn.classList.add('d-none');
        menubtn2.classList.add('d-none');
        menubtn3.classList.remove('d-none');
        menubtn4.classList.remove('d-none');
    }
})
menueyeglasses.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    menu2div1.classList.remove('d-none');
    menu2div2.classList.remove('d-none');
    menu2divspan.classList.add('d-none');
})
menusunglasses.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    menu3div1.classList.remove('d-none');
    menu3div2.classList.remove('d-none');
    menu3divspan.classList.add('d-none');
})
menucontacts.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    menu4div1.classList.remove('d-none');
    menu4div2.classList.remove('d-none');
    menu4divspan.classList.add('d-none');
})
menuaccessories.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    menu5div1.classList.remove('d-none');
    menu5div2.classList.remove('d-none');
    menu5divspan.classList.add('d-none');
})
menuprescription.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    menu6div1.classList.remove('d-none');
    menu6div2.classList.remove('d-none');
    menu6divspan.classList.add('d-none');
})