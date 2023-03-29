function AddUser() {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    var data = {
        FullName: $("input[name=FullName]").val(),
        HISCode: $("input[name=HISCode]").val(),
        BirthDay: $("input[name=BirthDay]").val(),
        Sex: $("input[name=Sex]").val(),
        Address: $("input[name=Address]").val(),
        PhoneNumber: $("input[name=PhoneNumber]").val(),
        Email: $("input[name=Email]").val(),
    }

    $.ajax({
        type: 'POST',
        url: '/Accounts/AddUser',
        dataType: 'json',

        contentType: dataType,
        data: JSON.stringify(data),
        success: function (result) {
            if (result.success) {
                $('#Add_Specialities_details').modal('toggle');
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
                })
            }

        }
    });
}

function RemoveUser(idUser) {
    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/accounts/RemoveUser/' + idUser,
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
                location.reload();
            }, 3000);
        }
    });
}