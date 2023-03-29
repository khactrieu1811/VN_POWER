



$('input[name="lockoutEnd"]').click(function () {
    var idstring = $(this).attr('id');
    var value = $(this).attr('data-value');
    LockOrUnLockStaff(idstring, value);
});
function LockOrUnLockStaff(idstring, value) {
    var dataType = 'application/json; charset=utf-8';
    var id = idstring.replace("lockout-", "");
    $.ajax({
        type: 'GET',
        url: '/accounts/LockOrUnlock/' + id + '/' + value,
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
                window.location.href = '/accounts/getAdminStaff';
            }, 3000);
        }
    });
}


function RemoveStaff(idUser) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/accounts/RemoveStaff/' + idUser,
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
            $('#delete-modal-' + idUser).modal('toggle');
        }
    });
}

$('.PermissionStaff').on('change', function () {
    var dataType = 'application/json; charset=utf-8';
    var userId = $(this).attr('id').replace("permission-", "");
    var roleName = $(this).val();
    $.ajax({
        type: 'POST',
        url: '/accounts/PermissionStaff/' + userId + '/' + roleName,
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
});

function ResetPassword(idUser) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'POST',
        url: '/accounts/ResetPassword/' + idUser,
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






