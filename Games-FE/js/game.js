// Variables
var serverBE = "http://164.68.113.2:44355"
var serverFE = "http://localhost/views"
var usuario = localStorage.getItem('usuario')
var idJuego

// Comprobación de que los query params sean correctos
$(document).ready(() => {
    let searchParams = new URLSearchParams(window.location.search)
    if (searchParams.has('title') && searchParams.has('username')) {
        title = searchParams.get('title')
        username = searchParams.get('username')
            // alert(param1 + ", " + param2)
    } else {
        alert('Link  no valido')
        window.location.replace("./user.html");
    }
})

//Función que obtiene el nombre de usuario
$(document).ready(function() {
    if (usuario) {
        $.ajax({
            url: serverBE + '/usuario/getData?username=' + usuario,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            success: function(data, status) {
                $('#usuario').text(data.username)
            }
        });
    }
});

//Información del juego
$(document).ready(function() {
    $.ajax({
        url: serverBE + '/juego/getdata?title=' + title + '&username=' + username,
        dataType: 'json',
        type: 'get',
        contentType: 'applicaciont/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                if (item.title){
                    $("#allContent").css({display: "block"});
                    $('#titleGame').text(item.title)
                    $('#descriptionGame').text(item.description)
                    $('#heightGame').text(item.height + "GB")
                        //console.log("Fecha:" + item.launchDate)
                    if (item.launchDate) {
                        $('#launchDateGame').text(formatDate(item.launchDate))
                        $('#notDate').text("")
                    }

                    if (item.multiplayer) {
                        $('#multiplayerGame').append($('<spam>').attr({ class: "fa fa-check text-success" }))
                    } else {
                        $('#multiplayerGame').append($('<spam>').attr({ class: "fa fa-times text-danger" }))
                    }

                    var $spam = $('<spam>').attr({ class: "fa fa-download text-secundary" })
                    var $a = $('<a>').attr({ href: item.url })
                    if (item.url) {
                        $('#urlGame').append($a.append($spam))
                    }

                    $.each(item.titleCategory, function(i, idCat) {
                        //console.log("IdCategory:" + idCat)
                        $('#titleCategoriesGame').append($('<h3>').text(idCat))
                    });

                    $.each(item.titlePlatform, function(i, idPlat) {
                        //console.log("IdPlatform:" + idPlat)
                        $('#titlePlatformsGame').append($('<h3>').text(idPlat))
                    });
                    idJuego = item.idGame

                    pintarComments()
                } else {
                    $("#allContent").css({display: "none"});
                }
            });
        },
        error: function(data, status) {
            //console.log(status)
            alert("Error, por favor consulte con un administrador")
            location.reload();
        }
    });
});

//Función comentarios del juego
function pintarComments() {
    $.ajax({
        url: serverBE + '/comentario/getCommentIdGame?idgame=' + idJuego,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status) {
            $.each(data, function(i, item) {
                // console.log(item);
                var $div = $('<div>').attr({ class: "commentCard" })
                var $primaryDiv = $('<div>').attr({ class: "card mb-4 box-shadow" })
                var $headerDiv = $('<div>').attr({ class: "card-header" })
                var $contentDiv = $('<div>').attr({ class: "card-body" })
                var $smallDate = $('<small>').attr({ class: "text-muted" })


                var $comment = $div.append(
                    $primaryDiv.append(
                        $headerDiv.append(
                            $('<h3>').text(item.username)
                        ),
                        $contentDiv.append(
                            $('<h5>').text(item.comment),
                            $('<spam>').append(
                                $smallDate.text(formatDate(item.date))
                            )
                        )
                    )
                )
                $('#commentsUsers').append($comment);
            })
        }
    });

}

//Función añadir comentario
$('#addComment').click(function addComment() {
    if (usuario) {
        $.ajax({
            url: serverBE + '/comentario',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify({
                "idgame": idJuego,
                "username": usuario,
                "comment": $('#textComment').val()
            }),
            success: function(data, status) {
                //console.log(status)
                $.ajax({
                    url: serverBE + '/juego/postNotification',
                    dataType: 'json',
                    type: 'post',
                    contentType: 'application/json',
                    data: JSON.stringify({
                        "idgame": idJuego,
                        "newComment": true,
                    }),
                });
                location.reload();
            },
            error: function(data, status) {
                //console.log(status)
                alert("Error, por favor consulte con un administrador")
                location.reload();
            }
        });
    } else {
        alert("No estás loggeado")
    }
})

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