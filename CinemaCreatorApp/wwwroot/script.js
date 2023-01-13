

window.BlazorJSFunctions =
{
    GetElementHeight: function (name) {
        return document.getElementById(name).offsetHeight;
    },
    GetElementWidth: function (name) {
        return document.getElementById(name).offsetWidth;
    },
    zoom: function (amount) {
        let e = document.querySelector(":root");
        let es = getComputedStyle(e);
        let val = parseFloat(es.getPropertyValue("--grid-zoom"));
        val += parseFloat(amount);
        e.style.setProperty("--grid-zoom", val);
    }
    
};
window.addEventListener('mouseup', (event) => {
    
    console.log(DotNet.invokeMethodAsync('CinemaCreatorApp','JSHandleMouseUp'));
});