$('input[name="bannerStatus"]').click(function () {
    var idstring = $(this).attr('id');
    var status = $(this).attr('data-status');
    ApproveBanner(idstring, status);
});
function ApproveBanner(idstring, status) {
    var dataType = 'application/json; charset=utf-8';
    var id = idstring.replace("banner-", "");
    $.ajax({
        type: 'GET',
        url: '/banners/ApproveBanner/' + id + '/' + status,
        dataType: 'json',

        contentType: dataType,
        success: function (result) {
            if (result.success) {
                $.toast({
                    heading: 'Success',
                    text: result.message,
                    showHideTransition: 'slide',
                    icon: 'success',
                    position: 'bottom-right',
                })
                setTimeout(function () {
                    window.location.href = '/banners/Index';
                }, 3000);
            } else {
                $.toast({
                    heading: 'Error',
                    text: result.message,
                    showHideTransition: 'slide',
                    icon: 'error',
                    position: 'bottom-right',
                });

            }

        }
    });
}


function RemoveBanner(id) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/banners/RemoveBanner/' + id,
        dataType: 'json',
        contentType: dataType,
        success: function (result) {
            
            if (result.success) {
                $.toast({
                    heading: 'Success',
                    text: result.message,
                    showHideTransition: 'slide',
                    icon: 'success',
                    position: 'bottom-right',
                });                
                setTimeout(function () {
                    location.reload();
                }, 3000);
            } else {

                
                $.toast({
                    heading: 'Error',
                    text: result.message,
                    showHideTransition: 'slide',
                    icon: 'error',
                    position: 'bottom-right',
                });

            }
            $('#delete-modal-' + id).modal('toggle');
        }
    });
}