$(document).ready(function () {
    loadDepartment();
})

function loadDepartment() {
    $.ajax({
        url: '/api/v1/Departments',
        method: 'GET'
    }).done(function (res) {
        $('#departmentId').empty();
        $.each(res, function (index, obj) {
            $('#departmentId').append(`<option value="${obj.departmentId}">${obj.departmentName}</option>`);
        })

    }).fail(function (res) {

    })
}