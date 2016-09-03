$(function () {
    $(".numericOnly").keypress(function (e) {
        var charCode = (e.which) ? e.which : e.keyCode;
        // Added to allow decimal, period, or delete
        if (charCode == 110 || charCode == 190) // || charCode == 46   remove form end 
            return true;

        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });
});

// to display the pop-up for create and edit case
function GetPopUp(id, requestUrl, title, action) {

    ShowProgress();

    var sendInfo = {
        id: id
    };
    $.ajax({
        type: "GET",
        dataType: "html",
        url: requestUrl,
        data: sendInfo,
        success: function (data) {
            var div = $('#DivBody');
            $.fx.speeds._default = 500;
            div.html(data).dialog({
                height: 'auto',
                width: '820px',
                modal: true,
                show: "drop",
                hide: "fold",
                close: function (event, ui) {
                    $("pop").dialog('destroy');
                }
            });
            HideProgress();
            $('#ui-id-1').text(title);
        }

    });
}

function ShowProgress() {

    $(".loader-gb").css("display", "block");
    $("#divajaxload").show();
}

function HideProgress() {

    $("#divajaxload").hide();
    $(".loader-gb").css("display", "none");
}

function ClosePopUp() {
    $('#DivBody').dialog('close');

}