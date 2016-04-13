var app = angular.module('app', ['ngRoute', 'conube.controller']);

app.config(function($routeProvider, $httpProvider) {
  $routeProvider
    .when('/', {templateUrl: 'Conube/conube.html'})
    .when('/conube', {templateUrl: 'Conube/conube.html'})
    .otherwise({templateUrl: 'Conube/conube.html'});
});
