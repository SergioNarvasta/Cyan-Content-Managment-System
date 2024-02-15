
function onSubmitLogin() {
    let form = "";
    $.ajax({   
        type: "POST",
        url: "/Identity/Login",
        data: { form },
        success: function (response) {
            $('#resultado').html('');
            $('#resultado').html(response);
        }
    });
}