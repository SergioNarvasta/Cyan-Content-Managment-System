
$(document).ready(function () {
    getCompaniesbyUser();
});

function getCompaniesbyUser() {
    $.ajax({
        url: 'Company/GetCompaniesByUser',
        method: 'GET',
        success: function (response) {
            
        },
        error: function (xhr, status, error) {
            console.error('Error en getCompaniesbyUser:', error);
        }
    });
}
function onSubmitLogin() {
    let formData = $("#loginForm").serialize(); 

    $.ajax({
        type: "POST",
        url: "Identity/Login", 
        data: formData, 
        success: function (data) {
            if (data.Response.status) {
                toastr.success(data.Response.message);
                location.reload();
            } else {
                toastr.error(response.message);
            }
        }
    });
}