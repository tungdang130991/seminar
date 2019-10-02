const school = function () {
    function saveNewSchool() {
                $.ajax({
                    url: "/Admin/School/Insert",
                    type: "POST",
                    data: $('#school_form').serialize(),
                    success: function (response) {
                        console.log('Save successfully');
                        if (response.html != "") {
                        var tableBody = $('#table_schools');
                            tableBody.html(response.html);
                            enovateValidator.rebuildValidation('school_form');
                            document.getElementById("btn_insert").disabled = false;
                        }
                        if (response.status === ResultCode.Ok) {
                            $('#dialog_infor_content').text(response.message);
                            $('#dialog_infor').modal();
                            console.log('Save successfully');
                        } else {
                            $('#dialog_infor_content').text(response.message);
                            $('#dialog_infor').modal();
                            console.log('Saving fail');
                        }
                    }
                });
    }
    
    function showpopupsave(control,idschool,textlocation) {
        if ($('#school_form').valid()) {
            $("#dialog_confirm_save").modal();
            switch (control) {
                case 0:
                    $('#dialog_confirm_save button.btn.btn-primary').attr('onclick', 'school.saveNewSchool();');
                    $('#dialog_confirm_save div.modal-body').text(textlocation);
                    break;
                case 1:
                    $('#dialog_confirm_save button.btn.btn-primary').attr('onclick', 'school.edit(' + idschool + ');');
                    $('#dialog_confirm_save div.modal-body').text(textlocation);
                    break;
                case 2:
                    $('#dialog_confirm_save button.btn.btn-primary').attr('onclick', 'school.remove(' + idschool + ');');
                    $('#dialog_confirm_save div.modal-body').text(textlocation);
                    break;
            }
        }
        if (control == 3) {
            $("#dialog_confirm_save").modal();
            $('#dialog_confirm_save button.btn.btn-primary').attr('onclick', 'school.cancel();');
            $('#dialog_confirm_save div.modal-body').text(textlocation);
        }
    }
 
    function edit(schoolCode) {
            $.ajax({
                url: "/Admin/School/Update",
                type: "POST",
                data: $('#school_form').serialize() + "&id=" + schoolCode,
                success: function (response) {
                    if (response.html != "") {
                    var tableBody = $('#table_schools');
                        tableBody.html(response.html);
                        document.getElementById("btn_insert").disabled = false;
                        enovateValidator.rebuildValidation('school_form');
                    }
                    if (response.status === ResultCode.Ok) {
                        $('#dialog_infor_content').text(response.message);
                        $('#dialog_infor').modal();
                        console.log('Save successfully');
                    } else {
                        $('#dialog_infor_content').text(response.message);
                        $('#dialog_infor').modal();
                        console.log('Saving fail');
                    }
                    
                }
            });
    }

    function remove(idsch) {
        $.ajax({
            url: "/Admin/School/Delete",
            type: "POST",
            data: "ids=" + idsch,
            success: function (response) {
                if (response.html != "") {
                var tableBody = $('#table_schools');
                tableBody.html(response.html);
                enovateValidator.rebuildValidation('school_form');
                }
                if (response.status === ResultCode.Ok) {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                    console.log('Delete successfully');
                } else {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                    console.log('Delete fail');
                }
            }
        });
    }
    function cancel() {
        document.getElementById("btn_insert").disabled = false;
        $.ajax({
            type: 'Get',
            url: '/Admin/School/LoadTable',
            success: function (response) {
                var tableBody = $('#table_schools');
                tableBody.html(response.htmlform);
                enovateValidator.rebuildValidation('school_form');
            }
        });
    }

    function createRowForNewSchool() {
        $.ajax({
            type: 'Get',
            url: '/Admin/School/New',
            success: function (response) {
                if (response.status === ResultCode.Ok) {
                    console.log('Save successfully');
                    var tableBody = $('#table_school_body');
                    tableBody.find('button').prop("disabled", true);
                    document.getElementById("btn_insert").disabled = true;
                    tableBody.html(response.html + tableBody.html());
                    enovateValidator.rebuildValidation('school_form');
                } else {
                    console.log('Saving fail');
                }
            }
        });
    }

   
    function getEditingHtml(schoolCode) {
        console.log(schoolCode);
        $.ajax({
            type: 'Get',
            url: '/Admin/School/Edit?code=' + schoolCode,
            success: function (response) {
                if (response.status === ResultCode.Ok) {
                    console.log('Save successfully');
                    document.getElementById("btn_insert").disabled = true;
                    var tablebody = $('#table_school_body');
                    tablebody.find('button').prop("disabled", true);
                    $('#' + response.schoolCode).html(response.html);
                    enovateValidator.rebuildValidation('school_form');
                } else {
                    console.log('Saving fail');
                }
            }
        });
    }
    return {
        edit: edit,
        saveNewSchool: saveNewSchool,
        createRowForNewSchool: createRowForNewSchool,
        getEditingHtml: getEditingHtml,
        remove: remove,
        cancel: cancel,
        showpopupsave: showpopupsave,
    }
}();