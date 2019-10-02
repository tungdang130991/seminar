const enovateValidator = function() {
    function rebuildValidation(formId) {
         var form = $('#' + formId)
            .removeData("validator")
            .removeData("unobtrusiveValidation"); 
            $.validator.unobtrusive.parse(form);
    }
    return {
        rebuildValidation: rebuildValidation
    }
}();