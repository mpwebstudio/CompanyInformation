dataApp.controller('HomeController',
    function HomeController($scope, $log, companyService, $window) {

            companyService.getAllCompany(1,
            function (data) {
                $scope.allCompany = data;
            });

            $scope.addCompany = function () {
                $window.location = '#/addCompany';
            }

            
    });
