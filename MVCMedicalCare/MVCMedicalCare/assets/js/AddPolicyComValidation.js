$(document).ready(function () {

    $('#contact-form').validate({
        rules: {
            name: {
                minlength: 3,
                required: true
            },
            amount:{
                required: true,
				number: true
				
            },
            emi: {
                required:true,
                number: true
            },
            descr: {
                minlength: 5,
                required: true
            }
        },
        highlight: function (element) {
            $(element).closest('.control-group').removeClass('success').addClass('error');
        },
        success: function (element) {
            element
            .text('OK!').addClass('valid')
            .closest('.control-group').removeClass('error').addClass('success');
        }
    });

}); 