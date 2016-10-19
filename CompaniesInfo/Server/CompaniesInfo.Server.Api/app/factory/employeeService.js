dataApp.factory('employeeService', function($http) {
    return {
        getAllEmployees: function(id, successcb) {
            const url = 'api/employee/getAllEmployees';

            $http.get(url)
                .success(function(data) {
                    successcb(data);
                });
        }
    }
})