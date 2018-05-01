
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
            tableName = "Features";
            pKey = "FeatureID";
            gridId = "listItems";


            gridColumns = [
                {
                    "mDataProp": "FeatureID",
                    "bSortable": true
                },
                {
                    "mDataProp": "FeatureParentName",
                    "bSortable": true,
                    "mData": function (row) {
                        return row.FeatureParentName ? row.FeatureParentName : '';
                    }
                },
                {
                    "mDataProp": "FeatureName",
                    "bSortable": true
                },
                {
                    "mDataProp": "FeatureNameAr",
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


            $.fn.afterLoadDatawithdata = function (data) {
                if (data.FeatureParentID)
                    $('#FeatureParentID').select2("trigger", "select", {
                        data: { id: data.FeatureParentID, text: data.FeatureParentName }
                    });
            }

        };


    return {
        Init: init
    };

}();



pageManager.Init();



