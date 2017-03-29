
function injectList(url) {
    $.ajax({
        url: url,
        type: 'get',
        success: function (result) {
            $("#injectHere").html(result);
        }
    })
}
