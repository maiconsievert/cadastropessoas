$(document).ready(function () {

    $('#Cpf').mask('000.000.000-00', { placeholder: "___.___.___-__" });
    $('#Cnpj').mask('00.000.000/0000-00', { placeholder: "__.___.___/____-__" });
    //$('#DataNascimento').mask('00/00/0000', { placeholder: "__/__/____" });
    //$('#Rg').attr("data-val", true).attr("data-val-required", true);

    //$("#add-another").click(function () {
    //    $.get('/Cadastros/Telefone', function (template) {
    //        $(".ct").append(template);
    //        atualizarEventoClique();
    //    });
    //});
    
    //function atualizarEventoClique() {
    //    $(".remover-telefone").click(function () {
    //        if ($(".ct").find(".form-horizontal").length > 1)
    //            $(this).parent().parent().parent().remove();
    //    });
    //}

    //atualizarEventoClique();


    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $("#Tipo").val($(e.target).attr("id"));
    })



});


feather.replace();