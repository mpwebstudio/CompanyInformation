dataApp.factory('employeeService', function ($http, $window, $location, $log) {
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return {
        getSingleEmployee: function (id, successcb) {
            const url = 'api/employee/getSingleEmployee/';

            $http.get(url + id)
                .success(function (response) {
                    if (response.success === true) {
                        successcb(response.data);
                    } else {
                        alert('No such a User!');
                    }
                });
        },

        getAllEmployees: function (id, successcb) {
            const url = 'api/employee/getAllEmployees';

            $http.get(url)
                .success(function (data) {
                    successcb(data);
                });
        },

        addEmployee: function (employee, successcb) {

            const url = 'api/employee/createemployee';
            let request = {
                fullname: employee.fullname,
                preferedName: employee.preferedName,
                telephone: employee.telephone,
                email: employee.email
            };

            $http.post(url, request, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        updateEmployee: function (id, successcb) {
            const url = 'api/employee/updateEmployeeDetails';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                })
                .error(function (data) {
                    alert(data.message);
                });
        },

        deleteEmployee: function (id, successcb) {
            const url = 'api/employee/deleteEmployee';

            $http.post(url, id, config)
                .success(function (data) {
                    successcb(data);
                });
        },

        addDelegatedAuthority: function (id, successcb) {
            const url = 'api/delegatedAuthority/addAuthority';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        updateDelegatedAuthority: function (id, successcb) {
            const url = 'api/delegatedAuthority/updateAuthority';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        deleteDelegatedAuthority: function (id, successcb) {
            const url = 'api/delegatedAuthority/deleteAuthority';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        addEmployeeToCompany: function (id, successcb) {
            const url = 'api/employeeToCompany/addEmployeeToCompany';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        addEmployeeToCompanies: function (id, successcb) {
            const url = 'api/employeeToCompany/addEmployeeToCompanies';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        deleteAllEmployeeToCompany: function (id, successcb) {

            const url = 'api/employeeToCompany/deleteAllEmployeeToCompany';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        updateEmployeeToCompanies: function (id, successcb) {
            const url = 'api/employeeToCompany/updateEmployeeToCompany';

            $http.post(url, id, config)
                .success(function (data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        }
    }
})