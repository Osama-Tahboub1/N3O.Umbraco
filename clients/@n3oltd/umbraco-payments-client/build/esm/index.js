/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var PaymentsClient = /** @class */ (function () {
    function PaymentsClient(baseUrl, http) {
        this.jsonParseReviver = undefined;
        this.http = http ? http : window;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "https://localhost:6001";
    }
    PaymentsClient.prototype.findPaymentMethods = function (req) {
        var _this = this;
        var url_ = this.baseUrl + "/umbraco/api/Payments/paymentMethods/find";
        url_ = url_.replace(/[?&]$/, "");
        var content_ = JSON.stringify(req);
        var options_ = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };
        return this.http.fetch(url_, options_).then(function (_response) {
            return _this.processFindPaymentMethods(_response);
        });
    };
    PaymentsClient.prototype.processFindPaymentMethods = function (response) {
        var _this = this;
        var status = response.status;
        var _headers = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach(function (v, k) { return _headers[k] = v; });
        }
        ;
        if (status === 200) {
            return response.text().then(function (_responseText) {
                var result200 = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                return result200;
            });
        }
        else if (status === 400) {
            return response.text().then(function (_responseText) {
                var result400 = null;
                result400 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                return throwException("A server side error occurred.", status, _responseText, _headers, result400);
            });
        }
        else if (status === 500) {
            return response.text().then(function (_responseText) {
                return throwException("A server side error occurred.", status, _responseText, _headers);
            });
        }
        else if (status !== 200 && status !== 204) {
            return response.text().then(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve(null);
    };
    PaymentsClient.prototype.getLookupPaymentMethods = function () {
        var _this = this;
        var url_ = this.baseUrl + "/umbraco/api/Payments/lookups/paymentMethods";
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };
        return this.http.fetch(url_, options_).then(function (_response) {
            return _this.processGetLookupPaymentMethods(_response);
        });
    };
    PaymentsClient.prototype.processGetLookupPaymentMethods = function (response) {
        var _this = this;
        var status = response.status;
        var _headers = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach(function (v, k) { return _headers[k] = v; });
        }
        ;
        if (status === 200) {
            return response.text().then(function (_responseText) {
                var result200 = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                return result200;
            });
        }
        else if (status === 400) {
            return response.text().then(function (_responseText) {
                var result400 = null;
                result400 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                return throwException("A server side error occurred.", status, _responseText, _headers, result400);
            });
        }
        else if (status === 500) {
            return response.text().then(function (_responseText) {
                return throwException("A server side error occurred.", status, _responseText, _headers);
            });
        }
        else if (status !== 200 && status !== 204) {
            return response.text().then(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve(null);
    };
    PaymentsClient.prototype.getAllLookups = function (criteria) {
        var _this = this;
        var url_ = this.baseUrl + "/umbraco/api/Payments/lookups/all";
        url_ = url_.replace(/[?&]$/, "");
        var content_ = JSON.stringify(criteria);
        var options_ = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };
        return this.http.fetch(url_, options_).then(function (_response) {
            return _this.processGetAllLookups(_response);
        });
    };
    PaymentsClient.prototype.processGetAllLookups = function (response) {
        var _this = this;
        var status = response.status;
        var _headers = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach(function (v, k) { return _headers[k] = v; });
        }
        ;
        if (status === 200) {
            return response.text().then(function (_responseText) {
                var result200 = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                return result200;
            });
        }
        else if (status === 400) {
            return response.text().then(function (_responseText) {
                var result400 = null;
                result400 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                return throwException("A server side error occurred.", status, _responseText, _headers, result400);
            });
        }
        else if (status === 500) {
            return response.text().then(function (_responseText) {
                return throwException("A server side error occurred.", status, _responseText, _headers);
            });
        }
        else if (status !== 200 && status !== 204) {
            return response.text().then(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve(null);
    };
    return PaymentsClient;
}());
export { PaymentsClient };
export var PublishedItemType;
(function (PublishedItemType) {
    PublishedItemType[PublishedItemType["Unknown"] = 0] = "Unknown";
    PublishedItemType[PublishedItemType["Element"] = 1] = "Element";
    PublishedItemType[PublishedItemType["Content"] = 2] = "Content";
    PublishedItemType[PublishedItemType["Media"] = 3] = "Media";
    PublishedItemType[PublishedItemType["Member"] = 4] = "Member";
})(PublishedItemType || (PublishedItemType = {}));
var ApiException = /** @class */ (function (_super) {
    __extends(ApiException, _super);
    function ApiException(message, status, response, headers, result) {
        var _this = _super.call(this) || this;
        _this.isApiException = true;
        _this.message = message;
        _this.status = status;
        _this.response = response;
        _this.headers = headers;
        _this.result = result;
        return _this;
    }
    ApiException.isApiException = function (obj) {
        return obj.isApiException === true;
    };
    return ApiException;
}(Error));
export { ApiException };
function throwException(message, status, response, headers, result) {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}
//# sourceMappingURL=index.js.map