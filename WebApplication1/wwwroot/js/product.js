 var dataTable;
$(document).ready(function () {
    loaddatatabe();
});
function loaddatatable() {
    dataTable = $('#table_id').DataTable({
        "ajax": {
            "url": "/admin/Product/Getall",
      
            "type": "GET",

            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
        ]
    });
}