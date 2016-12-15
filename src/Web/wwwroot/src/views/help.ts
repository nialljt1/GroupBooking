import { inject } from "aurelia-framework";
import { HttpClient, json } from "aurelia-fetch-client";

@inject(HttpClient, json)
export class Help {
    constructor(private http: HttpClient) { }
}