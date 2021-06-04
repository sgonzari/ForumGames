// Variables
var serverBE = "http://localhost:44355"
var serverFE = "http://localhost/views"
var usuario = localStorage.getItem('usuario').substr(500)
var idJuego

//Si no está loggeado le devuelve a la pantalla de loggueo/registro
if (!usuario) {
    window.location.replace("..");
}

//Tabla de información personal
$(document).ready(function() {
    $.ajax({
        url: serverBE + '/usuario/getData?username=' + usuario,
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
        url: serverBE + '/juego/getdatausername?username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                // console.log(item)
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

                if (item.newComment) {
                    var $td_newComment = $('<td>').append(
                        $('<spam class="fa fa-check text-success"></spam>')
                    )
                } else {
                    var $td_newComment = $('<td>').append(
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
                    class: "btn btn-warning btn-sm",
                    value: "Compartir",
                    onclick: "addInfoShare('" + item.title + "')",
                    'data-toggle': "modal",
                    'data-target': "#shareGameModal"
                });
                //Botón de ver
                var showBtn = $('<input/>').attr({
                    type: "button",
                    class: "btn btn-success btn-sm",
                    value: "Ver",
                    onclick: "showGame(" + item.idGame + ", '" + item.title + "')"
                });
                //Botón de eliminar
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
                    $('<td>').text(item.height + "GB"),
                    $td_multiplayer,
                    $td_newComment,
                    $('<td>').append(showBtn),
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
        url: serverBE + '/categoria',
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
        url: serverBE + '/categoria',
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
        url: serverBE + '/plataforma',
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
        url: serverBE + '/plataforma',
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
    var $urlGame = $('#urlGame').val()

    if (!$urlGame.includes("http://") && !$urlGame.includes("https://")) {
        var $urlGame = null
    }

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
        if (!$urlGame) {
            alert("URL inválida, acuerda de añadir al principio: http:// o https://")
        } else {
            $.ajax({
                url: serverBE + '/juego',
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
                    "idplatform": platforms.map(i => Number(i)),
                    "url": $urlGame
                }),
                success: function(data, status) {
                    //console.log(status)
                    location.reload();
                },
                error: function(data, status) {
                    alert("Error, recuerda no duplicar juegos con el mismo título")
                }
            });
        }
    } else {
        alert("Comprueba tener todos los campos obligatorios rellenos")
    }
});

//Función añadir contenido al modal de editar
function addInfoGame(title) {
    $.ajax({
        url: serverBE + '/juego/getdata?title=' + title + '&username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'applicaciont/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                $('#editTitle').attr({ value: item.title })
                $('#editDescription').text(item.description)
                $('#editHeight').attr({ value: item.height })
                    //console.log("Fecha:" + item.launchDate)
                if (item.launchDate !== null) {
                    $('#editLaunchDate').attr({ value: formatDate(item.launchDate) })
                }

                if (item.multiplayer) {
                    $('#editMultiplayerYes').attr('checked', true)
                } else {
                    $('#editMultiplayerNo').attr('checked', true)
                }

                $.each(item.titleCategory, function(i, idCat) {
                    //console.log("IdCategory:" + idCat)
                    $('input[id="' + idCat + '"]').attr('checked', true)
                });

                $.each(item.titlePlatform, function(i, idPlat) {
                    //console.log("IdPlatform:" + idPlat)
                    $('input[id="' + idPlat + '"]').attr('checked', true)
                });

                $('#editUrlGame').attr({ value: item.url })

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
    var $editUrlGame = $('#editUrlGame').val()

    if (!$editUrlGame.includes("http://") && !$editUrlGame.includes("https://")) {
        var $editUrlGame = null
    }

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
        if (!$editUrlGame) {
            alert("URL inválida, acuerda de añadir al principio: http:// o https://")
        } else {
            $.ajax({
                url: serverBE + '/juego/update',
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
                    "idplatform": editPlatforms.map(i => Number(i)),
                    "url": $editUrlGame
                }),
                success: function(data, status) {
                    //console.log(status)
                    location.reload();
                },
                error: function(data, status) {
                    //console.log(data)
                    alert("Error, por favor consulte con un administrador")
                    location.reload();
                }
            });
        }
    } else {
        alert("Comprueba tener todos los campos obligatorios rellenos")
    }
});

//Función ver juego
function showGame(idGame, titleGame) {
    $.ajax({
        url: serverBE + '/juego/postNotification',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({
            "idgame": idGame,
            "newComment": false,
        }),
        success: function(data, status) {
            window.location.replace("./game.html?title=" + titleGame + "&username=" + usuario);
        }
    });
}

//Función añadir contenido al modal de compartición
function addInfoShare(title) {
    var tituloNoSpace = encodeURIComponent(title.trim())
    var usuarioNoSpace = encodeURIComponent(usuario.trim())
    var urlGame = (serverFE + "/game.html?title=" + tituloNoSpace + "&username=" + usuarioNoSpace);
    $('#shareUrlGame').attr({ value: urlGame, 'readonly': true })
    $('#subjectUrlGame').text("Compartición de un juego")
    $('#bodyUrlGame').text("Hey tío! Aquí te mando un juego que he realizado y me gustaría que probases.")
}

//Función compartir juego
$('#shareGame').click(function shareGame() {
    var $mail = $('#mailUrlGame').val()
    var $subject = $('#subjectUrlGame').val()
    var $body = $('#bodyUrlGame').val()
    var $urlGame = $('#shareUrlGame').val()
    if ($mail) {
        if ($mail.includes("@") && $mail.includes(".com") || $mail.includes(".es")) {
            location.href = 'mailto:' + $mail + '?Subject=' + $subject + '&body=' + $body + '%0D%0A%0D%0A' + $urlGame + '';
        } else {
            alert("Correo electrónico inválido")
        }
    } else {
        alert("No has introducido un correo electrónico")
    }
});

//Función borrar juego
function deleteGame(idGame) {
    $.ajax({
        url: serverBE + '/juego',
        dataType: 'json',
        type: 'delete',
        contentType: 'application/json',
        data: JSON.stringify({
            "idGame": idGame
        }),
        success: function(data, status) {
            //console.log(status)
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
    window.location.replace("..")
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

//Función que copia el enlace cuando haces click
document.getElementById("shareUrlGame").onclick = function() {
    this.select();
    document.execCommand('copy');
}