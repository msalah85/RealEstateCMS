// ref commonManger.js
// ref dataServices.js

var serviceManager = function () {

    var sUrl = sUrl ? sUrl : '/api/data/',
        getData = function (param, successCallback) {
            var returnData = function (data) {
                var json = commonManger.decoData(data); // convert commpressed data to json
                successCallback(json);
            };

            dataService.callAjax('POST', JSON.stringify(param), sUrl + 'GetDataList', returnData, commonManger.errorException);
        },
        saveData = function (funName, param, successCallback) {
            var dto = {
                actionName: funName,
                names: param[0],
                values: param[1]
            };

            dataService.callAjax('POST', JSON.stringify(dto), sUrl + 'SaveData',
                successCallback, commonManger.errorException);
        };

    return {
        getData: getData,
        saveData: saveData,
    };
}();


