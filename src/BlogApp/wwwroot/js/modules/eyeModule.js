//#region Vars
var InnerEye = null;
//#endregion

//#region API

export function InitAnimation() {
    EyeTracker();
}

export function Dispose() {
    if (InnerEye != null) {
        InnerEye.removeEventListener('mousemove', MovementListner);
        InnerEye = null;
    }
}

//#endregion

//#region Functions

function EyeTracker() {
    InnerEye = document.getElementById('InnerEye');
    document.addEventListener('mousemove', MovementListner);
}

function MovementListner(e) {
    var numberX = ScaleDown(e.clientX, 0, window.innerWidth, 65 / 2, 65);
    var numberY = ScaleDown(e.clientY, 0, window.innerHeight, 25 / 2, 30);

    InnerEye.style.transform = 'translate('
        + numberX
        + 'px,'
        + numberY
        + 'px)';
}

function convertRemToPixels(rem) {
    return rem * parseFloat(getComputedStyle(document.documentElement).fontSize);
}

function ScaleDown(value, oldMin, oldMax, newMin, newMax) {
    let oP = (value - oldMin) / (oldMax - oldMin);
    return ((newMax - newMin) * oP) + newMin;
}

//#endregion