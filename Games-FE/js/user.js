$(document).ready(function(){
	//Según se cargue el HTML, consume un servicio GET para obtener
	//Todos los usuarios y los rellena en la tabla vacía results.
	$.ajax({
        url: 'https://localhost:44355/juego',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status){
            //Por cada elemento dentro del array data, construye una fila (tr)
            //y añade celdas con los campos de cada elemento del array.
		    $.each(data, function(i, item) {
                if (item.multiplayer){
                    var $td = $('<td>').append(
                        $('<spam class="fa fa-check text-primary"></spam>')
                    )
                }else{
                    var $td = $('<td>').append(
                        $('<spam class="fa fa-times text-light"></spam>')
                    )
                }
		        var $tr = $('<tr>').append(
		            $('<td>').text(item.title),
		            $('<td>').text(item.description),
		            $('<td>').text(item.launchDate),
		            $('<td>').text(item.height),
		            $td
		        ); //.appendTo('#records_table');
		        //console.log($tr.wrap('<p>').html());
		        $('#results').append($tr);
		    });
			
      	}
    });
});

$(document).ready(function(){
	//Según se cargue el HTML, consume un servicio GET para obtener
	//Todos los usuarios y los rellena en la tabla vacía results.
	$.ajax({
        url: 'https://localhost:44355/usuario',
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function(data, status){
            $('#firstname').text(data[0].firstname)
            console.log(data)
      	}
    });
});

//Función para volver a login
function logout(){
	window.location.replace("./login.html");
}
