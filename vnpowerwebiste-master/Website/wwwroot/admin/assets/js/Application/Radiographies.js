//var listFile = [];

//$('#listFile').on('change', function () {
    
//    console.log(listFile);
//});

$('#EditRadiographies').on('click', function () {
    var formData = new FormData();
    var listFile = $("input[name=listFile]").prop("files");
    //var listFile = $.map(propFile, function (val) { return val.name; });
    var file = $(".js-ajaxUploadImages").find("input[name=file]")[0].files;


    formData.append("id", $("input[name=Id]").val());
    for (var x = 0; x < file.length; x++) {
        formData.append("file", file[x]);
    }
    for (var x = 0; x < listFile.length; x++) {
        formData.append("listFile", listFile[x]);
    }  
    $.ajax({
        url: '/Radiography/Edit',
        type: 'POST',
        data: formData, // serializes the form's elements.
        contentType: false,
        processData: false,
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
                    window.location.href = '/radiographies/getall';
                },
                    2000);
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


});
