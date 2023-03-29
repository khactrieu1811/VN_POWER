
var quill = new Quill('#editor-container', {
    modules: {
        toolbar: '#toolbar-container'
    },
    placeholder: 'Nhập nội dung...',
    theme: 'snow',
});


const editor = document.getElementById('editor-container');
const hiddenInput = document.getElementById('PostContent');
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
    this.quill.insertEmbed(range.index, 'image', url);
}


// quill editor add image handler
var toolbar = quill.getModule('toolbar');
toolbar.addHandler('image', selectLocalImage);


function categoryChange() {
    var name = $("#CategoryId option:selected").text();
    if (name === 'Event') {
        $("#TimeEventInfo").removeClass("d-none");
        $("#DeadlineTime").removeClass("d-none");
    } else {
        $("#TimeEventInfo").addClass("d-none");
        $("#DeadlineTime").addClass("d-none");
    }
}

$(function () {
    $('#EndDateString').datetimepicker({
        format: 'DD/MM/YYYY HH:mm'
    });
});

$(document).ready(function () {
    var name = $("#CategoryId option:selected").text();
    if (name === 'Event') {
        $("#TimeEventInfo").removeClass("d-none");
        $("#DeadlineTime").removeClass("d-none");
    } else {
        $("#TimeEventInfo").addClass("d-none");
        $("#DeadlineTime").addClass("d-none");
    }
});