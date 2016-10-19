dataApp.controller('CompanyController',
    function CompanyController($scope, employeeService, $log, companyService, $window, $uibModal) {

        $scope.animationsEnabled = true;

        $scope.Items = ['item1', 'item2', 'item3'];

        $scope.open = function (size) {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'ModalController',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.Items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

    });

