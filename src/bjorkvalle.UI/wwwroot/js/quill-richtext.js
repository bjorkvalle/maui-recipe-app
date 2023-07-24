(function () {
    window.QuillFunctions = {
        createQuill: function (element, debugLevel = 'info', dotNetObjectReference) {
            var options = {
                debug: debugLevel,
                modules: {
                    toolbar: '#toolbar',
                },
                placeholder: 'Compose an epic...',
                readOnly: false,
                theme: 'snow',
            }

            const quill = new Quill(element, options);

            const onEventChangeInterval = 1000;
            quill.on('editor-change', throttle(function (eventName, ...args) {
                dotNetObjectReference.invokeMethodAsync('HandleEditorChange');
            }, onEventChangeInterval));

            return quill;
        },
        getQuillContent: function (element) {
            return JSON.stringify(element.__quill.getContents());
        },
        getQuillText: function (element) {
            return element?.__quill.getText();
        },
        getQuillHTML: function (element) {
            return element.__quill.root.innerHTML;
        },
        loadQuillContent: function (element, quillContent) {
            if (!quillContent)
                return;

            content = JSON.parse(quillContent);
            return element.__quill.setContents(content, 'api');
        },
        disableQuillEditor: function (element) {
            element.__quill.enable(false);
        },
        enableQuillEditor: function (element) {
            element.__quill.enable(true);
        }
    }
})();