System.register(["aurelia-framework"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var aurelia_framework_1;
    var DatePicker;
    function createEvent(name) {
        const event = document.createEvent("Event");
        event.initEvent(name, true, true);
        return event;
    }
    function fireEvent(element, name) {
        const event = createEvent(name);
        element.dispatchEvent(event);
    }
    return {
        setters:[
            function (aurelia_framework_1_1) {
                aurelia_framework_1 = aurelia_framework_1_1;
            }],
        execute: function() {
            DatePicker = class DatePicker {
                constructor(element) {
                    this.element = element;
                }
                attached() {
                    ////$.noConflict();
                    $(this.element).datepicker({
                        dateFormat: 'dd/mm/yy',
                        onSelect: function (dateText, _this) {
                            $(this).change();
                        }
                    });
                    ////$(this.element).datepicker().on("change", e => fireEvent(e.target, "input"));
                }
                detached() {
                    $(this.element).datepicker("destroy").off("change");
                }
            };
            DatePicker = __decorate([
                aurelia_framework_1.customAttribute("datepicker"),
                aurelia_framework_1.inject(Element)
            ], DatePicker);
            exports_1("DatePicker", DatePicker);
        }
    }
});
//# sourceMappingURL=datepicker.js.map