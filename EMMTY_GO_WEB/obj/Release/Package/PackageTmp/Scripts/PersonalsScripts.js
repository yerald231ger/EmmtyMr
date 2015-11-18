$(document).ready(function () {


    //Oculta y muestra un elemento
    //$("#VerOcultar").click(function () {
    //    $("#NSCajeroTB").toggle();
    //});

    //var hasBeenModify = false;
    //$("#NSCajeroTB").click(function () {
    //    if (hasBeenModify)
    //        $(this).val() == $(this).val();
    //    else
    //        $(this).val(null);
    //})

    //$("#NSCajeroTB").focusout(function () {
    //    if ($(this).val() == "") {
    //        hasBeenModify = false;
    //        $(this).val("Buscar por NSCajero");
    //    }    })

    //Este es el jquery ajax para actualizar la busqueda en la lista de cajeros
    // (Nota*: Este metodo remplasa el elemento que que precede a .replaceWith por lo que es necesario reescribirlo en la vista que se renderizara)
    //$("#NSCajeroTB").keyup(function () {
    //    hasBeenModify = true;
    //    var str = $(this).val();
    //    $.ajax({
    //        url: "Cajero/FindCajero/", data: { NSCajero: str }, success: function (result) {
    //            $("#divTableCajero").replaceWith(result);
    //        }
    //    });
    //});

    //Este es el jquery ajax para actualizar la busqueda en la lista de cajeros
   

    $("#showModal").click(function () {
        ShowLoginModal();
    });

    function ShowLoginModal() {
        var path = location.protocol + "//" + location.host + "/Account/PartialLogin/";

        $("#modal_PartialLogin_id").load(path, function (response, status, xhr) {
            $("#modal_PartialLogin_id").modal("show");
        });
    }
    
});