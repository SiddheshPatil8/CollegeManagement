var MyApp = angular.module("CMSApp", []);

MyApp.controller("TestAngularController", function ($scope) {


    $scope.ShowData = function () {


        var Mes = "";
        Mes = $scope.txtMessage;

        alert(Mes);

        $scope.txtMessage = "";
    };
});