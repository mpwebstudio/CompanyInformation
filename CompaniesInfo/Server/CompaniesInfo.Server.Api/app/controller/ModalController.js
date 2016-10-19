dataApp.controller('ModalController', 
    function ModalController($scope, $uibModalInstance, items, employeeService) {

        employeeService.getAllEmployees(1,
                    function (data) {
                        $scope.items = data;
                            
                        ;
                    });

        //$scope.items = ['item1', 'item2', 'item3'];

        $scope.selected = {
            item: $scope.items
        };

        $scope.ok = function () {
            $uibModalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    });