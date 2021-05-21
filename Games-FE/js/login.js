function handleSubmit(event) {
    event.preventDefault()
    var username = $("#login").val().trim();
    var passwd = $("#password").val().trim();

    if (username != "" && password != "") {
        $.ajax({
            url: 'https://localhost:44355/login',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify({ username: username, passwd: passwd }),
            success: function (data, status) {
                //alert("Data: " + data + "\nStatus: " + status);
                if (data) {
                    window.location.replace("./user.html");
                    window.localStorage.setItem('usuario', username)
                } else {
                    $("#error").css("display", "block");
                }
            }
        })
    }
}

$('#addUser').click(function addUser() {
    if (($('#username').val() !== "") && ($('#firstname').val() !== "") && ($('#surname').val() !== "") && ($('#passwd').val() !== "")) {
        var $email = null
        var $phone = null
        if ($('#email').val() !== "") {
            $email = $('#email').val()
        }
        if ($('#phone').val() !== "") {
            $phone = $('#phone').val()
        }

        $.ajax({
            url: 'https://localhost:44355/usuario',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify({
                "username": $('#username').val(),
                "firstname": $('#firstname').val(),
                "surname": $('#surname').val(),
                "email": $email,
                "phone": parseInt($phone),
                "passwd": $('#passwd').val()
            }),
            success: function (data, status) {
                alert("Usuario creado correctamente")
                location.reload();
            },
            error: function (data, status) {
                alert("No se ha podido crear el usuario")
            }
        });
    } else {
        alert("Campos obligatorios no relleneados")
    }

});