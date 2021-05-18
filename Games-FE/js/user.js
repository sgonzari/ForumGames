var usuario = localStorage.getItem('usuario');
var logout = document.getElementById("logout");
var editProfile = document.getElementById("editProfile");

if (usuario == "") {
    window.location.replace("./login.html");
}

logout.addEventListener("click", function () {
    window.location.replace("./login.html");
    window.localStorage.setItem('usuario', "")
});

editProfile.addEventListener("click", function () {
    window.location.replace("./editProfile.html")
})

$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/usuario/getData?username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $('#firstname').text(data.firstname + " " + data.surname)
            $('#usuario').text("@" + data.username)
            if (data.email !== null) {
                $('#emailUser').text(data.email)
            } else {
                $('#emailUser').text("no tienes vinculado ningún correo electrónico").attr({ style: "color: red" })
            }
            if (data.phone !== null) {
                $('#phoneUser').text(data.phone)
            } else {
                $('#phoneUser').text("no tienes vinculado ningún número de teléfono").attr({ style: "color: red" })
            }
            $('#registerUser').text(data.registerDate)
            $('#groupUser').text(data.group)
        }
    });
});

$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/juego/getdatausername?username=' + usuario,
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
                var editBtn = $('<input/>').attr({
                    type: "button",
                    id: "field",
                    value: "Editar",
                    onclick: "editGame()"
                });
                //Botón de compartir
                var shareBtn = $('<input/>').attr({
                    type: "button",
                    id: "field",
                    value: "Compartir",
                    onclick: "shareGame()"
                });
                //Botón de compartir
                var deleteBtn = $('<input/>').attr({
                    type: "button",
                    id: "field",
                    value: "Eliminar",
                    onclick: "deleteGame(" + item.idGame + ")"
                });

                //Relleno de las tablas
                var $tr = $('<tr>').append(
                    $('<td>').text(item.title),
                    $('<td>').text(item.description),
                    $('<td>').text(item.launchDate),
                    $('<td>').text(item.titleCategory),
                    $('<td>').text(item.height).attr({ style: "text-align: center" }),
                    $td.attr({ style: "text-align: center" }),
                    $('<td>').append(editBtn),
                    $('<td>').append(shareBtn),
                    $('<td>').append(deleteBtn)
                ); //.appendTo('#records_table');
                //console.log($tr.wrap('<p>').html());
                $('#gamesTable').append($tr);
            });
        }
    });
});

function editGame() {
    window.location.replace("#");
}

function shareGame() {
    window.location.replace("#");
}

function deleteGame(title) {
    $.ajax({
        url: 'https://localhost:44355/juego',
        dataType: 'json',
        type: 'delete',
        contentType: 'application/json',
        data: JSON.stringify({
            "idGame": title
        }),
        success: function (data, status) {
            console.log(status)
            alert("Juego eliminado correctamente")
            location.reload();
        },
        error: function (data, status) {
            console.log(status)
        }
    });
}