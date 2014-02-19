$(document).ready(function () {
    $('#contact-form').validate({
        rules: {
            name: {
                minlength: 3,
                required: true
            },
            field:{
                required: true,
				number: true,
				minlength: 7
            },
            subject: {
                required:true,
                url: true,
				maxlength:50
            },
            message: {
                minlength: 3,
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