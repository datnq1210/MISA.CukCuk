$(document).ready(function () {
    new EmployeeJS();
})
/**
 * Class quản lý các sự kiện cho trang Employee
 * CreatedBy: NQDAT (28/12/2020)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }
    setDataUrl() {
        this.dataUrl = "/api/v1/Employees/";
    }
    
}

