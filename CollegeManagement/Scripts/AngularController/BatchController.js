var MyApp = angular.module("CMSApp", []);

MyApp.controller("BatchController", function ($scope, $http) {
    $scope.btnSaveText = "Save";

    $scope.SaveData = function () {
        if ($scope.btnSaveText == "Save") {
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
                alert("Failed");
<<<<<<< HEAD
            });
=======
            })
>>>>>>> 9215d4a5faf17b6fb2f1ec91ad20f597dbf695b6
        }
        else {
            $scope.btnSaveText = "Updating.....";
            $http({
                method: 'POST',
                url: '/Batch/Update_Info',
                data: $scope.BatchDataObject
            }).success(function (a) {
<<<<<<< HEAD
                $scope.btnSaveText = "Save";
=======
                $scope.btnSaveText = "Update";
>>>>>>> 9215d4a5faf17b6fb2f1ec91ad20f597dbf695b6
                $scope.BatchDataObject = null;
                alert(a);
            }).error(function () {
                alert("Failed");
<<<<<<< HEAD
            });
        }
=======
            })
        }

>>>>>>> 9215d4a5faf17b6fb2f1ec91ad20f597dbf695b6
    };

    $http.get("/Batch/Load_Data").then(function (d) {
        $scope.Batch = d.data;

    }, function (error) {
        alert("Failed");
    });

    $scope.GetOneRecord = function (MasterId) {
        $http.get("/Batch/GetMasterDataById?MasterId=" + MasterId).then(function (d) {
            $scope.BatchDataObject = d.data[0];
            $scope.btnSaveText = "update";
        }, function (error) {
            alert("Failed");
        });
    };

    $scope.DeleteMasterData = function (Batch_Id) {
        $http.get("/Batch/RemoveDataByMasterId?Batch_Id=" + Batch_Id).then(function (d) {
            alert(d.data);
            $http.get("/Batch/Load_Data").then(function (d) {
                $scope.Batch = d.data;

            }, function (error) {
                alert("Failed");
            });
        },
            function (error) {
                alert("Failed");
            }
        );
    };
});