dataApp.directive('modal', function() {
    return {
        template: '<div class="modal fade">' +
          '<div class="modal-dialog">' +
            '<div class="modal-content">' +
              '<div class="modal-header">' +
                '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<select ng-model="selectedEmployee" ng-options="empl.id as empl.fullname for empl in buttonClicked"> </select> ' +
              '</div>' +
              '<div class="modal-body" ng-transclude></div>' +
            '</div>' +
            '<div class="modal-footer">' +
            '<button class="btn btn-primary" type="button" ng-click="ok()">OK</button>' +
            '<button class="btn btn-warning" type="button" ng-click="cancel()">Cancel</button>' +
        '</div>' +
          '</div>' +
          
        '</div>',
        restrict: 'E',
        transclude: true,
        resolve: {
            function() {
                return $scope.selectedEmployee;
            }
        },
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });



            $(element).on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    };
});