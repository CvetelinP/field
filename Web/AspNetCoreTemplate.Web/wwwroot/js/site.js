// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Write your JavaScript code.
// add classes to thumb in order to apply first .thumb, then .one, .two, three....etc.
var classes = ["one", "two", "three", "four", "five", "six"];
var a = document.querySelectorAll('.thumb').forEach((el, index) => {
    el.classList.add(`${classes[index]}`);
})

// transform calculations when mouse enter/leave to keep avatars positioning and rotation 
var degs = [0, -60, -120, 180, 120, 60];
var avatar = document.querySelectorAll('.avatar');
var img = document.querySelectorAll(".thumb img");
for (let i = 0; i < avatar.length; i++) {
    avatar[i].setAttribute("style", "transform: rotate(" + degs[i] + "deg) translateY(-150px);");
    img[i].onmouseenter = enlargeImg
    img[i].onmouseleave = reduceImg
}
function enlargeImg(event) {
    event.target.setAttribute("style", "transform: scale(1.3);");
}
function reduceImg(event) {
    event.target.setAttribute("style", "transform: scale(1);");
}

