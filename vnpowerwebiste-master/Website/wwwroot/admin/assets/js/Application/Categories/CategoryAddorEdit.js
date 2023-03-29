var quill = new Quill('#editor-container', {
    modules: {
        toolbar: '#toolbar-container'
    },
    placeholder: 'Nhập nội dung...',
    theme: 'snow',
});


const editor = document.getElementById('editor-container');
const hiddenInput = document.getElementById('Description');
const form = document.forms.mainform;
form.addEventListener('submit', function (e) {
    e.preventDefault();
    hiddenInput.value = editor.firstChild.innerHTML
    this.submit();
});
function categoryChange() {
    var name = $("#ParentId option:selected").text();
    if (name === 'Event') {
        $("#TimeEventInfo").removeClass("d-none");
        $("#DeadlineTime").removeClass("d-none");
    } else {
        $("#TimeEventInfo").addClass("d-none");
        $("#DeadlineTime").addClass("d-none");
    }
}

$(document).ready(function () {
    var name = $("#ParentId option:selected").text();
    if (name === 'Event') {
        $("#TimeEventInfo").removeClass("d-none");
        $("#DeadlineTime").removeClass("d-none");
    } else {
        $("#TimeEventInfo").addClass("d-none");
        $("#DeadlineTime").addClass("d-none");
    }
});