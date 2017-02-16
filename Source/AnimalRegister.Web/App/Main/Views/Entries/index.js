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
                                    return "<a href='/#/entries/" + full.id + "/edit'>Bewerken</a>" +
                                        " | <a ng-click='index.delete(\"" + full.id + "\")'>Verwijderen</a>";
                                }
                            }
                        ],
                        createdRow: function (row, data, index) {
                            var childScope = $scope.$new(true);
                            childScope.index = vm;
                            $compile(row)(childScope);
                        } //,
                        //drawCallback: function (settings) {
                        //    if (!vm.drawed) {
                        //        var api = this.api();
                        //        $("#dataTable").append(
                        //            $('<tfoot/>').append($("#dataTable thead tr").clone())
                        //        );

                        //        $('#dataTable tfoot th').each(function () {
                        //            var title = $(this).text().trim();
                        //            if (title === "#") {
                        //                $(this).html('<input type="text" size="4" placeholder="' + title + '" />');
                        //            } else if (title === "Acties") {
                        //                $(this).html('&nbsp;');
                        //            } else {
                        //                $(this).html('<input type="text" size="10" placeholder="' + title + '" />');
                        //            }
                        //        });

                        //        api.columns().every(function (index) {
                        //            var that = api.column(index);
                        //            $('input', that.footer()).on('keyup change', function () {
                        //                if (that.search() !== this.value) {
                        //                    that
                        //                        .search(this.value)
                        //                        .draw();
                        //                }
                        //            });
                        //        });

                        //        vm.drawed = true;
                        //    }
                        //}
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