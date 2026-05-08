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
        barangayClearance: [
            { value: 'job_application', label: 'Job application' },
            { value: 'business_permit', label: 'Business permit' },
            { value: 'passport_requirement', label: 'Passport requirement' },
            { value: 'bank_requirement', label: 'Bank requirement' }
        ],
        barangayCertificate: [
            { value: 'general_certification', label: 'General certification' },
            { value: 'personal_use', label: 'Personal use' },
            { value: 'proof_of_identity', label: 'Proof of identity' },
            { value: 'community_verification', label: 'Community verification' }
        ],
        certificateOfResidency: [
            { value: 'school_enrollment', label: 'School requirement' },
            { value: 'scholarship_application', label: 'Scholarship application' },
            { value: 'passport_application', label: 'Passport application' },
            { value: 'bank_account_opening', label: 'Bank account opening' },
            { value: 'voter_registration', label: 'Voter registration' },
            { value: 'housing_application', label: 'Housing application' },
            { value: 'id_application', label: 'ID application' }

        ],
        certificateOfIdigency: [
            { value: 'medical_assistance', label: 'Medical assistance' },
            { value: 'hospital_admission', label: 'Hospital admission' },
            { value: 'financial_assistance', label: 'Financial assistance' },
            { value: 'charity_assistance', label: 'Charity Assistance' },
            { value: 'scholarship_application', label: 'Scholarship application' },
            { value: 'burial_assistance', label: 'Burial assistance' },
            { value: '4Ps/DSWD_requirement', label: '4Ps / DSWD requirement' },
        ],
        certificateOfCohabitation: [
            { value: 'solo_parent_benefits', label: 'Solo parent benefits' },
            { value: 'DSWD_application', label: 'DSWD application' },
            { value: 'school_assistance', label: 'School assistance' },
            { value: 'government_welfare_programs', label: 'Government welfare programs' }
        ],
        firstTimeJobSeekerCert: [
            { value: 'nbi_police_clearance', label: 'NBI / Police Clearance Requirement' },
            { value: 'employment_application', label: 'Employment application' },
            { value: 'Pre-employment requirements', label: 'Pre-employment requirements' }
        
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
        //{
        //    id: "REQ-001",
        //    document: "Barangay Clearance",
        //    status: "Processing",
        //    priority: "High Priority",
        //    resident: "Juan Dela Cruz",
        //    purpose: "Employment",
        //    dateRequested: "04/26/2026"
        //},
        //{
        //    id: "REQ-002",
        //    document: "Certificate of Residency",
        //    status: "Approved",
        //    priority: "Normal Priority",
        //    resident: "Maria Santos",
        //    purpose: "Scholarship",
        //    dateRequested: "04/25/2026"
        //}
    ];

    // Manage request
    $scope.manageReqsArr = [];

    //Req and History
    $scope.reqAndHistoryArr = [];

    //Reg Acc
    $scope.residentAccsArr = [];

    //Archieve
    $scope.residentArchieveArr = [];

    //List of residents
    $scope.listOfResidentArr = [];

});