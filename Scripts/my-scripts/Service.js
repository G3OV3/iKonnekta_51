app.service("iKonnekta_51_Service", function ($http) {
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
});