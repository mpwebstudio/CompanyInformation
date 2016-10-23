dataApp.controller('EmployeeController',
    function EmployeeController($scope, employeeService, $log, companyService, $window, $uibModal, $q, $routeParams, $location) {

        $scope.animationsEnabled = true;

        $scope.employee = [];

        let empId = +$routeParams.id;

        if (angular.isNumber(empId) && !isNaN(empId)) {
            employeeService.getSingleEmployee(empId,
                function (response) {
                    $scope.employee = response;
                });
        }

        $scope.viewEmployee = function(empId) {
            $window.location = '#/addEmployee/' + empId.id;
        }

        $scope.openDelegatedEmployee = function () {

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
                $scope.employee.delegatedAuthority = selectedItem.fullname;
                $scope.employee.delegatedAuthorityID = selectedItem.id;

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
                let company = { companyID: selectedCompany.id, companyName: selectedCompany.companyName };
                $scope.employee.company.push(company);

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

        $scope.removeCompany = function(compName) {
            $scope.employee.company.splice(compName,1);
        }

        $scope.addEmployee = function (employee) {
            employeeService.addEmployee(employee,
                function (response) {
                    if (response.status === true) {
                        if (employee.companyId != null) {
                            let request = { employeeID: response.data.id, companyId: employee.companyId };
                            employeeService.addEmployeeToCompany(request,
                                function (response) {
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
                                function (response) {
                                    if (response.success === false) {
                                        alert('Something went wrong with authority');
                                        return;
                                    }
                                });
                        }
                        alert('User added successfuly');
                        $window.location = '#/';
                    } else {
                        alert('Can not add the Client');
                    }
                });
        }

        $scope.allEmployees = [];

        if ($location.path() == '/allEmployees/') {
            employeeService.getAllEmployees(1, function (response) {
                $scope.allEmployees = response.data;
                $log.error(response.data);
            });
        }
    })