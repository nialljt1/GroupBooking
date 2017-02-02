import { inject } from "aurelia-framework";
import { HttpClient, json } from "aurelia-fetch-client";

@inject(HttpClient, json)
export class BaseViewModel {

    apiUrl: string;
    mgr: Oidc.UserManager;
    message: string;

    constructor(private http: HttpClient) { }

    activate() {
        this.setup();
    }

    setup() {
        ////this.apiUrl = "http://localhost:57832/api/v1/Bookings/"
        ////var config = {
        ////    authority: "http://localhost/IdentityServer2",
        ////    ////authority: "http://localhost:5000",
        ////    client_id: "js",
        ////    redirect_uri: "http://localhost/GroupBookingApp/src/callback.html",
        ////    response_type: "id_token token",
        ////    scope: "openid profile api1",
        ////    post_logout_redirect_uri: "http://localhost/GroupBookingApp/index.html",
        ////};
        this.apiUrl = "http://www.api.groupbookit.com/api/v1/Bookings/"
        ////var config = {
        ////    authority: "http://www.identity.groupbookit.com",
        ////    client_id: "js",
        ////    redirect_uri: "http://www.groupbookit.com/src/callback.html",
        ////    response_type: "id_token token",
        ////    scope: "openid profile api1",
        ////    post_logout_redirect_uri: "http://www.groupbookit.com/index.html",
        ////};
        //// this.mgr = new Oidc.UserManager(config);
    }
}