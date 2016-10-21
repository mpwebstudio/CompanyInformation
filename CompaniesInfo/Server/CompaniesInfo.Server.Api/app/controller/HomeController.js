dataApp.controller('HomeController',
    function HomeController($scope, $log, companyService, $window, $uibModal) {

            companyService.getAllCompany(1,
            function (data) {
                $scope.allCompany = data;
            });

        $scope.addCompany = function() {
            $window.location = '#/addCompany';
        };

        $scope.animationsEnabled = true;

        $scope.editCompany = function (company) {

            $scope.company = company;

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'editCompany.html',
                controller: 'ModalController',
                scope: $scope,
                resolve: {
                    items: function () {
                        return $scope.add;
                    }
                }
            });

            modalInstance.result.then(function () {
                companyService.editCompany(company);
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.openEmployee = function () {
                
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'currentEmployees.html',
                controller: 'ModalController',
                resolve: {
                    items: function () {
                        return $scope.add;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $log.error(selectedItem);
                $scope.company.contactName = selectedItem.fullname;
                $scope.company.contactPreferName = selectedItem.preferedName;
                $scope.company.contactEmail = selectedItem.email;
                $scope.company.contactNumber = selectedItem.telephone;

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };


        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };


    });
