app.controller("ikonnekta_51_Controller", function ($scope, $timeout, iKonnekta_51_Service) {


    // Initial state
    $scope.showRegistration = true;
    $scope.showLogin = true;
    $scope.showTFA = false;
    $scope.showTFAForgotPass = true;


    // Navigate Pages
    $scope.navigate = function (page) {
        switch (page) {
            case 'login':
                window.location.href = "/iKonnekta_51/LoginPage"
                break;
            case 'register':
                window.location.href = "/iKonnekta_51/RegistrationPage"
                break;
            case 'forgotPassword':
                window.location.href = "/iKonnekta_51/ForgotPasswordPage"
                break;

            // Resident Pages
            case 'residentDashboard':
                window.location.href = "/Resident/DashboardPage"
                break;
            case 'submitRequest':
                window.location.href = "/Resident/SubmitRequestPage"
                break;
            case 'trackRequest':
                window.location.href = "/Resident/TrackRequestPage"
                break;
            case 'requestHistorypage':
                window.location.href = "/Resident/HistoryPage_Resident"
                break;
            case 'residentNotification':
                window.location.href = "/Resident/NotificationPage"
                break;
            case 'residentProfile':
                window.location.href = "/Resident/ResidentProfilePage"
                break;

            // Staff Pages
            case 'StaffDashboard':
                window.location.href = "/VStaff/VDashboardViewPage"
                break;
            case 'AddResident':
                window.location.href = "/VStaff/VAddResidentViewPage"
                break;
            case 'Archive':
                window.location.href = "/VStaff/VArchivesViewPage"
                break;
            case 'ListOfResidents':
                window.location.href = "/VStaff/VListofResidentsViewPage"
                break;
            case 'ManageRequests':
                window.location.href = "/VStaff/VManageRequestViewPage"
                break;
            case 'StaffNotification':
                window.location.href = "/VStaff/VNotificationViewPage"
                break;
            case 'AccsOfResidents':
                window.location.href = "/VStaff/VRegisteredResidentsViewPage"
                break;
            case 'RequestHistoryRecords':
                window.location.href = "/VStaff/VRequestHistory_RecordsViewPage"
                break;
            case 'EditResidentInfo':
                window.location.href = "/VStaff/VViewEditResidentInfoViewPage"
                break;
            case 'ViewRequestOfDetails':
                window.location.href = "/VStaff/VViewRequestDetailsViewPage"
                break;
        }
    }
    // OTP Part
    $scope.showTFAFunc = function () {
        $scope.showTFA = true;
        $scope.showRegistration = false;
        $scope.showLogin = false;

    }
    // OTP input handling
    $scope.otp = ['', '', '', '', '', ''];

    $scope.otpKeydown = function (e, index) {
        const allowed = ['Backspace', 'Tab', 'ArrowLeft', 'ArrowRight', 'Delete'];

        if (!allowed.includes(e.key) && !/^\d$/.test(e.key)) {
            e.preventDefault();
        }

        if (e.key === 'Backspace' && !$scope.otp[index] && index > 0) {
            $scope.otp[index - 1] = '';
            $timeout(function () {
                document.querySelectorAll('.otp-input')[index - 1].focus();
            });
        }
    };

    $scope.otpInput = function (index) {
        $scope.otp[index] = ($scope.otp[index] || '').replace(/\D/g, '').slice(0, 1);

        if ($scope.otp[index] && index < 5) {
            $timeout(function () {
                const inputs = document.querySelectorAll('.otp-input');
                if (inputs[index + 1]) {
                    inputs[index + 1].focus();
                }
            });
        }
    };
    $scope.verifyOTP = function (endpoint) {
        const otp = $scope.otp.join('');

        if (otp.length < 6) {
            Swal.fire({
                icon: 'error',
                text: 'Please enter a valid 6-digit OTP'
            });
            return;
        }

        if (endpoint === 'login') {

            // login OTP logic here

        }
        else if (endpoint === 'forgotPassword') {
            $scope.showTFAForgotPass = false;
            $scope.showCreateNewPassword = true;
        }
        else {
            // fallback / register / other
        }

        // call your API with otp here
    };

    //Sidebar
    $scope.sidebarOpen = false;
    $scope.toggleSidebar = function () {
        $scope.sidebarOpen = !$scope.sidebarOpen;
    }
    $scope.closeSidebar = function () {
        $scope.sidebarOpen = false
    }

    //Prevent Letters for to input in textbox for num
    var numericFields = ['digit', 'phone', 'cardNo'];

    numericFields.forEach(function (field) {
        $scope.$watch(field, function (newVal) {
            if (!newVal) return;
            var clean = newVal.replace(/[^0-9]/g, '');
            if (clean !== newVal) {
                $scope[field] = clean;
            }
        });
    });

    //checking if it the user input has at sign
    $scope.warningMessage = "";
    $scope.inputEmail = "";

    $scope.checkAtSign = function () {
        var input = $scope.inputEmail;
        var emailPattern = /^[^\s@]+@[^\s@]+\.com$/;

        if (!input || input.trim() === '') {
            $scope.warningMessage = "";
        } else if (!emailPattern.test(input)) {
            $scope.warningMessage = "must include @ and .com";
        } else {
            $scope.warningMessage = "";
        }
    };

    // Resident Part

    //TrackRequests
    $scope.requests = [
        //{
        //    documentType: "Barangay Clearance",
        //    requestId: "REQ-001",
        //    status: "Processing",
        //    purpose: "Employment",
        //    submittedDate: "April 30, 2026",
        //    contact: "09171234567",
        //    estimatedCompletion: "April 30, 2026"
        //}
    ];

    $scope.cancelRequest = function (request) {

        Swal.fire({
            title: "Cancel Request?",
            text: "Are you sure you want to cancel this request?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, cancel it",
            cancelButtonText: "No, keep it"
        }).then((result) => {
            if (result.isConfirmed) {
                request.status = "Cancelled";
            }
        });

         Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to cancel this request?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, cancel it!',
            cancelButtonText: 'No, keep it'
        }).then((result) => {
            if (result.isConfirmed) {
                request.status = 'Cancelled';
                $scope.$apply(); // Required to update AngularJS binding

                Swal.fire({
                    title: 'Cancelled!',
                    text: 'The request has been cancelled.',
                    icon: 'success'
                });
            }
        });


    };

    //Resident Profile
    $scope.showProfileCard = true;
    $scope.showEditProfileFunc = function () {
        $scope.showEditProfileCard = true;
        $scope.showProfileCard = false;

    }

    $scope.cancelUpdeteProfileFunc = function () {
        $scope.showEditProfileCard = false;
        $scope.showProfileCard = true;
    }

    $scope.saveChangesProfileFunc = function () {
        //Swal.fire({
        //    icon: 'success',
        //    text: 'Profile updated successfully'
        //});
        if ($scope.phone === "" || $scope.inputEmail === "") {
            Swal.fire({
                icon: 'error',
                text: 'Empty fields'
            });
        }
    }

    //

    //Notification 
        $scope.currentTab = 'all';
        $scope.allNotifications = [
            //{
            //    id: 1, icon: '📄',
            //    title: 'Barangay Clearance',
            //    sub: 'Your Certification for barangary clearance is processing.',
            //    time: 'Just now', read: false,
            //},
        ];

        $scope.setTab = function (tab) {
            $scope.currentTab = tab;
        };

        $scope.unreadNotifications = function () {
            return $scope.allNotifications.filter(function (n) { return !n.read; });
        };

        $scope.unreadCount = function () {
            return $scope.allNotifications.filter(function (n) { return !n.read; }).length;
        };

        $scope.toggleRead = function (n) {
            n.read = !n.read;
        };

        $scope.markAllRead = function () {
            $scope.allNotifications.forEach(function (n) { n.read = true; });
        };

        //Submit Document Request

        $scope.qty = 1;
        $scope.needMoreCopies = false;

        $scope.changeQty = function (delta) {
            var val = $scope.qty + delta;
            $scope.qty = Math.max(1, Math.min(10, val));
        };

        $scope.resetQty = function () {
            $scope.qty = 1;
    };

    // Purpose
    $scope.selectedDocument = '';
    $scope.selectedPurpose = '';
 

    $scope.resetSpecific = function () {
        $scope.selectedPurpose = '';
    };

    $scope.options = {
        // Document_Type_ID = 1
        1: [
            { value: 1, label: 'Job Application' },
            { value: 2, label: 'Business Permit' },
            { value: 3, label: 'Passport Requirement' },
            { value: 4, label: 'Bank Requirement' }
        ],

        // Document_Type_ID = 2
        2: [
            { value: 12, label: 'General Certification' },
            { value: 13, label: 'Personal Use' },
            { value: 14, label: 'Proof of Identity' },
            { value: 15, label: 'Community Verification' }
        ],

        // Document_Type_ID = 3
        3: [
            { value: 5, label: 'School Requirement' },
            { value: 6, label: 'Scholarship Application' },
            { value: 7, label: 'Passport Application' },
            { value: 8, label: 'Bank Account Opening' },
            { value: 9, label: 'Voter Registration' },
            { value: 10, label: 'Housing Application' },
            { value: 11, label: 'ID Application' }
        ],

        // Document_Type_ID = 4
        4: [
            { value: 16, label: 'Medical Assistance' },
            { value: 17, label: 'Hospital Admission' },
            { value: 18, label: 'Financial Assistance' },
            { value: 19, label: 'Charity Assistance' },
            { value: 20, label: 'Scholarship Application' },
            { value: 21, label: 'Burial Assistance' },
            { value: 22, label: '4Ps / DSWD Requirement' }
        ],

        // Document_Type_ID = 5
        5: [
            { value: 23, label: 'Solo Parent Benefits' },
            { value: 24, label: 'DSWD Application' },
            { value: 25, label: 'School Assistance' },
            { value: 26, label: 'Government Welfare Programs' }
        ],

        // Document_Type_ID = 6
        6: [
            { value: 27, label: 'NBI / Police Clearance Requirement' },
            { value: 28, label: 'Employment Application' },
            { value: 29, label: 'Pre-employment Requirements' }
        ]
    };

    $scope.isPurposeAndDocSelected = function () {
        if ($scope.selectedDocument === '' && $scope.selectedPurpose === '') {
            Swal.fire({
                icon: 'error',
                text: 'Must fill the dropdown'
            })
        }
        else {
            Swal.fire({
                icon: 'success',
                text: 'Your request is on process '
            })
        }
    }


    //Staff Pages

    $scope.recentRequests = [

    ];
    // Manage request
    $scope.manageReqsArr = [];

    //Req and History
    $scope.reqAndHistoryArr = [];


    //Resident Acc
    $scope.getResidentAccs = function () {
        iKonnekta_51_Service.getResidentAccService()
            .then(function (response) {
                   $scope.residentsAccs = response.data.data;
 
            })
    }

    //archive
    $scope.getListOfArchivedResidents = function () {
        iKonnekta_51_Service.getListOfArchivedResidentsService()
            .then(function (response) {
                $scope.archivedResidentsList = response.data.data;
            });
    };

    //List of residents
    $scope.getListOfResidents = function () {
        iKonnekta_51_Service.getListOfResidentsService()
            .then(function (response) {
                $scope.residentsList = response.data.data;
            });
    };
    

    // Authentication:
    // 1. Register
    $scope.registerUser = function () {
        var userInfo = {
            PhySys_Card_No: $scope.cardNo,
            Username: $scope.Username,
            Password: $scope.Password
        }
        if (!$scope.cardNo || !$scope.Username || !$scope.Password || !$scope.ConfirmPassword) {
            Swal.fire("Notice!", "Please complete all fields.", "warning");
            return;
        }

        if ($scope.Password != $scope.ConfirmPassword) {
            Swal.fire("Notice!", "Passwords do not match.", "warning");
            return;
        }
        var Service = iKonnekta_51_Service.registerUserService(userInfo);
        Service.then(function (response) {
            if (response.data.success) {
                Swal.fire("Notice!!!", "Registration Success");
            } else {
                Swal.fire("Notice!!!", response.data.message);
            }
        });
    }
    // 2. Login
    // Controller.js

    // 2. Login
    $scope.loginUser = function () {

        if (!$scope.User_Username || !$scope.User_Password) {

            Swal.fire("Warning", "Please fill in all fields", "warning");
            return;
        }

        var userLoginInfo = {
            Username: $scope.User_Username,
            Password: $scope.User_Password
        };

        var service = iKonnekta_51_Service.loginUserService(userLoginInfo);

        service.then(function (response) {

            if (response.data.success) {

                sessionStorage.setItem("user", JSON.stringify({

                    userId: response.data.userId,
                    residentId: response.data.residentId,
                    roleId: response.data.roleId,
                    username: response.data.username,

                    firstName: response.data.firstName,
                    lastName: response.data.lastName,

                    contact: response.data.contact,
                    address: response.data.address
                }));

                if (response.data.roleId === 1) {

                    window.location.href = "/Resident/DashboardPage";
                }
                else if (response.data.roleId === 2) {

                    window.location.href = "/VStaff/VDashboardViewPage";
                }
            }
            else {

                Swal.fire("Login Failed", response.data.message, "error");
            }
        });
    };
    // for Top bar username saka id
    $scope.user = {};
    var storedUser = sessionStorage.getItem("user");
    if (storedUser) {
        $scope.user = JSON.parse(storedUser);
    }
    // 2. Resident
    // for cards data
    $scope.dashboardStats = {};
    $scope.loadDashboardStats = function () {

        var storedUser = sessionStorage.getItem("user");
        if (!storedUser) {
            return;
        }

        var user = JSON.parse(storedUser);

        if (!user || !user.residentId) {
            return;
        }

        var Service = iKonnekta_51_Service.getDashboardStatsService(user.residentId);

        Service.then(function (response) {
            $scope.dashboardStats = response.data;
        });
    };
    $scope.loadDashboardStats();
    // for recent list
    $scope.loadRecentRequest = function () {
        var storedUser = sessionStorage.getItem("user");
        if (!storedUser) {
            return;
        }
        var user = JSON.parse(storedUser);

        if (!user || !user.userId) {
            return;
        }
        var Service = iKonnekta_51_Service.getRecentRequestListService(user.userId);
        Service.then(function (response) {
            $scope.requests = response.data;
        });
    };
    // for submiting request
    $scope.residentInfo = {};
    $scope.loadResidentInfo = function () {

        var storedUser = sessionStorage.getItem("user");
        if (!storedUser) return;

        var user = JSON.parse(storedUser);

        if (!user || !user.residentId) return;

        var Service = iKonnekta_51_Service.getResidentInfoService(user.residentId);

        Service.then(function (response) {
            $scope.residentInfo = response.data || {};
        });
    };
    $scope.loadResidentInfo();
    $scope.submitRequest = function () {

        if (!$scope.selectedDocument || !$scope.selectedPurpose) {
            Swal.fire("Warning", "Please complete all fields", "warning");
            return;
        }

        var storedUser = sessionStorage.getItem("user");
        var user = JSON.parse(storedUser);

        var requestData = {
            Resident_ID: user.residentId, 
            Document_Type_ID: parseInt($scope.selectedDocument),
            Purpose_ID: parseInt($scope.selectedPurpose),
            Quantity: $scope.qty,
            Priority_Level_ID: 1
        };

        var Service = iKonnekta_51_Service.submitRequestService(requestData);

        Service.then(function (response) {

            if (response.data.success) {

                Swal.fire("Success", response.data.message, "success");

                $scope.selectedDocument = "";
                $scope.selectedPurpose = "";
                $scope.qty = 1;
            }
            else {
                Swal.fire("Warning", response.data.message, "warning");
            }
        });
    };
    // Tracking request
    $scope.requests = [];

    $scope.loadTrackingRequests = function () {
        var storedUser = sessionStorage.getItem("user");
        if (!storedUser) {
            return
        };

        var user = JSON.parse(storedUser);
        if (!user || !user.residentId) {
            return
        };
        $scope.requests = [];

        var Service = iKonnekta_51_Service.getTrackingRequestsService(user.residentId);

        Service.then(function (response) {
            $scope.requests = response.data || [];

        });
    };
    $scope.loadTrackingRequests();
    $scope.cancelRequest = function (request) {

        Swal.fire({
            title: "Cancel Request?",
            text: "This action cannot be undone",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, cancel it"
        }).then((result) => {

            if (result.isConfirmed) {

                var Service = iKonnekta_51_Service.cancelRequestService(request.requestId);

                Service.then(function (response) {

                    if (response.data.success) {

                        request.progress = "Cancelled";

                        Swal.fire("Cancelled", "Request has been cancelled", "success");

                        $scope.loadTrackingRequests(); // refresh
                    }
                });
            }
        });
    };
    // Staff
    // cards
});