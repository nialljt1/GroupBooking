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
    }


    login() {
        this.baseViewModel.mgr.signinRedirect();
    }

    register() {
        this.baseViewModel.mgr.signinRedirect();
    }
}