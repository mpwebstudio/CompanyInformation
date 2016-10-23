dataApp.controller('ModalController', 
    function ModalController($scope, $uibModalInstance, items, employeeService, companyService, $window) {

        employeeService.getAllEmployees(1,
                    function (data) {
                        $scope.items = data.data;
                    });

        companyService.getAllCompany(1,
            function(data) {
                $scope.companies = data;
            });

        $scope.selected = {
            item: $scope.items
        };

        $scope.updatedComp = {
            item: $scope.companies
    }

        $scope.ok = function () {
            $uibModalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
            
        };
        
        $scope.okCompany = function() {
            $uibModalInstance.close($scope.updatedCompany);
        }

        $scope.okComp = function () {
            $uibModalInstance.close($scope.updatedComp.item);
        }

        $scope.okDelete = function() {
            $uibModalInstance.close($scope.selected);
        }

    });