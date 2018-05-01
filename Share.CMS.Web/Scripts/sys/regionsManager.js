
var pageManager = function () {

    var init = function () {
        pageProperties();
        pageEvents();
    },
        pageProperties = function () {
            modalDialog = "addModal";
            formName = 'aspnetForm';
            deleteModalDialog = 'deleteModal';
            tableName = "Regions";
            pKey = "RegionID";
            gridId = "listItems";


            gridColumns = [
                {
                    "mDataProp": "RegionID",
                    "bSortable": true
                },
                {
                    "mDataProp": "Parents",
                    "bSortable": true,
                    'mData': function (row) {
                        return row.Parents ? row.Parents : row.RegionName;
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

            // bind select2 data in modal for edit
            $.fn.afterLoadDatawithdata = function (row) {
                //reset old selection
                $('#RegionParentID').select2("trigger", "select", {
                    data: { id: 0, text: null }
                });


                if (row.RegionParentID) { // check has a prerant nodes
                    // get parents nodes as array.
                    var namesArr = row.Parents ? row.Parents.split(' > ') : [],
                        parentNme = namesArr[namesArr.length - 2] || '';

                    $('#RegionParentID').select2("trigger", "select", {
                        data: { id: row.RegionParentID, text: parentNme }
                    });
                }
            }
        };


    return {
        Init: init
    };

}();



pageManager.Init();



