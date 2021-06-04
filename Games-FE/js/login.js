//Variables
var serverBE = "http://localhost:44355"
var serverFE = "http://localhost/views"
var usuario = localStorage.getItem('usuario')

//Si está loggeado le devuelve a la dashboard de usuario
if (usuario) {
    window.location.replace("../views/user.html");
}

// Función para realizar login mediante 'intro' y dándole al botón
function handleSubmit(event) {
    event.preventDefault()
    var username = $("#login").val().trim();
    var passwd = $("#password").val().trim();

    if (username != "" && password != "") {
        $.ajax({
            url: serverBE + '/login',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify({ username: username, passwd: passwd }),
            success: function(data, status) {
                //alert("Data: " + data + "\nStatus: " + status);
                if (data) {
                    window.location.replace("./views/user.html");
                    window.localStorage.setItem('usuario', token(500) + username)
                } else {
                    $("#error").css("display", "block");
                }
            }
        })
    }
}

// Función para registrar un usuario.
$('#addUser').click(function addUser() {
    var createUser = true
    var username = $('#username').val()
    var firstname = $('#firstname').val()
    var surname = $('#surname').val()
    var passwd = $('#passwd').val()
    var $email = $('#email').val()
    var $phone = $('#phone').val()
    if (username && firstname && surname && passwd) {
        if ($email) {
            if (!$email.includes("@") && !$email.includes(".com") || !$email.includes(".es")) {
                createUser = false
                alert("Correo electrónico inválido")
            }
        }
        if ($phone) {
            if (!$phone > 999999999 && !$phone < 599999999) {
                createUser = false
                alert("Número de teléfono inválido")
            }
        }

        if (createUser) {
            $.ajax({
                url: serverBE + '/usuario',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json',
                data: JSON.stringify({
                    "username": username,
                    "firstname": firstname,
                    "surname": surname,
                    "email": $email,
                    "phone": parseInt($phone),
                    "passwd": passwd
                }),
                success: function(data, status) {
                    alert("Usuario creado correctamente")
                    location.reload();
                },
                error: function(data, status) {
                    alert("Usuario ya registrado")
                }
            });
        }
    } else {
        alert("Comprueba tener todos los campos obligatorios rellenos")
    }

});

//Función que genera un token aleatorio
function token(length) {
    var a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".split("");
    var b = [];
    for (var i = 0; i < length; i++) {
        var j = (Math.random() * (a.length - 1)).toFixed(0);
        b[i] = a[j];
    }
    return b.join("");
}