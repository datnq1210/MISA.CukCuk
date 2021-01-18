class BaseJS {
    constructor() {
        this.dataUrl = null;
        this.setDataUrl();
        this.loadData();
        this.initEvent();
    }
    //Đặt giá trị cho url api.
    setDataUrl() {
    }
    /**
     * Khởi tạo các sự kiện trong trang*/
    initEvent() {
        var me = this;
        /**
         * URL api (được khởi tạo giá trị ở lớp con)
         * */
        var URL = this.dataUrl;
        /**
         * Biến action khi ấn nút [Lưu] 
         * -1: no action
         * 0 : thêm dữ liệu
         * 1 : sửa dữ liệu
         * */
        var action = -1;
        var dialog = $('.dialog-detail').dialog({
            autoOpen: false,
            modal: true,
            width: 700
        })
        //Làm mới dữ liệu khi ấn button [refesh]
        $('.btn--refesh').click(function () {
            this.loadData();
        }.bind(this));

        //Hiển thị form chi tiết khi ấn nút [Thêm nhân viên]
        $('.btn--add-emplpoyee').click(function () {
            dialog.dialog('open');
            $('.dialog-content input').val(null);
            $('.dialog-content .m-input').removeClass('border-red');
            action = 0;
            $('.btn-delete').hide();
        })

        //Đóng form chi tiết khi ấn button [Hủy]
        $('.dialog-bottom .btn-cancel').click(function () {
            dialog.dialog('close');
        })

        //Hiển thị form chi tiết khi double click vào dòng thông tin nhân viên
        $('table tbody').on('dblclick', 'tr', function () {
            dialog.dialog('open');
            action = 1;
            $('.btn-delete').show();
            $.ajax({
                url: URL + $(this).data('code'),
                method: 'GET'
            }).done(function (res) {
                console.log(res);
                for (var key in res) {
                    if (key.toLowerCase().indexOf('date') != -1) {
                        var date = new String(res[key]);
                        $(`#${key}`).val(date.substring(0, 10));
                    }
                    else
                        $(`#${key}`).val(res[key]);
                }
            }).fail(function (res) {
                console.log(res);
            })
        })


        //Kiểm tra trường nhập vào không được trống
        $('input[required]').blur(function () {
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không được phép để trống!');
                $(this).attr('validate', false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })
        //Kiểm tra email phải đúng định dạng
        $('input[type="email"]').blur(function () {
            var userinput = $(this).val();
            var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
            if (!pattern.test(userinput)) {
                $(this).addClass('border-red');
                $(this).attr('validate', false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })

        //Thêm || sửa dữ liệu khi ấn button [Lưu]
        $('.dialog-bottom .btn-save').click(function () {
            //validate dữ liệu
            var inputValidates = $('input[required], input[type="email"]');
            $.each(inputValidates, function (index, input) {
                $(input).trigger('blur');
            })
            var inputValidates = $('input[validate=false]');
            if (inputValidates && inputValidates.length > 0) {
                alert('Kiểm tra lại dữ liệu');
                inputValidates[0].focus();
                return;
            }

            var formData = $('.dialog-content').serializeArray();
            var employee = formData.reduce(function (employee, item) {
                if (!employee[item.name]) employee[item.name] = item.value;
                return employee;
            }, {})
            for (var key in employee) {
                if (employee[key] == "") delete employee[key];
            }
            if (action == 0) {
                console.log(employee);
                $.ajax({
                    url: URL,
                    method: 'POST',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    if (res.misaCode == 400) {
                        alert(res.messenger);
                    }
                    else {
                        alert(res.messenger);
                        dialog.dialog('close');
                    }
                    me.loadData();
                }).fail(function (res) {
                    alert('Thêm dữ liệu thất bại');
                })
            }
            else if (action == 1) {
                console.log(employee);
                $.ajax({
                    url: URL,
                    method: 'PUT',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    if (res.misaCode == 400) {
                        alert(res.messenger);
                    }
                    else {
                        alert(res.messenger);
                        dialog.dialog('close');
                    }
                    me.loadData();
                }).fail(function (res) {
                    alert('Sửa dữ liệu thất bại');
                })
            }

        })
        //Xóa dữ liệu khi ấn button [Xóa]
        $('.dialog-bottom .btn-delete').click(function () {
            var formData = $('.dialog-content').serializeArray();
            var employee = formData.reduce(function (employee, item) {
                if (!employee[item.name]) employee[item.name] = item.value;
                return employee;
            }, {})
            for (var key in employee) {
                if (employee[key] == "") delete employee[key];
            }
            var isDelete = confirm(`Bạn có chắn chắn muốn xóa nhân viên [${employee.employeeCode}] không?`);
            if (isDelete == true) {
                $.ajax({
                    url: URL,
                    method: 'DELETE',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    if (res.misaCode == 400) {
                        alert(res.messenger);
                    }
                    else {
                        alert(res.messenger);
                    }
                    dialog.dialog('close');
                    me.loadData();
                }).fail(function (res) {
                    alert('Xóa dữ liệu thất bại');
                })
            }
            else
                return;

        })
    }

    /**
    * Load dữ liệu
    * */
    loadData() {
        //Lấy dữ liệu
        try {
            $.ajax({
                url: this.dataUrl,
                method: "GET",
            }).done(function (res) {
                /**
                 * Đếm số object được trả về
                 * */
                var count = 0;
                $('table tbody').empty();
                $.each(res, function (index, employee) {
                    var tr = $(`<tr data-code= "${employee.employeeCode}"></tr>`);
                    $.each($('table thead th'), function (index, column) {
                        var td = $(`<td></td>`);
                        var fieldName = $(column).attr('fieldName');
                        var formatType = $(column).attr('formatType');
                        var value = employee[fieldName];
                        switch (formatType) {
                            case "ddmmyyyy":
                                value = formatDate(value);
                                td.addClass('text-align-center');
                                break;
                            case "Money":
                                value = formatMoney(value);
                                td.addClass('text-align-right');
                                break;
                            case "gender":
                                value = convertGender(value);
                                td.addClass('text-align-center');
                                break;
                            default:
                                break;
                        }
                        $(td).prop('title', value);
                        $(td).append(value);
                        $(tr).append(td);
                    })
                    $('table tbody').append(tr);
                    count += 1;
                })
                $('.page-info').empty();
                $('.page-total').empty();
                $('.page-info').append(`<span>Hiển thị 1 - ${count} nhân viên</span>`)
                $('.page-total').append(`<span>Hiển thị ${count}/${count} nhân viên</span>`)
            }).fail(function (res) {
                alert(res);
            })
        } catch (e) {
            alert("Không load được dữ liệu!");
        }
    }
}
