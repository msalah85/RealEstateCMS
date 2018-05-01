
var pageManager = function () {

    var
        init = function () {
            pageProperties();
            pageEvents();
        },
        pageProperties = function () {
            modalDialog = "addModal";
            formName = 'aspnetForm';
            deleteModalDialog = 'deleteModal';
            tableName = "UrlRecord";
            pKey = "URLID";
            gridId = "listItems";


            gridColumns = [
                {
                    "mDataProp": "URLID",
                    "bSortable": true
                },
                {
                    "mDataProp": "URL",
                    "bSortable": true
                },
                {
                    "mDataProp": "EntityName",
                    "bSortable": true
                },
                {
                    "mDataProp": "EntityID",
                    "bSortable": true
                },
                {
                    "mDataProp": "Active",
                    "bSortable": true,
                    "mData": function (d) {
                        return d.Active === 'true' ? '<i class="fa fa-check green"></i>' : '<i class="fa fa-remove red"></i>';
                    }
                },
                {
                    "mDataProp": null,
                    "bSortable": false,
                    "sClass": 'hidden-print',
                    "mData": function () {
                        return '<button class="btn btn-primary btn-mini edit" title="Edit"><i class="fa fa-pencil"></i></button> ' +
                            '<button class="btn btn-danger btn-mini remove" title="Delete"><i class="fa fa-trash"></i></button>'
                    }
                }];

            DefaultGridManager.Init();

        },
        pageEvents = function () {
            $('#btnSave').click(function (e) {
                e.preventDefault();
                $('#aspnetForm').submit();
            });


            // bind contact type option for edit
            //$.fn.afterLoadDatawithdata = function (data) {
            //    var $select = $('#UrlRecordTypeID');
            //    if (data.UrlRecordTypeID) {
            //        $select.select2("trigger", "select", {
            //            data: { id: data.UrlRecordTypeID, text: data.UrlRecordTypeName }
            //        });
            //    }
            //}

        };


    return {
        Init: init
    };

}();



pageManager.Init();



