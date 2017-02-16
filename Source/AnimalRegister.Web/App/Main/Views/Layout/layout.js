(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$rootScope',
        '$state',
        function ($rootScope, $state) {
            var vm = this;
            vm.menus = [];

            function getMenus() {
                vm.menus.push(abp.nav.menus.MainMenu);
            };

            getMenus();
        }]);
})();