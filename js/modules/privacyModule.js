//#region Vars

//#endregion

//#region API

export function InitAnimation() {
    anime({
        targets: '.article-header h1, .header-link',
        opacity: [0, 1],
        translateY: [500, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        delay: anime.stagger(100),
        loop: false
    });
}

export function Dispose() {

}

//#endregion