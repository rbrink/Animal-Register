(function () {
    var controllerId = 'app.views.entries.edit';
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

            function getEntry() {
                entryService.getEntry({ id: $stateParams.entryid }).success(function (result) {
                    vm.entry = result;

                    if (vm.entry.dateIn) {
                        var dateIn = moment(vm.entry.dateIn);
                        vm.entry.dateIn = (dateIn.isValid() ? dateIn.format("DD/MM/YYYY") : "");
                    }

                    if (vm.entry.dateOut) {
                        var dateOut = moment(vm.entry.dateOut);
                        vm.entry.dateOut = (dateOut.isValid() ? dateOut.format("DD/MM/YYYY") : "");
                    }
                });
            };

            vm.save = function () {
                entryService.updateEntry(vm.entry).success(function () {
                    $location.path("entries");
                });
            };

            getEntry();
        }
    ]);
})();