$(document).ready(function () {
    loadPosition();
})

function loadPosition() {
    $.ajax({
        url: '/api/v1/Positionals',
        method: 'GET'
    }).done(function (res) {
        $('#positionalId').empty();
        $.each(res, function (index, obj) {
            $('#positionalId').append(`<option value="${obj.positionalId}">${obj.positionalName}</option>`);
        })
    }).fail(function (res) {

    })
}