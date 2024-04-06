
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
        success: function (response) {
            if (response.status) {
                // alert(response.message);
                toastr.success(response.message);
                location.reload();
            } else {
                // alert(response.message);
                toastr.error(response.message);
            }
        }
    });
}