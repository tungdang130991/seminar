const tag = function () {
    function submit() {
        $('input[type=submit]').click();
    }

    function save(event) {
        event.preventDefault();
        var thisform = $('#tag_form');
        console.log(thisform.attr('method'));
        console.log(thisform.attr('action'));
        $.ajax({
            type: thisform.attr('method'),
            url: thisform.attr('action'),
            data: thisform.serialize(),
            success: function (response) {
                if (response.status === ResultCode.Ok) {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                    resetButtons();
                    console.log('Save successfully');
                } else {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                    console.log('Saving fail');
                }
            }
        });
    }

    function showSaveDialog(id) {
        if ($('#tag_form').valid())
            $('#' + id).modal();
    }

    function cancel() {
        let tagPart = resetButtons();
        $('#' + tagPart).val($('#original_data').val());
        $('#tag_form').valid();
    }

    function resetButtons() {
        let tagPart = "";
        $("textarea").each(function () {
            if ($(this).prop('readonly') === false)
                tagPart = $(this).prop('id');
        });
        showButton(tagPart);
        return tagPart;
    }

    function hideButton(tagPart) {
        $("button[id$='_edit']").each(function () {
            $(this).attr("disabled", true);
        });
        $("button[id^=" + tagPart).each(function () {
            var obj = $(this);
            if (obj.hasClass("d-none"))
                obj.removeClass("d-none");
        })
        $('#' + tagPart + '_edit').addClass("d-none");
        var textArea = $('#' + tagPart);
        textArea.attr("readonly", false);
        $('#original_data').val(textArea.val());
    }

    function showButton(tagPart) {
        $("button[id$='_edit']").each(function () {
            $(this).attr("disabled", false);
        });
        $("button[id^=" + tagPart).each(function () {
            var obj = $(this);
            if (!obj.hasClass("d-none"))
                obj.addClass("d-none");
        });
        $('#' + tagPart + '_edit').removeClass("d-none");
        $('#' + tagPart).attr("readonly", true)
    }

    return {
        submit: submit,
        save: save,
        hideButton: hideButton,
        showButton: showButton,
        cancel: cancel,
        showSaveDialog: showSaveDialog
    }
}();



