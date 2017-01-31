import { BaseViewModel } from "./baseViewModel";
import { inject } from "aurelia-framework";
import { HttpClient, json } from "aurelia-fetch-client";

@inject(BaseViewModel, HttpClient, json)
export class Welcome {

    baseViewModel: BaseViewModel;

    constructor(baseViewModel: BaseViewModel, private http: HttpClient) {
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
        this.baseViewModel.mgr = new Oidc.UserManager(config);
    }


    login() {
        this.baseViewModel.mgr.signinRedirect();
    }

    register() {
        this.baseViewModel.mgr.signinRedirect();
    }
}