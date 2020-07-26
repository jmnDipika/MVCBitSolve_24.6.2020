


//required validation
(function ($) {
    $.fn.required = function () {
        var isvalid = false;
        this.each(function () {
            if ($(this).val() == "") {
                setErrorFor($(this), "* This " + $(this).parent().prev("label").attr('text') + " field is required.");
                isvalid = false;
            }
            else {
                setSuccessFor($(this))
                isvalid = true;
            }
        });
        return isvalid;
    }
}(jQuery));

//email validation
(function ($) {
    $.fn.email = function () {
        var isvalid = false;
        var expr = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            ///^([a-zA-Z0-9_\-\.]+)@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        this.each(function () {
            if (!expr.test($(this).val().trim())) {
                setErrorFor($(this), "Invalid Email.");
                isvalid = false;
            }
            else {
                setSuccessFor($(this))
                isvalid = true;
            }
        });
        return isvalid;
    }
}(jQuery));
//no validation

(function ($) {
    $.fn.numbers = function () {
        var isvalid = false;
        var regexpr = /^\d*$/;
        this.each(function () {
            if (!regexpr.test($(this).val().trim())) {
                this.value = this.value.replace(/[^0-9.]/g, '');
                setErrorFor($(this), "Only numbers allowed.");
                isvalid = false;
            }
            else {
                setSuccessFor($(this))
                isvalid = true;
            }
        });
        return isvalid;
    }
}(jQuery));
//compare string vaidation

(function ($) {
    $.fn.compareWith = function (input2) {
        var isvalid = false;
        this.each(function () {
            if ($(this).val().trim() != $(input2).val().trim()) {
                setErrorFor($(input2), $(input2).parent().prev("label").attr('text') + " does not match with " + $(this).parent().prev("label").attr('text'));
                isvalid = false;
            }
            else {
                setSuccessFor($(this))
                isvalid = true;
            }
        });
        return isvalid;
    }
}(jQuery));

//length validation




function setErrorFor(input, message) {
    var formGroup = input.parent();
    formGroup.children('span').html(message);
    formGroup.children('span').show()
    formGroup.addClass('has-error');
}

function setSuccessFor(input) {
    var formGroup = input.parent();
    var errorSpan = formGroup.children('span').html("");
    formGroup.removeClass('has-error');
    formGroup.addClass('has-success');
}

(function ($) { //Protect the $ Alias and Adding Scope
    $.fn.restrictNoLength = function (lengthVal) {
        //This plugin will work for all the elements that match the selector
        return this.each(function () {
            //Capture the keypress event and evaluate the input value length
            $(this).keypress(function (e) {
                //Make sure the data attribute is a number, else allow unrestricted max value
                //prevents hex and other number with alphas
                this.value = this.value.replace(/[^0-9.]/g, '');
                var dataMax = !isNaN($(this).data('maxlength')) ? $(this).data('maxlength') : ($(this).val().length + 1);
                //Use the passed in value if it exists, if not use the data attribute (if it exists and is a nummber), else make it longer than the current value (not restricted)
                var length = !isNaN(lengthVal) ? lengthVal : dataMax;
                if ($(this).val().length >= length) {
                    //String is too long, don't execute the event
                    return false;
                } else {
                    //String length is good, allow the keyPress event to continue
                    return true;
                }
            });
        });

    };
}(jQuery));



//function keyupValidateEventlistener() { //keyup event vaidation
//    $('input, select').each(function (index) {
//        var htmlControl = $(this).attr('id');
//        $('#' + htmlControl).keyup(function () {
//            checkInput($(this));
//        });
//    });
//}