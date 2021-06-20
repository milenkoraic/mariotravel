// CONTACT US - CONTACT FORM - SUBMIT FUNCTION
$(function () {
    $('#submit-contact-form').click(function () {
        var form = $('#contact-us');
        form.validate();
        if (!form.valid()) {
            return;
        }
        else {
            $('#contact-us').submit(function (e) {
                e.preventDefault();
                var formData = ConvertFormToJSON(this);
                $.ajax({
                    type: 'POST',
                    contentType: "application/json",
                    url: "/contact-us/submit",
                    data: JSON.stringify(formData)
                })
                    .done(function () {
                        $('.error').hide();
                        $('.success').addClass('success');
                        $('input').val('');
                        $('textarea').val('');
                        $('#submit-contact-form').hide();
                        $('.success').html('Your message has been sent. We will be in touch!');
                        setTimeout(function () {
                            window.location.reload();
                        }, 5000);
                    })
                    .fail(function () {
                        $('.error').addClass('error');
                        $('.error').html('Something went wrong and we couldn\'t send your message, please try again later.');
                    });
            });

            function ConvertFormToJSON(form) {
                var array = jQuery(form).serializeArray();
                var json = {};

                jQuery.each(array, function () {
                    json[this.name] = this.value || '';
                });

                return json;
            }
        }
    });
});
//END OF CONTACT US SECTION-----------------------------------------------------------------------