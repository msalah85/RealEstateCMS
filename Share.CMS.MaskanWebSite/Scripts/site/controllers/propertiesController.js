
var propertiesController = function () {

    var
        // global search paramters
        filterParam = {
            DisplayStart: 0,
            //DisplayLength: 10,
            //SearchParam: '',
            //SortColumn: 0,
            //SortDirection: 0
        },

        init = function () {
            getProperties();
        },

        getProperties = function () {
            // get user search paramter.
            var _searchKey = commonManger.getQueryStrs().k;
            if (_searchKey) filterParam.SearchParam = _searchKey;

            var
                data = {
                    actionName: 'Properties_Search',
                    names: $.map(filterParam, function (v, k) { return k; }),
                    values: $.map(filterParam, function (v, k) { return v; })
                },

                showingData = function (d) {
                    var list = d.list,
                        list1 = d.list1,
                        list2 = d.list2;

                    var propertyBox = $(list).map(function (i, v) {

                        // update latest displayIdex
                        filterParam.DisplayStart = v.RowNo;

                        return `<div class="buildingCard">
                                <div class="row">
                                    <div class="col m4 l4">
                                        <div class="buldImg">
                                            <img src="/public/${v.MainPicture ? 'images/' + v.MainPicture : 'default.jpg'}" class="img-responsive" alt="${v.PropertyTitle}" title="build" />
                                            <div class="description">
                                                <h6 class="description_content"></h6>
                                                <fieldset class="rating">
                                                    <input type="radio" id="star25" name="rating" value="5">
                                                    <label class="full" for="star25" title="5 start"></label>
                                                    <input type="radio" id="star24" name="rating" value="4">
                                                    <label class="full" for="star24" title="4 stars "></label>
                                                    <input type="radio" id="star23" name="rating" value="3">
                                                    <label class="full" for="star23" title="3 stars"></label>
                                                    <input type="radio" id="star22" name="rating" value="2">
                                                    <label class="full" for="star22" title="2 stars"></label>
                                                    <input type="radio" id="star21" name="rating" value="1">
                                                    <label class="full" for="star21" title="bad  1 star"></label>
                                                </fieldset>
                                                <a title="أضف للمفضله" href="PropertyDetails/${v.PropertyID}" class="fav active"><i class="material-icons">favorite_border</i></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col m8 l8">
                                        <div class="BuildRight">
                                            <h5>${v.PropertyTitle}</h5>
                                            <h5>${v.Description}</h5>
                                            <div class="row">
                                                <ul class="first">
                                                    <li><h5>3.3 DR</h5></li>
                                                    <li><h5>56513</h5></li>
                                                    <li><h5>جاهز للنقل</h5></li>
                                                </ul>
                                            </div>
                                            <div class="row">
                                                <ul class="second ">
                                                    <li><h6>39,194 قدم مربع</h6></li>
                                                    <li><h6>المساحة نص تجريبي</h6></li>
                                                    <li><h6>حالة البناء</h6></li>
                                                </ul>
                                            </div>
                                            <div class="buildingsBtn">
                                                <div class="row">
                                                    <div class="col m4">
                                                        <a href="PropertyDetails/${v.PropertyID}" class="waves-effect waves-light btn" style="background-color: #818287">المزيد </a>
                                                    </div>
                                                    <div class="col m4">
                                                        <a href="PropertyDetails/${v.PropertyID}" class="waves-effect waves-light orange btn">طلب الآن </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>`;
                    }).get();

                    // adding result boxes to html
                    $('.search-result').append(propertyBox);

                    // showing more button
                    if (list2 && list2.PropertyID * 1 > 0) {
                        $('.more-button a').attr('href', `javascript:propertiesController.showMore(${filterParam.DisplayStart});`);
                    } else
                        $('.more-button').remove();
                };

            serviceManager.getData(data, showingData);
        },
        showMore = function (startIndex) {
            filterParam.DisplayStart = startIndex;
            getProperties();
        };

    return {
        Init: init,
        showMore: showMore
    };

}();