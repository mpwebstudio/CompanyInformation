'use strict';

var dataApp = angular
    .module('dataApp', ['ngResource', "ngRoute", 'ngAnimate', 'ui.bootstrap'])
    .config(function($routeProvider) {
        $routeProvider
            .when('/',
            {
                templateUrl: '/app/templates/home.html'
            })
            .when('/company/:id',
            {
                templateUrl: 'app/templates/companyInforamtion.html'
            })
            .when('/allCompany',
            {
                templateUrl: 'app/templates/allCompany.html'
            })
            .when('/addCompany',
            {
                templateUrl: 'app/templates/addCompany.html'
            })
            .when('/addEmployee/:id',
            {
                templateUrl: 'app/templates/addEmployee.html'
            })
            .when('/addEmployee/',
            {
                templateUrl: 'app/templates/addEmployee.html'
            })
            .when('/allEmployees/',
            {
                templateUrl: 'app/templates/allEmployees.html'
            })
            .when('/companyInfo/:id',
            {
                templateUrl: 'app/templates/companyInfo.html'
            })
            .otherwise({ redirectTo: '/' });
    });