/** -----------------------------------------------
 * Định dạng dữ liệu kiểu ngày/tháng/năm
 * @param {any} date tham số có kiểu dữ liệu bất kì
 * CreatedBy: NQDAT (27/12/2020)
 */
function formatDate(date) {
    if (!date)
        return "";
    var date = new Date(date);
    if (isNaN(date.getTime()) == true)
        return "";

    var year = date.getFullYear();

    if (year < 1800)
        return "";
    var month = date.getMonth() + 1;

    var day = date.getDate();

    if (day < 10) day = "0" + day;

    if (month < 10) month = "0" + month;


    return day + "/" + month + "/" + year;
}

/** -----------------------------
 * Hàm định dạng hiển thị tiền tệ
 * @param {Number} money Số tiền
 * CreatedBy: NQDAT (27/12/2020)
 */
function formatMoney(money) {
    if (money)
        return money.toFixed(0).replace(/\d(?=(\d{3})+(?!\d))/g, '$&,');
    return "";
}

/**
 * Hàm xử lý giới tính 0 - Nam, 1 - Nữ, 2 - không xác định
 * @param {any} gender
 */
function convertGender(gender) {
    if (gender == 0) return "Nam";
    if (gender == 1) return "Nữ";
    return "Không xác định"
}