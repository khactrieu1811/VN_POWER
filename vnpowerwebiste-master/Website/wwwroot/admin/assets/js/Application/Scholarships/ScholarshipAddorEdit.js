
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

var scholarshipCreateTagsOptions = {
    url: '/api/Tags/GetAll',
    list: {
        match: {
            enabled: true
        },
        sort: {
            enabled: true
        },
        showAnimation: {
            type: "slide", //normal|slide|fade
            time: 100,
        },

        hideAnimation: {
            type: "slide", //normal|slide|fade
            time: 100,
        },
        onChooseEvent: function () {
            var tagValue = $("#tags").getSelectedItemData().name;

            console.log('aaaa');
            addNewTag(tagValue);
        }
    },
    getValue: "name"
};

// Tag input init
$("#tags").easyAutocomplete(scholarshipCreateTagsOptions);

// Remove a tag
$(".scholarship-tags__list").on("click", ".remove-tag", function (e) {
    e.preventDefault();
  
    var elem = e.target.closest('.scholarship-tags__item');
    var value = $(elem).attr("data-tag");
    $("#TagsData").val($("#TagsData").val().replace(value, ","));
    e.target.closest('.scholarship-tags__item').remove();
})

// Add new tag if not exist
$("#tags").keypress(function (e) {
    if (e.keyCode == 13 && $(this).val() != '') {
        var tagValue = $("#tags").val();
        addNewTag(tagValue);
    }
})

// Add new tag method
function addNewTag(value) {
    $(".scholarship-tags__list").append(
        '<div class="scholarship-tags__item" data-tag="' + value + '">' +
        '<span class="name">' + value + '</span>' +
        '<a href="" class="remove-tag">x</a>' +
        '</div>'
    );

    $("#TagsData").val($("#TagsData").val() + ',' + value);
    $("#tags").val(''); // Refresh tag input value
}

$('#formScholarship').on('keyup keypress', function (e) {
    var keyCode = e.keyCode || e.which;
    if (keyCode === 13) {
        e.preventDefault();
        return false;
    }
});

$(function () {
    $('#EndDate').datetimepicker({
        format: 'DD/MM/YYYY HH:mm'
    });
});