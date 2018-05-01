/// <reference path="common.js" />
/// <reference path="DataService.js" />


String.prototype.format = function () {
    var str = this;
    for (var i = 0; i < arguments.length; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        str = str.replace(reg, arguments[i]);
    }
    return str;
};

var 
    newPostManager = function () {
        var
            btnUpload = $('#uploadAll'),
            sUrl = '/api/Upload/',

            init = function () {
                pageEvents();

                getProperties();
            },
            $id = 0,
            getProperties = function () {
                // Social settings
                $id = commonManger.getQueryStrs().id;
                var uRL = '/api/data/GetData',
                    data = {
                        actionName: 'Images_Properties',
                        value: ($id ? $id : 0)
                    },
                    settingCallBack = function (data) {
                        data = commonManger.decoData(data),
                            list = data.list,
                            list1 = data.list1;



                        if (list)
                            $('.title').text(`(${list.PropertyTitle})`);



                        if (list1)
                            OnImagesSuccess(list1);

                    };

                if (!$id)
                    return;

                // to go edit
                $('.edit-me').attr('href', `PropertyAddEdit?id=${$id}`);


                dataService.callAjax('GET', data, uRL, settingCallBack,
                    commonManger.errorException);
            },
            enableCTRL = function (ctrl, isEnabled) {
                if (isEnabled)
                    ctrl.removeAttr("disabled").html('<span class="ace-icon glyphicon glyphicon-cloud"></span> Upload');
                else
                    ctrl.prop('disabled', 'disabled').text('Processing...');
            },
            resetSelection = function () {
                $('.ace-file-input a.remove').click();
            },
            showMessage = function (typeID, message) {
                var _msg = '<div class="alert alert-' + (typeID > 1 ? 'danger' : 'success') + '">' + message + '</div>';
                $('.message').html(_msg);
            },
            OnImagesSuccess = function (data) {
                // reset gallery
                var $img = $('#divIMagesList');
                $img.html('');

                $(data).each(function (i, item) {
                    var main = item.IsMain === 'true',
                        img = '<li><a target="_blank" href="/public/images/' + item.MediaUrl + '" data-rel="colorbox">\
                    <img style="width: 150px; height: 150px" src="/public/images/_thumb/' + item.MediaUrl + '" />\
                    <div class="text">\
                        <div class="inner">' + (main ? "Main" : "") + '</div>\
                    </div>\
                </a>\
                    <div class="tools tools-bottom">\
                        <a href="javascript:void(0);" class="set-main ' + (main ? "hidden" : "") + '" data-id="' + item.MediaUrl + '" title="' + (main ? "Main" : "") + '"><i class="fa fa-thumb-tack"></i></a>\
                        <a class="itemToDelete" href="javascript:void(0);" data-id="' + item.MediaUrl + '" title="Delete"><i class="fa fa-trash red"></i></a>\
                    </div>\
                </li>';

                    $img.append(img);
                }).promise().done(function () {
                    // fire sorting & filter
                    //$('[data-rel="colorbox"]').colorbox();
                });
            },
            getImageName = function () {
                var nme = $('input[type=file]').eq(0).val().replace(/.*(\/|\\)/, '');
                return nme.split(".")[0];
            },
            uploadImage = function (imgStr) {
                var
                    uploadCallBack = function (data) {
                        console.log(data);
                    },
                    data = { Name: imgStr };


                dataService.callAjax('POST', JSON.stringify(data), sUrl + "Save",
                    uploadCallBack, commonManger.errorException);
            },
            uploadImages = function () {
                var
                    post = {
                        uRL: '/api/Upload/Save',
                        imgs: $('span.ace-file-name.large').map(function (i, item) {
                            return $(item).data('base64');
                        }).get(),
                        postedSocialCallBack: function (d) {
                            showMessage(1, 'Successfully uploaded images.');
                            getProperties(); // refresh
                        }
                    },
                    _data = {
                        Name: post.imgs,
                        ID: $id
                    };


                // get data
                if (post.imgs && post.imgs.length > 0)
                    dataService.callAjax('POST', JSON.stringify(_data), post.uRL,
                        post.postedSocialCallBack, commonManger.errorException);
                else
                    showMessage(3, 'Please select a photo(s) first, then press Upload!');
            },
            pageEvents = function () {
                $('#image').ace_file_input({
                    style: 'well',
                    btn_choose: 'Drop image here or click to choose',
                    btn_change: null,
                    no_icon: 'ace-icon fa fa-picture-o',
                    droppable: true,
                    thumbnail: 'large', //| true | 
                    whitelist: 'gif|png|jpg|jpeg',
                    blacklist: 'exe|php|asp|aspx|txt|doc',
                    allowExt: ["jpeg", "jpg", "png", "gif", "bmp"],
                    allowMime: ["image/jpg", "image/jpeg", "image/png", "image/gif", "image/bmp"],
                    before_change: function (files, dropped) {
                        var validImg = true;
                        for (var i = 0; i < files.length; i++) {
                            var
                                _file = files[i],
                                _img = new Image();

                            _img.onload = function () {
                                if (!_img || (_img.height < 200 && _img.width < 200)) {
                                    commonManger.showMessage('Too small !!!', `The image (${_file.name}) is too small, please select a large image.`);
                                    $('.ace-file-input a.remove').trigger('click'); // remove the selected image
                                    validImg = false;
                                }
                            }
                            _img.src = URL.createObjectURL(_file);
                        }


                        return validImg;
                    },
                    before_remove: function () {
                        return true;
                    },
                    preview_error: function (filename, error_code) {
                        //name of the file that failed
                        //error_code values
                        //1 = 'FILE_LOAD_FAILED',
                        //2 = 'IMAGE_LOAD_FAILED',
                        //3 = 'THUMBNAIL_FAILED'
                        //alert(error_code);
                    }
                }).on('change', function () {
                    var _this = $(this)[0],
                        images = _this.files;

                    for (var i = 0; i < images.length; i++) {
                        var $image = images ? images[i] : null;

                        if ($image) {
                            bindFullImage($image, i);
                        }
                    }
                });

                // events
                // start post to all pages
                btnUpload.click(function (e) {
                    e.preventDefault();
                    uploadImages();

                });

                // delete an image
                $(document).on('click', 'a.itemToDelete', function (e) {
                    e.preventDefault();
                    var _this = $(this),
                        funCallBak = function () {
                            enableCTRL(btnUpload, false);
                            var p = _this.attr('data-id');
                            deletePicture(p);
                        };


                    confirmationMsg(funCallBak, 1); // delete
                });

                // set main image
                $(document).on('click', 'a.set-main', function (e) {
                    e.preventDefault();

                    var _this = $(this),
                        p = _this.attr('data-id'),
                        setMainPic = function () {
                            enableCTRL(btnUpload, false);
                            setMainPicture(p);
                        };


                    confirmationMsg(setMainPic, 2); // reset main
                });

            },
            confirmationMsg = function (funCallBack, resetDelete) {
                var _message = resetDelete === 1 ? 'Are you sure? Delete this image?'
                    : 'Are you sure you want to reset this image?';

                if ($.isFunction(funCallBack)) {
                    bootbox.confirm(_message,
                        function (result) { if (result) { funCallBack(); } });
                } else {
                    return confirm(_message);
                }
            },
            bindFullImage = function ($image, idex) {
                var reader = new FileReader();
                reader.onloadend = function () {
                    var $imgg = $('span.ace-file-name:eq(' + idex + ')');
                    
                    if ($imgg) {
                        $imgg.data('base64', reader.result.split(',')[1]);
                    }
                }
                reader.readAsDataURL($image);
            },
            OnDeleteSuccess = function (data) {
                if (data === "1") {
                    showMessage(1, 'The selected image has been deleted.');
                    getProperties();
                }
                else
                    showMessage(3, 'Error! while deleting image.');

                // enable uploading
                enableCTRL(btnUpload, true);
            },
            deletePicture = function (name) {
                var
                    _url = `${sUrl}Del`,
                    dta = { id: name };


                dataService.callAjax('GET', dta, _url,
                    OnDeleteSuccess, commonManger.errorException);
            },
            onSetMainSuccess = function (d) {
                if (d == "1") {
                    //$('#divIMagesList li a.hidden').removeClass('hidden').closest('li').find('div.text span').html('').removeClass('red');
                    //$('#divIMagesList li a[data-id="' + p + '"]').attr('title', 'Main').addClass('hidden').closest('li').find('div.text span').html("<span class='red'>Main</span>");

                    // show success message
                    showMessage(1, 'The main image has been selected.');

                    getProperties(); // refresh
                } else
                    showMessage(2, 'Error occured while setting main image');

                // enable uploading
                enableCTRL(btnUpload, true);
            },
            setMainPicture = function (name) {
                var _url = sUrl + "Main", data = { id: name };


                dataService.callAjax('GET', data, _url,
                    onSetMainSuccess,
                    commonManger.errorException);
            };

        return {
            init: init
        };

    }();


newPostManager.init();