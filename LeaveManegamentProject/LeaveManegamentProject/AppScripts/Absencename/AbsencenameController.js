

app.controller("AbsencenameController", ["$scope", "$http", "$stateParams", "$rootScope", "$location", "leaveservice",
    function ($scope, $http, $stateParams, $rootScope, $location, leaveservice, ) {

        $scope.Absencenames = [];
        $scope.IsVisible = false;
        $scope.GetAllData = function () {
            $http.get('/Absencename').success(function (response) {
                console.log(response);
                $scope.Absencenames = response;

            });
        };
        $scope.GetAllData();
        $scope.Delete = function (Id) {

            $http.get('/Absencename/Delete/' + Id).success(function (response) {

                if (response.IsSuccess) {
                    leaveservice.RecordStatusMessage("success", response.Message);
                    $scope.GetAllData();
                }
                else {
                    leaveservice.RecordStatusMessage("danger", response.Message);
                }
            });
        };     
    }
]);

app.controller("AbsencenameAddController", ["$scope", "$http", "$stateParams", "$location", "leaveservice",
    function ($scope, $http, $stateParams, $location, leaveservice) {



        $scope.Absencename = {};




        $scope.IsEditMode = false;

        if ($stateParams.Id != undefined) {
            $scope.IsEditMode = true;

            $http.post("/Absencename/edit", { Id: $stateParams.Id }).success(function (response) {
                console.log(response);
                console.log($stateParams);

                $scope.Absencename = response;
               
            });

        }          

        $scope.Save = function () {
            if ($scope.IsEditMode) {
                $http.post("/Absencename/Update", { absencenameview: $scope.Absencename }).success(function (response) {
                    console.log(response);
                    if (response.IsSuccess) {
                        $scope.Absencename = {};
                        leaveservice.RecordStatusMessage("success", response.Message);
                        $location.path("/absencename");

                    } else {
                        leaveservice.RecordStatusMessage("error", response.Message);
                    }

                });
            }
            else {

                $http.post("/Absencename/Save", { absencenameview: $scope.Absencename }).success(function (response) {
                    console.log(response);
                    if (response.IsSuccess) {
                        $scope.Absencename = {};
                        leaveservice.RecordStatusMessage("success", response.Message);
                        $location.path("/absencename");

                    } else {
                        leaveservice.RecordStatusMessage("error", response.Message);
                    }

                });
            }
           


        };
    }]);