import {inject, customAttribute} from 'aurelia-framework';

@customAttribute('datepicker')
@inject(Element)
export class DatePicker {
    constructor(element) {
        this.element = element;
    }
  
    attached() {
        var _this = this;
        $(this.element).datepicker({
            dateFormat: 'dd/mm/yy',   
            onSelect: function(dateText, _this) {
                 $(this).change();
            }        
        })
            .on('change', e => fireEvent(e.target, 'input'));
    
    }
  
    detached() {
        $(this.element).datepicker('destroy')
          .off('change');
    }
}

function createEvent(name) {
    var event = document.createEvent('Event');
    event.initEvent(name, true, true);
    return event;
}

function fireEvent(element, name) {
    var event = createEvent(name);
    element.dispatchEvent(event);
}