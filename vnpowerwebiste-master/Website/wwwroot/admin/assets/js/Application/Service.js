$('input[name="serviceStatus"]').click(function () {
    var id = $(this).attr('id');
    var status = $(this).attr('data-status');
    Approve(id, status);
});

function Approve(id, status) {
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/services/Approve/' + id + '/' + status,
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

        }
    });
}


function Remove(id) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'Delete',
        url: '/services/Delete/' + id,
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