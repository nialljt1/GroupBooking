System.register(["./baseViewModel", "./../Components/date-format", "aurelia-framework", "aurelia-fetch-client", 'aurelia-router'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var baseViewModel_1, date_format_1, aurelia_framework_1, aurelia_fetch_client_1, aurelia_router_1;
    var EditBooking;
    return {
        setters:[
            function (baseViewModel_1_1) {
                baseViewModel_1 = baseViewModel_1_1;
            },
            function (date_format_1_1) {
                date_format_1 = date_format_1_1;
            },
            function (aurelia_framework_1_1) {
                aurelia_framework_1 = aurelia_framework_1_1;
            },
            function (aurelia_fetch_client_1_1) {
                aurelia_fetch_client_1 = aurelia_fetch_client_1_1;
            },
            function (aurelia_router_1_1) {
                aurelia_router_1 = aurelia_router_1_1;
            }],
        execute: function() {
            EditBooking = class EditBooking {
                constructor(baseViewModel, dateFormatValueConverter, http) {
                    this.http = http;
                    this.baseViewModel = baseViewModel;
                    this.dateFormatValueConverter = dateFormatValueConverter;
                }
                activate(params) {
                    this.baseViewModel.setup();
                    this.apiUrl = this.baseViewModel.apiUrl + "/" + params.id;
                    this.loadBooking();
                }
                showBookingDetails() {
                    $("#booking-details-row").show();
                    $("#booking-details-tab").addClass("active");
                    $("#diner-details-row").hide();
                    $("#diner-details-tab").removeClass("active");
                }
                showDinerDetails() {
                    $("#booking-details-row").hide();
                    $("#booking-details-tab").removeClass("active");
                    $("#diner-details-row").show();
                    $("#diner-details-tab").addClass("active");
                }
                loadBooking() {
                    var _this = this;
                    ////this.baseViewModel.mgr.getUser().then(function (user) {
                    ////if (user)
                    ////{
                    ////    _this.http.configure(config => {
                    ////        config
                    ////            .withDefaults({
                    ////                headers: {
                    ////                    'Accept': 'application/json',
                    ////                    'X-Requested-With': 'Fetch',
                    ////                    'Authorization': "Bearer " + user.access_token
                    ////                }
                    ////            })
                    ////    });
                    ////}
                    _this.http.fetch(_this.apiUrl, {
                        method: "get"
                    }).then(response => response.json())
                        .then(response => {
                        _this.booking = response;
                        _this.booking.bookingDate = _this.dateFormatValueConverter.toDate(_this.booking.startingAt);
                        _this.booking.bookingTime = _this.dateFormatValueConverter.toTime(_this.booking.startingAt);
                        console.log("booking loaded: ", response);
                    });
                    ////});    
                }
                updateBooking() {
                    var _this = this;
                    _this.apiUrl = this.baseViewModel.apiUrl + "Update";
                    ////this.baseViewModel.mgr.getUser().then(function (user) {
                    var booking = {
                        id: _this.booking.id,
                        firstName: _this.booking.firstName,
                        surname: _this.booking.surname,
                        emailAddress: _this.booking.emailAddress,
                        telephoneNumber: _this.booking.telephoneNumber,
                        startingAt: new Date(_this.dateFormatValueConverter.toUSDate(_this.booking.bookingDate) + " " + _this.booking.bookingTime),
                        numberOfDiners: _this.booking.numberOfDiners
                    };
                    ////if (user) {
                    ////    _this.http.configure(config => {
                    ////        config
                    ////            .withDefaults({
                    ////                headers: {
                    ////                    'Accept': 'application/json',
                    ////                    'X-Requested-With': 'Fetch',
                    ////                    'Authorization': "Bearer " + user.access_token
                    ////                }
                    ////            })
                    ////    });
                    ////}
                    _this.http.fetch(_this.apiUrl, {
                        method: "put",
                        body: aurelia_fetch_client_1.json(booking)
                    }).then(response => {
                        console.log("booking updated: ", response);
                    });
                    ////});
                }
            };
            EditBooking = __decorate([
                aurelia_framework_1.inject(baseViewModel_1.BaseViewModel, date_format_1.DateFormatValueConverter, aurelia_fetch_client_1.HttpClient, aurelia_fetch_client_1.json, aurelia_router_1.Router)
            ], EditBooking);
            exports_1("EditBooking", EditBooking);
        }
    }
});
//# sourceMappingURL=editBooking.js.map