// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function runMarkupConvert() {
    var text = document.getElementById('ReadMeContents').innerHTML,
        target = document.getElementById('ReadMeContents'),
        converter = new showdown.Converter(),
        html = converter.makeHtml(text);
        target.innerHTML = html;
}
