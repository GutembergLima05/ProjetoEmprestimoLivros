$(document).ready(function () {

    $('#Emprestimos').DataTable({
        language:
        {
            "decimal": "",
            "emptyTable": "Nenhum cadastro realizado",
            "info": "Mostrando _START_ registro de _END_ em um total de _TOTAL_ entradas",
            "infoEmpty": "Mostrando _START_ registro de _END_ em um total de _TOTAL_ entradas",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 3000)

});