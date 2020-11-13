    var selectedId;
        $(document).ready(function () {
        $('#edit').on('show.bs.modal', function (e) {
            e.stopPropagation();
            var _row = $(e.relatedTarget).parents("tr");
            selectedId = _row.find("#Id").html();

            var _store = _row.find("#store").text();
            var _month = _row.find("#month").text();
            var _wasteKind = _row.find("#wasteKind").text();
            var _quantity = _row.find("#quantity").text();
            var _quantityUnit = _row.find("#quantityUnit").text();
            var _wasteType = _row.find("#wasteType").text();
            var _recipientCompany = _row.find("#recipientCompany").text();
            var _wasteDate = _row.find("#wasteDate").text();
            var _content = _row.find("#content").text();

            var wasteDateFormatted = new Date(_wasteDate).toISOString().slice(0, 10);

            $(this).find("#StoreTxt").val(_store);
            $(this).find("#MonthTxt").val(_month);
            $(this).find("#WasteKindTxt").val(_wasteKind);
            $(this).find("#QuantityTxt").val(_quantity);
            $(this).find("#UnitSelect").val(_quantityUnit);
            $(this).find("#WasteTypeTxt").val(_wasteType);
            $(this).find("#RecipientCompanyTxt").val(_recipientCompany);
            $(this).find("#WasteDateTxt").val(wasteDateFormatted);
            $(this).find("#ContentTxt").val(_content);
        });

            $("tbody #delete").click(function (e) {
        myDeleteFunction(e);
            });
        });
        function InitializeModal(id) {
            var Id = null;
            var Store = $("#StoreTxt option:selected").text();
            var Month = $("#MonthTxt option:selected").text();
            var WasteKind = $("#WasteKindTxt option:selected").text();
            var Quantity = $("#QuantityTxt").val();
            var QuantityUnit = $("#UnitSelect option:selected").text();
            var WasteType = $("#WasteTypeTxt option:selected").text();
            var RecipientCompany = $("#RecipientCompanyTxt option:selected").text();
            var WasteDate = $("#WasteDateTxt").val();
            var Content = $("#ContentTxt").val();
            if (id != null) {
        Id = id;
            }
            var dataObj = {
        Id: Id, Store: Store, Month: Month, WasteKind: WasteKind, Quantity: Quantity, QuantityUnit: QuantityUnit,
                WasteType: WasteType, RecipientCompany: RecipientCompany, WasteDate: WasteDate, Content: Content
            };
            return dataObj;
        }

        function myDeleteFunction(e) {
            var selectedId = $(e.target).closest('tr').find("#Id").html();
            alert(selectedId);
            swal({
        title: 'Silinecek!',
                text: "Silmek istediğinize emin misiniz?",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, sil!',
                cancelButtonText: 'İptal!',
                closeOnConfirm: false
            }).then(function (result) {
                if (result) {
        $.ajax({
            url: '/Home/Delete/',
            data: { id: selectedId },
            type: 'POST',
            dataType: 'json',
            success: function () {
                swal('Silindi!', 'Silindi', 'success');
            },
            error: function () {
                swal('Hata', 'Hata', 'error');
            }
        });
                }
            })
        }
        function myUpdateFunction() {
            var id = selectedId;
            var dataObj = InitializeModal(id);
            $.ajax({
        type: "POST",
                url: "/Home/Update",
                data: dataObj,
                success: function (data) {
        swal('Başarılı!', 'Başarılı güncellendi', 'success');
                },
                error: function (xhr, ajaxOptions, thrownError) {
        swal('Hata!', 'Hata', 'error');
                }
            });
        }
        function myAddFunction() {
            var dataObj = InitializeModal();
            $.ajax({
        type: "POST",
                url: "/Home/Add",
                data: dataObj,
                success: function (data) {
                    if(data=="True")
                        swal('Başarılı!', 'Başarılı eklendi', 'success');
                    else
                        swal('Hata!', 'Hata', 'error');
                },
                error: function (xhr, ajaxOptions, thrownError) {
        swal('Hata!', 'Hata', 'error');
                }
            });
        }

        var assetListVM;
        var $table = ('#WasteTable');
        $(function () {
        assetListVM = {
            dt: null,
            init: function () {
                $.ajax({
                    url: '/Home/Get/',
                    type: 'GET',
                    dataType: 'json',
                    success: function (data) {
                        dt = $('#WasteTable').DataTable({
                            oLanguage: {
                                "sSearch": 'Search',
                                "sLengthMenu": "_MENU_",
                                "sInfoEmpty": "0",
                                "sInfo": "_START_ - _END_ (_TOTAL_)",
                                "sZeroRecords": "-",
                                "sLoadingRecords": "...",
                                "sInfoThousands": "."
                            },
                            columns: [
                                { "data": "id", "searchable": true },
                                { "data": "store", "searchable": true },
                                { "data": "month", "searchable": true },
                                { "data": "wasteKind", "searchable": true },
                                { "data": "quantity" },
                                { "data": "quantityUnit", "searchable": true },
                                { "data": "wasteType", "searchable": true },
                                { "data": "recipientCompany", "searchable": true },
                                { "data": "wasteDate", "searchable": true },
                                { "data": "content", "searchable": true },
                                {
                                    "mRender": function (data, type, row) {
                                        return '<p style="white-space: nowrap" title = "Options" ><button class="btn btn-primary btn-sm" data-title="Edit" data-toggle="modal" data-target="#edit" ><span class="fa fa-pencil-square-o"></span></button><button class="btn btn-danger btn-sm" id="delete" onClick="myDeleteFunction(event)" data-title="Delete"><span class="fa fa-trash-o"></span></button></p>';
                                    }
                                }
                            ],
                            columnDefs: [
                                {
                                    targets: 0,
                                    'width': "10%",
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'Id');
                                    }
                                },
                                {
                                    targets: 1,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'store');
                                    }
                                },
                                {
                                    targets: 2,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'month');
                                    }
                                },
                                {
                                    targets: 3,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'wasteKind');
                                    }
                                },
                                {
                                    targets: 4,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'quantity');
                                    }
                                },
                                {
                                    targets: 5,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'quantityUnit');
                                    }
                                },
                                {
                                    targets: 6,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'wasteType');
                                    }
                                }, {
                                    targets: 7,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'recipientCompany');
                                    }
                                }, {
                                    targets: 8,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'wasteDate');
                                    }
                                },
                                {
                                    targets: 9,
                                    "createdCell": function (td) {
                                        $(td).attr('id', 'content');
                                    }
                                }, {
                                    targets: 10,
                                    render: function (data, type, row) {
                                        return type === 'display' && data != null ?
                                            data.substr(0, 10) + '…' :
                                            data;
                                    }
                                }
                            ],
                            data: data
                        })
                    },
                    error: function (hata, thrownError) {
                        alert(hata.status);
                        alert(thrownError);
                        alert(hata.responseText);
                    }
                });
            }
        }
            assetListVM.init();
        });
