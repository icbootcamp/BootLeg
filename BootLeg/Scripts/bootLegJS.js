function popShow(result, saveText, modalText) {
    $("#edit-student-form").html(result);

    $(".close-btn").html("Cancel");
    $(".save-changes-btn").html(saveText);

    $(".modal-title").text(modalText);
    $("#craigs-model").modal("show");
}
function popHide(result, saveText, modalText) {
    $(".modal-title").val("");
    $("#craigs-model").modal("hide");
}
function saveUpdatePopup(url1, thisId, saveText, modalText, url2, reloadAction) {
    $.ajax({
        url: url1,
        type: 'post',
        data: { Id: thisId },
        success: function (result) {
            popShow(result, saveText, modalText);
            $(".save-changes-btn").click(
                function () { saveUpdateBtnClick(url2, reloadAction) })
        }

    })
}
function saveUpdateBtnClick(actionUrl, reloadAction) {
    var x = $("#edit-student-form").serialize();
    $.ajax(
            {
                url: actionUrl,
                type: 'post',
                data: x,
                success: function (result) {
                    popHide();
                    reloadAction();
                }
            }
        )
}

function removeComfirm(ActionUrl, thisId, ActionFunction) {
    {
        if (confirm('Confirm to delete?')) {
            removeBtnClick(ActionUrl,thisId, ActionFunction);
            return true;
        } return
            alert("Canceled");
            false;
    }
}
function removeBtnClick(ActionUrl,thisId, ActionFunction){

    $.ajax({
        url: ActionUrl,
        type: 'post',
        data: { Id: thisId },
        success: function (result) {
            ActionFunction()
        }
    })
}