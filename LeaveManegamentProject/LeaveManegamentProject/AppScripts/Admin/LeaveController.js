

app.controller("LeaveController", ["$scope", "$http", "$stateParams", "$rootScope", "$location", "leaveservice",
    function ($scope, $http, $stateParams,  $rootScope,$location, leaveservice, ) {
       
        $scope.Leaves = [];
        $scope.IsVisible = false;
        $scope.GetAllData = function () {
            $http.get('/Leave').success(function (response) {
                console.log(response);
                $scope.Leaves = response;
                
            });
        };
        $scope.GetAllData();
        $scope.Delete = function (id) {

            $http.get("/Leave/Delete/" + id).success(function (response) {

                if (response.IsSuccess) {
                    leaveservice.RecordStatusMessage("success", response.Message);
                    $scope.GetAllData();
                }
                else {
                    leaveservice.RecordStatusMessage("danger", response.Message);
                }
            });
        };
        $scope.accept = function (Id) {

            $http.get("/Leave/accept/" + Id).success(function (response) {

                leaveservice.RecordStatusMessage("success", response.Message);
                console.log(response);
                $scope.Leave = response.Data;
                console.log($scope.Leave.Action);
                $scope.GetAllData();

                console.log($scope.Leave.CurrentBalance);



               

                $http.post("/Admin/date", { adminview: $scope.Leave.CurrentBalance, Email: $scope.Leave.Email }).success(function (response) {
                        console.log(response);
                        if (response.IsSuccess) {
                            $scope.Admin = {};
                            leaveservice.RecordStatusMessage("success", response.Message);
                            

                        } else {
                            leaveservice.RecordStatusMessage("error", response.Message);
                        }
                    });             
              
            });           
        }
        
                
        $scope.reject = function (id) {
            $http.get("/Leave/reject/" + id).success(function (response) {
                leaveservice.RecordStatusMessage("success", response.Message);    
                $scope.GetAllData();               
            });
        }
        if ($stateParams.email != undefined) {

            $scope.email = $stateParams.email;
            console.log($scope.ProjectName);
            return ($scope.email);
        }
           

    }]);

app.controller("LeaveAddController", ["$scope", "$http", "$stateParams", "$location", "leaveservice",
    function ($scope, $http,$stateParams, $location, leaveservice) {
       
        $scope.Leave = {};
       
      
           
           
              
     
        
        
        $scope.IsVisible = false;
     
        $scope.GetAllData = function () {
            $http.get('/Absencename').success(function (response) {
                console.log(response);
                $scope.Absencenames = response;
                
            });
        };
        $scope.GetAllData();

        $scope.IsEditMode = false;
       
        if ($stateParams.email != undefined) {
            $scope.IsEditMode = true;
             
            $http.post("/admin/edit", { email: $stateParams.email }).success(function (response) {
               
                console.log(response);
                console.log($stateParams);
             
                $scope.Leave = response;
                //$scope.IsVisible = "Admin";
                //$scope.Visible = "Team Lead";
                console.log($scope.IsVisible);
                if ($scope.Leave.Role == "Admin") {
                    $scope.IsVisible = $scope.IsVisible = true;

                }
                else if ($scope.Leave.Role == "Team Lead") {
                    $scope.Visible = $scope.Visible = true;
                }
                else {
                    $scope.IsVisible = $scope.IsVisible = false;
                    $scope.Visible = $scope.Visible = false;
                }
                //$scope.Leave.Date1 = new Date();
                $scope.date1 = new Date();
                $scope.ms = new Date().getTime() + 86400000*30;
                $scope.date2 = new Date($scope.ms);
               
                //if ($scope.date2 = new Date().getMonth() + 2 > 12) {
                //    $scope.date2 = new Date().getMonth() + 2 - 12;
                //}
                //else {
                //    $scope.date2 = new Date().getMonth() + 2;
                //}
                
                

            });        
        }

        $scope.calculate = function () {

            $scope.Leave.Action = "Pending";

            console.log($scope.Leave.Date1);
            console.log($scope.Leave.Date2);
            $scope.Day = $scope.Leave.Date1 - $scope.Leave.Date2;
            $scope.ab = (24 * 60 * 60 * 1000);
            
            if ($scope.Leave.Days = -($scope.Day / $scope.ab) + 1 <1) {
               
                alert("Check your Dates");
            }
             else  {
               
                $scope.Leave.Days = -($scope.Day / $scope.ab) + 1;
                
            }
           
        }
        $scope.GetAllData = function () {
            $http.get('/Admin').success(function (response) {
                console.log(response);
                $scope.Admins = response;

            });
        };
        $scope.GetAllData();
        $scope.sendmail = function () {
            
           
            console.log($scope.Leave.email);
            var butClick = document.getElementById("ButClick").getAttribute("value");
            console.log($scope.Leave.ProjectName);
            if (butClick == "Send") {
                $scope.ec = {};
                $scope.ec.ProjectName = $scope.Leave.ProjectName;
                $scope.ec.From = $scope.Leave.Email;;
                //$scope.ec.To = "kilupatil@gmail.com";
                $scope.ec.Body = "https://localhost:44336/#/leave";
                $scope.ec.Subject = "Leave Application";
                $scope.ec.Password = $scope.Leave.Password;
                $http({
                    method: 'POST',
                    url: '/Leave/emailsend',
                    data: JSON.stringify($scope.ec, $scope.ProjectName)
                }).then(function (result) {
                    alert(result.data);
                });
                $scope.Save();
            }
        }

        $scope.Save = function () {
          
          
            $http.post("/Leave/Save", { leaveview: $scope.Leave }).success(function (response) {
                console.log(response);
                if (response.IsSuccess) {
                    $scope.Leave = {};
                    leaveservice.RecordStatusMessage("success", response.Message);
                    

                } else {
                    leaveservice.RecordStatusMessage("error", response.Message);
                }
                  if ($stateParams.email != undefined) {
                    $scope.IsEditMode = true;

                    $http.post("/Admin/edit", { email: $stateParams.email }).success(function (response) {
                        console.log(response);
                        console.log($stateParams);

                        $scope.Leave = response;

                    });

                }
            });
              
           
           

        };

      

    }]);































