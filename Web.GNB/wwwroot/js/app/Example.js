//var Example = (function (){
//    return{ };
//})();

$(document).ready(function () {
    $('#dtExample').DataTable();

    //$('#btnEdit').on('click', function () {
    //    alert('Test');
    //});

    $(document).off('#btnEdit').click('#btnEdit', function () {
        //alert('Test');
        DialogPost('/Example/_PartialModalEdit', null, '#ModalDisplay', 'Test');
    });
});

