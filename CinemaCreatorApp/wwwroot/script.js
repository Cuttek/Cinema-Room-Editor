
function zoom(amount)
{
    let e = document.querySelector(":root");
    let es = getComputedStyle(e);
    let val = parseFloat(es.getPropertyValue("--grid-zoom"));
    val += parseFloat(amount);
    e.style.setProperty("--grid-zoom", val);
    console.log(val);
        //let val = parseFloat(element.style.zoom);

        //console.log(element.style.zoom);
        //val += parseFloat(amount);
        //element.style.zoom = 0.9;  

    
    
    
}