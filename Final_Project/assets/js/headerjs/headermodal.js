//   header modal-mobile
let borderBtm2 = document.querySelector('.mobile-bottom-header ul .eyeglassesli a');
let borderBtm3 = document.querySelector('.mobile-bottom-header ul .hometryonli a');
let hdrModal = document.querySelector('.headermodal');
let hdrModal2 = document.querySelector('.headermodal2');
let hometryon = document.querySelector('.hometryonli');
let eyeglasses = document.querySelector('.eyeglassesli');
let mobileHdr = document.querySelector('.mobile-header .mobile-top-header');
let modalClose = document.querySelector('.headermodal .bottombtn');
let modalClose2 = document.querySelector('.headermodal2 .bottombtn');

eyeglasses.addEventListener('click', function(){
    hdrModal.classList.remove('d-none');
    borderBtm2.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
    borderBtm2.style.paddingBottom = '16px';
    borderBtm2.style.transition = 'border-bottom 0.3s';
    document.body.style.overflow = 'hidden';
    if(!hdrModal2.classList.contains('d-none')){
      hdrModal2.classList.add('d-none');
      document.body.style.overflow = 'hidden';
      borderBtm3.style.borderBottom = 'none';
    }
    mobileHdr.addEventListener('click', ()=>{
      if(!hdrModal.classList.contains('d-none')){
        hdrModal.classList.add('d-none');
        document.body.style.overflow = 'auto';
        borderBtm2.style.borderBottom = 'none';
      }
    });
    modalClose.onclick = function(){
      hdrModal.classList.add('d-none');
      document.body.style.overflow = 'auto';
      borderBtm2.style.borderBottom = 'none';
    }
});

hometryon.addEventListener('click', function(){
  hdrModal2.classList.remove('d-none');
  borderBtm3.style.transition = 'border-bottom 0.3s';
  borderBtm3.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  borderBtm3.style.paddingBottom = '16px';
  document.body.style.overflow = 'hidden';
  if(!hdrModal.classList.contains('d-none')){
    hdrModal.classList.add('d-none');
    document.body.style.overflow = 'hidden';
    borderBtm2.style.borderBottom = 'none';
  }
  mobileHdr.addEventListener('click', ()=>{
    if(!hdrModal2.classList.contains('d-none')){
      hdrModal2.classList.add('d-none');
      document.body.style.overflow = 'auto';
      borderBtm3.style.borderBottom = 'none';
    }
  });
  modalClose2.onclick = function(){
    hdrModal2.classList.add('d-none');
    document.body.style.overflow = 'auto';
    borderBtm3.style.borderBottom = 'none';
  };
});
// header modal-tablet
let tableteyeglasses = document.querySelector('.tablet-bottom-header .eyeglasses');
let tabletsunglasses = document.querySelector('.tablet-bottom-header .sunglasses');
let tablethometryon = document.querySelector('.tablet-bottom-header .hometryon');
let webeyeglasses = document.querySelector('.web-bottom-header .eyeglasses');
let websunglasses = document.querySelector('.web-bottom-header .sunglasses');
let webhometryon = document.querySelector('.web-bottom-header .hometryon');
let tabletmodal = document.querySelector('.tablet-header .modaltablet');
let tabletmodal2 = document.querySelector('.tablet-header .modaltablet2');
let tabletmodal3 = document.querySelector('.tablet-header .modaltablet3');
let webmodal = document.querySelector('.web-header .modaltablet');
let webmodal2 = document.querySelector('.web-header .modaltablet2');
let webmodal3 = document.querySelector('.web-header .modaltablet3');
let tableteyebtn = document.querySelector('.tablet-bottom-header ul .eyeglasses');
let tabletsunbtn = document.querySelector('.tablet-bottom-header ul .sunglasses');
let tablethomebtn = document.querySelector('.tablet-bottom-header ul .hometryon');
let webeyebtn = document.querySelector('.web-bottom-header ul .eyeglasses');
let websunbtn = document.querySelector('.web-bottom-header ul .sunglasses');
let webhomebtn = document.querySelector('.web-bottom-header ul .hometryon');
let tabletheader = document.querySelector('.tablet-top-header');
let webheader = document.querySelector('.web-top-header');
let tabletheaderbtm = document.querySelector('.tablet-bottom-header');
let webheaderbtm = document.querySelector('.web-bottom-header');
let tabletmodalshop = document.querySelector('.hometryon2btn .shopeye div');
let tabletmodalshop2 = document.querySelector('.hometryon2btn .shopsun div');
let tabletshopeye = document.querySelector('.modaltablet3eye');
let tabletshopsun = document.querySelector('.modaltablet3sun');
tableteyeglasses.addEventListener('click', function(){
  tabletmodal.classList.remove('d-none');
  tableteyebtn.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  tableteyebtn.style.paddingBottom = '16px';
  tableteyebtn.style.transition = 'border-bottom 0.3s';
  document.body.style.overflow = 'hidden';
  tabletheaderbtm.style.margin = '2px auto 0px';
  if(!tabletsunglasses.classList.contains('d-none')){
    tabletmodal2.classList.add('d-none');
    tabletsunbtn.style.borderBottom = 'none';
  }
  if(!tablethometryon.classList.contains('d-none')){
    tabletmodal3.classList.add('d-none');
    tabletshopeye.classList.add('d-none');
    tabletshopsun.classList.add('d-none');
    tablethomebtn.style.borderBottom = 'none';
  }
  tabletheader.addEventListener('click', ()=>{
    if(!tabletmodal.classList.contains('d-none')){
      tabletmodal.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tableteyebtn.style.borderBottom = 'none';
    }
  });
  tabletmodal.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletmodal)){
      tabletmodal.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tableteyebtn.style.borderBottom = 'none';
    }
  });
});
tabletsunglasses.addEventListener('click', function(){
  tabletmodal2.classList.remove('d-none');
  tabletsunbtn.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  tabletsunbtn.style.paddingBottom = '16px';
  tabletsunbtn.style.transition = 'border-bottom 0.3s';
  document.body.style.overflow = 'hidden';
  tabletheaderbtm.style.margin = '2px auto 0px';
  if(!tableteyeglasses.classList.contains('d-none')){
    tabletmodal.classList.add('d-none');
    tableteyebtn.style.borderBottom = 'none';
  }
  if(!tablethometryon.classList.contains('d-none')){
    tabletmodal3.classList.add('d-none');
    tabletshopeye.classList.add('d-none');
    tabletshopsun.classList.add('d-none');
    tablethomebtn.style.borderBottom = 'none';
  }
  tabletheader.addEventListener('click', ()=>{
    if(!tabletmodal2.classList.contains('d-none')){
      tabletmodal2.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tabletsunbtn.style.borderBottom = 'none';
    }
  });
  tabletmodal2.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletmodal2)){
      tabletmodal2.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tabletsunbtn.style.borderBottom = 'none';
    }
  });
});
tablethometryon.addEventListener('click', function(){
  tabletmodal3.classList.remove('d-none');
  tablethomebtn.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  tablethomebtn.style.paddingBottom = '16px';
  tablethomebtn.style.transition = 'border-bottom 0.3s';
  document.body.style.overflow = 'hidden';
  tabletheaderbtm.style.margin = '2px auto 0px';
  if(!tableteyeglasses.classList.contains('d-none')){
    tabletmodal.classList.add('d-none');
    tableteyebtn.style.borderBottom = 'none';
  }
  if(!tabletsunglasses.classList.contains('d-none')){
    tabletmodal2.classList.add('d-none');
    tabletsunbtn.style.borderBottom = 'none';
  }
  tabletheader.addEventListener('click', ()=>{
    if(!tabletmodal3.classList.contains('d-none')){
      tabletmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tablethomebtn.style.borderBottom = 'none';
    }
  });
  tabletmodal3.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletmodal3)){
      tabletmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tablethomebtn.style.borderBottom = 'none';
    }
  });
});
tabletmodalshop.addEventListener('click', function(){
  tabletshopeye.classList.remove('d-none');
  tabletheader.addEventListener('click', ()=>{
    if(!tabletmodalshop.classList.contains('d-none')){
      tabletshopeye.classList.add('d-none');
      tabletmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tablethomebtn.style.borderBottom = 'none';
    }
  });
  tabletshopeye.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletshopeye)){
      tabletshopeye.classList.add('d-none');
      tabletmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tablethomebtn.style.borderBottom = 'none';
    }
  });
  if(!tableteyeglasses.classList.contains('d-none')){
    tabletmodal.classList.add('d-none');
    tableteyebtn.style.borderBottom = 'none';
  }
  if(!tabletsunglasses.classList.contains('d-none')){
    tabletmodal2.classList.add('d-none');
    tabletsunbtn.style.borderBottom = 'none';
  }
});
tabletmodalshop2.addEventListener('click', function(){
  tabletshopsun.classList.remove('d-none');
  tabletheader.addEventListener('click', ()=>{
    if(!tabletmodalshop2.classList.contains('d-none')){
      tabletshopsun.classList.add('d-none');
      tabletmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tablethomebtn.style.borderBottom = 'none';
    }
  });
  tabletshopsun.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletshopsun)){
      tabletshopsun.classList.add('d-none');
      tabletmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      tablethomebtn.style.borderBottom = 'none';
    }
  });
  if(!tableteyeglasses.classList.contains('d-none')){
    tabletmodal.classList.add('d-none');
    tableteyebtn.style.borderBottom = 'none';
  }
  if(!tabletsunglasses.classList.contains('d-none')){
    tabletmodal2.classList.add('d-none');
    tabletsunbtn.style.borderBottom = 'none';
  }
});
// header modal-web
webeyeglasses.addEventListener('click', function(){
  webmodal.classList.remove('d-none');
  webeyebtn.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  webeyebtn.style.paddingBottom = '16px';
  webeyebtn.style.transition = 'border-bottom 0.3s';
  document.body.style.overflow = 'hidden';
  webheaderbtm.style.margin = '2px auto 0px';
  if(!websunglasses.classList.contains('d-none')){
    webmodal2.classList.add('d-none');
    websunbtn.style.borderBottom = 'none';
  }
  if(!webhometryon.classList.contains('d-none')){
    webmodal3.classList.add('d-none');
    tabletshopeye.classList.add('d-none');
    tabletshopsun.classList.add('d-none');
    webhomebtn.style.borderBottom = 'none';
  }
  webheader.addEventListener('click', ()=>{
    if(!webmodal.classList.contains('d-none')){
      webmodal.classList.add('d-none');
      tabletshopeye.classList.add('d-none');
      tabletshopsun.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webeyebtn.style.borderBottom = 'none';
    }
  });
  webmodal.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(webmodal)){
      webmodal.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webeyebtn.style.borderBottom = 'none';
    }
  });
});
websunglasses.addEventListener('click', function(){
  webmodal2.classList.remove('d-none');
  websunbtn.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  websunbtn.style.paddingBottom = '16px';
  websunbtn.style.transition = 'border-bottom 0.3s';
  document.body.style.overflow = 'hidden';
  webheaderbtm.style.margin = '2px auto 0px';
  if(!webeyeglasses.classList.contains('d-none')){
    webmodal.classList.add('d-none');
    webeyebtn.style.borderBottom = 'none';
  }
  if(!webhometryon.classList.contains('d-none')){
    webmodal3.classList.add('d-none');
    tabletshopeye.classList.add('d-none');
    tabletshopsun.classList.add('d-none');
    webhomebtn.style.borderBottom = 'none';
  }
  webheader.addEventListener('click', ()=>{
    if(!webmodal2.classList.contains('d-none')){
      webmodal2.classList.add('d-none');
      tabletshopeye.classList.add('d-none');
      tabletshopsun.classList.add('d-none');
      document.body.style.overflow = 'auto';
      websunbtn.style.borderBottom = 'none';
    }
  });
  webmodal2.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(webmodal2)){
      webmodal2.classList.add('d-none');
      tabletshopeye.classList.add('d-none');
      tabletshopsun.classList.add('d-none');
      document.body.style.overflow = 'auto';
      websunbtn.style.borderBottom = 'none';
    }
  });
});
webhometryon.addEventListener('click', function(){
  webmodal3.classList.remove('d-none');
  webhomebtn.style.borderBottom = '2px solid rgba(65, 75, 86, 1)';
  webhomebtn.style.paddingBottom = '16px';
  webhomebtn.style.transition = 'border-bottom 0.3s';
  document.body.style.overflow = 'hidden';
  webheaderbtm.style.margin = '2px auto 0px';
  if(!webeyeglasses.classList.contains('d-none')){
    webmodal.classList.add('d-none');
    webeyebtn.style.borderBottom = 'none';
  }
  if(!websunglasses.classList.contains('d-none')){
    webmodal2.classList.add('d-none');
    websunbtn.style.borderBottom = 'none';
  }
  webheader.addEventListener('click', ()=>{
    if(!webmodal3.classList.contains('d-none')){
      webmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webhomebtn.style.borderBottom = 'none';
    }
  });
  webmodal3.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(webmodal3)){
      webmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webhomebtn.style.borderBottom = 'none';
    }
  });
});
tabletmodalshop.addEventListener('click', function(){
  tabletshopeye.classList.remove('d-none');
  webheader.addEventListener('click', ()=>{
    if(!tabletmodalshop.classList.contains('d-none')){
      tabletshopeye.classList.add('d-none');
      webmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webhomebtn.style.borderBottom = 'none';
    }
  });
  tabletshopeye.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletshopeye)){
      tabletshopeye.classList.add('d-none');
      webmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webhomebtn.style.borderBottom = 'none';
    }
  });
  if(!webeyeglasses.classList.contains('d-none')){
    webmodal.classList.add('d-none');
    webeyebtn.style.borderBottom = 'none';
  }
  if(!websunglasses.classList.contains('d-none')){
    webmodal2.classList.add('d-none');
    websunbtn.style.borderBottom = 'none';
  }
});
tabletmodalshop2.addEventListener('click', function(){
  tabletshopsun.classList.remove('d-none');
  webheader.addEventListener('click', ()=>{
    if(!tabletmodalshop2.classList.contains('d-none')){
      tabletshopsun.classList.add('d-none');
      webmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webhomebtn.style.borderBottom = 'none';
    }
  });
  tabletshopsun.addEventListener('click', (e)=>{
    const target = e.target;
    if(target.contains(tabletshopsun)){
      tabletshopsun.classList.add('d-none');
      webmodal3.classList.add('d-none');
      document.body.style.overflow = 'auto';
      webhomebtn.style.borderBottom = 'none';
    }
  });
  if(!webeyeglasses.classList.contains('d-none')){
    webmodal.classList.add('d-none');
    webeyebtn.style.borderBottom = 'none';
  }
  if(!websunglasses.classList.contains('d-none')){
    webmodal2.classList.add('d-none');
    websunbtn.style.borderBottom = 'none';
  }
});
