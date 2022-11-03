
    $(function () {
        $("#DepartmentId").change(function () {
            $.getJSON("/Employee/getDesinationList", { dId: $("#DepartmentId").val() }, function (d) {
                var row = "";
                console.log("Hello");
                $("#DesignationId").empty();
                $.each(d, function (i, v) {
                    console.log("12");
                    console.log(v);
                    row += "<option value=" + v.value + ">" + v.text + "</option>";
                });
                $("#DesignationId").html(row);
            })
        })
    //    $("#ddlstate").change(function () {
    //    $.getJSON("/Home/GetCitylist", { Sid: $("#ddlstate").val() }, function (d) {
    //        var row = "";
    //        $("#ddlcity").empty();
    //        $.each(d, function (i, v) {
    //            row += "<option value=" + v.value + ">" + v.text + "</option>";
    //        });
    //        $("#ddlcity").html(row);
    //    })
    //})
    })
