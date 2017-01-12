System.register(["./views/baseViewModel", "aurelia-framework", "aurelia-router"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var baseViewModel_1, aurelia_framework_1, aurelia_router_1;
    var App;
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
            }],
        execute: function() {
            App = class App {
                constructor(baseViewModel) {
                    this.dateValue = null;
                    this.baseViewModel = baseViewModel;
                }
                activate() {
                    this.baseViewModel.setup();
                    this.setup();
                }
                setup() {
                    var _this = this;
                    ////this.baseViewModel.mgr.getUser().then(function (user) {
                    ////    if (user) {
                    ////        _this.isLoggedIn = true;                
                    ////    }
                    ////    else {
                    ////        _this.baseViewModel.mgr.signinRedirect();
                    ////        _this.isLoggedIn = false;
                    ////    }
                    ////});
                }
                configureRouter(config, router) {
                    this.router = router;
                    config.title = "Group Booking App";
                    config.map([
                        { route: ["", "welcome"], moduleId: "./views/welcome", nav: true, title: "Welcome" },
                        { route: ["help"], moduleId: "./views/help", nav: true, title: "Help" },
                        { route: ["about"], moduleId: "./views/about", nav: true, title: "About" },
                        { route: ["logout"], moduleId: "./views/logout", nav: true, title: "Log out" },
                        { route: ["addBooking"], moduleId: "./views/addBooking", nav: true, title: "Add booking" },
                        { name: "editBooking", route: ["editBooking/:id"], moduleId: "./views/editBooking", nav: false, title: "Edit booking" },
                        { route: ["bootstrapForm"], moduleId: "./views/bootstrapForm", nav: true, title: "Bootstrap Form" },
                        { route: ["bookings"], moduleId: "./views/bookings", nav: true, title: "Bookings" },
                    ]);
                }
                logout() {
                    this.baseViewModel.mgr.signoutRedirect();
                }
            };
            App = __decorate([
                aurelia_framework_1.inject(baseViewModel_1.BaseViewModel, aurelia_router_1.Router)
            ], App);
            exports_1("App", App);
        }
    }
});
//# sourceMappingURL=app.js.map