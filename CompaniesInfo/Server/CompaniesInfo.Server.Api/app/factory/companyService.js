dataApp.factory('companyService', function ($http) {
    return {
        getAllCompany: function(id, successcb) {
            const url = 'api/company/getAllCompany';

            $http.get(url)
                .success(function(data) {
                    successcb(data);
                });


        }
    }
})