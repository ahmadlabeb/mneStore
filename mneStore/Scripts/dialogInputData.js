$(document).ready(function () {
    var urlBrands = '/items/sendBrand';
    var urlsendUnitItems = '/items/sendUnitItems';
    // var form = $("theFormBrand").serialize();
    // var formkinds=$("theFormKinds").serialize();
    $("#markup").click(function () {
        $("#dialog-mark").dialog({
            autoOpen: true,
            resizable: false,
            width: 500,
            height: 180,
            title: "الماركة",
            buttons: {
                "انشاء": function () {
                    $.ajax({
                        url: urlBrands,
                        method: "POST",
                        //dataType: "json",
                        data: { nameBrand: $("#nameBrand").val() },
                        success: function (data) {
                            let nameBarnds = $("#nameBrand").val();
                            if (nameBarnds === '' || nameBarnds == NaN || nameBarnds === isNaN()) {
                                UIkit.notification({
                                    message: 'من فضلك ادخل الماركة',
                                    status: 'danger',
                                    pos: 'top-right',
                                    timeout: 5000
                                });

                            } else {

                                UIkit.notification({
                                    message: 'تم التخزين الماركة بنجاح',
                                    status: 'success',
                                    pos: 'top-right',
                                    timeout: 5000
                                });
                                $("#dialog-mark").dialog("close");

                            }
                            //if (data.success) {
                            //} else {
                            //    console.log(data.message);
                            //}

                        }
                    }).fail(function () {
                        alert("error");
                    })
                        .always(function () {
                            //alert("complete");
                            

                        });
                },
                "اغلاق": function () {
                    $(this).dialog("close");
                }
            }

            //close: function () {
            //    pubop.dialog("destroy").remove();
            //}
        });
    });
    $("#unitDialog").click(function () {
        $("#dialog-NameUnit").dialog({
            autoOpen: true,
            resizable: false,
            width: 500,
            height: 200,
            title: "الوحدة",
            buttons: {
                "انشاء": function () {
                    $.ajax({
                        url: urlsendUnitItems,
                        method: "POST",
                        data: { NameUnit: $("#NameUnit").val() },
                        success: function (data) {
                            $("#dialog-NameUnit").dialog("close");
                        }
                    }).done(function (msg) {
                        console.log("data saved : " + msg);
                        UIkit.notification({
                            message: 'تم التخزين الوحدة بنجاح',
                            status: 'success',
                            pos: 'top-left',
                            timeout: 3000
                        });
                    });
                },
                "اغلاق": function () {
                    $(this).dialog("close");
                }
            }
        });
    });
});