// home-index.js

function homeIndexController($scope, $http) {
    
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/v1/topics?includeReplies=true")
        .then(function (result) {
            //successful
            angular.copy(result.data, $scope.data);
            
        },
            function () {
                //Error
                alert("could not load topics");
            })
        .then(function () {
            $scope.isBusy = false;
        });

}