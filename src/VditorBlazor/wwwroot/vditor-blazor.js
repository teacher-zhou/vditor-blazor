const convertJsonKey = function (jsonObj) {
    var result = {};
    for (key in jsonObj) {
        var keyval = jsonObj[key];
        if (keyval == null) {
            continue;
        }

        key = key.replace(key[0], key[0].toLowerCase());

        result[key] = keyval;
    }
    return result;
}


window.vditorBlazor = window.vditorBlazor || {
    createVditor: function (domRef, vditorDotNet, options) {

        options = convertJsonKey(options);

        domRef.Vditor = new Vditor(domRef, {
            ...options,
            cache: {
                enable: false
            },
            after: () => vditorDotNet.invokeMethodAsync('invokeAfter'),
            input: (value) => vditorDotNet.invokeMethodAsync('invokeInput', value),
            focus: (value) => { },
            blur: (value) => { },
            esc: (value) => { },
            select: (value) => { },
            ctrlEnter: (value) => { },
        });
    },
};