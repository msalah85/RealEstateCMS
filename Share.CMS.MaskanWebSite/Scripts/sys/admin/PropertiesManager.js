
var pageManager =
    function () {
        var
            init = function () {
                pageProperties();
                pageEvents();
            },
            pageProperties = function () {
                modalDialog = "addModal";
                formName = 'aspnetForm';
                deleteModalDialog = 'deleteModal';
                tableName = "Properties";
                pKey = "PropertyID";
                gridId = "listItems";

                gridColumns = [
                    {
                        "mDataProp": "PropertyID",
                        "bSortable": true
                    },
                    {
                        "mDataProp": "PropertyTypeName",
                        "bSortable": true
                    },
                    {
                        "mDataProp": "PropertyTitle",
                        "bSortable": true
                    },
                    {
                        "mDataProp": "PriceTypeName",
                        "bSortable": true,
                        "mData": function (d) {
                            return numeral(d.Price).format('0,0') +', '+ d.PriceTypeName;
                        }
                    },
                    {
                        "mDataProp": "CreationDate",
                        "bSortable": true,
                        "mData": function (d) {
                            return moment(d.CreationDate).format('MM/DD/YYYY');
                        }
                    },
                    {
                        "mDataProp": "CountryName",
                        "bSortable": true,
                        "mData": function (d) {
                            return `${d.CountryName}, ${d.CityName}, ${d.ResidanceName}`;
                        }
                    },
                    {
                        "mDataProp": "Active",
                        "bSortable": true,
                        "mData": function (d) {
                            return d.Active === 'true' ? '<i class="fa fa-check green"></i>' : '<i class="fa fa-remove red"></i>';
                        }
                    },
                    {
                        "mDataProp": "MainPicture",
                        "bSortable": true,
                        "mData": function (d) {
                            return d.MainPicture ? `<a href="Images?id=${d.PropertyID}" title="Photos"><img src="/public/images/_thumb/${d.MainPicture}" class="media-object" /></a>` : '';
                        }
                    },
                    {
                        "mDataProp": null,
                        "bSortable": false,
                        "sClass": 'hidden-print',
                        "mData": function (d) {
                            return `<a href="PropertyAddEdit?id=${d.PropertyID}" class="btn btn-primary btn-mini" title="Edit"><i class="fa fa-pencil"></i></a>
                                <a href="Images?id=${d.PropertyID}" class="btn btn-pink btn-mini" title="Photos"><i class="fa fa-picture-o"></i></a>
                                <button class="btn btn-danger btn-mini remove" title="Delete"><i class="fa fa-trash"></i></button>`;
                        }
                    }];

                DefaultGridManager.Init();
            },
            pageEvents = function () {
                //$('#btnSave').click(function (e) {
                //    e.preventDefault();
                //    $('#aspnetForm').submit();
                //});

                //// bind contact type option for edit
                //$.fn.afterLoadDatawithdata = function (data) {
                //    var $select = $('#PropertyTypeID');
                //    if (data.PropertyTypeID) {
                //        $select.select2("trigger", "select", {
                //            data: { id: data.PropertyTypeID, text: data.PropertyTypeName }
                //        });
                //    }
                //}

            };



        return {
            Init: init
        };

    }();


pageManager.Init();