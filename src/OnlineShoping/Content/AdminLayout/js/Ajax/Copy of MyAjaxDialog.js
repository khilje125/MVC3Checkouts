$(function () {
    //Optional: turn the chache off
    $.ajaxSetup({ cache: false });
    $('#btnCreate').click(function () {
        $('#dialogContent').load(this.href, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');
            
            $(".nscroller").nanoScroller();
            bindForm(this);
        });
        return false;
    });

    $('a#btnEdit').click(function () {
        $('#dialogContent').load(this.href, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');

            $(".nscroller").nanoScroller();
            bindForm(this);
        });
        return false;
    });

    $('a#btnRemove').click(function () {
        var url = this.href;
        bootbox.confirm(this.getAttribute('msg'), function (result) {
            if (result) {
                $.ajax({
                    url: url,
                    type: 'post',
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success || result.Result) {
                            $('#dialogDiv').modal('hide');
                            SuccessCallback(result);
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

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success || result.Result) {
                    $('#dialogDiv').modal('hide');
                    SuccessCallback(result);
                    bootbox.alert(result.Message);

                    // Refresh:
                    // location.reload();
                } else {
                    $('#dialogContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}
$(document).ready(function () {
    debugger;
    $.ajaxSetup({ cache: false });
    if ($("#openDialog").live) {
        $("#openDialog").live("click", function (e) {
            e.preventDefault();
            var url = $(this).attr('href');

            $("#myDialog").dialog({
                title: '',
                id: 'myDialog',
                autoOpen: false,
                resizable: false,
                position: ['center', 'top'],
                //height: 355,
                //width: 400,
                show: { effect: 'drop', direction: "up", closeBtn: "none" },
                modal: true,
                draggable: true,
                open: function (event, ui) {
                    $("#overlay").show();
                    $("#myDialog").fadeIn(300);
                    $(this).load(url);
                }
            });
            $("#myDialog").dialog('open');
            return false;
        });
    }

    if ($("#btncancel").live) {
        $("#btncancel").live("click", function (e) {
            $("#myDialog").dialog('close');
            $("#overlay").hide();
            $("#myDialog").fadeOut(300);
        });
    }

    if ($("#alert-dialog").dialog) {
        $("#alert-dialog").dialog({
            title: '',
            id: 'AlertDialog',
            autoOpen: false,
            resizable: false,
            //height: 355,
            //width: 400,
            show: { effect: 'drop', direction: "up", closeBtn: "none" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $("#overlay").show();
                $("#alert-dialog").fadeIn(300);
            }
        });
    }

    if ($("#btnCloseAlert").live) {
        $("#btnCloseAlert").live("click", function (e) {
            $("#alert-dialog").dialog('close');
            $("#overlay").hide();
            $("#alert-dialog").fadeOut(300);
        });
    }
});
function Alert(msg) {
    var dlg = $('#alert-dialog');
    dlg.html("<div class=\"block-flat\"> <div class=\"header\"> <h3>Message</h3> </div> <div class=\"content\"><p>" + msg + "</p><input type=\"button\" value=\"Ok\" id=\"btnCloseAlert\" class=\"btn btn-primary\" /></div></div>");

    //$("#myDialog").dialog('close');
    //$("#overlay").hide();
    //$("#myDialog").fadeOut(300);

    dlg.dialog('open');
}

function wizardGoNext(ctrl) {
    var id = ctrl.getAttribute('data-wizard');
    debugger;
    $(id).wizard('next');
    return false;
}
function wizardGoPrev(ctrl) {
    var id = ctrl.getAttribute('data-wizard');
    $(id).wizard('previous');
    return false;
}

//function SuccessCallback(data) {
//    if (data.Result == true) {

//        if (data.Action == "add") {
//            $('#Itemslist tr:last').after(data.Data);
//        }
//        else if (data.Action == "update") {
//            var item = $("#" + data.ID)[0];
//            item.innerHTML = data.Data;
//        }
//        else if (data.Action == "remove") {
//            var item = $("#" + data.ID)[0];
//            item.remove();
//        }
//        $("#myDialog").dialog('close');
//        $("#overlay").hide();
//        $("#myDialog").fadeOut(300);
//    }
//}
