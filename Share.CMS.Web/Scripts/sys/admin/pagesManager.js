var PagesManager = function () {

    var
        Init = function () {

            tableName = "Pages";
            pKey = "Id";
            gridId = "itemsDataTable";

            gridColumns = [
                {
                    "mDataProp": "Id",
                    "bSortable": true
                },
                {
                    "mDataProp": "Title",
                    "bSortable": true
                },
                {
                    "mDataProp": "LanguageName",
                    "bSortable": true
                },
                {
                    "mDataProp": "DisplayOrder",
                    "bSortable": true
                },
                {
                    "mData": function (d) {
                        return d.Published === 'true' ? '<i class="green fa fa-check"></i>' : '<i class="red fa fa-times"></i>';
                    },
                    "bSortable": true
                },
                {
                    "mData": function (d) {
                        return d.IncludeInTopMenu === 'true' ? '<i class="green fa fa-check"></i>' : '<i class="red fa fa-times"></i>';
                    },
                    "bSortable": true
                },
                {
                    "mData": function (d) {
                        return d.IncludeInFooterMenu === 'true' ? '<i class="green fa fa-check"></i>' : '<i class="red fa fa-times"></i>';
                    },
                    "bSortable": true
                },
                {
                    "bSortable": false,
                    "mData": function (row) {
                        return '<a href="PagesAddEdit?id=' + row.Id + '" class="btn btn-primary btn-xs" title="Edit"><i class="fa fa-pencil"></i></a>' +
                            '<button class="btn btn-danger btn-xs remove" title="Delete"><i class="fa fa-trash"></i></button>';
                    }
                }];

            DefaultGridManager.Init();
        };

    return {
        init: Init
    };

}();

PagesManager.init();