
function Remove(id) {
    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'Delete',
        url: '/products/delete/' + id,
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
            $('#delete-modal-' + idDoctor).modal('toggle');
        }
    });
}

$('input[name="productStatus"]').click(function () {
    var idstring = $(this).attr('id');
    var value = $(this).attr('data-status');
    console.log(value);
    approve(idstring, value);
});
function approve(idstring, value) {
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/products/Approve/' + idstring + '/' + value,
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

            } else {
                $.toast({
                    heading: 'Error',
                    text: result.message,
                    showHideTransition: 'slide',
                    icon: 'error',
                    position: 'bottom-right',
                });

            }
            setTimeout(function () {
                location.reload();
            }, 3000);
        }
    });
}

function LockOrUnLock(idstring, value) {
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/products/ChangeState/' + idstring + '/' + value,
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

            } else {
                $.toast({
                    heading: 'Error',
                    text: result.message,
                    showHideTransition: 'slide',
                    icon: 'error',
                    position: 'bottom-right',
                });

            }
            setTimeout(function () {
                location.reload();
            }, 3000);
        }
    });
}
