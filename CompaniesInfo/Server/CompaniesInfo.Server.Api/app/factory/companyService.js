dataApp.factory('companyService', function ($http, $log, employeeService) {
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return {
      

        getAllCompany: function(id, successcb) {
            const url = 'api/company/getAllCompany';

            $http.get(url)
                .success(function(data) {
                    successcb(data);
                });


        },

        createCompany: function(id, successcb) {
            const url = 'api/company/createCompany';
            let req = { companyName: id.company, primeContactId: id.primeContactId };

            $http.post(url, req, config)
                .then(function (response) {
                    $log.error(response);
                    let request = { companyId: response.data.id, employeeId: response.data.primeContactID };
                    employeeService.addEmployeeToCompany(request);
                });
            //.success(function(data) {
            //    if (data.status === true) {
            //        successcb(data);
            //    }
            //});
        }


    }
})


