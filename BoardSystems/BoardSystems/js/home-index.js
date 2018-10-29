// home-index.js

function homeIndexController($scope, $http) {
    $scope.dataCount = 0;
    $scope.data = [];

    $http.get("/api/v1/topics?includeReplies=true")
        .then(function (result) {
            //successful
            angular.copy(result.data, $scope.data);
        },
        function () {
            //Error
            alert("could not load topics");
        })

}