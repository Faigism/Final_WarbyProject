let categorytitle = document.querySelectorAll('.category2 .categoryall button');
categorytitle.forEach((button)=>{
    button.addEventListener('click', function(e){
        e.preventDefault();
        e.stopPropagation();
        categorytitle.forEach((btn)=>{
            btn.classList.remove('active');
        });
        this.classList.add('active');
    });
});

let filterClassList = ['.center3', '.center4', '.center5', '.center6', '.center7', '.center8', '.center9', '.center10'];
filterClassList.forEach((className)=>{
    let filterexist = document.querySelectorAll(className + ' .centertype fieldset');
    filterexist.forEach((button) => {
        button.addEventListener('click', function(e) {
            e.preventDefault();
            e.stopPropagation();
            if (button.style.border == '1px solid black') {
                button.style.border = '1px solid transparent';
            } else {
                button.style.border = '1px solid black';
                button.style.borderRadius = '13px';
            }
        });
    });
});

//filterdata color
function addClickHandlers(buttons) {
    buttons.forEach((btn) => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            e.stopPropagation();

            buttons.forEach((otherBtn) => {
                otherBtn.style.boxShadow = 'none';
            });

            btn.style.boxShadow = 'rgb(255, 255, 255) 0px 0px 0px 2px, rgb(65, 75, 86) 0px 0px 0px 3px';
        });
    });
}

let prdcolor = document.querySelectorAll('.prdcolor .colorimg .colorimg1 .colorimg2 .colorfilter button');
let prdcolor2 = document.querySelectorAll('.prdcolor .colorimg .colorimg1 .colorimg2 .colorfilter2 button');
let prdcolor3 = document.querySelectorAll('.prdcolor .colorimg .colorimg1 .colorimg2 .colorfilter3 button');
let prdcolor4 = document.querySelectorAll('.prdcolor .colorimg .colorimg1 .colorimg2 .colorfilter4 button');
let prdcolor5 = document.querySelectorAll('.prdcolor .colorimg .colorimg1 .colorimg2 .colorfilter5 button');
let prdcolor6 = document.querySelectorAll('.prdcolor .colorimg .colorimg1 .colorimg2 .colorfilter6 button');

addClickHandlers(prdcolor);
addClickHandlers(prdcolor2);
addClickHandlers(prdcolor3);
addClickHandlers(prdcolor4);
addClickHandlers(prdcolor5);
addClickHandlers(prdcolor6);

