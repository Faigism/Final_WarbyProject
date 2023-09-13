let eyesearch = document.querySelector('.filtersearch .search button div');
let eyeglassessearch = document.querySelector('.eyeglassessearch');
let searchclosebtn = document.querySelector('.eyeglassessearch .in6button');
// web-search section
eyesearch.addEventListener('click', function (e) {
    e.preventDefault();
    e.stopPropagation();
    eyeglassessearch.classList.remove('d-none');
    if (!eyeglassessearch.classList.contains('d-none')) {
        eyeglassessearch.style.opacity = '1';
    }
    document.body.style.overflow = 'hidden';
    searchclosebtn.onclick = function () {
        eyeglassessearch.classList.add('d-none');
        if (eyeglassessearch.classList.contains('d-none')) {
            eyeglassessearch.style.opacity = '0';
        }
        document.body.style.overflow = 'auto';
    };
});