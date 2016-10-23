dataApp.factory('employeeService', function($http, $window, $location, $log) {
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return {

        getSingleEmployee: function(id, successcb) {
            const url = 'api/employee/getSingleEmployee/';

            $http.get(url + id)
            .success(function(response) {
                if (response.status === true) {
                    successcb(response.data);
                } else {
                    alert('No such a User!');
                }
            });

        },

        getAllEmployees: function(id, successcb) {
            const url = 'api/employee/getAllEmployees';

            $http.get(url)
                .success(function(data) {
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
                    if (data.status === true) {
                        successcb(data);
                   } 
                });
        },

        addEmployeeToCompany: function(id, successcb) {
            const url = 'api/employeeToCompany/addEmployeeToCompany';
            
            $http.post(url, id, config)
                .success(function(data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        addEmployeeToCompanies: function(id, successcb) {
            const url = 'api/employeeToCompany/addEmloyeeToCompanies';

            $http.post(url, id, config)
                .success(function(data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        },

        addDelegatedAuthority: function(id, successcb) {
            const url = 'api/delegatedAuthority/addAuthority';

            $http.post(url, id, config)
                .success(function(data) {
                    if (data.success === true) {
                        successcb(data);
                    }
                });
        }


    }
})