var PagesManager = function () {

    var 
        Init = function () {
            tableName = "Pages";
            pKey = "Id";
            gridId = "itemsDataTable";
            //deleteModalDialog = 'deleteModal';

            $.fn.afterLoadDatawithdata = function (data) {
                // assign Body control
                // assign the selected language
                $('#LanguageId').select2("trigger", "select", {
                    data: { id: data.LanguageId, text: data.LanguageName }
                });
            }

            CKEDITOR.replace('Body');

            $('form').each(function () { $(this).validate(); });

            // Get Pages Body by ID
            var qsId = commonManger.getQueryStrs().id;
            if (qsId) {
                getPagesBody(qsId);
            }

            // validate Body field
            $.fn.beforeSave = function () {
                var detailts = CKEDITOR.instances.Body.getData();

                if (detailts === '') {
                    commonManger.showMessage("Body field is required", "Please enter Pages Body.");
                    return false;
                }

                return true
            }

            pageEvents();
        },
        getPagesBody = function (Id) {
            var
                dto = {
                    actionName: tableName + '_One',
                    value: Id
                },
                BodyBinding = function (data) {
                    var jsonData = commonManger.decoData(data),
                        _dataList = jsonData.list;

                    if (_dataList) {
                        $.each(_dataList, function (key, vl) {

                            $('#' + key).val(vl);

                            // lang select2
                            if (key === 'LanguageId') {
                                $('#' + key).select2("trigger", "select", {
                                    data: { id: _dataList.LanguageId, text: _dataList.LanguageName }
                                });
                            }

                            // fill editor
                            if ($('#' + key).hasClass('ck-editor')) {
                                CKEDITOR.instances[key].setData(vl);
                            }

                            // checkboxes
                            if ($('#' + key).attr('type') === 'checkbox' && (vl === 'true')) {
                                $('#' + key).prop('checked', true);
                            }
                        });
                    }
                };
            
            dataService.callAjax('GET', dto, sUrl + 'GetData', BodyBinding, commonManger.errorException);
        },
        pageEvents = function () {
            // save all
            $('.btnSave').click(function (e) {
                e.preventDefault();

                var _names = [],
                    _values = [],
                    lists = $('input[id], textarea[id], select[id]').map(function (i, v) {
                        var $el = $(v),
                            _id = $el.attr('id'),
                            valu = $el.val();

                        if ($el.hasClass('ck-editor')) {
                            valu = CKEDITOR.instances[_id].getData();
                        }
                        else if ($el.attr('type') === 'checkbox') {
                            valu = $el.is(':checked') ? 1 : 0;
                        }

                        _names.push(_id);
                        _values.push(valu);

                        return {
                            id: _id,
                            value: valu
                        };
                    }).get(),
                    dto = {
                        actionName: tableName + '_Save',
                        names: _names,
                        values: _values
                    },
                    isValid = $('#addForm').valid(),
                    savedDataFun = function (data) {
                        if (data && data.ID * 1 > 0) {
                            commonManger.showMessage('Data saved', 'Data has been saved successfully.');
                            window.location.href = 'Pages';
                        }
                    };


                console.log(dto);

                if (isValid) {
                    dataService.callAjax('POST', JSON.stringify(dto), sUrl + 'SaveData', savedDataFun, commonManger.errorException);
                } else {
                    commonManger.showMessage('Required fields!', 'Please enter all required fields.');
                }

            });
        };

    return {
        init: Init
    };

}();

PagesManager.init();