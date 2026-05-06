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
            case 'notification':
                window.location.href = "/Resident/NotificationPage"
                break;
            case 'residentProfile': 
                window.location.href = "/Resident/ResidentProfilePage"
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

    $scope.$watch('phone', function (newVal, oldVal) {
        if (!newVal) return;

        var clean = newVal.replace(/[^0-9]/g, '');

        if (clean !== newVal) {
            $scope.phone = clean;
        }
    });

    //Notification 
    $scope.currentTab = 'all';

  
    $scope.allNotifications = [
        {
            id: 1, icon: '📄', iconBg: 'bg-blue-50',
            badge: 'Processing', badgeCss: 'bg-blue-100 text-blue-700',
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



});