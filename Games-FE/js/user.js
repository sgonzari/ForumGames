// Variables
var usuario = localStorage.getItem('usuario')
var idJuego

//Si no está loggeado le devuelve a la pantalla de loggueo/registro
if (!usuario) {
    window.location.replace("./login.html");
}

//Tabla de información personal
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:44355/usuario/getData?username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
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
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:44355/juego/getdatausername?username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                //Muestra un tick / cross si es multijugador o no
                if (item.multiplayer) {
                    var $td_multiplayer = $('<td>').append(
                        $('<spam class="fa fa-check text-success"></spam>')
                    )
                } else {
                    var $td_multiplayer = $('<td>').append(
                        $('<spam class="fa fa-times text-danger"></spam>')
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
                    onclick: "shareGame('" + item.title + "')"
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
                    $('<td>').text(item.height + "GB").attr({ style: "text-align: center" }),
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
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:44355/categoria',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
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
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:44355/categoria',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                var $label = $('<label>').attr({ id: "category" })
                var $categories = $('<div>').append(
                    $('<input>').attr({ type: "checkbox", id: item.name, name: "editCategories", value: item.idCategory, style: "margin-right: 5px" }),
                    $label.text(item.name)
                );
                $('#allEditCategories').append($categories);
            });
        }
    });
});

//Plataformas - Agregar Juego
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:44355/plataforma',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
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
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:44355/plataforma',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                var $label = $('<label>').attr({ id: "platform" })
                var $platforms = $('<div>').append(
                    $('<input>').attr({ type: "checkbox", id: item.name, name: "editPlatforms", value: item.idPlatform, style: "margin-right: 5px" }),
                    $label.text(item.name)
                );
                $('#allEditPlatforms').append($platforms);
            });
        }
    });
});

//Función añadir juego
$('#addGame').click(function addGame() {
    var $title = $('#title').val()
    var $description = $('#description').val()
    var $height = parseFloat($('#height').val())
    var $launchDate = $('#launchDate').val()
    var $multiplayer = null

    var categories = [];
    $.each($('input[name="categories"]:checked'), function() {
        categories.push($(this).val());
    });
    var platforms = [];
    $.each($('input[name="platforms"]:checked'), function() {
        platforms.push($(this).val());
    });

    if ($('#multiplayerYes').is(':checked')) {
        var $multiplayer = true
    } else if ($('#multiplayerNo').is(':checked')) {
        var $multiplayer = false
    }

    if ($title && $description && $height && categories.length !== 0 && platforms.length !== 0 && $multiplayer !== null) {
        $.ajax({
            url: 'https://localhost:44355/juego',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify({
                "title": $title,
                "fkusername": usuario,
                "description": $description,
                "height": $height,
                "launchDate": $launchDate,
                "multiplayer": $multiplayer,
                "idCategory": categories.map(i => Number(i)),
                "idplatform": platforms.map(i => Number(i))
            }),
            success: function(data, status) {
                //console.log(status)
                location.reload();
            },
            error: function(data, status) {
                alert("Juego ya creado")
            }
        });
    } else {
        alert("Comprueba tener todos los campos obligatorios rellenos")
    }
});

//Función añadir contenido al modal
function addInfoGame(title) {
    $.ajax({
        url: 'https://localhost:44355/juego/getdata?title=' + title + '&username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'applicaciont/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                $('#editTitle').attr({ value: item.title })
                $('#editDescription').attr({ value: item.description })
                $('#editHeight').attr({ value: item.height })
                console.log("Fecha:" + item.launchDate)
                if (item.launchDate !== null) {
                    $('#editLaunchDate').attr({ value: formatDate(item.launchDate) })
                }

                if (item.multiplayer) {
                    $('#editMultiplayerYes').attr('checked', true)
                } else {
                    $('#editMultiplayerNo').attr('checked', true)
                }

                $.each(item.titleCategory, function(i, idCat) {
                    console.log("IdCategory:" + idCat)
                    $('input[id="' + idCat + '"]').attr('checked', true)
                });

                $.each(item.titlePlatform, function(i, idPlat) {
                    console.log("IdPlatform:" + idPlat)
                    $('input[id="' + idPlat + '"]').attr('checked', true)
                });
                idJuego = item.idGame
            });
        },
        error: function(data, status) {
            //console.log(status)
            alert("Error, por favor consulte con un administrador")
            location.reload();
        }
    });
}

//Función editar juego
$('#editGame').click(function editGame() {
    var $editTitle = $('#editTitle').val()
    var $editDescription = $('#editDescription').val()
    var $editHeight = parseFloat($('#editHeight').val())
    var $editLaunchDate = $('#editLaunchDate').val()
    var $editMultiplayer = null

    var editCategories = [];
    $.each($('input[name="editCategories"]:checked'), function() {
        editCategories.push($(this).val());
    });
    var editPlatforms = [];
    $.each($('input[name="editPlatforms"]:checked'), function() {
        editPlatforms.push($(this).val());
    });

    if ($('#editMultiplayerYes').is(':checked')) {
        var $editMultiplayer = true
    } else if ($('#editMultiplayerNo').is(':checked')) {
        var $editMultiplayer = false
    }
    if ($editTitle && $editDescription && $editHeight && editCategories.length !== 0 && editPlatforms.length !== 0 && $editMultiplayer !== null) {
        $.ajax({
            url: 'https://localhost:44355/juego/update',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify({
                "idGame": parseInt(idJuego),
                "title": $editTitle,
                "fkusername": usuario,
                "description": $editDescription,
                "height": $editHeight,
                "launchDate": $editLaunchDate,
                "multiplayer": $editMultiplayer,
                "idCategory": editCategories.map(i => Number(i)),
                "idplatform": editPlatforms.map(i => Number(i))
            }),
            success: function(data, status) {
                console.log(status)
                location.reload();
            },
            error: function(data, status) {
                //console.log(data)
                alert("Error, por favor consulte con un administrador")
                location.reload();
            }
        });
    } else {
        alert("Comprueba tener todos los campos obligatorios rellenos")
    }
});

//Función compartir juego
function shareGame(titleGame) {
    window.location.replace("./game.html?title=" + titleGame + "&username=" + usuario);
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
        success: function(data, status) {
            console.log(status)
            alert("Juego eliminado correctamente")
            location.reload();
        },
        error: function(data, status) {
            //console.log(status)
            alert("Error, por favor consulte con un administrador")
            location.reload();
        }
    });
}

//Función salir de la interfaz
$('#logout').click(function logout() {
    window.location.replace("./login.html")
    window.localStorage.removeItem('usuario')
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