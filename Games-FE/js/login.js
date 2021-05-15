$(document).ready(function(){
    $("#go").click(function(){
        var username = $("#login").val().trim();
        var passwd = $("#password").val().trim();

        if( username != "" && password != "" ){
            $.ajax({
                url: 'https://localhost:44355/login',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json',
                data: JSON.stringify({username:username,passwd:passwd}),
                success: function(data, status){
                    //alert("Data: " + data + "\nStatus: " + status);
                    if(data){ 
                        window.location.replace("./home_page.html");
                    } else {
                        $("#error").css("display","block");
                    }
				}
            })
        }
    });
});