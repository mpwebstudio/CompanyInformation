dataApp.controller('ModalController', 
    function ModalController($scope, $uibModalInstance, items, employeeService) {

        employeeService.getAllEmployees(1,
                    function (data) {
                        $scope.items = data.data;
                    });

        $scope.selected = {
            item: $scope.items
        };

        $scope.ok = function () {
            $uibModalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        //$scope.editCompany = function(company) {
        //    $scope.editCompany = company;
        //    $uibModalInstance.close($scope.edited);
        //};

        $scope.okCompany = function() {
            $uibModalInstance.close($scope.updatedCompany);
        }
    });