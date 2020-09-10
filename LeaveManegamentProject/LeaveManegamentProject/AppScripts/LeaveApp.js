

var app = angular.module("app", ["ui.router" ]);

app.controller("HeadController", ["$scope", "$rootScope", "$http", function ($scope, $rootScope, $http) {
    $scope.Visible = false;
    $rootScope.$on("CallParentMethod", function () {
        $scope.Visible = true;
    });
    $scope.click = function () {
        $scope.Visible = false;
    }
}]);

app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/admin/home");
    //home
    var home = {
        url: '/admin/home',
        title: 'Home',
        name: 'home',
        templateUrl: "/AppScripts/Admin/Login.html",
    };
    $stateProvider.state(home);
    var leave = {
        view: {
            url: '/leave',
            title: 'leaves',
            name: 'leaves',
            templateUrl: "/AppScripts/Admin/LeaveApprovalTable.html",
        },
        edit: {
            url: '/leave/:email',
            title: 'Login',
            name: 'login',
            templateUrl: "/AppScripts/Admin/Leave.html"
        },
        add: {
            url: '/leave/new',
            title: 'New leave',
            name: 'newleave',
            templateUrl: "/AppScripts/Admin/LeaveTable.html",
        },
        
        
    };
    $stateProvider.state(leave.view);
    $stateProvider.state(leave.edit);
    $stateProvider.state(leave.add);
   
    //table




    //BusinessType
    var admins = {
        view: {
            url: '/admin',
            title: 'admins',
            name: 'admins',
            templateUrl: "/AppScripts/Admin/index.html",
        },
        add: {
            url: '/admin/new',
            title: 'New admin',
            name: 'newadmin',
            templateUrl: "/AppScripts/Admin/add.html",
        },
        edit: {
            url: '/admin/:Email',
            title: 'Edit admin',
            name: 'editadmin',
            templateUrl: "/AppScripts/Admin/add.html",
        },
    };
    $stateProvider.state(admins.view);
    $stateProvider.state(admins.add);
    $stateProvider.state(admins.edit);
    //Employee
    var employees = {
        view: {
            url: '/employee',
            title: 'employee',
            name: 'employeess',
            templateUrl: "/AppScripts/Admin/index.html",
        },
        add: {
            url: '/employee/:email',
            title: 'employee history',
            name: 'employeesshistory',
            templateUrl: "/AppScripts/Admin/LeaveTable.html",
        }
    };
    $stateProvider.state(employees.view);
    $stateProvider.state(employees.add);
   

    //absencename
   
    var absencenames = {
        view: {
            url: '/absencename',
            title: 'absencenames',
            name: 'absencenames',
            templateUrl: "/AppScripts/Absencename/index.html",
        },
        add: {
            url: '/absencename/new',
            title: 'New absencename',
            name: 'newabsencename',
            templateUrl: "/AppScripts/Absencename/add.html",
        },
        edit: {
            url: '/absencename/:Id',
            title: 'Edit absencename',
            name: 'editabsencename',
            templateUrl: "/AppScripts/Absencename/add.html",
        },
    };
    $stateProvider.state(absencenames.view);
    $stateProvider.state(absencenames.add);
    $stateProvider.state(absencenames.edit);

    var filters = {
        view: {
            url: '/filter/:ProjectName',
            title: 'Filter',
            name: 'FilterTable',
            templateUrl: '/AppScripts/Admin/index.html',
        },     
        edit: {
            url: "/filter/:Email",
            title: "commentbox",
            name: "commentbox",
            templateUrl:"/AppScripts/RejectcommentBox.html",
        }
    };
    $stateProvider.state(filters.view);
    $stateProvider.state(filters.edit);

    
  
}]); 