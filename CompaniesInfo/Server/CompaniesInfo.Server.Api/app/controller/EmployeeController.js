dataApp.controller('EmployeeController',
    function EmployeeController($scope, employeeService, $log, companyService, $window, $uibModal, $q, $routeParams, $location) {

        let isCompanyChange = false;
        let isAuthorityChange = false;
        let oldEmploee = {};

        $scope.animationsEnabled = true;

        $scope.employee = {};

        let empId = +$routeParams.id;

        if (angular.isNumber(empId) && !isNaN(empId)) {
            employeeService.getSingleEmployee(empId,
                function (response) {
                    $scope.employee = response;
                    if (oldEmploee === {}) {
                        oldEmploee = response;
                    }
                });
        }

        $scope.viewEmployee = function (empId) {
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
                isAuthorityChange = true;

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        function checkAvailability(arr, val) {
            return arr.some(arrVal => val === arrVal.companyID);
        }

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
                let company = { companyID: selectedCompany.id, companyName: selectedCompany.companyName };
                if ($scope.employee.company == null) {
                    $scope.employee.company = [];
                    $scope.employee.company.push(company);
                } else {

                    if (checkAvailability($scope.employee.company, company.companyID)) {
                        alert('Company exist')
                    } else {
                        $scope.employee.company.push(company);
                        isCompanyChange = true;
                    }
                }

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

        $scope.removeCompany = function (compName) {
            $scope.employee.company.splice(compName, 1);
            isCompanyChange = true;
        }

        $scope.removeAuthority = function () {
            $scope.employee.delegatedAuthorityID = null;
            $scope.employee.delegatedAuthority = null;
            isAuthorityChange = true;
        }

        $scope.addEmployee = function (employee) {
            employeeService.addEmployee(employee,
                function (response) {
                    if (response.success === true) {
                        if (employee.company != null) {
                            let comp = [...employee.company];
                            let compIdSum = [];
                            for (valCompany of comp) {
                                compIdSum.push(valCompany.companyID);
                            }
                            let request = { employeeID: response.data.id, companyId: compIdSum };
                            employeeService.addEmployeeToCompanies(request,
                                function (response) {
                                    if (response.success === false) {
                                        alert('Something went wromg with Employee to Company');
                                        return;
                                    }
                                });
                        }

                        if (employee.delegatedAuthorityID != null) {
                            let request = {
                                employeeId: response.data.id,
                                authorityEmployeeID: employee.delegatedAuthorityID
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
            });
        }

        $scope.updateEmployee = function (employee) {
            if (oldEmploee === employee) {
                $log.error(oldEmploee);
                $log.error(employee);


                alert('Same');
            } else {
                employeeService.updateEmployee(employee,
                    function (response) {
                        if (response.success === true && isAuthorityChange === true) {
                            if (employee.delegatedAuthorityID === null) {
                                employeeService.deleteDelegatedAuthority(employee.id,
                                    function (response) {
                                        if (response.success === false) {
                                            alert('Something went wrong for Autority User');
                                        }
                                    });
                            }
                            if (oldEmploee.delegatedAuthorityID === null && employee.delegatedAuthorityID !== null) {
                                let request = {
                                    authorityEmployeeID: employee.delegatedAuthorityID,
                                    employeeID: employee.id
                                };
                                employeeService.addDelegatedAuthority(request,
                                    function (response) {
                                        if (response.success === false) {
                                            alert('Something went wrong for Autority User');
                                        }
                                    });
                            } else {
                                let request = {
                                    authorityEmployeeID: employee.delegatedAuthorityID,
                                    employeeID: employee.id
                                };
                                employeeService.updateDelegatedAuthority(request,
                                    function (response) {
                                        if (response.success === false) {
                                            alert('Something went wrong for Autority User');
                                        }
                                    });
                            }

                            alert('User details updated');
                        }

                        if (response.success === true && isCompanyChange === true) {
                            if (employee.company.lenght == 0) {
                                let request = { employeeID: employee.id };
                                employeeService.deleteAllEmployeeToCompany(request,
                                    function (response) {
                                        if (response.success === true) {
                                            $log.error('company to employee deleted');
                                        }
                                    });
                            } else {
                                let comp = [...employee.company];
                                let compIdSum = [];
                                for (valCompany of comp) {
                                    compIdSum.push(valCompany.companyID);
                                }
                                let request = { employeeID: response.data.id, companyId: compIdSum };
                                employeeService.updateEmployeeToCompanies(request,
                                    function (response) {
                                        if (response.success === false) {
                                            alert('Something went wromg with Employee to Company');
                                            return;
                                        }
                                    });
                            }

                            alert('User details updated');

                        }

                        if (response.success === false) {
                            alert('Something went wrong in employee');
                        }
                    });
            }
        }

        $scope.deleteEmployee = function (employee) {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'deleteUser.html',
                controller: 'ModalController',
                scope: $scope,
                resolve: {
                    items: function () {
                        return $scope.add;
                    }
                }
            });

            modalInstance.result.then(function (selected) {
                if (selected === true) {
                    let request = { employeeID: employee.id };
                    employeeService.deleteEmployee(request,
                        function (response) {
                            if (response.success === true) {
                                $window.location = '#/';
                            } else {
                                alert(response.message);
                            }
                        });
                }

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }

        $scope.cancel = function() {
            $window.location = '#/allEmployees';
        }
    })