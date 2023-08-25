let filterbtn = document.querySelector('.filtersearch .button1');
let filterclose = document.querySelector('.filtertop .topclose');
let filterfooter = document.querySelector('.filtermobile .filterfooter');
let filtermobile = document.querySelector('.filtermain');
let filterwebclose = document.querySelector('.filterweball .filterclose');
let filterwebmain = document.querySelector('.filterall3');
let filterwebbtn = document.querySelector('.filtersearch .button2');

filterbtn.addEventListener('click', function(e){
    e.preventDefault();
    e.stopPropagation();
    filtermobile.style.visibility = 'visible';
    filtermobile.style.transform = 'translateY(0%)';
    document.body.style.overflow = 'hidden';
    filterfooter.style.visibility = 'visible';
    filterfooter.style.transform = "translateY(0%)";
});
filterclose.addEventListener('click', function(e){
    e.preventDefault();
    e.stopPropagation();
    filtermobile.style.visibility = 'hidden';
    filtermobile.style.transform = 'translateY(100%)';
    document.body.style.overflow = 'auto';
    filterfooter.style.visibility = 'hidden';
    filterfooter.style.transform = "translateY(100%)";
});
filterwebbtn.addEventListener('click', function(e){
    e.preventDefault();
    e.stopPropagation();
    if(filterwebmain.classList.contains('invisible')){
        filterwebmain.style.maxHeight = '320px';
        filterwebmain.classList.add('visible');
        filterwebmain.classList.remove('invisible');
    }
    else{
        filterwebmain.style.maxHeight = '0';
        filterwebmain.classList.add('invisible');
        filterwebmain.classList.remove('visible');
    }
});
filterwebclose.addEventListener('click', function(e){
    e.preventDefault();
    e.stopPropagation();
    if(filterwebmain.classList.contains('invisible')){
        filterwebmain.style.maxHeight = '320px';
        filterwebmain.classList.add('visible');
        filterwebmain.classList.remove('invisible');
    }
    else{
        filterwebmain.style.maxHeight = '0';
        filterwebmain.classList.add('invisible');
        filterwebmain.classList.remove('visible');
    }
});

const elements = {
    filterwebline: document.querySelector('.centername .nameline'),
    filterwebnames:[
        document.querySelector('.centername #width'),
        document.querySelector('.centername #shape'),
        document.querySelector('.centername #material'),
        document.querySelector('.centername #color'),
        document.querySelector('.centername #price'),
        document.querySelector('.centername #presc'),
        document.querySelector('.centername #features'),
        document.querySelector('.centername #bridge')
    ],
    filterwebtypes:[
        document.querySelector('.filtercenter .center2 .center3'),
        document.querySelector('.filtercenter .center2 .center4'),
        document.querySelector('.filtercenter .center2 .center5'),
        document.querySelector('.filtercenter .center2 .center6'),
        document.querySelector('.filtercenter .center2 .center7'),
        document.querySelector('.filtercenter .center2 .center8'),
        document.querySelector('.filtercenter .center2 .center9'),
        document.querySelector('.filtercenter .center2 .center10')
    ]
};

elements.filterwebnames.forEach((filterwebname, index) => {
    filterwebname.addEventListener('click', function(e){
        e.preventDefault();
        e.stopPropagation();
        const translateXValues = [-1, 112, 181, 263, 326, 435, 546, 630];
        const widthValues = [103, 55, 71, 49, 101, 102, 73, 104];
        elements.filterwebline.style.transform = `translateX(${translateXValues[index]}px)`;
        elements.filterwebline.style.width = `${widthValues[index]}%`;

        elements.filterwebtypes.forEach((centerType, centerIndex) => {
            if(centerIndex === index){
                centerType.classList.remove('d-none');
            }
            else{
                centerType.classList.add('d-none');
            }
        });
        elements.filterwebnames.forEach((centerTypeColor, ColorIndex) => {
            if(ColorIndex === index){
                centerTypeColor.style.color = 'rgba(65, 75, 86, 1)';
            }
            else{
                centerTypeColor.style.color = 'rgba(103, 111, 120)';
            }
        })
    });
});

