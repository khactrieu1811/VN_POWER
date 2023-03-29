
var quill = new Quill('#editor-container', {
    modules: {
        toolbar: '#toolbar-container'
    },
    placeholder: 'Nhập nội dung...',
    theme: 'snow'
});


const editor = document.getElementById('editor-container');
const hiddenInput = document.getElementById('PoliciesAndTerms');
const form = document.forms.mainform;
form.addEventListener('submit', function (e) {
    e.preventDefault();
    hiddenInput.value = editor.firstChild.innerHTML
    this.submit();
});

function selectLocalImage() {
    const input = document.createElement('input');
    input.setAttribute('type', 'file');
    input.click();

    // Listen upload local image and save to server
    input.onchange = () => {
        const file = input.files[0];

        // file type is only image.
        if (/^image\//.test(file.type)) {
            saveToServer(file);
        } else {
            console.warn('You could only upload images.');
        }
    };
}

/**
 * Step2. save to server
 *
 
 */
function saveToServer(file) {
    const fd = new FormData();
    fd.append('image', file);

    const xhr = new XMLHttpRequest();
    xhr.open('POST', '/api/Images/UploadFileImage', true);
    xhr.onload = () => {
        if (xhr.status === 200) {
            // this is callback data: url
            const url = JSON.parse(xhr.responseText).data;

            insertToEditor(url);
        }
    };
    xhr.send(fd);
}

/**
 * Step3. insert image url to rich editor.
 *
 */
function insertToEditor(url) {

    // push image url to rich editor.
    // Save current cursor state
    const range = this.quill.getSelection(true);
    //   const range = editor.getSelection();
    this.quill.insertEmbed(range.index, 'image', '/' + url);
}

// quill editor add image handler
var toolbar = quill.getModule('toolbar');
toolbar.addHandler('image', selectLocalImage);



$(document).ready(function () {
    $("#InputPrice").on("keyup", function () {
        var valueTargetRevenue = $("#InputPrice").val();
        var value = parseFloat(this.value.replace(/,/g, "") || 0).toFixed(0).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        $("#InputPrice").val(value);
        $("#Price").val(valueTargetRevenue.replace(/,/g, ""));
    });
});


//$('#AddService').on('click', function () {
//    var formData = new FormData();  
//    var file = $(".js-ajaxUploadImages").find("input[name=file]")[0].files;
//    formData.append("Name", $("input[name=Name]").val());
//    formData.append(".GroupService", $(".GroupService option:selected").val());
//    formData.append("Price", $("input[name=Price]").val());
//    formData.append("Desciption", $("textarea[name=Id]").val());
//    formData.append("PoliciesAndTerms", $(".ql-editor").html());
//    for (var x = 0; x < file.length; x++) {
//        formData.append("FileImage", file[x]);
//    }   
//    $.ajax({
//        url: '/services/AddService',
//        type: 'POST',
//        data: formData, // serializes the form's elements.
//        contentType: false,
//        processData: false,
//        success: function (result) {
//            if (result.success) {
//                $.toast({
//                    heading: 'Success',
//                    text: result.message,
//                    showHideTransition: 'slide',
//                    icon: 'success',
//                    position: 'bottom-right',
//                });
//                setTimeout(function () {
//                    window.location.href = '/services/getall';
//                },
//                    2000);
//            } else {
//                $.toast({
//                    heading: 'Error',
//                    text: result.message,
//                    showHideTransition: 'slide',
//                    icon: 'error',
//                    position: 'bottom-right',
//                });

//            }

//        }
//    });


//});
