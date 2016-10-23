dataApp.controller('CompanyController',
    function CompanyController($scope, employeeService, $log, companyService, $window, $uibModal, $q, $routeParams) {

        //Checks if we are calling single company
        let compId = +$routeParams.id;

        if (angular.isNumber(compId) && !isNaN(compId)) {

            companyService.getCompanyById(compId,
                function (data) {
                    $scope.companyInfo = data;
                });
        }

        $scope.animationsEnabled = true;

        $scope.editCompany = function (company) {

            $log.error(company);

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


        $scope.deleteCompany = function (company) {
            companyService.deleteCompany(company, function (response) {
                if (response.success === true) {
                    $window.location = '#/';
                }
            });
        };

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

        $scope.addCompany = function (employee, company) {

            if (employee.id != undefined) {
                let mix = { company: company, primeContactId: employee.id };
                companyService.createCompany(mix);
                $window.location = '#/';
            } else {
                employeeService.addEmployee(employee,
                    function (empResponse) {
                        let requestCompany = { company: company, primeContactId: empResponse.data.id };
                        companyService.createCompany(requestCompany,
                            function (response) {
                                if (response.success === true) {
                                    $window.location = '#/';
                                } else {
                                    alert('Something whent wrong');
                                }
                            });
                    });
            }
        }

        $scope.allUsers = function () {
            
            companyService.getAllCompanyUsers(compId,
                function(response) {
                    $log.error(response);
                    $scope.allEmployees = response.data;
                });
        }

        $scope.viewEmployee = function(emp) {
            $window.location = '#/addEmployee/' + emp.id;
        }
    });

