var newsManager = function () {

    var targetdata,
        Init = function () {

            tableName = "News";
            pKey = "NewsID";
            gridId = "itemsDataTable";

            gridColumns = [
                {
                    "mDataProp": "NewsID",
                    "bSortable": true
                },
                {
                    "mDataProp": "Title",
                    "bSortable": true
                },
                {
                    "mDataProp": "Short",
                    "bSortable": true
                },
                {
                    "mDataProp": "LanguageName",
                    "bSortable": true
                },
                {
                    "mData": function (d) {
                        return d.Active === 'true' ? '<i class="green fa fa-check"></i>' : '<i class="red fa fa-times"></i>';
                    },
                    "bSortable": true
                },
                {
                    "mData": function (d) {
                        return moment(d.CreatedOnUtc).format('DD/MM/YYYY');
                    }, // news date
                    "bSortable": true
                },
                {
                    "mData": function (d) {
                        return '<a target="_blank" href="/Public/' + (d.PhotoUrl ? 'images/news/' + d.PhotoUrl : 'default.jpg') + '"><img alt="photo" width="60" src="/Public/' + (d.PhotoUrl ? 'images/news/_thumb/' + d.PhotoUrl : 'default.jpg') + '" /></a>';
                    },
                    "bSortable": true
                },
                {
                    "bSortable": false,
                    "mData": function (row) {
                        return '<a href="NewsAddEdit?id=' + row.NewsID + '" class="btn btn-primary btn-xs edit" title="Edit"><i class="fa fa-pencil"></i></a>' +
                            '<button class="btn btn-danger btn-xs remove" title="Delete"><i class="fa fa-trash"></i></button>'
                    }
                }];

            DefaultGridManager.Init();
        };

    return {
        init: Init
    };

}();

newsManager.init();