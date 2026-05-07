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

    //Prevent Letters for phone textbox
    $scope.$watch('phone', function (newVal, oldVal) {
        if (!newVal) return;

        var clean = newVal.replace(/[^0-9]/g, '');

        if (clean !== newVal) {
            $scope.phone = clean;
        }
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
        {
            documentType: "Barangay Clearance",
            requestId: "REQ-001",
            status: "Processing",
            purpose: "Employment",
            submittedDate: "April 30, 2026",
            contact: "09171234567",
            estimatedCompletion: "April 30, 2026"
        }
    ];

    $scope.cancelRequest = function (request) {
        if (confirm("Are you sure you want to cancel this request?")) {
            request.status = "Cancelled";
        }
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
        Swal.fire({
            icon: 'success',
            text: 'Profile updated successfully'
        });
    }

    //Notification 
    $scope.currentTab = 'all';


    $scope.allNotifications = [
        {
            id: 1, icon: '📄',
            title: 'Document request approved',
            sub: 'Your Certification of proof of Residency is processing.',
            time: 'Just now', read: false,
        },
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

    //$scope.dismiss = function (n) {
    //    var idx = $scope.allNotifications.indexOf(n);
    //    if (idx !== -1) $scope.allNotifications.splice(idx, 1);
    //};

    $scope.markAllRead = function () {
        $scope.allNotifications.forEach(function (n) { n.read = true; });
    };

    //Staff Pages



});