$(document).ready(function () {
    $('ErrorDialog').dialog({
        autoOpen: false,
        width: 500,
        modal: true,
        resizable: false,
        "Submit": function () {
            $(".ui-dialog-buttonpane button:contains('Submit')").button("disable");
            $(".ui-dialog-buttonpane button:contains('Edit')").button("disable");
            document.ConnectForm.Submit();
        },
        "Edit": function () {
            $(this).dialog("close");
        },

    })

});