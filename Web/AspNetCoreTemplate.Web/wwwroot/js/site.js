// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Write your JavaScript code.
var classes = ["one", "two", "three", "four", "five", "six"]
document.querySelectorAll('.thumb').forEach((el, index) => {
    el.classList.add(`${classes[index]}`);
})