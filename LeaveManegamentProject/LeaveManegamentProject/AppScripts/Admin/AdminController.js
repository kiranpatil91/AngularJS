app.controller("AdminController", ["$scope", "$http","$rootScope", "$stateParams", "$location", "leaveservice",  "$rootScope",
    function ($scope, $http, $rootScope, $stateParams, $location, leaveservice) {


        $scope.Admins = [];

        $scope.GetAllData = function () {
            $http.get('/Admin').success(function (response) {
                console.log(response);
                $scope.Admins = response;

            });
        };
        $scope.GetAllData();
        $scope.Delete = function (UserId) {

            $http.get("/Admin/Delete/" + UserId).success(function (response) {

                if (response.IsSuccess) {
                    leaveservice.RecordStatusMessage("success", response.Message);
                    $scope.GetAllData();
                }
                else {
                    leaveservice.RecordStatusMessage("danger", response.Message);
                }
            });
        };
        if ($stateParams.ProjectName != undefined) {

            $scope.ProjectName = $stateParams.ProjectName;
            console.log($scope.ProjectName);
            return ($scope.ProjectName);
        }
        $rootScope.$on("tablerefresh", function (){
            $scope.GetAllData();

        });
        
    }

]);

app.controller("AdminAddController", ["$scope", "$http", "$rootScope", "$stateParams", "$location", "leaveservice",
    function ($scope, $http, $rootScope, $stateParams, $location, leaveservice) {

        $scope.Admin = {};
        $scope.IsEditMode = false;
        $scope.IsVisible = false;
        $scope.Visible = false;
        console.log($stateParams);
    

        if ($stateParams.Email != undefined) {
            $scope.IsEditMode = true;
            $http.post("/Admin/edit", { Email: $stateParams.Email }).success(function (response) {
                console.log(response);
                console.log($stateParams);       
              
               
                $scope.Admin = response;
            });
           
            
        }
        //if ($stateParams.email != undefined) {

        //    $scope.IsEditMode = true;
        //    $http.post("/Admin/Login", { email: $stateParams.email }).success(function (response) {
        //        console.log(response);
        //        console.log($stateParams);


        //        if (response.IsSuccess) {
        //            leaveservice.RecordStatusMessage("success", response.Message);
        //            $scope.Admin = response.Data;
        //            console.log($scope.Admin.role);

        //            $scope.IsVisible = "Admin";
        //            console.log($scope.IsVisible);
        //            if ($scope.Admin.role == $scope.IsVisible) {
        //                $scope.IsVisible = $scope.IsVisible = true;
        //            }
        //            else {
        //                $scope.IsVisible = $scope.IsVisible = false;
        //            }
        //            return $scope.Admin;
        //        } else {
        //            $location.path("/Admin/home");
        //            leaveservice.RecordStatusMessage("error", response.Message);
        //        }
        //    });


        //}

     
        $scope.Login = function (Admin) {
          
            $stateParams.Email = Admin.Email;
            //  $stateParams.password = Admin.password;
            password = Admin.password;
            
            if ($stateParams.Email != undefined) {
                $http.post("/Admin/Login", { Email: $stateParams.Email, password }).success(function (response) {
                    console.log(response);
                    console.log($stateParams);
                   
                    if (response.IsSuccess) {
                        $rootScope.$emit("CallParentMethod", {});
                        leaveservice.RecordStatusMessage("success", response.Message);
                        $scope.Admin = response.Data;
                       
                        $location.path("/leave/" + Admin.Email);
                        //$scope.IsVisible = "Admin";
                        //$scope.IsVisible = "Team Lead";
                        //console.log($scope.IsVisible);
                       // if ( $scope.Admin.Role == $scope.IsVisible) {
                       //     $scope.IsVisible = true;
                       // }
                       // else {
                       //     $scope.IsVisible = $scope.IsVisible = false;
                       // }
                       //// return $scope.IsVisible;
                    } else {
                        $location.path("/Admin/home");
                        leaveservice.RecordStatusMessage("error", response.Message);
                    }
                });
            }
        }
        //$rootScope.$on("MyFunction", function (CurrentBalance) {
        //    $scope.CurrentBalance;
        //    alert('Ctrl1 MyFunction')
        //    console.log($scope.CurrentBalance);
        //    if ($scope.IsEditMode = true) {
        //        $http.post("/Admin/update", { adminview: $scope.Admin }).success(function (response) {
        //            console.log(response);
        //            if (response.IsSuccess) {
        //                $scope.Admin = {};
        //                leaveservice.RecordStatusMessage("success", response.Message);
        //                $location.path("/admin");

        //            } else {
        //                leaveservice.RecordStatusMessage("error", response.Message);
        //            }


        //        });
        //    }
        //});
        $scope.Save = function () {
            if ($scope.IsEditMode) {
               // $scope.Admin.CurrentBalance = $scope.Admin.AlocatedLeaves;
                $http.post("/Admin/update", { adminview: $scope.Admin }).success(function (response) {
                    console.log(response);
                    if (response.IsSuccess) {
                        $scope.Admin = {};
                        leaveservice.RecordStatusMessage("success", response.Message);
                        $location.path("/admin");

                    } else {
                        leaveservice.RecordStatusMessage("error", response.Message);
                    }

                });
            }
            else {
                $scope.Admin.CurrentBalance = $scope.Admin.AlocatedLeaves;
                $http.post("/Admin/Save", { adminview: $scope.Admin }).success(function (response) {
                    console.log(response);
                    if (response.IsSuccess) {
                        $scope.Admin = {};
                        leaveservice.RecordStatusMessage("success", response.Message);
                        $location.path("/admin");

                    } else {
                        leaveservice.RecordStatusMessage("error", response.Message);

                    }
                    return $scope.Admin;
                });

            }

        };
        $scope.UpdateLeave = function (Admin) {
            AlocatedLeaves = Admin;
            $http.post("/Admin/UpdateLeave", { AlocatedLeaves}).success(function (response) {
                if (response.IsSuccess) {
                    $rootScope.$emit("tablerefresh", {  });
                    leaveservice.RecordStatusMessage("success", response.Message);
                } else {
                    leaveservice.RecordStatusMessage("error", response.Message);
                }
                

            });
        }
    }
    
]);