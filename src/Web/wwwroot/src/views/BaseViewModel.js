System.register(["aurelia-framework", "aurelia-fetch-client"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var aurelia_framework_1, aurelia_fetch_client_1;
    var BaseViewModel;
    return {
        setters:[
            function (aurelia_framework_1_1) {
                aurelia_framework_1 = aurelia_framework_1_1;
            },
            function (aurelia_fetch_client_1_1) {
                aurelia_fetch_client_1 = aurelia_fetch_client_1_1;
            }],
        execute: function() {
            BaseViewModel = class BaseViewModel {
                constructor(http) {
                    this.http = http;
                }
                activate() {
                    this.setup();
                }
                setup() {
                    this.apiUrl = "http://f2c4a73f.ngrok.io/gb/api/v1/Bookings/";
                    ////var config = {
                    ////    authority: "http://localhost/IdentityServer2",
                    ////    client_id: "js",
                    ////    redirect_uri: "http://localhost/GroupBookingApp/src/callback.html",
                    ////    response_type: "id_token token",
                    ////    scope: "openid profile api1",
                    ////    post_logout_redirect_uri: "http://localhost/GroupBookingApp/index.html",
                    ////};
                    ////this.mgr = new Oidc.UserManager(config);
                }
            };
            BaseViewModel = __decorate([
                aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient, aurelia_fetch_client_1.json)
            ], BaseViewModel);
            exports_1("BaseViewModel", BaseViewModel);
        }
    }
});
//# sourceMappingURL=BaseViewModel.js.map