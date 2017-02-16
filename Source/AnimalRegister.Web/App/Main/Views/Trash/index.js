(function () {
    var controllerId = 'app.views.trash.index';
    angular.module('app').controller(controllerId, [
        '$rootScope',
        '$scope',
        'abp.services.mgmt.entry',
        '$compile',
        '$stateParams',
        function ($rootScope, $scope, entryService, $compile, $stateParams) {
            var vm = this;
            vm.entries = [];

            function getEntries() {
                abp.ui.block('.panel');

                entryService.getAllTrashedEntries().success(function (result) {
                    vm.entries = result.items;

                    if ($.fn.dataTable.isDataTable('#dataTable')) {
                        location.reload();
                    }

                    $('#dataTable').DataTable({
                        data: vm.entries,
                        stateSave: true,
                        language: {
                            url: "//cdn.datatables.net/plug-ins/1.10.13/i18n/Dutch.json"
                        },
                        dom: 'ltip',
                        columns: [
                            {
                                'data': 'id',
                                'title': '#&nbsp;&nbsp;',
                            },
                            {
                                'data': 'dateIn',
                                'title': 'Datum in',
                                render: function (data, type, full, meta) {
                                    var date = moment(data);
                                    return (date.isValid() ? date.format("DD/MM/YYYY") : "");
                                }
                            },
                            {
                                'data': 'specy',
                                'title': 'Diersoort',
                            }, {
                                'data': 'location',
                                'title': 'Vindplaats',
                            }, {
                                'data': 'via',
                                'title': 'Via',
                            }, {
                                'data': 'diagnose',
                                'title': 'Diagnose',
                            }, {
                                'data': 'dateOut',
                                'title': 'Datum uit',
                                render: function (data, type, full, meta) {
                                    var date = moment(data);
                                    return (date.isValid() ? date.format("DD/MM/YYYY") : "");
                                }
                            },
                            {
                                'data': 'result',
                                'title': 'Resultaat',
                            },
                            {
                                'data': null,
                                'title': 'Acties',
                                render: function (data, type, full, meta) {
                                    return "<a ng-click='index.restore(\"" + full.id + "\")'>Herstellen</a>" +
                                        " | <a ng-click='index.delete(\"" + full.id + "\")'>Verwijderen</a>";
                                }
                            }
                        ],
                        createdRow: function (row, data, index) {
                            var childScope = $scope.$new(true);
                            childScope.index = vm;
                            $compile(row)(childScope);
                        }
                    });

                    abp.ui.unblock('.panel');
                });
            };

            vm.emptyTrash = function (entryId) {
                abp.message.confirm(
                    "Weet u zeker dat u " + vm.entries.length + " regel(s) definitief wilt verwijderen?",
                    "Regel verwijderen",
                    function (isConfirmed) {
                        if (isConfirmed) {
                            entryService.deleteAllTrashedEntries().success(function () {
                                location.reload();
                            });
                        }
                    }
                );
            };

            vm.restore = function (entryId) {
                entryService.restoreEntry({ id: entryId }).success(function () {
                    location.reload();
                });
            };

            vm.delete = function (entryId) {
                abp.message.confirm(
                    "Weet u zeker dat u deze regel definitief wilt verwijderen?",
                    "Regel verwijderen",
                    function (isConfirmed) {
                        if (isConfirmed) {
                            entryService.deleteEntry({ id: entryId }).success(function () {
                                location.reload();
                            });
                        }
                    }
                );
            };

            getEntries();
        }
    ]);
})();