System.register(["./baseViewModel", "aurelia-framework", "aurelia-fetch-client"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var baseViewModel_1, aurelia_framework_1, aurelia_fetch_client_1;
    var Welcome;
    return {
        setters:[
            function (baseViewModel_1_1) {
                baseViewModel_1 = baseViewModel_1_1;
            },
            function (aurelia_framework_1_1) {
                aurelia_framework_1 = aurelia_framework_1_1;
            },
            function (aurelia_fetch_client_1_1) {
                aurelia_fetch_client_1 = aurelia_fetch_client_1_1;
            }],
        execute: function() {
            Welcome = class Welcome {
                constructor(baseViewModel, http) {
                    this.http = http;
                    this.baseViewModel = baseViewModel;
                }
                activate() {
                    this.baseViewModel.setup();
                    var config = {
                        authority: "http://identity.groupbookit.com",
                        client_id: "js",
                        redirect_uri: "http://groupbookit.com/src/callback.html",
                        response_type: "id_token token",
                        scope: "openid profile api1",
                        post_logout_redirect_uri: "http://groupbookit.com/index.html",
                    };
                    ////var config = {
                    ////    authority: "http://localhost/IdentityServer2",
                    ////    authority: "http://localhost:5000",            
                    ////    client_id: "js",
                    ////    redirect_uri: "http://localhost/GroupBookingApp/src/callback.html",
                    ////    response_type: "id_token token",
                    ////    scope: "openid profile api1",
                    ////    post_logout_redirect_uri: "http://localhost/GroupBookingApp/index.html",
                    ////};
                    this.baseViewModel.mgr = new Oidc.UserManager(config);
                }
                login() {
                    this.baseViewModel.mgr.signinRedirect();
                }
                register() {
                    this.baseViewModel.mgr.signinRedirect();
                }
            };
            Welcome = __decorate([
                aurelia_framework_1.inject(baseViewModel_1.BaseViewModel, aurelia_fetch_client_1.HttpClient, aurelia_fetch_client_1.json)
            ], Welcome);
            exports_1("Welcome", Welcome);
        }
    }
});
//# sourceMappingURL=welcome.js.map