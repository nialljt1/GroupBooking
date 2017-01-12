System.register(["./baseViewModel", "./../Components/date-format", "aurelia-framework", "aurelia-fetch-client"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var baseViewModel_1, date_format_1, aurelia_framework_1, aurelia_fetch_client_1;
    var AddBooking;
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
            }],
        execute: function() {
            AddBooking = class AddBooking {
                constructor(baseViewModel, dateFormatValueConverter, http) {
                    this.http = http;
                    this.baseViewModel = baseViewModel;
                    this.dateFormatValueConverter = dateFormatValueConverter;
                }
                activate() {
                    this.apiUrl = this.baseViewModel.apiUrl;
                    this.baseViewModel.setup();
                }
                addBooking() {
                    var _this = this;
                    ////this.baseViewModel.mgr.getUser().then(function (user) {
                    var newBooking = {
                        firstName: _this.firstName,
                        surname: _this.surname,
                        emailAddress: _this.emailAddress,
                        telephoneNumber: _this.telephoneNumber,
                        startingAt: new Date(_this.dateFormatValueConverter.toUSDate(_this.bookingDate) + " " + _this.bookingTime),
                        numberOfDiners: _this.numberOfDiners
                    };
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
                        method: "post",
                        body: aurelia_fetch_client_1.json(newBooking)
                    }).then(response => {
                        $.notify("booking added");
                        ////console.log("booking added: ", response);
                    });
                    //});    
                }
            };
            AddBooking = __decorate([
                aurelia_framework_1.inject(baseViewModel_1.BaseViewModel, date_format_1.DateFormatValueConverter, aurelia_fetch_client_1.HttpClient, aurelia_fetch_client_1.json)
            ], AddBooking);
            exports_1("AddBooking", AddBooking);
        }
    }
});
//# sourceMappingURL=addBooking.js.map