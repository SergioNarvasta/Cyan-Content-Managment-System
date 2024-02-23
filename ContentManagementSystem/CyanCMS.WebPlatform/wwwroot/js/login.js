

function onSubmitLogin() {
    let formData = $("#loginForm").serialize(); 

    $.ajax({
        type: "POST",
        url: "Identity/Login", 
        data: formData, 
        success: function (response) {
            if (response.status) {
                alert(response.message);
                // toastr.success(response.message);
                location.reload();
            } else {
                alert(response.message);
                // toastr.error(response.message);
            }
        }
    });
}