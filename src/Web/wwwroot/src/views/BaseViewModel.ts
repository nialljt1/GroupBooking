import { inject } from "aurelia-framework";
import { HttpClient, json } from "aurelia-fetch-client";

@inject(HttpClient, json)
export class BaseViewModel {

    apiUrl: string;
    mgr: Oidc.UserManager;
    message: string;

    constructor(private http: HttpClient) { }

    activate() {
        ////this.apiUrl = "http://localhost:5001/GroupBookingAppApi/Bookings/"
        this.apiUrl = "http://localhost/gb/api/v1/Bookings/"
        this.setup();
    }

    setup() {
        var config = {
            authority: "http://localhost/IdentityServer2",
            client_id: "js",
            redirect_uri: "http://localhost/GroupBookingApp/src/callback.html",
            response_type: "id_token token",
            scope: "openid profile api1",
            post_logout_redirect_uri: "http://localhost/GroupBookingApp/index.html",
        };
        this.mgr = new Oidc.UserManager(config);
    }
}