import { BaseViewModel } from "./baseViewModel";
import { DateFormatValueConverter } from "./../Components/date-format";
import { inject } from "aurelia-framework";
import { HttpClient, json } from "aurelia-fetch-client";
import { Router } from 'aurelia-router';


@inject(BaseViewModel, DateFormatValueConverter, HttpClient, json, Router)
export class EditBooking {
    booking: IBooking;
    baseViewModel: BaseViewModel;
    dateFormatValueConverter: DateFormatValueConverter;

    apiUrl: string;

    constructor(baseViewModel: BaseViewModel, dateFormatValueConverter: DateFormatValueConverter, private http: HttpClient) {
        this.baseViewModel = baseViewModel;
        this.dateFormatValueConverter = dateFormatValueConverter;
    }

    activate(params) {
        ////this.apiUrl = "http://localhost:5001/TodoAppApi/Bookings/"
        this.baseViewModel.setup();
        this.apiUrl = "http://localhost:5001/Bookings/GetBookingById/" + params.id
        this.loadBooking();
    }

    showBookingDetails()
    {
        $("#booking-details-row").show();
        $("#booking-details-tab").addClass("active");
        $("#diner-details-row").hide();  
        $("#diner-details-tab").removeClass("active");      
    }

    showDinerDetails() {
        $("#booking-details-row").hide();
        $("#booking-details-tab").removeClass("active");    
        $("#diner-details-row").show();  
        $("#diner-details-tab").addClass("active");
    }

    loadBooking() {
        var _this = this;
        this.baseViewModel.mgr.getUser().then(function (user) {
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
                method: "get"
            }).then(response => response.json())
                .then(response => {
                    _this.booking = response;
                    _this.booking.bookingDate = _this.dateFormatValueConverter.toDate(_this.booking.startingAt);
                    _this.booking.bookingTime = _this.dateFormatValueConverter.toTime(_this.booking.startingAt);
                console.log("booking loaded: ", response);
            });
        });    
    }

    updateBooking() {
        var _this = this;
        _this.apiUrl = "http://localhost:5001/Bookings/Update";
        this.baseViewModel.mgr.getUser().then(function (user) {
            var booking = {
                id: _this.booking.id,
                firstName: _this.booking.firstName,
                surname: _this.booking.surname,
                emailAddress: _this.booking.emailAddress,
                telephoneNumber: _this.booking.telephoneNumber,
                startingAt: new Date(_this.dateFormatValueConverter.toUSDate(_this.booking.bookingDate) + " " + _this.booking.bookingTime),
                numberOfDiners: _this.booking.numberOfDiners
            };
            if (user) {
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
                method: "put",
                body: json(booking)

            }).then(response => {
                console.log("booking added: ", response);
            });

        });
    }
}

export interface IBooking {
    id: number;
    firstName: string;
    surname: boolean;
    emailAddress: string;
    telephoneNumber: string;
    bookingDate: string;
    bookingTime: string;
    startingAt: Date;
    numberOfDiners: number;
}