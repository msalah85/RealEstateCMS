
var propertyDetailsController = function () {
    var
        init = function () {
            getProperty();
        },
        getProperty = function () {
            var
                _id = commonManger.getUrlSegment(),
                data = {
                    actionName: 'Properties_One',
                    names: ['ID'],
                    values: [_id]
                },
                showingData = function (d) {

                    var list = d.list, // details
                        list1 = d.list1, // images
                        list2 = d.list2; // features

                    // images
                    var _imagesLarge = [],
                        _imagesThumb = $(list1).map(function (i, v) {
                            //if (v.MediaUrl) {
                            _imagesLarge.push(`<div class="sp-slide"><img class="sp-image" src="/content/MasknVr1/img/blank.gif" data-src="/public/${v.MediaUrl ? 'images/' + v.MediaUrl : 'default.jpg'}" />
                                                <p class="sp-layer sp-white sp-padding" data-horizontal="10" data-vertical="10" data-width="300"></p></div>`);

                            return `<img class="sp-thumbnail" src="/public/${v.MediaUrl ? 'images/_thumb/' + v.MediaUrl : 'default.jpg'}" />`;
                        }).get();
                    
                    $('.sp-slides').html(_imagesLarge.join(''));
                    $('.sp-thumbnails').html(_imagesThumb);

                    // fire slide
                    fireImagesSlide();
                    
                    // property info.
                    if (list) {
                        $.each(list, function (k, v) {
                            $('#' + k).html(v);
                        });

                        // seo
                        document.title = list.PropertyTitle + ' - مسكن.كوم';
                        $('meta[name=description],meta[name=keywords]').remove();

                        // set anew one
                        var metaDesc = $('<meta name="description" />').attr('content', list.Description),
                            metaKeys = $('<meta name="keywords" />').attr('content', list.PropertyTitle.split(' ').join(','));

                        $('head').append(metaDesc);
                        $('head').append(metaKeys);
                    }
                    
                    // showing features
                    var _features = $(list2).map(function (i, v) {
                        return `<li>${v.Icon ? v.Icon : ''} <h6>${v.FeatureName}</h6></li>`;
                    }).get();
                    $('.Amenities').html(_features);
                };

            if (_id)
                serviceManager.getData(data, showingData);
        };

    return {
        Init: init
    };

}();
