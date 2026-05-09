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
    this.getListOfResidentsService = function () {
        return $http.get("/VStaff/GetListOfResidents")
    }
<<<<<<< HEAD
    // submit request
    this.getResidentInfoService = function (residentId) {

        return $http({

            url: "/Resident/getResidentInfo",

            method: "post",

            data: {
                residentId: residentId
            }
        });
    };

    this.submitRequestService = function (requestData) {

        return $http({

            url: "/Resident/submitDocumentRequest",

            method: "post",

            data: requestData
        });
    };
    this.getResidentAccService = function () {
        return $http.get("/VStaff/GetRegisteredAccounts")
    }
    // Tracking request
    this.getTrackingRequestsService = function (residentId) {
        return $http({
            url: "/Resident/getTrackingRequests",
            method: "post",
            data: {
                residentId: residentId
            }
        });
    };
    this.cancelRequestService = function (requestId) {
        return $http({
            url: "/Resident/cancelRequest",
            method: "post",
            data: { requestId: requestId }
        });
    };
=======
>>>>>>> latest
>>>>>>> format of date in archieve
});