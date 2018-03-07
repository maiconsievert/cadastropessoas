$(document).ready(function () {

    $('#Cpf').mask('000.000.000-00', { placeholder: "___.___.___-__" });
    $('#DataNascimento').mask('00/00/0000', { placeholder: "__/__/____" });
    $('#Rg').attr("data-val", true).attr("data-val-required", true);

    $("#add-another").click(function () {
        $.get('/Cadastros/Telefone', function (template) {
            $(".ct").append(template);
            atualizarEventoClique();
        });
    });
    
    function atualizarEventoClique() {
        $(".remover-telefone").click(function () {
            if ($(".ct").find(".form-horizontal").length > 1)
                $(this).parent().parent().parent().remove();
        });
    }

    atualizarEventoClique();

});