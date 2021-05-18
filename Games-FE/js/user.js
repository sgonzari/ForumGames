var usuario = localStorage.getItem('usuario');
var logout = document.getElementById("logout")
var editProfile = document.getElementById("editProfile")

logout.addEventListener("click", function(){
    window.location.replace("./login.html");
    window.localStorage.setItem('usuario', "")
});

editProfile.addEventListener("click", function(){
    window.location.replace("./editProfile.html")
})

$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/juego',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $.each(data, function (i, item) {
                //Muestra un tick / cross si es multijugador o no
                if (item.multiplayer) {
                    var $td = $('<td>').append(
                        $('<spam class="fa fa-check text-primary"></spam>')
                    )
                } else {
                    var $td = $('<td>').append(
                        $('<spam class="fa fa-times text-light"></spam>')
                    )
                }
                
                //Botón de editar
                var btn = $('<input/>').attr({
                    type: "button",
                    id: "field",
                    value: "Editar",
                    onclick: "editCategory()"
                });

                //Relleno de las tablas
                var $tr = $('<tr>').append(
                    $('<td>').text(item.title),
                    $('<td>').text(item.description),
                    $('<td>').text(item.launchDate),
                    $('<td>').text(item.titleCategory),
                    $('<td>').text(item.height).css("text-align", "center"),
                    $td.css("text-align", "center"),
                    $('<td>').append(btn)
                ); //.appendTo('#records_table');
                //console.log($tr.wrap('<p>').html());
                $('#tablaJuegos').append($tr);
            });
        }
    });
});

$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/usuario',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $('#firstname').text(usuario)
            //console.log(data)
        }
    });
});

function editCategory() {
    window.location.replace("./login.html");
}