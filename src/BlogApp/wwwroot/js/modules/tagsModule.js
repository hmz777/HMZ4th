//#region Vars

//#endregion

//#region API

export function InitAnimation() {
    anime({
        targets: '.article-header h1',
        translateY: [500, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        loop: false
    });
}

export function ScrollElementIntoView(id) {
    document.getElementById(id).scrollIntoView();
}

export function Dispose() {

}

//#endregion