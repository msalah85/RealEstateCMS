var newsManager = function () {

    var targetdata,
        Init = function () {
            tableName = "News";
            pKey = "NewsID";
            gridId = "itemsDataTable";

            $.fn.afterLoadDatawithdata = function (data) {
                // assign details control
                // assign the selected language
                $('#LanguageId').select2("trigger", "select", {
                    data: { id: data.LanguageId, text: data.LanguageName }
                });
            }

            CKEDITOR.replace('Details');

            //$('form').each(function () { $(this).validate(); });

            // Get news details by ID
            var qsId = commonManger.getQueryStrs().id;
            if (qsId) {
                getNewsDetails(qsId);
            }


            // validate details field
            $.fn.beforeSave = function () {
                var detailts = CKEDITOR.instances.Details.getData();

                if (detailts === '') {
                    commonManger.showMessage("Details field is required", "Please enter news details.");
                    return false;
                }

                return true
            }

            //editables on first profile page
            try {//ie8 throws some harmless exceptions, so let's catch'em

                //first let's add a fake appendChild method for Image element for browsers that have a problem with this
                //because editable plugin calls appendChild, and it causes errors on IE at unpredicted points
                try {
                    document.createElement('IMG').appendChild(document.createElement('B'));
                } catch (e) {
                    Image.prototype.appendChild = function (el) { }
                }

                var last_gritter,
                    $photo = $('.PhotoUrl');

                $photo.editable({
                    //mode: 'inline',
                    type: 'image',
                    name: 'PhotoUrl',
                    value: null,
                    //onblur: 'ignore',  //don't reset or hide editable onblur?!
                    image: {
                        //specify ace file input plugin's options here
                        btn_choose: 'Change photo',
                        droppable: true,
                        //minSize: 110000,//~100Kb

                        //and a few extra ones here
                        name: 'PhotoUrl',//put the field name here as well, will be used inside the custom plugin
                        on_error: function (error_type) {//on_error function will be called when the selected file has a problem
                            if (last_gritter) $.gritter.remove(last_gritter);
                            if (error_type == 1) {//file format error
                                last_gritter = $.gritter.add({
                                    title: 'File is not an image!',
                                    text: 'Please choose a jpg|gif|png image!',
                                    class_name: 'gritter-error gritter-center'
                                });
                            } else if (error_type == 2) {//file size rror
                                last_gritter = $.gritter.add({
                                    title: 'File too big!',
                                    text: 'Image size should not exceed 100Kb!',
                                    class_name: 'gritter-error gritter-center'
                                });
                            }
                            else {//other error
                            }
                        },
                        on_success: function () {
                            $.gritter.removeAll();
                        }
                    },
                    url: function (params) {
                        // ***UPDATE AVATAR HERE*** //
                        var deferred = new $.Deferred

                        var value = $photo.next().find('input[type=hidden]:eq(0)').val();
                        if (!value || value.length == 0) {
                            deferred.resolve();
                            return deferred.promise();
                        }

                        //dummy upload
                        setTimeout(function () {
                            if ("FileReader" in window) {
                                //for browsers that have a thumbnail of selected image
                                var thumb = $photo.next().find('img').data('thumb'),
                                    full = $photo.next().find('img').data('full');

                                if (thumb) $photo.get(0).src = thumb;
                                if (full) {
                                    $('#PhotoUrl').data('img', full.split(',')[1]);
                                    uploadImage();
                                }
                            }

                            deferred.resolve({ 'status': 'OK' });

                            if (last_gritter) $.gritter.remove(last_gritter);

                        }, parseInt(Math.random() * 800 + 800))

                        return deferred.promise();
                        // ***END OF UPDATE AVATAR HERE*** //
                    },
                    success: function (response, newValue) { }
                })
            } catch (e) { }

            pageEvents();
        },
        getNewsDetails = function (newsID) {
            var
                dto = {
                    actionName: tableName + '_One',
                    value: newsID
                },
                detailsBinding = function (data) {
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

                            // showing a photo
                            if (key === 'PhotoUrl' && vl) {
                                $('.' + key).attr('src', '/public/images/news/_thumb/' + vl);
                                $('#' + key).val(vl);
                            }
                        });
                    }
                };


            dataService.callAjax('GET', dto, sUrl + 'GetData',
                detailsBinding, commonManger.errorException);
        },
        pageEvents = function () {
            $(document).delegate('input[type=file]:eq(0)', 'change', function (evt) {
                var mediaFile = evt.target.files;
                if (mediaFile) {
                    bindFullImage(mediaFile[0]);
                }
            });

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
                            window.location.href = 'news';
                        }
                    };

                if (isValid) {
                    dataService.callAjax('POST', JSON.stringify(dto), sUrl + 'SaveData', savedDataFun, commonManger.errorException);
                } else {
                    commonManger.showMessage('Required fields!', 'Please enter all required fields.');
                }

            });
        },
        uploadImage = function () {
            // upload to the server.
            var upload_url = '/api/upload/Send',
                imgStr = $('#PhotoUrl').data('img');

            if (imgStr === '') {
                commonManger.showMessage('Upload faild!', 'Please try again by uploading image or contact system administrator.');
                return false;
            }

            var
                media = {
                    ID: imgStr
                },
                uploaded =
                    function (dd) {
                        if (dd.indexOf('Error') <= 0) {
                            $('#PhotoUrl').val(dd)
                            return true;
                        }
                        else
                            return false;
                    };

            dataService.callAjax('POST', JSON.stringify(media), upload_url,
                uploaded, commonManger.errorException);
        },
        bindFullImage = function ($image) {
            var reader = new FileReader(),
                $imgg = $('.PhotoUrl:eq(0)');

            reader.onloadend = function () {
                if ($imgg) {
                    $imgg.data('base64', reader.result.split(',')[1]);
                }
            }
            reader.readAsDataURL($image);
        };

    return {
        init: Init
    };

}();

newsManager.init();