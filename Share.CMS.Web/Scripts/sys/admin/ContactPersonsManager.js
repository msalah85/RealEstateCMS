
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
            tableName = "ContactPersons";
            pKey = "ContactPersonID";
            gridId = "listItems";


            gridColumns = [
                {
                    "mDataProp": "ContactPersonID",
                    "bSortable": true
                },
                {
                    "mDataProp": "ContactPersonTypeName",
                    "bSortable": true,
                    "mData": function (row) {
                        return row.ContactPersonTypeName ? row.ContactPersonTypeName : '';
                    }
                },
                {
                    "mDataProp": "ContactName",
                    "bSortable": true
                },
                {
                    "mDataProp": "ContactNameAr",
                    "bSortable": true
                },
                {
                    "mDataProp": "ContactMobile",
                    "bSortable": true
                },
                {
                    "mDataProp": "ContactEmail",
                    "bSortable": true
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
            $.fn.afterLoadDatawithdata = function (data) {
                var $select = $('#ContactPersonTypeID');
                
                if (data.ContactPersonTypeID) {
                    $select.select2("trigger", "select", {
                        data: { id: data.ContactPersonTypeID, text: data.ContactPersonTypeName }
                    });
                }
            }

        };


    return {
        Init: init
    };

}();



pageManager.Init();



