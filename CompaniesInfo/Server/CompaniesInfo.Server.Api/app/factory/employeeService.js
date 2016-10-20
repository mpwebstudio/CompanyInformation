dataApp.factory('employeeService', function($http, $window, $location) {
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return {
        getAllEmployees: function(id, successcb) {
            const url = 'api/employee/getAllEmployees';

            $http.get(url)
                .success(function(data) {
                    successcb(data);
                });
        },

        addEmployee: function(id, successcb) {
            const url = 'api/employee/createemployee';

            $http.post(url, { request: id })
                .success(function(data) {
                   if (data.status === true) {
                       successcb(data);
                   } 
                });
        },

        addEmployeeToCompany: function(id, successcb) {
            const url = 'api/employeeToCompany/addEmployeeToCompany';
            
            $http.post(url, id, config)
                .success(function(data) {
                    if (data.status === true) {
                        successcb(data);
                    }
                });
        }


    }
})