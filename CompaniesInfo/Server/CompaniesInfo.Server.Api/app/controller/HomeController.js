dataApp.controller('HomeController',
    function HomeController($scope, $log, companyService, $window, $uibModal, $q) {

        companyService.getAllCompany(1,
        function (data) {
            $scope.allCompany = data;
        });

        $scope.addCompany = function () {
            $window.location = '#/addCompany';
        };

        $scope.addEmployee = function() {
            $window.location = '#/addEmployee';
        }
        $scope.viewCompany = function(company) {
            $window.location = '#/companyInfo/' + company.id;
        };
    });
