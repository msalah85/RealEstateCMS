var
    select2Manager = select2Manager || {},
    select2Manager = function () {
        var select2Defaults = {
            pageSize: 10,
            serviceUrl: sUrl + 'Select2'
        },
            getSelect2ResultFormat = function (data, page) {
                var dAll = commonManger.decoData(data), // decompress data from server
                    resultJson = (dAll.list ? dAll.list : []), // result data (id, text1)
                    resultCount = (dAll.list1 ? dAll.list1.CNT : 0), // results count
                    resultAsArray = $.isArray(resultJson)
                        ? $.map(resultJson, function (el) { return { id: el.id, text: el.text1 } }) // convert json to array with enhanced nodes (multiple rows).
                        : [{ id: resultJson.id, text: resultJson.text1 }], // single results data
                    more = ((page * select2Defaults.pageSize) < resultCount);

                return { results: resultAsArray, pagination: { more: more } };
            },
            init = function () {

                $('.select2').select2({
                    //placeholder: 'Select',
                    minimumInputLength: 0, //Does the user have to enter any data before sending the ajax request                
                    ajax: {
                        url: select2Defaults.serviceUrl,
                        allowClear: true,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        type: 'GET',
                        data: function (params) { //Our search term and what page we are on
                            var funName = $(this).data('fn-name'),
                                _names = $(this).data('srch-names') ? $(this).data('srch-names').split('~') : [],
                                _values = (_names.length > 0 ? $(_names).map(function (i, el) { return $('#' + el).val(); }).get() : []),

                                dta = {
                                    fnName: funName,
                                    pageNum: params.page || 1,
                                    pageSize: select2Defaults.pageSize,
                                    searchTerm: params.term || '',
                                    // additional parameters as string separated by (~) char.
                                    names: _names.join('~'),
                                    values: _values.join('~')
                                };

                            return dta;
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            var title = textStatus + ": " + errorThrown,
                                message = jqXhr.responseText ? jqXhr.responseText.Message : 'Unexpected error';
                            console.log(title + ': ' + message);
                        },
                        processResults: function (data, params) {
                            var results = getSelect2ResultFormat(data, params);
                            return results;
                        },
                        cache: true,
                        initSelection: function (element, callback) {
                            //callback($.map(element.val().split(','),
                            //    function (id) {
                            //        return { id: id, text: id };
                            //    }));

                            var id = $(element).val();
                            if (id !== "") {
                                $.ajax(select2Defaults.serviceUrl, {
                                    data: { programid: id },
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    type: 'GET'
                                }).done(function (data) {
                                    $.each(data, function (i, value) {
                                        console.log(i, value);
                                        callback({ "text": value.text, "id": value.id });
                                    });
                                });
                            }
                        }
                    }
                });
            };

        return {
            Init: init
        }

    }();

select2Manager.Init();