(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ngResource',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'moment-picker',

        'abp'
    ]);

    app.config([
       '$stateProvider', '$urlRouterProvider',
       function ($stateProvider, $urlRouterProvider) {
           $urlRouterProvider.otherwise('/entries');
           setNavigation($stateProvider, abp.nav.menus["MainMenu"]);
       }
    ]);

    abp.log.log = {};
    abp.message.error = {};

    function setNavigation($stateProvider, menu) {
        if (menu.items.length) {
            $.each(menu.items, function (idx, m) {
                setNavigation($stateProvider, m);
            });
        }

        try {
            if (menu.url && menu.customData.templateUrl && menu.customData.routeUrl) {
                $stateProvider
                    .state(menu.name, {
                        url: menu.customData.routeUrl,
                        templateUrl: menu.customData.templateUrl,
                        menu: menu.displayName
                    });
            }
        } catch (err) { }
    };

})();