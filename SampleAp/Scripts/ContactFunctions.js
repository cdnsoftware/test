$(document).ready(function () {
    $("#MasterDisplayAsId").change(function () {
        debugger;
        var selecetdId = $(this).val();
        if (selecetdId != "") {

            var RFN = $("#FirstName").val();
            var RLN = $("#LastName").val();
            var RKN = $("#Knickname").val();


            var varDisplayAs = "";

            if (selecetdId == 1) {
                varDisplayAs = RFN + " " + RLN;
            }
            else if (selecetdId == 2) {
                varDisplayAs = RLN + " " + RFN;
            }
            else if (selecetdId == 3) {
                varDisplayAs = RKN
            }

            $("#Preview").text(varDisplayAs);
        }
        else {
            $("#Preview").text("");
        }

    });
});