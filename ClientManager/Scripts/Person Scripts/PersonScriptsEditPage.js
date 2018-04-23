/* Formatando o datepicker para datas brasileiras */
$(document).ready(function () {

    $("#Birthdate").each(function () {

        $(this).datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd-mm-yy',
            yearRange: startDateRange + ":" + endDateRange
        });
    });
/* Aplicando mascara no formato brasileiro */
    $("#Phone1").inputmask("mask", { "mask": "(99) 9999-9999[9]", greedy: false });
    $("#Birthdate").inputmask("mask", { "mask": "99-99-9999", greedy: false });
/* Controlar Cadastro de RG baseado no UF */
    if ($("#Uf").val() == "SC") {
        $("#rgInput").show();
    } else {
        $("#rgInput").hide();
    }
    
    $("#Uf").on("change",
        function () {
            if ($("#Uf").val() == "SC") {
                $("#rgInput").show();
                $("#Rg").prop('required', true);
            } else {
                $("#rgInput").hide();
                $("#Rg").prop('required', false);
            }
        });
});