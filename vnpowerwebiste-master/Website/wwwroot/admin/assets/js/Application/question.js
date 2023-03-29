$('input[name="questionStatus"]').click(function () {
    var idstring = $(this).attr('id');
    ApproveQuestion(idstring);

});
function ApproveQuestion(idstring) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    var id = idstring.replace("question-", "");
    $.ajax({
        type: 'GET',
        url: '/Questions/ApproveQuestion/'+id,
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
                setTimeout(function () {
                    location.reload();
                }, 3000);
            }

        }
    });
}

function RemoveQuestion(idQuestion) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    $.ajax({
        type: 'GET',
        url: '/Questions/RemoveQuestion/' + idQuestion,
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
            $('#delete-modal-' + idQuestion).modal('toggle');
            
        }
    });
}

function SendQuestion(idstring) {

    //JSON data
    var dataType = 'application/json; charset=utf-8';
    var id = idstring.replace("question-", "");
    $.ajax({
        type: 'GET',
        url: '/Questions/Sendmail/' + id,
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
                setTimeout(function () {
                    location.reload();
                }, 3000);
            }

        }
    });
}