app.service("iKonnekta_51_Service", function ($http) {
    // 1. Authentication
    this.registerUserService = function (userInfo) {
        var response = $http({
            url: "/iKonnekta_51/registerUser",
            method: "post",
            data: userInfo
        });
        return response;
    }
    this.loginUserService = function (userLoginInfo) {
        var response = $http({
            url: "/iKonnekta_51/loginUser",
            method: "post",
            data: userLoginInfo
        });
        return response;
    }
    // 2. Resident
    this.getDashboardStatsService = function (residentId) {
        var response = $http({
            url: "/Resident/getResidentDashboardStats",
            method: "post",
            data: {
                residentId: residentId
            }
        });
        return response;
    }
    this.getRecentRequestListService = function (residentId) {
        return $http({
            url: "/Resident/getRecentRequestList",
            method: "post",
            data: {
                residentId: residentId
            }
        });
    };
});