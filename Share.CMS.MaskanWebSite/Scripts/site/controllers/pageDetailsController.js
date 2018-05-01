
var pageDetailsController = function () {
    var
        init = function () {
            getNewsDetails();
        },
        getNewsDetails = function () {
            var
                _id = commonManger.getUrlSegment(),
                data = {
                    actionName: 'Pages_One',
                    names: ['ID'],
                    values: [_id]
                },
                showingData = function (d) {
                    var list = d.list;

                    if (list) {
                        $.each(list, function (k, v) {
                            $('#' + k).html(v);
                        });


                        // seo
                        document.title = list.Title + ' - مسكن.كوم';

                        $('meta[name=description],meta[name=keywords]').remove();
                        // set anew one
                        var metaDesc = $('<meta name="description" />').attr('content', $(list.Body).text()),
                            metaKeys = $('<meta name="keywords" />').attr('content', list.Title.split(' ').join(','));

                        $('head').append(metaDesc);
                        $('head').append(metaKeys);
                    }
                };

            serviceManager.getData(data, showingData);
        };

    return {
        Init: init
    };
}();
