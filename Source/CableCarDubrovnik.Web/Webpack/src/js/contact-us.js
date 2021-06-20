// CHANGE HREF LINKS TO REDIRECT TO HOME PAGE SECTIONS
let homeUrl = '/';

let btn1Href = $('.header-menu a:nth-child(2)');
let btn2Href = $('.header-menu a:nth-child(3)');
let btn3Href = $('.header-menu a:nth-child(4)');
let btn4Href = $('.header-menu a:nth-child(5)');
let btn5Href = $('.header-menu a:nth-child(6)');
let btn6Href = $('.header-menu a:nth-child(7)');

let link1Href = $('.header-menu a:nth-child(2)').attr("href");
let link2Href = $('.header-menu a:nth-child(3)').attr("href");
let link3Href = $('.header-menu a:nth-child(4)').attr("href");
let link4Href = $('.header-menu a:nth-child(5)').attr("href");
let link5Href = $('.header-menu a:nth-child(6)').attr("href");
let link6Href = $('.header-menu a:nth-child(7)').attr("href");

link1Href = link1Href.substring(1);
link2Href = link2Href.substring(1);
link3Href = link3Href.substring(1);
link4Href = link4Href.substring(1);
link5Href = link5Href.substring(1);
link6Href = link6Href.substring(1);

btn1Href.attr('onclick','').unbind('click');
btn2Href.attr('onclick','').unbind('click');
btn3Href.attr('onclick','').unbind('click');
btn4Href.attr('onclick','').unbind('click');
btn5Href.attr('onclick','').unbind('click');
btn6Href.attr('onclick','').unbind('click');

btn1Href.attr("href", homeUrl + "#scroll:" + link1Href);
btn2Href.attr("href", homeUrl + "#scroll:" + link2Href);
btn3Href.attr("href", homeUrl + "#scroll:" + link3Href);
btn4Href.attr("href", homeUrl + "#scroll:" + link4Href);
btn5Href.attr("href", homeUrl + "#scroll:" + link5Href);
btn6Href.attr("href", homeUrl + "#scroll:" + link6Href);

// CONTACT US - CONTACT FORM - SUBMIT FUNCTION
$(function () {
    $('#submit-contact-form').click(function () {
        var form = $('#contact-us');
        form.validate();
        if (!form.valid()) {
            return;
        } else {
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