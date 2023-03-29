
var quill = new Quill('#editor-container-reply', {
    modules: {
        toolbar: '#toolbar-container-reply'
    },
    placeholder: 'Nhập câu trả lời...',
    theme: 'snow'
});

if (status === 3) {
    quill.disable();
}

const editor = document.getElementById('editor-container-reply');
const hiddenInput = document.getElementById('ReplyContent');
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
