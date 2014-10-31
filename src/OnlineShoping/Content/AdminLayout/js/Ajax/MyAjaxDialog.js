
$(function() {
    init_events();
});
var selectedInput = null;
function InsertPlaceholder(value) {
    if (selectedInput && (selectedInput.id == "Subject" || selectedInput.id == "Body")) {
        //insertAtCaret(selectedInput.id, '@Model.' + value);
        var txtarea = selectedInput;
        var text = '@Model.' + value;

        var scrollPos = txtarea.scrollTop;
        var strPos = 0;
        var br = ((txtarea.selectionStart || txtarea.selectionStart == '0') ?
            "ff" : (document.selection ? "ie" : false));
        if (br == "ie") {
            txtarea.focus();
            var range = document.selection.createRange();
            range.moveStart('character', -txtarea.value.length);
            strPos = range.text.length;
        }
        else if (br == "ff") strPos = txtarea.selectionStart;

        var front = (txtarea.value).substring(0, strPos);
        var back = (txtarea.value).substring(strPos, txtarea.value.length);
        txtarea.value = front + text + back;
        strPos = strPos + text.length;
        if (br == "ie") {
            txtarea.focus();
            var range = document.selection.createRange();
            range.moveStart('character', -txtarea.value.length);
            range.moveStart('character', strPos);
            range.moveEnd('character', 0);
            range.select();
        }
        else if (br == "ff") {
            txtarea.selectionStart = strPos;
            txtarea.selectionEnd = strPos;
            txtarea.focus();
        }
        txtarea.scrollTop = scrollPos;
    }
    //selectedInput.value += '@Model.' + value;
}
function init_events() {
    $("form").delegate("input:text, textarea", "click focus", function () {
        var elem = $(this);
        setTimeout(function () {
            selectedInput = elem[0];
        }, 10);
    });
    $("a#btnEditDialog").unbind("click");
    $('a#btnEditDialog').on('click', function () {
        var $modal = $('#' + this.getAttribute('container'));
        var $target = this.getAttribute('target');
        // create the backdrop and wait for next modal to be triggered
        $('body').modalmanager('loading');
        var url = this.href;
        setTimeout(function () {
            $modal.load(url, '', function () {
                $modal.modal();
                bindForm(this, $modal, $target);
                init_events();
            });
        }, 1000);
        return false;
    });

    $("a#btnRemove").unbind("click");
    $('a#btnRemove').click(function () {
        var url = this.href;
        var target = this.getAttribute('target');//targetList
        bootbox.confirm(this.getAttribute('msg'), function (result) {
            if (result) {
                $.ajax({
                    url: url,
                    type: 'post',

                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success || result.Result) {
                            
                            $('#dialogDiv').modal('hide');
                            DialogSuccessCallback(result, target);
                        }
                        bootbox.alert(result.Message);
                    }
                });
                //return false;
            }
        });
        return false;
    });

    $("a#btnEmail").unbind("click");
    $('a#btnEmail').click(function () {
        var url = this.href;
        $('body').modalmanager('loading');
        $.ajax({
            url: url,
            type: 'post',

            data: $(this).serialize(),
            success: function (result) {
                if (result.success || result.Result) {

                }
                bootbox.alert(result.Message);
            }
        });
        return false;
    });
}

$(function () {
    $('#dialogDiv').on('hidden.bs.modal', function () {
        $(this).removeData('modal');
    });

    ////Optional: turn the chache off
    //$.ajaxSetup({ cache: false });
    //$('a#btnCreate').click(function () {
        
    //    if (window.mobilecheck())
    //        return true;
    //    var target = this.getAttribute('targetList');
    //    $('#dialogContent').load(this.href, function () {
    //        $('#dialogDiv').modal({
    //            backdrop: 'static',
    //            keyboard: true
    //        }, 'show');

    //        //$('.switch').bootstrapSwitch();
    //        bindForm(this, target);
    //        initInnerDialog();
    //    });

    //    return false;
    //});

    //$('a#btnEdit').click(function () {
    //    if (window.mobilecheck())
    //        return true;
    //    var target = this.getAttribute('targetList');
    //    $('#dialogContent').load(this.href, function () {
    //        $('#dialogDiv').modal({
    //            backdrop: 'static',
    //            keyboard: true
    //        }, 'show');

    //        //$(".nscroller").nanoScroller();
    //        bindForm(this, target);
    //    });
    //    return false;
    //});

    

    
});

//function initInnerDialog() {
//    $('a#btnCreateInner').click(function () {

//        //if (window.mobilecheck())
//        //    return true;
//        var target = this.getAttribute('targetList');
//        $('#dialogContentInner').load(this.href, function () {
//            $('#dialogDivInner').modal({
//                backdrop: 'static',
//                keyboard: true
//            }, 'show');

//            //$('.switch').bootstrapSwitch();
//            bindForm(this, target);
//        });

//        return false;
//    });
//}

function progressHandlingFunction(e) {
    if (e.lengthComputable) {
        //$('progress').attr({ value: e.loaded, max: e.total });
    }
}

function ValidateImages(frm) {

}

function bindForm(dialog, dialogBox, target) {
    $(".datetime").datetimepicker({ format: 'dd-mm-yyyy hh:mm:ss', todayBtn: true, showMeridian: true });
    $('form', dialog).ajaxForm({ // initialize the plugin
        // any other options,
        beforeSubmit: function () {
            return $('form', dialog).parsley('validate');
            //return $('form').parsley('validate'); // $("#myForm").valid(); // TRUE when form is valid, FALSE will cancel submit
        },
        success: function (result) {
            if (result.success || result.Result) {
                //$('#dialogDiv').modal('hide');
                dialogBox.modal('hide'); 
                DialogSuccessCallback(result, target);
                bootbox.alert(result.Message);
                init_events();
                App.init({}, '#dialog-container');

            } else {
                dialog.innerHTML = result;
                //$('#dialogContent').html(result);
                bindForm(dialog, dialogBox, target);
            }
            
        }

    });
    //$(".nscroller").nanoScroller();
}

//function bindFormInner(container) {

//    $('form', '#' + container).ajaxForm({ // initialize the plugin
//        // any other options,
//        beforeSubmit: function () {
//            return $('form', '#' + container).parsley('validate'); // $("#myForm").valid(); // TRUE when form is valid, FALSE will cancel submit
//        },
//        success: function (result) {
//            if (result.success || result.Result) {
//                $('#dialogDiv').modal('hide');
//                SuccessCallback(result);
//                bootbox.alert(result.Message);

//            } else {
//                $('#dialogContent').html(result);
//                bindForm();
//            }
//        }
//    });

////    $('form', dialog).submit(function () {
////        var res = $('form').parsley('validate');
////        if (!res) return false;
////        $.ajax({
////            url: this.action,
////            type: this.method,
////            data: $(this).serialize(),
////            success: function (result) {
////                if (result.success || result.Result) {
////                    $('#dialogDiv').modal('hide');
////                    SuccessCallback(result);
////                    bootbox.alert(result.Message);

////                } else {
////                    $('#dialogContent').html(result);
////                    bindForm();
////                }
////            }
////        });
////        return false;
////    });
//    //$(".nscroller").nanoScroller();
//}

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

function DialogSuccessCallback(data, target) {
    
    if (data.Result == true) {
        if (target != null){//} || target != "Group_ID") {
            if (data.Action == "add") {
                var tbl = $("#" + target);
                tbl.append(data.Data);
            } else if (data.Action == "update") {
                var item = data.ID != null ? $("#" + data.ID, "#" + target)[0] : $("#" + target)[0];
                item.innerHTML = data.Data;
            } else if (data.Action == "remove") {
                var item = $("#" + data.ID, "#" + target)[0];
                item.remove();
            }
        } else {
            location.reload();
            //var lst = $('#' + target)[0];
            //lst.innerHTML = lst.innerHTML + data.Data;
            //
        }
    }
    init_events();
}
