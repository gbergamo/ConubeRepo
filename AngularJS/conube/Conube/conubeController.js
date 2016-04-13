angular.module('conube.controller', [])
.controller('ConubeCtrl', ['$scope', '$http', function($scope, $http) {

  $scope.storyonesubmit = function(){
    var data = $scope.s1
    $http.post('http://conube.brag-soft.com/conube/calculateWithhold', data)
      .success(function(data, status, headers, config) {
        $scope.responseS1 = data;
      })
      .error(function(data, status, headers, config) {
        alert('Ocorreu um erro ao carregar os dados. ERRO 002');
      })
      .finally(function() {});
  }

  $scope.storytwosubmit = function(){
    var data = $scope.s2
    $http.post('http://conube.brag-soft.com/conube/CalculateWithholdWithCustomTaxValues', data)
      .success(function(data, status, headers, config) {
        $scope.responseS2 = data;
      })
      .error(function(data, status, headers, config) {
        alert('Ocorreu um erro ao carregar os dados. ERRO 002');
      })
      .finally(function() {});
  }

  $scope.storythreesubmit = function(){
    var data = $scope.s3
    $http.post('http://conube.brag-soft.com/conube/calculateWithhold', data)
      .success(function(data, status, headers, config) {
        $scope.responseS3 = data;
      })
      .error(function(data, status, headers, config) {
        alert('Ocorreu um erro ao carregar os dados. ERRO 002');
      })
      .finally(function() {});
  }

}])
