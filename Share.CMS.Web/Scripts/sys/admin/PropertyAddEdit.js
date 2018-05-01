
//=======================================
// Developer: M. Salah (09-02-2016)
// Email: eng.msalah.abdullah@gmail.com
//=======================================

var
    pageManager = pageManager || {},
    pageManager = function () {
        "use strict";
        var
            _id = commonManger.getUrlVars().id,
            $formId = '#masterForm',

            Init = function () {
                // set buyers and shippers lists for binding.            
                applyValidation();
                setFormProperties();
                pageEvents();
            },
            applyValidation = function () {
                jQuery(function ($) {

                    $('[data-rel=tooltip]').tooltip();
                    $('form').each(function () {
                        $(this).validate({
                            highlight: function (e) {
                                $(e).closest('.form-group').removeClass('has-info').addClass('has-error');
                            },
                            success: function (e) {
                                $(e).closest('.form-group').removeClass('has-error');//.addClass('has-info');
                                $(e).remove();
                            },
                            //errorPlacement: function (error, element) {
                            //    if (element.is('input[type=checkbox]') || element.is('input[type=radio]')) {
                            //        var controls = element.closest('div[class*="col-"]');
                            //        if (controls.find(':checkbox,:radio').length > 1) controls.append(error);
                            //        else error.insertAfter(element.nextAll('.lbl:eq(0)').eq(0));
                            //    }
                            //    else if (element.is('.select2')) {
                            //        error.insertAfter(element.siblings('[class*="select2-container"]:eq(0)'));
                            //    }
                            //    else if (element.is('.chosen-select')) {
                            //        error.insertAfter(element.siblings('[class*="chosen-container"]:eq(0)'));
                            //    }
                            //    else error.insertAfter(element.parent());
                            //},
                            showErrors: function (errorMap, errorList) {
                                $.each(this.validElements(), function (index, element) {
                                    var $element = $(element);
                                    $element.data("title", "").removeClass("error").tooltip("destroy");
                                    $element.closest('.form-group').removeClass('has-error');
                                });
                                $.each(errorList, function (index, error) {
                                    var $element = $(error.element);
                                    $element.tooltip("destroy").data("title", error.message).addClass("error").tooltip();
                                    $element.closest('.form-group').removeClass('has-info').addClass('has-error');
                                })
                            },
                        })
                    });

                });
            },
            pageEvents = function () {
                // save all data
                $('#btnSave').click(function (e) {
                    var isValid = $(this).closest('form').valid();
                    if (!isValid) {
                        e.preventDefault();
                        commonManger.showMessage('All (*) are required!', 'Please enter all mandatory fields.')
                    } else {
                        SaveAllData();
                    }
                });
            },
            // start Save data.
            SaveAllData = function () {
                var
                    _dVals = $('select[name="FeatureID"]').val(),
                    valuesDetails = _dVals ? _dVals.map(function (vl, i) { return `0~0~${vl}`; }) : [],
                    namesDetails = ['PropertyID', 'PropertyFeatureID', 'FeatureID'],
                    namesMaster = $(`${$formId} input[id],${$formId} select[id],${$formId} textarea[id]`).map((i, k) => { return $(k).attr('id'); }).get(),
                    valuesMaster = $(`${$formId} input[id],${$formId} select[id],${$formId} textarea[id]`).map((i, k) => { return $(k).val(); }).get();

                SaveDataMasterDetails(namesMaster, valuesMaster, namesDetails, valuesDetails);
            },
            SaveDataMasterDetails = function (fieldsMaster, valuesMaster, fieldsDetails, valuesDetails) {
                var DTO = {
                    actionName: 'Properties_Save',
                    namesM: fieldsMaster,
                    valuesM: valuesMaster,
                    namesD: fieldsDetails,
                    valuesD: valuesDetails,
                    useIP: true
                };

                dataService.callAjax('Post',
                    JSON.stringify(DTO),
                    '/api/data/SaveMasterDetails',
                    successSaved, commonManger.errorException);
            },
            validateMayData = function () {
                // validate all data before SaveAllData.
                var _valid = true;
                if (!$($formId).valid())
                    _valid = false;
                return true;
            },
            successSaved = function (data) {
                if (data.Status) {
                    window.location.href = 'Images.aspx?id=' + data.ID; //upload photos
                } else {
                    commonManger.showMessage('Error!', 'Error occured!:' + data.message);
                }
            },
            setFormProperties = function () {
                // Edit invoice
                var bindFormControls = function (d) {
                    var d = commonManger.decoData(d),
                        jsn = d.list,
                        // jsn1 should called propery features
                        jsn1 = d.list1;
                    // jas2 should called contact person


                    if (jsn) {
                        $.each(jsn, function (k, v) {
                            var $el = $('#' + k);

                            if ($el.hasClass('select2')) {
                                var vl = v.split('|');
                                $el.select2("trigger", "select", {
                                    data: { id: vl[0], text: vl[1] }
                                });
                            } else
                                $el.val(v);
                        });


                        $('.date-picker').val(function () {
                            return moment($(this).val()).format('MM/DD/YYYY');
                        });
                    }


                    if (jsn1) {
                        $(jsn1).each(function (i, item) {
                            $('[name="FeatureID"]').select2("trigger", "select", {
                                data: { id: item.FeatureID, text: item.FeatureName }
                            });
                        });
                    }
                },
                    DTO = {
                        actionName: 'Properties_Row',
                        value: _id
                    };

                // new property
                if (!_id)
                    return;


                dataService.callAjax('GET', DTO, sUrl + 'GetData',
                    bindFormControls, commonManger.errorException);
            },
            BindGrid = function () {
                var jsn = {
                    ExpenseID: $('#ExpenseID').val(),
                    ExpenseName: $('#ExpenseID option:selected').text(),
                    Cost: $('#Cost').val(),
                    Amount: $('#Amount').val()
                }, _tbl = $('#listItems tbody');

                if (jsn) {
                    // collect table rows
                    var rows = $(jsn).map(function (i, v) {
                        return $('<tr><td data-inv-details-id="' + (v.InvoiceDetailsID ? v.InvoiceDetailsID : 0) + '">' + v.ExpenseID + '</td><td>' + v.ExpenseName + '</td>\
                             <td><input type="number" value="' + numeral(v.Cost).format('0.0') + '" /></td><td><input type="number" value="' + numeral(v.Amount).format('0.0') + '" /></td>\
                             <td><button class="btn btn-minier btn-danger remove" data-rel="tooltip" data-placement="top" data-original-title="Delete" title="Delete"><i class="fa fa-remove icon-only"></i></button></td></tr>');
                    }).get(), isExist = false;


                    $('#listItems tbody tr').each(function (i, item) {
                        if ($(this).children('td:eq(0)').text() === jsn.ExpenseID)
                            isExist = true;
                    });


                    if (!isExist) {
                        // populate to payments table
                        _tbl.append(rows);
                        // show payments total amount.
                        showPaymentsTotal();
                    } else {
                        commonManger.showMessage('Data Exists:', 'Data already exists before.');
                    }
                }

                $('.modal').modal('hide');
            },
            showPaymentsTotal = function () {
                var _totalCost = 0,
                    _total4Cust = 0;


                $('#listItems tbody tr').each(function (i, item) {
                    try {
                        var cstVal = $(this).find('td:eq(2) input').val(),
                            custVal = $(this).find('td:eq(3) input').val();


                        _totalCost += numeral().unformat(cstVal && !isNaN(cstVal) ? cstVal : 0) * 1; // cost
                        _total4Cust += numeral().unformat(custVal && !isNaN(custVal) > 0 ? custVal : 0) * 1; // amount/customer
                    } catch (err) { console.log(err); }
                });

                // show total amount and profit.
                $('#TotalAmount').text(numeral(_total4Cust).format('0,0.0')); // show invoice total
                $('#TotalProfit').text(numeral(_total4Cust - _totalCost).format('0,0.0')); // show invoice total


                // show final save button.
                if (_total4Cust > 0) {
                    $('#SaveAll').removeClass('hidden');
                } else {
                    $('#SaveAll').addClass('hidden');
                }

            },
            resetMyForm = function () {
                $($formId)[0].reset();
            };

        return {
            Init: Init
        };

    }();