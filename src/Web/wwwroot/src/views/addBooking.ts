import { BaseViewModel } from "./baseViewModel";
import { DateFormatValueConverter } from "./../Components/date-format";
import { inject } from "aurelia-framework";
import { HttpClient, json } from "aurelia-fetch-client";

@inject(BaseViewModel, DateFormatValueConverter, HttpClient, json)
export class AddBooking {
    firstName: string;
    surname: string;
    emailAddress: string;
    telephoneNumber: string;
    bookingDate: string;
    bookingTime: string;
    numberOfDiners: number;
    startingAt: Date;
    baseViewModel: BaseViewModel;
    dateFormatValueConverter: DateFormatValueConverter;

    apiUrl: string;

    constructor(baseViewModel: BaseViewModel, dateFormatValueConverter: DateFormatValueConverter, private http: HttpClient) {
        this.baseViewModel = baseViewModel
        this.dateFormatValueConverter = dateFormatValueConverter;
    }

    activate() {
        this.apiUrl = this.baseViewModel.apiUrl;
        this.baseViewModel.setup();
    }

    addBooking() {
        var _this = this;        
        this.baseViewModel.mgr.getUser().then(function (user) {
            var newBooking = {
                firstName: _this.firstName,
                surname: _this.surname,
                emailAddress: _this.emailAddress,
                telephoneNumber: _this.telephoneNumber,
                startingAt: new Date(_this.dateFormatValueConverter.toUSDate(_this.bookingDate) + " " + _this.bookingTime),
                numberOfDiners: _this.numberOfDiners
            };

            if (user)
            {
                _this.http.configure(config => {
                    config
                        .withDefaults({
                            headers: {
                                'Accept': 'application/json',
                                'X-Requested-With': 'Fetch',
                                'Authorization': "Bearer " + user.access_token
                            }
                        })

                });
            }

            _this.http.fetch(_this.apiUrl, {
                method: "post",
                body: json(newBooking)

            }).then(response => {
                $.notify("booking added");
                ////console.log("booking added: ", response);
            });

        });    
    }
}

export interface IBooking {
    id: number;
    firstName: string;
    Surname: boolean;
    emailAddress: string;
    telephoneNumber: string;
    bookingDate: string;
    bookingTime: string;
}