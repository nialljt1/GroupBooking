import { BaseViewModel } from "./views/baseViewModel";
import { inject } from "aurelia-framework";
import { Router } from "aurelia-router";

@inject(BaseViewModel, Router)
export class App {
    router: Router;
    isLoggedIn: boolean;
    dateValue = null;
    baseViewModel: BaseViewModel;

    constructor(baseViewModel: BaseViewModel) {
        this.baseViewModel = baseViewModel;
    }

    activate() {
        this.baseViewModel.setup();
        this.setup();
    }

    setup() {
        var _this = this;
        if (this.baseViewModel.mgr != null)
        {
            this.baseViewModel.mgr.getUser().then(function (user) {
                if (user) {
                    _this.isLoggedIn = true;
                }
                else {
                    _this.baseViewModel.mgr.signinRedirect();
                    _this.isLoggedIn = false;
                }
            });
        }
    }

    configureRouter(config, router: Router) {
        this.router = router;

        config.title = "Group Booking App";
        config.map(
            [
                { route: ["", "welcome"], moduleId: "./views/welcome", nav: true, title: "Welcome" },
                { route: ["help"], moduleId: "./views/help", nav: true, title: "Help" },
                { route: ["about"], moduleId: "./views/about", nav: true, title: "About" },
                { route: ["logout"], moduleId: "./views/logout", nav: true, title: "Log out" },
                { route: ["addBooking"], moduleId: "./views/addBooking", nav: true, title: "Add booking" },
                { name:"editBooking", route: ["editBooking/:id"], moduleId: "./views/editBooking", nav: false, title: "Edit booking" },
                { route: ["bootstrapForm"], moduleId: "./views/bootstrapForm", nav: true, title: "Bootstrap Form" },
                { route: ["bookings"], moduleId: "./views/bookings", nav: true, title: "Bookings" },
            ]);        
    }

    logout() {
        this.baseViewModel.mgr.signoutRedirect();
    }
}