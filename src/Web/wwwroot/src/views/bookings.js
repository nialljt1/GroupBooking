System.register(["./baseViewModel", "aurelia-framework", 'aurelia-router', "aurelia-fetch-client"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var baseViewModel_1, aurelia_framework_1, aurelia_router_1, aurelia_fetch_client_1;
    var Bookings;
    return {
        setters:[
            function (baseViewModel_1_1) {
                baseViewModel_1 = baseViewModel_1_1;
            },
            function (aurelia_framework_1_1) {
                aurelia_framework_1 = aurelia_framework_1_1;
            },
            function (aurelia_router_1_1) {
                aurelia_router_1 = aurelia_router_1_1;
            },
            function (aurelia_fetch_client_1_1) {
                aurelia_fetch_client_1 = aurelia_fetch_client_1_1;
            }],
        execute: function() {
            Bookings = class Bookings {
                constructor(baseViewModel, router, http) {
                    this.http = http;
                    this.pageSize = 10;
                    this.router = router;
                    this.baseViewModel = baseViewModel;
                }
                bind() {
                    ////this.apiUrl = "http://localhost:5001/GroupBookingApi/Bookings/"
                    this.apiUrl = "http://localhost/gb/api/v1/Bookings/FilterBookings/1";
                    this.baseViewModel.setup();
                    this.setup();
                }
                setup() {
                    var _this = this;
                    this.bookingFromDate = null;
                    this.bookingToDate = "13/12/2016";
                    this.isCancelled = false;
                    this.baseViewModel.mgr.getUser().then(function (user) {
                        if (user) {
                            _this.fetchBookings();
                        }
                    });
                }
                fetchBookings() {
                    var _this = this;
                    var filterCriteria = {
                        fromDate: _this.bookingFromDate,
                        toDate: _this.bookingToDate,
                        isCancelled: _this.isCancelled
                    };
                    this.baseViewModel.mgr.getUser().then(function (user) {
                        _this.http.configure(config => {
                            config.withDefaults({
                                headers: {
                                    'Authorization': "Bearer " + user.access_token
                                }
                            });
                        });
                        return _this.http.fetch(_this.apiUrl, {
                            method: "POST",
                            body: aurelia_fetch_client_1.json(filterCriteria)
                        }).
                            then(response => response.json()).then(data => {
                            $('#example2').hide;
                            _this.bookings = data;
                            ////$('#example2').DataTable().rows().clear();
                            // TODO: Resolve timing issue in table
                            // TODO: filtering leaves existing data in table - fix
                            setTimeout(function () {
                                ////$('#example2').DataTable();
                                $('#example2').show();
                            }, 500);
                        });
                    });
                }
                deleteBooking(bookingId) {
                    this.http.fetch(this.apiUrl + bookingId, { method: "delete" }).then(() => { this.fetchBookings(); });
                }
                viewBooking(booking) {
                    this.router.navigateToRoute('editBooking', { id: booking.id });
                }
            };
            Bookings = __decorate([
                aurelia_framework_1.inject(baseViewModel_1.BaseViewModel, aurelia_router_1.Router, aurelia_fetch_client_1.HttpClient, aurelia_fetch_client_1.json)
            ], Bookings);
            exports_1("Bookings", Bookings);
        }
    }
});
//# sourceMappingURL=bookings.js.map