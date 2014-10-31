$(function () {
    $('#dialogDiv').on('hidden.bs.modal', function () {
        $(this).removeData('modal');
    });

    //Optional: turn the chache off
    $.ajaxSetup({ cache: false });
    $('a#btnCreate').click(function () {
        
        if (window.mobilecheck())
            return true;
        var target = this.getAttribute('targetList');
        $('#dialogContent').load(this.href, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');

            //$('.switch').bootstrapSwitch();
            bindForm(this, target);
        });

        return false;
    });

    $('a#btnEdit').click(function () {
        if (window.mobilecheck())
            return true;
        var target = this.getAttribute('targetList');
        $('#dialogContent').load(this.href, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');

            $(".nscroller").nanoScroller();
            bindForm(this, target);
        });
        return false;
    });

    $('a#btnRemove').click(function () {
        var url = this.href;
        var target = this.getAttribute('targetList');
        bootbox.confirm(this.getAttribute('msg'), function (result) {
            if (result) {
                $.ajax({
                    url: url,
                    type: 'post',

                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success || result.Result) {
                            $('#dialogDiv').modal('hide');
                            SuccessCallback(result, target);
                        }
                        bootbox.alert(result.Message);
                    }
                });
                //return false;
            }
        });
        return false;
    });

    
});

function progressHandlingFunction(e) {
    if (e.lengthComputable) {
        //$('progress').attr({ value: e.loaded, max: e.total });
    }
}

function ValidateImages(frm) {

}

function bindForm(dialog, target) {
    $(".datetime").datetimepicker({ format: 'dd-mm-yyyy hh:mm:ss', todayBtn: true, showMeridian: true });
    $('form', dialog).ajaxForm({ // initialize the plugin
        // any other options,
        beforeSubmit: function () {
            return $('form', dialog).parsley('validate');
            //return $('form').parsley('validate'); // $("#myForm").valid(); // TRUE when form is valid, FALSE will cancel submit
        },
        success: function (result) {
            if (result.success || result.Result) {
                $('#dialogDiv').modal('hide');
                SuccessCallback(result, target);
                bootbox.alert(result.Message);

            } else {
                $('#dialogContent').html(result);
                bindForm();
            }
        }
    });

    $(".nscroller").nanoScroller();
}

function bindFormInner(container) {

    $('form', '#' + container).ajaxForm({ // initialize the plugin
        // any other options,
        beforeSubmit: function () {
            return $('form', '#' + container).parsley('validate'); // $("#myForm").valid(); // TRUE when form is valid, FALSE will cancel submit
        },
        success: function (result) {
            if (result.success || result.Result) {
                $('#dialogDiv').modal('hide');
                SuccessCallback(result);
                bootbox.alert(result.Message);

            } else {
                $('#dialogContent').html(result);
                bindForm();
            }
        }
    });

//    $('form', dialog).submit(function () {
//        var res = $('form').parsley('validate');
//        if (!res) return false;
//        $.ajax({
//            url: this.action,
//            type: this.method,
//            data: $(this).serialize(),
//            success: function (result) {
//                if (result.success || result.Result) {
//                    $('#dialogDiv').modal('hide');
//                    SuccessCallback(result);
//                    bootbox.alert(result.Message);

//                } else {
//                    $('#dialogContent').html(result);
//                    bindForm();
//                }
//            }
//        });
//        return false;
//    });
    $(".nscroller").nanoScroller();
}

function wizardGoNext(ctrl) {
    var id = ctrl.getAttribute('data-wizard');
    $(id).wizard('next');
    return false;
}
function wizardGoPrev(ctrl) {
    var id = ctrl.getAttribute('data-wizard');
    $(id).wizard('previous');
    return false;
}

