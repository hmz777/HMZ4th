//#region Vars
var AnimeInstance = null;
var pb;
//#endregion

//#region API

export function Animate(state) {
    pb = document.getElementById("prograss-bar");
    if (state) {
        pb.style.width = "10%";
        UpdateProgress(pb, 10);
    } else {
        pb.style.width = "100%";
    }
}

//#endregion

//#region Tools

function UpdateProgress(el, percent) {
    let prog = percent;
    if (el.className.indexOf('active') != -1) {
        if (parseInt(el.style.width.split('%')[0]) < 100) {
            prog += 0.5 * Math.pow(1 - Math.sqrt(prog), 2);
            el.style.width = prog + "%";
            setTimeout(() => { UpdateProgress(el, prog); }, 1000);
        }
    }
}

//#endregion