

function onSubmitLogin() {
    let formData = $("#loginForm").serialize(); 

    $.ajax({
        type: "POST",
        url: "Identity/Login", 
        data: formData, 
        success: function (response) {
            if (response.status) {
                // toast.success(response.message);
                location.href="Home/Index"
            } else {
                // toast.error(response.message);
            }
        }
    });
}