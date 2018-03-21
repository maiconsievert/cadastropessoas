(function($) {


    $(".form-signin").submit(function(e){

        e.preventDefault();

        var loginData = {
            grant_type: 'password',
            username: $("#login").val(),
            password: $("#senha").val()
        };
        
        $.ajax({
            type: 'POST',
            url: 'http://localhost:58050/token',
            //headers: { "Accept": "application/json" },
            //contentType: "application/x-www-form-url; charset=urf-8",
            data: loginData
        }).done(function (data) {

            
            localStorage.setItem('usuarioatual', JSON.stringify({ token: data.access_token, name: loginData.username }));
            
            $(".login").hide();
            $(".listagempessoas").fadeIn(200);

            ConsultaPessoas();

        }).fail(function(data) {
            $(".alert").fadeIn(200);
        });

    });

    function ConsultaPessoas() {

        var usuarioatual = JSON.parse(localStorage.getItem('usuarioatual'));
        var token = usuarioatual.token;

        $.ajax({
            type: 'GET',
            url: 'http://localhost:58050/api/listarpessoas',
            headers: { "Authorization": "Bearer " + token },
            crossOrigin: true
        }).done(function (data) {

            $(".carregando").hide();
            
            Listagem(data);

        }).fail();


    }

    function Listagem(data) {


        new Vue({
            el: "#app",
            data: {
                itens: data
            }
        });

        


    }

    $(document).ready(function () {
   

    });

})(jQuery);



