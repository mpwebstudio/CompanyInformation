dataApp.controller('EmployeeController',
    function EmployeeController($scope, employeeService, $log, companyService, $window, $uibModal, $q, $routeParams) {
        
        $scope.animationsEnabled = true;

        $scope.employee = [];

        $scope.openEmployee = function () {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'employeeContent.html',
                controller: 'ModalController',
                resolve: {
                    items: function () {
                        return $scope.add;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $log.error(selectedItem);
                $scope.employee.delegatedEmployee = selectedItem.fullname;
                $scope.employee.delegatedEmployeeId = selectedItem.id;

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.openCompany = function () {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'companyContent.html',
                controller: 'ModalController',
                resolve: {
                    items: function () {
                        return $scope.add;
                    }
                }
            });

            modalInstance.result.then(function (selectedCompany) {
                $log.error(selectedCompany);
                $scope.employee.companyId = selectedCompany.id;
                $scope.employee.companyName = selectedCompany.companyName;

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

        $scope.addEmployee = function (employee) {
            employeeService.addEmployee(employee,
                function(response) {
                    if (response.status === true) {
                        if (employee.companyId != null) {
                            let request = { employeeID: response.data.id, companyId: employee.companyId };
                            employeeService.addEmployeeToCompany(request,
                                function(response) {
                                    if (response.success === false) {
                                        alert('Something went wromg with Employee to Company');
                                        return;
                                    }
                                });
                        }

                        if (employee.delegatedEmployeeId != null) {
                            let request = {
                                employeeId: response.data.id,
                                authorityEmployeeID: employee.delegatedEmployeeId
                            };
                            employeeService.addDelegatedAuthority(request,
                                function(response) {
                                    if (response.success === false) {
                                        alert('Something went wrong with authority');
                                        return;
                                    }
                                });
                        }
                        alert('User added successfuly');
                        $window,location = '#/'
                    } else {
                        alert('Can not add the Client');
                    }
                });
        }
    })