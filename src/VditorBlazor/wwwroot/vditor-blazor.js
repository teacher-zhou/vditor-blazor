window.vditorBlazor = window.vditorBlazor || {
    createVditor: function (domRef, vditorDotNet, options) {

        return new Vditor(domRef, {
            ...options,
            cache: {
                enable: false
            },
            after: () => vditorDotNet.invokeMethodAsync('invokeRendered'),
            input: (value) => vditorDotNet.invokeMethodAsync('invokeInput', value),
            focus: (value) => vditorDotNet.invokeMethodAsync('invokeFocus', value),
            blur: (value) => vditorDotNet.invokeMethodAsync('invokeBlur', value),
            esc: (value) => vditorDotNet.invokeMethodAsync('invokeEscape', value),
            select: (value) => vditorDotNet.invokeMethodAsync('invokeSelect', value),
            ctrlEnter: (value) => vditorDotNet.invokeMethodAsync('invokeCtrlEnter', value),
        });
    },
};