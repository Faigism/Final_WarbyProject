let hdrsearch = document.querySelector('.hdr-search button div');
let hdrsearchin = document.querySelector('.hdrsearch-in');
let searchbtn = document.querySelector('.in6button');
// web-search section
hdrsearch.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    hdrsearchin.classList.remove('d-none');
    if (!hdrsearchin.classList.contains('d-none')) {
        hdrsearchin.style.opacity = '1';
    }
    document.body.style.overflow = 'hidden';
    searchbtn.onclick = function () {
        hdrsearchin.classList.add('d-none');
        if (hdrsearchin.classList.contains('d-none')) {
            hdrsearchin.style.opacity = '0';
        }
        document.body.style.overflow = 'auto';
    };
});
// tablet-search section
let hdrsearch2 = document.querySelector('.tablet-top-header .hdr-search button div');
hdrsearch2.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    hdrsearchin.classList.remove('d-none');
    if (!hdrsearchin.classList.contains('d-none')) {
        hdrsearchin.style.opacity = '1';
    }
    document.body.style.overflow = 'hidden';
    searchbtn.onclick = function () {
        hdrsearchin.classList.add('d-none');
        if (hdrsearchin.classList.contains('d-none')) {
            hdrsearchin.style.opacity = '0';
        }
        document.body.style.overflow = 'auto';
    };
});
// mobile-search section
let hdrsearch3 = document.querySelector('.mobile-burgermenu .burgermenu-center .menu-hdr .menu-search button div');
hdrsearch3.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    hdrsearchin.classList.remove('d-none');

    menuDivSpans.forEach(span => span.classList.remove('d-none'));
    toggleButtons([menubtn3, menubtn4], true);
    toggleButtons([menubtn, menubtn2], false);
    allMenuDivs.forEach(div => div.classList.add('d-none'));

    if (!hdrsearchin.classList.contains('d-none')) {
        hdrsearchin.style.opacity = '1';
    }
    document.body.style.overflow = 'hidden';
    searchbtn.onclick = function () {
        hdrsearchin.classList.add('d-none');
        if (hdrsearchin.classList.contains('d-none')) {
            hdrsearchin.style.opacity = '0';
        }
        document.body.style.overflow = 'auto';
    };
})


