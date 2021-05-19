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