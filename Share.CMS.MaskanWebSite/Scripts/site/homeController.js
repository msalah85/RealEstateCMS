var homeController = function () {
    var
        init = function () {
            showHomeNews();
        },
        showHomeNews = function () {
            var langID = commonManger.getCurrentLanguage(),
                data = {
                    actionName: 'Site_HomeNews',
                    names: ['LangID'],
                    values: [langID]
                },
                showingNews = function (d) {
                    var list = d.list;

                    if (list) {
                        var newsHtml = $(list).map(function (i, v) {
                            // 1st item.
                            return i === 0 ? `<div class="col-md-6 col-lg-6"><div class="newsLeftImg">
                                        <a href="NewsDetails/${v.NewsID}"><img src="/public/${v.PhotoUrl ? 'images/news/' + v.PhotoUrl : 'default.jpg'}" class="img-responsive" alt="Maskn.com" title="build"></a>
                                        <div class="description">
                                            <h5 class="description_content">${v.Title}</h5>
                                            <h6 class="description_content">${v.Short}</h6>
                                        </div></div></div>`
                                : // other items
                                `<div class="media">
                                                    <a href="NewsDetails/${v.NewsID}" style="float: right; margin-left: 10px;">
                                                        <img class="media-object img-responsive" alt="maskn.com" src="/public/${v.PhotoUrl ? 'images/news/_thumb/' + v.PhotoUrl : 'default.jpg'}" style="width: 100px; height: 80px;">
                                                    </a>
                                                    <div class="media-body">
                                                        <a href="NewsDetails/${v.NewsID}">
                                                            <h5 class="media-heading">${v.Title}</h5>
                                                        </a>
                                                        <h6>${v.Short}</h6>
                                                    </div>
                                                </div>`;

                        }).get().join('');

                        $('.top-news-list').html('').html(newsHtml)
                            .find(".media").wrapAll('<div class="col-md-6 col-lg-6" />');

                    } else {
                        // hide news box
                        $('.news').addClass('hidden');
                    }
                };

            serviceManager.getData(data, showingNews);
        };

    return {
        Init: init
    };
}();
