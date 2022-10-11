var MyApp = angular.module("CMSApp", []);

MyApp.controller("BatchController", function ($scope, $http) {
    $scope.btnSaveText = "Save";

    $scope.SaveData = function () {
            $scope.btnSaveText = "Saving.....";
            $http({
                method: 'POST',
                url: '/Batch/Save_Info',
                data: $scope.BatchDataObject
            }).success(function (a) {
                $scope.btnSaveText = "Save";
                $scope.BatchDataObject = null;
                alert(a);
            }).error(function () {
                alert("Faild");
            })
    };

    $http.get("/Batch/Load_Data").then(function (d) {
        $scope.Batch = d.data;

    }, function (error) {
        alert("Failed");
    });

    $scope.GetOneRecord = function (MasterId) {
        $http.get("/Batch/GetMasterDataById?MasterId=" + MasterId).then(function (d) {
            $scope.BatchDataObject = d.data[0];

        }, function (error) {
            alert("Failed");
        });
    }
});