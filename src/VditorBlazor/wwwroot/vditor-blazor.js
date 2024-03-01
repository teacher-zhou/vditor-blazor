window.vditorBlazor = window.vditorBlazor || {
    createVditor: function (domRef, dotNet, options) {

        let vditor = new Vditor(domRef, {
            ...options,
            cache: {
                enable: false
            },
            after: () => dotNet.invokeMethodAsync('invokeRendered'),
            input: (value) => dotNet.invokeMethodAsync('invokeInput', value),
            focus: (value) => dotNet.invokeMethodAsync('invokeFocus', value),
            blur: (value) => dotNet.invokeMethodAsync('invokeBlur', value),
            esc: (value) => dotNet.invokeMethodAsync('invokeEscape', value),
            select: (value) => dotNet.invokeMethodAsync('invokeSelect', value),
            ctrlEnter: (value) => dotNet.invokeMethodAsync('invokeCtrlEnter', value),
        });
        return vditor;
    },
};