(function () {
    angular.module('app').filter('getById', function ($filter) {
        return function (input, id) {
            var i = 0, len = input.length;
            for (; i < len; i++) {
                if (input[i].id === id) {
                    return input[i];
                }
            }

            return null;
        };
    });
})();