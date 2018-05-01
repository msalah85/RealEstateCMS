var masterController = function () {
    var
        init = function () {
            masterMenu();
        },
        masterMenu = function () {
            var langID = commonManger.getCurrentLanguage(),
                data = {
                    actionName: 'Site_HomeMaster',
                    names: ['LangID', 'UserID'],
                    values: [langID, 0]
                },
                showingNews = function (d) {
                    var list = d.list, // menu
                        list1 = d.list1, // loggedin user info.
                        topMenu = $.grep(list, function (v, k) {
                            return v.IncludeInTopMenu === 'true';
                        }),
                        bottomMenu = $.grep(list, function (v, k) {
                            return v.IncludeInFooterMenu === 'true';
                        });
                    
                    if (topMenu) {
                        var topMenuHtml = $(topMenu).map(function (i, v) {
                            return `<li><a href="/page/${v.Id}">${v.Title}</a></li>`;
                        }).get().join('');
                        
                        $('#slide-out').append(topMenuHtml);
                    }

                    if (bottomMenu) {
                        var bottomMenuHtml = $(topMenu).map(function (i, v) {
                            return `<li><a href="/page/${v.Id}">${v.Title}</a></li>`;
                        }).get().join('');
                        
                        $('.ar-footer').html(bottomMenuHtml);
                    }

                    if (list1) {
                        //show loggedin user name & photo.
                    }
                };

            serviceManager.getData(data, showingNews);
        };

    return {
        Init: init
    };
}();
