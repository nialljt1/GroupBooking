System.register(["moment"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var moment_1;
    var DateFormatValueConverter;
    return {
        setters:[
            function (moment_1_1) {
                moment_1 = moment_1_1;
            }],
        execute: function() {
            DateFormatValueConverter = class DateFormatValueConverter {
                toView(value) {
                    return moment_1.default(value).format("DD/MM/YYYY hh:mm");
                }
                toDate(value) {
                    return moment_1.default(value).format("DD/MM/YYYY");
                }
                toTime(value) {
                    return moment_1.default(value).format("hh:mm");
                }
                toUSDate(value) {
                    var values = value.split('/');
                    var test = values[1] + "/" + values[0] + "/" + values[2];
                    return test;
                }
            };
            exports_1("DateFormatValueConverter", DateFormatValueConverter);
        }
    }
});
//# sourceMappingURL=date-format.js.map