import moment from "moment";

export class DateFormatValueConverter {
    toView(value) {
        return moment(value).format("DD/MM/YYYY hh:mm");
    }

    toDate(value) {
        return moment(value).format("DD/MM/YYYY");
    }

    toTime(value) {
        return moment(value).format("hh:mm");
    }

    toUSDate(value) {
        var values = value.split('/');
        var test = values[1] + "/" + values[0] + "/" + values[2];
        return test;
    }
}