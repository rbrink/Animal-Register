(function () {
    var controllerId = 'app.views.entries.index';
    angular.module('app').controller(controllerId, [
        '$rootScope',
        '$scope',
        'abp.services.mgmt.entry',
        '$compile',
        '$stateParams',
        function ($rootScope, $scope, entryService, $compile, $stateParams) {
            var vm = this;
            vm.entries = [];
            vm.drawed = false;
            vm.filterables = [
                '#',
                'Datum in',
                'Diersoort',
                'Vindplaats',
                'Via',
                'Diagnose',
                'Datum uit',
                'Resultaat'
            ];

            function getEntries() {
                abp.ui.block('.panel');

                entryService.getAllEntries().success(function (result) {
                    vm.entries = result.items;

                    if ($.fn.dataTable.isDataTable('#dataTable')) {
                        location.reload();
                    }

                    var table = $('#dataTable').DataTable({
                        data: vm.entries,
                        stateSave: false,
                        language: {
                            url: "//cdn.datatables.net/plug-ins/1.10.13/i18n/Dutch.json"
                        },
                        "lengthMenu": [
                            [10, 25, 50, 100, -1],
                            [10, 25, 50, 100, "Alles"]
                        ],
                        dom: 'Bpltip',
                        buttons: [
                            { extend: "copy", className: 'btn btn-default btn-sm margin-r-5 margin-b-5' },
                            { extend: "csv", className: 'btn btn-default btn-sm margin-r-5 margin-b-5' },
                            { extend: "excel", className: 'btn btn-default btn-sm margin-r-5 margin-b-5' },
                            { extend: "pdf", orientation: 'landscape', className: 'btn btn-default btn-sm margin-r-5 margin-b-5' },
                            { extend: "print", orientation: 'landscape', className: 'btn btn-default btn-sm margin-r-5 margin-b-5' }
                        ],
                        columns: [
                            {
                                'data': 'id'
                            },
                            {
                                'data': 'dateIn',
                                render: function (data, type, full, meta) {
                                    var date = moment(data);
                                    return (date.isValid() ? date.format("DD/MM/YYYY") : "");
                                }
                            },
                            {
                                'data': 'specy'
                            }, {
                                'data': 'location'
                            }, {
                                'data': 'via'
                            }, {
                                'data': 'diagnose'
                            }, {
                                'data': 'dateOut',
                                render: function (data, type, full, meta) {
                                    var date = moment(data);
                                    return (date.isValid() ? date.format("DD/MM/YYYY") : "");
                                }
                            },
                            {
                                'data': 'result'
                            },
                            {
                                'data': null,
                                render: function (data, type, full, meta) {
                                    return "<a href='/#/entries/" + full.id + "/edit'>Bewerken</a>" +
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

                    angular.forEach(vm.filterables, function (v, k) {
                        $("#filterable_" + k).on('keyup paste', function () {
                            table.column(k)
                                .search($(this).val().replace(/;/g, '&quot;|&quot;'), true, false)
                                .draw();
                        });
                    });

                    abp.ui.unblock('.panel');
                });
            };

            vm.delete = function (entryId) {
                abp.message.confirm(
                    "Weet u zeker dat u deze regel wilt verwijderen?",
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