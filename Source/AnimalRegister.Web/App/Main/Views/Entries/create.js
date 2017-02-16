(function () {
    var controllerId = 'app.views.entries.create';
    angular.module('app').controller(controllerId, [
        '$rootScope',
        '$scope',
        'abp.services.mgmt.entry',
        '$compile',
        '$stateParams',
        '$location',
        function ($rootScope, $scope, entryService, $compile, $stateParams, $location) {
            var vm = this;
            vm.entry = {};
            vm.pageform = undefined;

            vm.save = function () {
                entryService.createEntry(vm.entry).success(function () {
                    $location.path("entries");
                });
            };
        }
    ]);
})();