dataApp.controller('CompanyController',
    function CompanyController($scope, employeeService, $log, companyService, $window, $uibModal, $q) {

        $scope.animationsEnabled = true;

        $scope.open = function (size) {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'ModalController',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.add;
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



        $scope.addCompany = function(selected, company) {

            var deffered = $q.defer();

            if (selected.id != undefined) {
                let mix = { company: company, primeContactId: selected.id };
                companyService.createCompany(mix);

            } else {
                
            }

        };



    });

