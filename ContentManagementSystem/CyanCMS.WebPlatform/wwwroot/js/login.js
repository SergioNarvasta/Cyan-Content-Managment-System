

function onSubmitLogin() {
    let formData = $("#loginForm").serialize(); 

    $.ajax({
        type: "POST",
        url: "Identity/Login", 
        data: formData, 
        success: function (response) {
            if (response.status) {
                toastr.success(response.message);
                location.href="Home/Index"
            } else {
                toastr.error(response.message);
            }
        }
    });
}