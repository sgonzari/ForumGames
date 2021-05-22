var usuario = localStorage.getItem('usuario');

//Si no está loggeado le devuelve a la pantalla de loggueo/registro
if (usuario == "") {
    window.location.replace("./login.html");
}

//Tabla de información personal
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
            $('#registerUser').text(formatDate(data.registerDate))
            $('#groupUser').text(data.group)
        }
    });
});

//Tabla de videojuegos
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
                    var $td_multiplayer = $('<td>').append(
                        $('<spam class="fa fa-check text-primary"></spam>')
                    )
                } else {
                    var $td_multiplayer = $('<td>').append(
                        $('<spam class="fa fa-times text-light"></spam>')
                    )
                }

                if (item.launchDate !== null) {
                    var $td_launchDate = $('<td>').text(formatDate(item.launchDate))
                } else {
                    var $td_launchDate = $('<td>').text("")
                }

                //Botón de editar
                var editBtn = $('<input/>').attr({
                    type: "button",
                    class: "btn btn-primary btn-sm",
                    value: "Editar",
                    id: "editButton",
                    onclick: "addInfoGame('" + item.title + "')",
                    'data-toggle': "modal",
                    'data-target': "#editGameModal"
                });
                //Botón de compartir
                var shareBtn = $('<input/>').attr({
                    type: "button",
                    class: "btn btn-success btn-sm",
                    value: "Compartir",
                    onclick: "shareGame()"
                });
                //Botón de compartir
                var deleteBtn = $('<input/>').attr({
                    type: "button",
                    class: "btn btn-danger btn-sm",
                    id: "deleteButton",
                    value: "Eliminar",
                    onclick: "deleteGame(" + item.idGame + ")"
                });

                //Relleno de las tablas
                var $tr = $('<tr>').append(
                    $('<td>').text(item.title),
                    $('<td>').text(item.description),
                    $td_launchDate,
                    $('<td>').text(item.titleCategory),
                    $('<td>').text(item.titlePlatform),
                    $('<td>').text(item.height).attr({ style: "text-align: center" }),
                    $td_multiplayer.attr({ style: "text-align: center" }),
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

//Categorias - Agregar Juego
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/categoria',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $.each(data, function (i, item) {
                var $label = $('<label>').attr({ id: "category" })
                var $categories = $('<div>').append(
                    $('<input>').attr({ type: "checkbox", id: item.name, name: "categories", value: item.idCategory, style: "margin-right: 5px" }),
                    $label.text(item.name)
                );
                $('#allCategories').append($categories);
            });
        }
    });
});
//Categorias - Editar Juego
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/categoria',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $.each(data, function (i, item) {
                var $label = $('<label>').attr({ id: "category" })
                var $categories = $('<div>').append(
                    $('<input>').attr({ type: "checkbox", id: item.name, name: "categories", value: item.idCategory, style: "margin-right: 5px" }),
                    $label.text(item.name)
                );
                $('#allEditCategories').append($categories);
            });
        }
    });
});

//Plataformas - Agregar Juego
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/plataforma',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $.each(data, function (i, item) {
                var $label = $('<label>').attr({ id: "platform" })
                var $platforms = $('<div>').append(
                    $('<input>').attr({ type: "checkbox", id: item.name, name: "platforms", value: item.idPlatform, style: "margin-right: 5px" }),
                    $label.text(item.name)
                );
                $('#allPlatforms').append($platforms);
            });
        }
    });
});
//Plataformas - Editar Juego
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/plataforma',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $.each(data, function (i, item) {
                var $label = $('<label>').attr({ id: "platform" })
                var $platforms = $('<div>').append(
                    $('<input>').attr({ type: "checkbox", id: item.name, name: "platforms", value: item.idPlatform, style: "margin-right: 5px" }),
                    $label.text(item.name)
                );
                $('#allEditPlatforms').append($platforms);
            });
        }
    });
});

//Función editar perfil
$('#editProfile').click(function editProfile() {
    window.location.replace("./editProfile.html")
});

//Función añadir juego
$('#addGame').click(function addGame() {
    var categories = [];
    $.each($('input[name="categories"]:checked'), function () {
        categories.push($(this).val());
    });
    var platforms = [];
    $.each($('input[name="platforms"]:checked'), function () {
        platforms.push($(this).val());
    });

    if ($('#multiplayerYes').is(':checked')) {
        var $multiplayer = true
    } else if ($('#multiplayerNo').is(':checked')) {
        var $multiplayer = false
    }

    $.ajax({
        url: 'https://localhost:44355/juego',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({
            "title": $('#title').val(),
            "fkusername": usuario,
            "description": $('#description').val(),
            "height": parseFloat($('#height').val()),
            "launchDate": $('#launchDate').val(),
            "multiplayer": $multiplayer,
            "idCategory": categories.map(i => Number(i)),
            "idplatform": platforms.map(i => Number(i))
        }),
        success: function (data, status) {
            //console.log(status)
            location.reload();
        },
        error: function (data, status) {
            //console.log(status)
        }
    });
});

//Función añadir contenido al modal
function addInfoGame(title) {
    $.ajax({
        url: 'https://localhost:44355/juego/getdata?title=' + title + '&username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'applicaciont/json',
        success: function (data, status) {
            $.each(data, function (i, item) {
                $('#editTitle').attr({value: item.title}),
                $('#editDescription').attr({value: item.description}),
                $('#editHeight').attr({value: item.height}),
                $('#editLaunchDate').attr({value: formatDate(item.launchDate)})
            });
        },
        error: function (data, status) {
            console.log(status)
        }
    });
    // $('#editTitle').attr({value: title})
}

//Función compartir juego
function shareGame() {
    window.location.replace("#");
}

//Función borrar juego
function deleteGame(idGame) {
    $.ajax({
        url: 'https://localhost:44355/juego',
        dataType: 'json',
        type: 'delete',
        contentType: 'application/json',
        data: JSON.stringify({
            "idGame": idGame
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

//Función salir de la interfaz
$('#logout').click(function logout() {
    window.location.replace("./login.html")
    window.localStorage.setItem('usuario', "")
});

//Función que devuelve fecha y hora
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [year, month, day].join('-');
}