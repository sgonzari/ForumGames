var usuario = localStorage.getItem('usuario')

//Tabla de información personal
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44355/usuario/getData?username=' + usuario,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, status) {
            $('#firstname').text(data.firstname + " " + data.surname)
            $('#usuario').text(data.username)
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

var textarea = document.querySelector('textarea');

textarea.addEventListener('keydown', autosize);
             
function autosize(){
  var el = this;
  setTimeout(function(){
    el.style.cssText = 'height:auto; padding:0';
    // for box-sizing other than "content-box" use:
    // el.style.cssText = '-moz-box-sizing:content-box';
    el.style.cssText = 'height:' + el.scrollHeight + 'px';
  },0);
}