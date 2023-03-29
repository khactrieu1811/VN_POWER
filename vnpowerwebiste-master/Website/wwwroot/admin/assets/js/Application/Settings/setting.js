
var toolbarOptions = [
    [{ 'font': [] }],
    [{ header: [1, 2, false] }],
    ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
    ['image'],
    ['blockquote', 'code-block'],

    [{ 'header': 1 }, { 'header': 2 }],               // custom button values
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
    [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
    [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
    [{ 'direction': 'rtl' }],                         // text direction

    [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
    [{ 'align': [] }],

    ['clean']                                         // remove formatting button
];
var options = {
    theme: 'snow',
    placeholder: 'Nhập nội dung...',
    modules: {
        toolbar: toolbarOptions
    }
};
var quillInfo = new Quill('#editor-info', options);
var quill = new Quill('#editor-container', {
    modules: {
        toolbar: '#toolbar-container'
    },
    placeholder: 'Nhập nội dung...',
    theme: 'snow',
});


const editor = document.getElementById('editor-container');
const editorInfo = document.getElementById('editor-info');
const hiddenInput = document.getElementById('PostContent');
const hiddenInputInfo = document.getElementById('CompanyInfo');
const form = document.forms.mainform;
form.addEventListener('submit', function (e) {
    e.preventDefault();
    hiddenInput.value = editor.firstChild.innerHTML
    hiddenInputInfo.value = editorInfo.firstChild.innerHTML
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
    const rangeInfo = this.quillInfo.getSelection(true);
    //   const range = editor.getSelection();
    this.quill.insertEmbed(range.index, 'image', url);
    this.quillInfo.insertEmbed(rangeInfo.index, 'image', url);
}


// quill editor add image handler
var toolbar = quill.getModule('toolbar');
var toolbarInfo = quillInfo.getModule('toolbar');
toolbar.addHandler('image', selectLocalImage);
toolbarInfo.addHandler('image', selectLocalImage);
