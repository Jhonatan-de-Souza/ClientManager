$(document).ready(function () {
$(".dataField").each(function () {

    $(this).datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd-mm-yy',
        yearRange: startDateRange + ":" + endDateRange
    });
});

var table = $('#example').DataTable({
    
    buttons: [{ extend: 'excel', text: 'Baixar Excel' }, { extend: 'pdf', text: 'Baixar Pdf' }, { extend: 'colvis', text: 'Selecionar Colunas' }],
    "language": {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ Resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": ">",
            "sPrevious": "<",
            "sFirst": "<<",
            "sLast": ">>"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});
table.buttons().container()
    .insertBefore('#example_filter');
        });
$("#FilterDataBtn").on('click',
    function (e) {
        $("#PeopleReportForm").submit();
    });
$("#CleanFilterBtn").on('click',
    function (e) {
        $("#PeopleReportForm").submit();
    });